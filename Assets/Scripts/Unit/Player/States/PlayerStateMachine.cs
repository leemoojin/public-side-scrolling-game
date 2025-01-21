using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : StateMachine
    {
        public Player Player { get; }
        public PlayerDetectState DetectState { get; private set; }
        public PlayerAttackState AttackState { get; private set; }
        public PlayerIdleState IdleState { get; private set; }

        public Transform Target { get; set; }
        public bool IsDelaying { get; set; }
        public float TimeSinceLastDelay { get; set; }

        public PlayerStateMachine(Player player)
        {
            Player = player;
            DetectState = new PlayerDetectState(this);
            AttackState = new PlayerAttackState(this);
            IdleState = new PlayerIdleState(this);
        }

        public override void ChangeState(IState state)
        {
            base.ChangeState(state);
        }
    }
}

