
using UnityEngine;

namespace Player
{
    public class PlayerBaseState : IState
    {
        protected PlayerStateMachine stateMachine;

        private float delay = 1.0f;
        //private float _timeSinceLastDelay = 0f;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void PhysicsUpdate()
        {
            //Debug.Log($"PlayerIdleState - PhysicsUpdate() - Target {stateMachine.Target}");

            //_timeSinceLastDelay += Time.deltaTime;

            if (!stateMachine.IsDelaying) return;
        
            stateMachine.TimeSinceLastDelay += Time.fixedDeltaTime;
            //Debug.Log($"PlayerIdleState - PhysicsUpdate() - {_timeSinceLastDelay}");

            if (stateMachine.TimeSinceLastDelay >= delay)
            {
                //Debug.Log($"PlayerBaseState - PhysicsUpdate() - µÙ∑π¿Ã ≥°");
                stateMachine.TimeSinceLastDelay = 0f;
                stateMachine.IsDelaying = false;
                //stateMachine.isAttacking = false;
                //if (stateMachine.Target != null) stateMachine.ChangeState(stateMachine.AttackState);      
            }
        }

        public virtual void Update()
        {
        }
    }
}

