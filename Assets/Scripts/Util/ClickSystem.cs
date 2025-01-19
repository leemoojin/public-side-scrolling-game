using UnityEngine;

namespace Util
{
    public class ClickSystem : MonoBehaviour
    {
        public LayerMask monsterLayer; // 감지할 레이어 설정
        public Camera mainCamera; // 레이캐스트 기준 카메라

        void Start()
        {
            // 기본적으로 메인 카메라를 설정
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
            {
                HandleMouseClick();
            }
            else if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭 시 UI 숨김
            {
                Debug.Log("오른쪽 클릭");
                Time.timeScale = 1f;
                UIManager.Instance.HideMonsterInfo();
            }
        }

        void HandleMouseClick()
        {
            // 1. 마우스 클릭 위치를 Ray로 변환
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            // 2. Raycast로 충돌 검사 (2D 물리)
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, monsterLayer);

            if (hit.collider != null)
            {
                // 3. 충돌한 오브젝트의 정보를 가져오기
                Monster.Monster monster = hit.collider.GetComponent<Monster.Monster>();

                if (monster != null)
                {
                    //// 4. UIManager를 통해 정보 출력
                    //UIManager.Instance.ShowMonsterInfo(
                    //    monster.GetMonsterInfo(),
                    //    Input.mousePosition // 화면 좌표
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

