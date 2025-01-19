using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Util
{
    public class CSVParser
    {
        public static List<Dictionary<string, string>> ParseCSV(string filePath)
        {
            var rows = new List<Dictionary<string, string>>();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length <= 1) return rows; // 데이터가 없으면 빈 리스트 반환

            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                var row = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length; j++)
                {
                    row[headers[j]] = values[j];
                }

                rows.Add(row);
            }

            return rows;
        }
    }
}

