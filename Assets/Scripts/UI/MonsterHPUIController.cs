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
            // Model�� �̺�Ʈ�� �����Ͽ� View ������Ʈ
            monster.OnHealthChanged += healthBar.UpdateHealthBar;
        }

        private void OnDisable()
        {
            // �̺�Ʈ ���� ����
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


