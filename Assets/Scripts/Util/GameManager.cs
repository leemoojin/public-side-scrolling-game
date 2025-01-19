using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Util
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [field: SerializeField] public GameObject PlayerGameObject { get; private set; }
        [field: SerializeField] public CSVToScriptableObject CSVToScriptableObject { get; private set; }

        //public ScriptableObject[] MonsterDatas { get; private set; }
        public List<MonsterData> MonsterDatas = new List<MonsterData>();


        public Player.Player Player { get; private set; }

        private void Awake()
        {
            Instance = this;
            if (PlayerGameObject != null) Player = PlayerGameObject.GetComponent<Player.Player>();
            //Debug.Log("Awake" + Player);
        }

        //public void GetSOData()
        //{
        //    string folderPath = "Assets/ScriptableObjects";
        //    // 1. 특정 폴더에서 모든 ScriptableObject를 찾습니다.
        //    string[] assetGUIDs = AssetDatabase.FindAssets("t:ScriptableObject", new[] { folderPath });

        //    // 2. 결과를 배열로 변환합니다.
        //    ScriptableObject[] soArray = new ScriptableObject[assetGUIDs.Length];
        //    for (int i = 0; i < assetGUIDs.Length; i++)
        //    {
        //        // GUID를 경로로 변환
        //        string assetPath = AssetDatabase.GUIDToAssetPath(assetGUIDs[i]);

        //        // ScriptableObject 로드
        //        soArray[i] = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
        //    }

        //    MonsterDatas = soArray;
        //}
    }
}

