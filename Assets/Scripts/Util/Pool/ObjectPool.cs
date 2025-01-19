using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class ObjectPool : MonoBehaviour
    {
        //[SerializeField] private GameObject prefab;
        [SerializeField] private List<GameObject> prefabs;
        [SerializeField] private int initialSize;
        public bool isMonsterPool;

        private bool _isSinglePrefab;

        private Queue<GameObject> pool = new Queue<GameObject>();

        private void Awake()
        {
            if (isMonsterPool)
            {
                GameManager.Instance.CSVToScriptableObject.ConvertCSVToSO();
            }
            //Debug.Log(this.transform.position);

            int count = prefabs.Count;
            _isSinglePrefab = (count == 1);

            if (_isSinglePrefab)
            {
                for (int i = 0; i < initialSize; i++)
                {
                    GameObject obj = Instantiate(prefabs[0], transform);                    
                    obj.SetActive(false);
                    pool.Enqueue(obj);
                }
            }
            else
            {
                

                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < initialSize; j++)
                    {
                        //Debug.Log(prefabs[j].transform.position);

                        GameObject obj = Instantiate(prefabs[i], transform);
                        if (isMonsterPool)
                        {
                            obj.GetComponent<Monster.Monster>().ApplyData(GameManager.Instance.MonsterDatas[i]);
                        }
                        obj.SetActive(false);
                        pool.Enqueue(obj);
                    }
                }
            }
        }

        public GameObject Get()
        {
            if (_isSinglePrefab)
            {
                if (pool.Count > 0)
                {
                    GameObject obj = pool.Dequeue();
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    GameObject obj = Instantiate(prefabs[0], transform);
                    obj.SetActive(true);
                    return obj;
                }
            }
            else
            {
                GameObject obj = pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}
