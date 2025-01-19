using UnityEngine;

namespace UI
{
    public class MonsterHPUIController : MonoBehaviour
    {
        [SerializeField] private Monster.Monster monster; // Model
        [SerializeField] private MonsterHealthBar healthBar; // View


        private void OnEnable()
        {
            
        }

        private void Start()
        {
            // Model의 이벤트를 구독하여 View 업데이트
            monster.OnHealthChanged += healthBar.UpdateHealthBar;
        }

        private void OnDisable()
        {
            // 이벤트 구독 해제
        }

        private void OnDestroy()
        {
            monster.OnHealthChanged -= healthBar.UpdateHealthBar;

        }

        //public void ApplyDamage(float damage)
        //{
        //    monsterHealth.TakeDamage(damage);
        //}

    }
}


