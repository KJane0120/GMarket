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
        onClick += OnAttack; // 클릭 이벤트 연결
    }

    private void Update()
    {
        if (isGamePaused) return;

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            DetectTargetEnemy(); // 클릭 시 적 감지
            onClick.Invoke(); // 공격 실행
        }
    }

    // 적을 감지하는 함수
    public void DetectTargetEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            targetEnemy = hit.collider.GetComponent<Enemy>(); // 마우스 클릭 위치에 적이 있으면 타겟 설정
        }
    }

    public void OnAttack()
    {
        if (targetEnemy != null)
        {
            targetEnemy.Damaged();  // 클릭 공격
        }
    }
}
