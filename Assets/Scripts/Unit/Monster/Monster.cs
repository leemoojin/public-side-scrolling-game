using MBT;
using System;
using UnityEngine;

namespace Monster
{
    public class Monster : MonoBehaviour
    {
        public MonsterData monsterData;
        public Blackboard blackboard;
        public float MaxHealth;
        public float currentHealth;
        public event Action<float> OnHealthChanged;

        private void OnEnable()
        {
            currentHealth = MaxHealth;
            OnHealthChanged?.Invoke(currentHealth / MaxHealth);
            if (monsterData == null) return;
            blackboard.GetVariable<Variable<int>>("maxHP").Value = monsterData.Health;
            blackboard.GetVariable<Variable<int>>("curHP").Value = monsterData.Health;
        }

        public void ApplyData(MonsterData data)
        {
            monsterData = data;          
            MaxHealth = monsterData.Health;
            currentHealth = MaxHealth;
            blackboard.GetVariable<Variable<float>>("speed").Value = monsterData.Speed;
            blackboard.GetVariable<Variable<int>>("maxHP").Value = monsterData.Health;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            OnHealthChanged?.Invoke(currentHealth / MaxHealth);
        }
    }
}

