using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance; // 싱글톤

        public GameObject infoPanel; // MonsterInfoText의 부모 Panel (optional)
        public Text nameInfoText; // MonsterInfoText UI
        public Text gradeInfoText; // MonsterInfoText UI
        public Text speedInfoText; // MonsterInfoText UI
        public Text healthInfoText; // MonsterInfoText UI



        private void Awake()
        {
            Instance = this;
            infoPanel.SetActive(false);
        }

        public void ShowMonsterInfo(Monster.Monster monster)
        {
            nameInfoText.text = $"Name : {monster.monsterData.Name}";
            gradeInfoText.text = $"Grade : {monster.monsterData.Grade}";
            speedInfoText.text = $"Speed : {monster.monsterData.Speed}";
            healthInfoText.text = $"Health : {monster.monsterData.Health}";

            // UI 활성화
            infoPanel.SetActive(true);
        }

        public void HideMonsterInfo()
        {
            // UI 비활성화
            infoPanel.SetActive(false);
        }
    }
}

