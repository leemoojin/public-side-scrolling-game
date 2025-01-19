using MBT;
using System;
using UnityEngine;
using Util;
using Weapon;

namespace Monster
{
    [AddComponentMenu("")]
    [MBTNode("Monster/Monster Health Service")]
    public class MonsterHealthService : Service
    {
        //public event Action<float> OnHealthChanged;
        [SerializeField] private Monster monster; // Model

        public BoolReference isHurt;
        public BoolReference isDestroy;

        public IntReference maxHP;
        public IntReference curHP;

        public Animator animator;

        private AnimatorStateInfo stateInfo;
        //private bool isHurt;

        public override void OnEnter()
        {
            //Debug.Log($"MonsterHealthService - OnEnter()");
            base.OnEnter();
            curHP.Value = maxHP.Value;

        }

        public override void Task()
        {
            //Debug.Log($"MonsterHealthService - Task()");

            CheckAnimation();
        }

        //public void TakeDamage(int damage)
        //{
        //    curHP.Value -= damage;
        //    curHP.Value = Mathf.Clamp(curHP.Value, 0, maxHP.Value);

        //    // 체력 변경 알림
        //    OnHealthChanged?.Invoke(curHP.Value / maxHP.Value);
        //}


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                //Debug.Log("MonsterHealthService - 피격");
                StartDamageAnimation();
                int damege = collision.gameObject.GetComponent<ArrowProjectile>().Damage;
                monster.TakeDamage(damege);
                if ((curHP.Value -= damege) <= 0)
                {
                    //GameManager.Instance.Player.GetStateMachine().Target = null;
                    //Debug.Log($"MonsterHealthService - 몬스터 사망 {GameManager.Instance.Player.GetStateMachine().Target}");
                    //Debug.Log(GameManager.Instance.Player.GetStateMachine().Target);

                    isDestroy.Value = true;
                }
            }
        }

        private void StartDamageAnimation()
        {
            isHurt.Value = true;
            
            animator.SetBool("Hurt", true);
            animator.SetBool("Walk", false);

            //animator.Play("Hurt", 0, 0f);
            animator.Update(0);
        }

        private void CheckAnimation()
        {
            if (!isHurt.Value) return;

            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //Debug.Log($"{stateInfo.IsName("Hurt")}, {stateInfo.normalizedTime}");
            if (stateInfo.IsName("Hurt") && stateInfo.normalizedTime >= 1f)
            {
                //Debug.Log($"애니메이션 끝");
                animator.SetBool("Hurt", false);
                animator.SetBool("Walk", true);
                isHurt.Value = false;
            }

        }
    }

}


