using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy;  // 타겟 적
    public bool isGamePaused;
    public UnityAction onClick;
    private AutoClicker autoClicker; // AutoClicker 참조

    public GameObject UIPrefab;

    private RectTransform WindowUI;

    private void Start()
    {
        autoClicker = FindObjectOfType<AutoClicker>(); // AutoClicker 찾기
    }


    private void Update()
    {
        if (UIManager.Instance.inventoryPanel.activeInHierarchy || UIManager.Instance.PausePopup.activeInHierarchy)
        {
            isGamePaused = true;
        }
        else
        {
            isGamePaused = false;
        }

        if (isGamePaused) return;

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            //IndowUI 렉트트랜스폼을 찾은 뒤, 그 안에 마우스가 있는지 확인
            WindowUI = UIManager.Instance.transform.Find("WindowUI").GetComponent<RectTransform>();
            bool isMouseOnUI = RectTransformUtility.RectangleContainsScreenPoint(WindowUI, Input.mousePosition);
            
            // 만약 있다면, 실행시키지 않고 돌아가기
            if (isMouseOnUI)
            {
                //onClick 이벤트를 수행하지 않고 그냥 돌아가기
                return;
            }
            onClick.Invoke(); // 공격 실행
            Debug.Log("공격 감지");
        }
    }
    
}
