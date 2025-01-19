using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Util
{
    public class CSVToScriptableObject : MonoBehaviour
    {
        [Header("CSV File Path (Relative to Assets)")]
        public string csvFilePath = "Assets/Resources/Data/SampleMonster.csv";

        [Header("Output Directory for ScriptableObjects")]
        public string outputDirectory = "Assets/ScriptableObjects";

        // 게임 실행 시 바로 변환하도록 Start()에서 호출
        //void Start()
        //{

        //    ConvertCSVToSO();
        //}

        public void ConvertCSVToSO()
        {

            //Debug.Log("CSV 데이터를 ScriptableObject로 변환 중...");

            var dataRows = CSVParser.ParseCSV(csvFilePath);

            if (dataRows == null || dataRows.Count == 0)
            {
                //Debug.LogError("CSV 데이터를 읽는 데 실패했습니다. 경로를 확인하세요: " + csvFilePath);
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            int tempIndex = 0;
            foreach (var row in dataRows)
            {
                // ScriptableObject 생성
                MonsterData characterData = ScriptableObject.CreateInstance<MonsterData>();
                //characterData.ID = int.Parse(row["ID"]);
                characterData.Name = row["Name"];
                characterData.Grade = row["Grade"];
                characterData.Speed = float.Parse(row["\bSpeed"]);
                characterData.Health = int.Parse(row["Health"]);

                // SO 파일 저장
                string assetPath = $"{outputDirectory}/{tempIndex}_{characterData.Name}_Data.asset";
                tempIndex++;
                AssetDatabase.CreateAsset(characterData, assetPath);
                GameManager.Instance.MonsterDatas.Add(characterData);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            //Debug.Log("CSV 데이터를 ScriptableObject로 변환 완료!");
        }
    }
}


