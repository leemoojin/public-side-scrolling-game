using UnityEngine;

namespace Player
{
    public class PlayerDetectState : PlayerBaseState
    {
        //private Vector2 boxSize = new Vector2(2.5f, 1f); // 사각형 크기
        private Vector2 _point;
        private LayerMask _layerMask;
        //private float _interval = 0.5f;
        //private float _timeSinceLastDetection = 0f;

        public PlayerDetectState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //Debug.Log("PlayerDetectState - Enter()");
            stateMachine.Player.animator.SetBool("Idle", true);
            _point = stateMachine.Player.DetectPoint;
            _layerMask = stateMachine.Player.detectTargetLayerMask;
            //_interval = 0.3f;
        }


        public override void PhysicsUpdate()
        {


            base.PhysicsUpdate();

            CheckOverlapPoint();

            //_timeSinceLastDetection += Time.fixedDeltaTime;

            //if (_timeSinceLastDetection >= _interval)
            //{
            //    Debug.Log("PlayerDetectState - PhysicsUpdate() - 탐지 시작");

            //    _timeSinceLastDetection = 0f;
            //    CheckOverlapPoint();
            //}
        }

        public float debugLineLength = 0.5f; // 디버그 선 길이

        private void CheckOverlapPoint()
        {
            //Collider2D hitCollider = Physics2D.OverlapBox(_point, boxSize, 0f, _layerMask);

            //if (hitCollider != null)
            //{
            //    stateMachine.Target = hitCollider.transform; // 충돌체를 타겟으로 설정
            //    Debug.Log($"충돌체 발견: {hitCollider.name} at {hitCollider.transform.position}");
            //    stateMachine.ChangeState(stateMachine.AttackState); // 공격 상태로 전환
            //}
            //else
            //{
            //    //Debug.Log($"충돌체 발견 실패");
            //}

            Collider2D hitCollider = Physics2D.OverlapPoint(_point, _layerMask);

            if (hitCollider != null && !hitCollider.isTrigger)
            {
                if(Vector2.Distance(_point, hitCollider.transform.position) >= 1f) return;
                stateMachine.Target = hitCollider.transform;
                //Debug.Log("충돌체 발견: " + hitCollider.name);
                //Debug.Log($"탐지 위치 : {_point}, 대상 위치 : {hitCollider.transform.position}");
                stateMachine.ChangeState(stateMachine.AttackState);
            }

            Debug.DrawLine(_point - Vector2.up * debugLineLength, _point + Vector2.up * debugLineLength, Color.red);
        }

        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.animator.SetBool("Idle", false);
        }

    }
}


