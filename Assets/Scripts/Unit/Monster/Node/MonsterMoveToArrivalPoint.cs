using MBT;
using System.Collections;
using UnityEngine;
using Util;

namespace Monster
{
    [AddComponentMenu("")]
    [MBTNode("Monster/Monster Move To Arrival Point")]
    public class MonsterMoveToArrivalPoint : Leaf
    {
        public FloatReference speed;
        public BoolReference isDestroy;
        public BoolReference isHurt;
        private bool _isArrvial;
        private bool _isMoving;

        public override void OnEnter()
        {
            _isArrvial = false;
            _isMoving = true;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            float monsterSpeed = speed.Value;
            while (_isMoving)
            {
                if (isHurt.Value) transform.position += Vector3.right * 0.1f * Time.deltaTime;
                else transform.position += Vector3.left * monsterSpeed * Time.deltaTime;
                yield return null;
            }
        }

        public override NodeResult Execute()
        {
            if(_isArrvial || isDestroy.Value) return NodeResult.success;
            else return NodeResult.running;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 7) MonsterStop();
        }

        private void MonsterStop()
        {
            _isArrvial = true;
            _isMoving = false;
            StopCoroutine(Move());
            isDestroy.Value = true;
        }
    }
}


