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

        private AnimatorStateInfo stateInfo;
        //public BoolReference isDestroy;
        //public GameObjectReference selfGO;

        public override void OnEnter()
        {
            //Debug.Log("MonsterDestroy - OnEnter()");
            GameManager.Instance.Player.GetStateMachine().Target = null;

            isWork.Value = false;
            animator.SetBool("Hurt", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Death", true);

            //MonsterPool.Instance.ReturnMonster(selfGO.Value);
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
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //Debug.Log($"{stateInfo.IsName("Death")}, {stateInfo.normalizedTime}");
            if (stateInfo.IsName("Death") && stateInfo.normalizedTime >= 0.9f)
            {
                //Debug.Log($"애니메이션 끝, 몬스터 제거");
                
                MonsterPool.Instance.ReturnMonster(gameObject);
                isHurt.Value = false;
                GameManager.Instance.Player.GetStateMachine().Target = null;
            }

        }

        public override void OnExit()
        {
            //Debug.Log("MonsterDestroy - OnExit()");

        }
    }
}


