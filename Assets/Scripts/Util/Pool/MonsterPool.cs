using MBT;
using UnityEngine;

namespace Util
{
    public class MonsterPool : MonoBehaviour
    {
        public static MonsterPool Instance;

        private ObjectPool _objectPool;

        private void Awake()
        {
            Instance = this;
            _objectPool = GetComponent<ObjectPool>();
        }

        private void Start()
        {
            GetMonster();
        }

        public void GetMonster()
        {
            GameObject monster = _objectPool.Get();
            //Debug.Log($"MonsterPool - GetMonster - {monster.name}");
            monster.transform.position = transform.position;
            monster.GetComponent<Blackboard>().GetVariable<Variable<bool>>("isWork").Value = true;
            monster.GetComponent<Blackboard>().GetVariable<Variable<bool>>("isDestroy").Value = false;
        }

        public void ReturnMonster(GameObject monster)
        {
            _objectPool.ReturnToPool(monster);
            GetMonster();
        }
    }
}