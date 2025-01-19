using Monster;
using UnityEngine;
using Weapon;

namespace Util
{
    public class ArrowPool : MonoBehaviour
    {
        public static ArrowPool Instance;

        private ObjectPool _objectPool;

        private void Awake()
        {
            Instance = this;
            _objectPool = GetComponent<ObjectPool>();
        }

        //public void GetArrow()
        //{
        //    GameObject arrow = _objectPool.Get();
        //    arrow.transform.position = transform.position;
        //}

        public void GetArrow(Transform target)
        {
            GameObject arrow = _objectPool.Get();
            arrow.transform.position = transform.position;
            arrow.GetComponent<ArrowProjectile>().target = target;
            //Vector2 direction = (target.position - transform.position).normalized;
            //// 목표 방향으로 회전 (Z축만 회전)
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 방향을 각도로 변환
            //Quaternion targetRotation = Quaternion.Euler(0, 0, angle); // Z축 회전
            //transform.rotation = targetRotation;
        }

        public void ReturnArrow(GameObject arrow)
        {
            _objectPool.ReturnToPool(arrow);
        }
    }
}

