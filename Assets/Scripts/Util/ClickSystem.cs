using UnityEngine;

namespace Util
{
    public class ClickSystem : MonoBehaviour
    {
        public LayerMask monsterLayer; // ������ ���̾� ����
        public Camera mainCamera; // ����ĳ��Ʈ ���� ī�޶�

        void Start()
        {
            // �⺻������ ���� ī�޶� ����
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
            {
                HandleMouseClick();
            }
            else if (Input.GetMouseButtonDown(1)) // ���콺 ������ ��ư Ŭ�� �� UI ����
            {
                Debug.Log("������ Ŭ��");
                Time.timeScale = 1f;
                UIManager.Instance.HideMonsterInfo();
            }
        }

        void HandleMouseClick()
        {
            // 1. ���콺 Ŭ�� ��ġ�� Ray�� ��ȯ
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            // 2. Raycast�� �浹 �˻� (2D ����)
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, monsterLayer);

            if (hit.collider != null)
            {
                // 3. �浹�� ������Ʈ�� ������ ��������
                Monster.Monster monster = hit.collider.GetComponent<Monster.Monster>();

                if (monster != null)
                {
                    //// 4. UIManager�� ���� ���� ���
                    //UIManager.Instance.ShowMonsterInfo(
                    //    monster.GetMonsterInfo(),
                    //    Input.mousePosition // ȭ�� ��ǥ
                    //);
                    Time.timeScale = 0f;
                    UIManager.Instance.ShowMonsterInfo(monster);
                    Debug.Log($"Monster clicked: {monster}");
                }
            }
            else
            {
                Debug.Log("No monster clicked");
            }
        }
    }
}

