using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [field: Header("References")]
        //[field: SerializeField] public PlayerDataSO Data { get; private set; }
        [field: SerializeField] public Transform Detector { get; private set; }
        public Animator animator;

        public Transform target;


        public LayerMask detectTargetLayerMask;

        public Vector2 DetectPoint { get; private set; }
        private PlayerStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new PlayerStateMachine(this);
        }

        private void Start()
        {
            DetectPoint = new Vector2(Detector.position.x, Detector.position.y);
            _stateMachine.ChangeState(_stateMachine.DetectState);
        }

        private void FixedUpdate()
        {
            _stateMachine.PhysicsUpdate();
            target = _stateMachine.Target;
        }

        public void LostTarget()
        {
            _stateMachine.Target = null;
        }




        public PlayerStateMachine GetStateMachine() { return _stateMachine; }
    }
}
