using MBT;
using UnityEngine;
using Util;

namespace Monster
{
    [AddComponentMenu("")]
    [MBTNode("Monster/Monster Destroy")]
    public class MonsterDestroy : Leaf
    {
        public BoolReference isWork;
        public BoolReference isHurt;
        public Animator animator;
        private AnimatorStateInfo _stateInfo;

        public override void OnEnter()
        {
            GameManager.Instance.Player.GetStateMachine().Target = null;
            isWork.Value = false;
            animator.SetBool("Hurt", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Death", true);
        }

        public override NodeResult Execute()
        {
            CheckAnimation();

            if (isWork.Value)
            {
                animator.SetBool("Hurt", false);
                animator.SetBool("Walk", true);
                animator.SetBool("Death", false);
                return NodeResult.success;
            } 
            else return NodeResult.running;
        }

        private void CheckAnimation()
        {
            _stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (_stateInfo.IsName("Death") && _stateInfo.normalizedTime >= 0.9f)
            {
                MonsterPool.Instance.ReturnMonster(gameObject);
                isHurt.Value = false;
                GameManager.Instance.Player.GetStateMachine().Target = null;
            }

        }
    }
}


