using UnityEngine;
using System.Collections;
using Util;
using static UnityEngine.GraphicsBuffer;


namespace Weapon
{
    public class ArrowProjectile : MonoBehaviour
    {
        public float speed = 0.5f; // 화살 속도
        public float rotationSpeed = 50f; // 회전 속도
        public Transform target; // 목표
        public int Damage { get; private set; } = 100;

        //private void Awake()
        //{
        //    rb = GetComponent<Rigidbody>();
        //}

        //public void Launch(Transform target)
        //{
        //    this.target = target;
        //}

        private void FixedUpdate()
        {
            target = GameManager.Instance.Player.GetStateMachine().Target;
            if (target == null)
            {
                ArrowPool.Instance.ReturnArrow(gameObject);
                return;
            }



            // 목표 방향 계산
            Vector2 direction = (target.position - transform.position).normalized;

            // 목표 방향으로 회전 (Z축만 회전)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 방향을 각도로 변환
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle); // Z축 회전
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = targetRotation;


            // 화살 이동
            transform.position += (Vector3)direction * speed * Time.fixedDeltaTime;

        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.layer == 6) ArrowPool.Instance.ReturnArrow(gameObject);
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log($"화살 충돌 - {collision.gameObject.name}");
            if (collision.gameObject.layer == 6) ArrowPool.Instance.ReturnArrow(gameObject);
        }

        private void OnDisable()
        {
            target = null;
        }

    }
}


