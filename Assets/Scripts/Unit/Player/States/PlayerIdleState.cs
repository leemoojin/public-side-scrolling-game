

using UnityEngine;
using Util;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Player
{
    public class PlayerIdleState : PlayerBaseState
    {
        //private float delay = 2.0f;
        //private float _timeSinceLastDelay = 0f;

        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //Debug.Log($"PlayerIdleState - Enter()");
            stateMachine.Player.animator.SetBool("Idle", true);
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (stateMachine.Target == null)
            {
                stateMachine.ChangeState(stateMachine.DetectState);
                return;
            }

            if(!stateMachine.IsDelaying) stateMachine.ChangeState(stateMachine.AttackState);
        }


        public override void Exit()
        {
            base.Exit();
            stateMachine.Player.animator.SetBool("Idle", false);
        }
    }
}


