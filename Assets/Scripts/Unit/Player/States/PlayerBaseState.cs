
using UnityEngine;

namespace Player
{
    public class PlayerBaseState : IState
    {
        protected PlayerStateMachine stateMachine;

        private float _delay = 1.0f;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void PhysicsUpdate()
        {
            if (!stateMachine.IsDelaying) return;
            stateMachine.TimeSinceLastDelay += Time.fixedDeltaTime;
            if (stateMachine.TimeSinceLastDelay >= _delay)
            {
                stateMachine.TimeSinceLastDelay = 0f;
                stateMachine.IsDelaying = false;
            }
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

        public void Update()
        {
        }
    }
}

