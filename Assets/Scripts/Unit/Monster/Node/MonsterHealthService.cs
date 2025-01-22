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
        [SerializeField] private Monster monster;
        public BoolReference isHurt;
        public BoolReference isDestroy;
        public IntReference maxHP;
        public IntReference curHP;
        public Animator animator;
        private AnimatorStateInfo _stateInfo;

        public override void OnEnter()
        {
            base.OnEnter();
            curHP.Value = maxHP.Value;
        }

        public override void Task()
        {
            CheckAnimation();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                StartDamageAnimation();
                int damege = collision.gameObject.GetComponent<ArrowProjectile>().Damage;
                monster.TakeDamage(damege);
                if ((curHP.Value -= damege) <= 0) isDestroy.Value = true;
            }
        }

        private void StartDamageAnimation()
        {
            isHurt.Value = true;    
            animator.SetBool("Hurt", true);
            animator.SetBool("Walk", false);
            animator.Update(0);
        }

        private void CheckAnimation()
        {
            if (!isHurt.Value) return;
            _stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (_stateInfo.IsName("Hurt") && _stateInfo.normalizedTime >= 1f)
            {
                animator.SetBool("Hurt", false);
                animator.SetBool("Walk", true);
                isHurt.Value = false;
            }
        }
    }
}


