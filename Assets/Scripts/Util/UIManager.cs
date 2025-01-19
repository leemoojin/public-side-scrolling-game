using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance; // �̱���

        public GameObject infoPanel; // MonsterInfoText�� �θ� Panel (optional)
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

            // UI Ȱ��ȭ
            infoPanel.SetActive(true);
        }

        public void HideMonsterInfo()
        {
            // UI ��Ȱ��ȭ
            infoPanel.SetActive(false);
        }
    }
}

