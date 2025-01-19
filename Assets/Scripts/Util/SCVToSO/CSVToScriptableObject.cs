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

        // ���� ���� �� �ٷ� ��ȯ�ϵ��� Start()���� ȣ��
        //void Start()
        //{

        //    ConvertCSVToSO();
        //}

        public void ConvertCSVToSO()
        {

            //Debug.Log("CSV �����͸� ScriptableObject�� ��ȯ ��...");

            var dataRows = CSVParser.ParseCSV(csvFilePath);

            if (dataRows == null || dataRows.Count == 0)
            {
                //Debug.LogError("CSV �����͸� �д� �� �����߽��ϴ�. ��θ� Ȯ���ϼ���: " + csvFilePath);
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            int tempIndex = 0;
            foreach (var row in dataRows)
            {
                // ScriptableObject ����
                MonsterData characterData = ScriptableObject.CreateInstance<MonsterData>();
                //characterData.ID = int.Parse(row["ID"]);
                characterData.Name = row["Name"];
                characterData.Grade = row["Grade"];
                characterData.Speed = float.Parse(row["\bSpeed"]);
                characterData.Health = int.Parse(row["Health"]);

                // SO ���� ����
                string assetPath = $"{outputDirectory}/{tempIndex}_{characterData.Name}_Data.asset";
                tempIndex++;
                AssetDatabase.CreateAsset(characterData, assetPath);
                GameManager.Instance.MonsterDatas.Add(characterData);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            //Debug.Log("CSV �����͸� ScriptableObject�� ��ȯ �Ϸ�!");
        }
    }
}


