using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy;  // 타겟 적
    public bool isGamePaused;
    public UnityAction onClick;
    private AutoClicker autoClicker; // AutoClicker 참조

    public GameObject UIPrefab;

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
            onClick.Invoke(); // 공격 실행
        }
    }
}
