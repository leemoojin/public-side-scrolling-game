using MBT;
using UnityEngine;
using Util;

namespace Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        private AnimatorStateInfo _stateInfo;
        private Animator _animator;

        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _animator = stateMachine.Player.animator;
            _animator.SetBool("Attack", true);
            stateMachine.IsDelaying = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (stateMachine.Target == null)
            {
                stateMachine.ChangeState(stateMachine.DetectState);
                return;
            }

            _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (_stateInfo.IsName("Archer-Attack") && _stateInfo.normalizedTime >= 0.7f)
            {
                ArrowPool.Instance.GetArrow(stateMachine.Target);
                stateMachine.TimeSinceLastDelay = 0;
                stateMachine.IsDelaying = true;
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _animator.SetBool("Attack", false);
        }
    }
}


