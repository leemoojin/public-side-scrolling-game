using UnityEngine;

namespace Player
{
    public class PlayerDetectState : PlayerBaseState
    {
        private Vector2 _point;
        private LayerMask _layerMask;

        public PlayerDetectState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            stateMachine.Player.animator.SetBool("Idle", true);
            _point = stateMachine.Player.DetectPoint;
            _layerMask = stateMachine.Player.detectTargetLayerMask;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            CheckOverlapPoint();
        }

        private void CheckOverlapPoint()
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(_point, _layerMask);

            if (hitCollider != null && !hitCollider.isTrigger)
            {
                if(Vector2.Distance(_point, hitCollider.transform.position) >= 1f) return;
                stateMachine.Target = hitCollider.transform;
                stateMachine.ChangeState(stateMachine.AttackState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.animator.SetBool("Idle", false);
        }

    }
}


