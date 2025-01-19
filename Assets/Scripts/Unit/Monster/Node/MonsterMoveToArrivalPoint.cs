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
            //if (isDestroy.Value) return;
            _isArrvial = false;
            _isMoving = true;
            //Debug.Log($"MonsterMoveToArrivalPoint - OnEnter() = _isArrvial false : {_isArrvial}, _isMoving true : {_isMoving}, name : {gameObject.name}");

            StartCoroutine(Move());

            //if (gameObject.activeInHierarchy)
            //{
            //    StartCoroutine(Move());
            //}
            //else gameObject.SetActive(true);
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
            //Debug.Log("MonsterMoveToArrivalPoint - MonsterStop()");

            _isArrvial = true;
            _isMoving = false;
            StopCoroutine(Move());
            isDestroy.Value = true;
            //GameManager.Instance.Player.GetStateMachine().Target = null;
            //Debug.Log($"MonsterMoveToArrivalPoint - ¸ó½ºÅÍ µµÂø");
            //Debug.Log(GameManager.Instance.Player.GetStateMachine().Target);

        }

        public override void OnExit()
        {
            //Debug.Log($"MonsterMoveToArrivalPoint - OnExit() - name : {gameObject.name}");

        }
    }
}


