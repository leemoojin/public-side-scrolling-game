using UnityEngine;
using System.Collections;
using Util;
using static UnityEngine.GraphicsBuffer;


namespace Weapon
{
    public class ArrowProjectile : MonoBehaviour
    {
        public float speed = 0.5f; // ȭ�� �ӵ�
        public float rotationSpeed = 50f; // ȸ�� �ӵ�
        public Transform target; // ��ǥ
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



            // ��ǥ ���� ���
            Vector2 direction = (target.position - transform.position).normalized;

            // ��ǥ �������� ȸ�� (Z�ุ ȸ��)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ������ ������ ��ȯ
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle); // Z�� ȸ��
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = targetRotation;


            // ȭ�� �̵�
            transform.position += (Vector3)direction * speed * Time.fixedDeltaTime;

        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.layer == 6) ArrowPool.Instance.ReturnArrow(gameObject);
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log($"ȭ�� �浹 - {collision.gameObject.name}");
            if (collision.gameObject.layer == 6) ArrowPool.Instance.ReturnArrow(gameObject);
        }

        private void OnDisable()
        {
            target = null;
        }

    }
}


