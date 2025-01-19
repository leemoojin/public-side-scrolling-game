using MBT;
using UnityEngine;
using Util;

namespace Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        private AnimatorStateInfo stateInfo;
        private Animator animator;
        //private bool isAnimationFinished = false;

        //private bool isAttacking;

        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //Debug.Log("PlayerAttackState - Enter()");
            animator = stateMachine.Player.animator;
            animator.SetBool("Attack", true);
            stateMachine.IsDelaying = true;
            //isAttacking = false;
            //stateMachine.ChangeState(stateMachine.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (stateMachine.Target == null)
            {
                stateMachine.ChangeState(stateMachine.DetectState);
                return;
            }

            //if (stateMachine.isAttacking)
            //{
            //    stateMachine.ChangeState(stateMachine.IdleState);
            //    return;
            //}

            //if(isAnimationFinished) RestartAnimation();

            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //Debug.Log($"{stateInfo.IsName("Archer-Attack")}, {stateInfo.normalizedTime}");
            if (stateInfo.IsName("Archer-Attack") && stateInfo.normalizedTime >= 0.7f)
            {
                //Debug.Log($"화살 발사");
                ArrowPool.Instance.GetArrow(stateMachine.Target);
                stateMachine.TimeSinceLastDelay = 0;
                stateMachine.IsDelaying = true;
                stateMachine.ChangeState(stateMachine.IdleState);

                //stateMachine.isAttacking = true;

                //isAnimationFinished = true;
                //animator.SetBool("Attack", false);
                //animator.SetBool("Idle", true);
            }
        }

        //private void RestartAnimation()
        //{
        //    //animator.Play("Archer-Attack", 0, -1f); // 애니메이션 처음부터 다시 실행
        //    //animator.Update(0);
        //    //stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //    //Debug.Log($"다시 {stateInfo.IsName("Archer-Attack")}, {stateInfo.normalizedTime}");
        //    //animator.SetBool("Attack", false);
        //    //animator.SetBool("Attack", true);

        //    isAnimationFinished = false; // 플래그 리셋
        //}

        public override void Exit()
        {
            base.Exit();
            //Debug.Log("PlayerAttackState - Exit()");

            animator.SetBool("Attack", false);
        }
    }
}


