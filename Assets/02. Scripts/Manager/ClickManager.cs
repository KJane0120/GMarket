using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy;  // 타겟 적
    public bool isGamePaused = false;
    public UnityAction onClick;
    private AutoClicker autoClicker; // AutoClicker 참조

    private void Start()
    {
        autoClicker = FindObjectOfType<AutoClicker>(); // AutoClicker 찾기
    }

    private void Update()
    {
        if (isGamePaused) return;

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            onClick.Invoke(); // 공격 실행
        }
    }
}
