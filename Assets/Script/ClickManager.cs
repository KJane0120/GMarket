using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy; //Enemy 오브젝트

    public bool isGamePaused = false; // 게임 일시 정지 상태 체크
    public int autoAttackLevel = 1; // 자동 공격 레벨
    public float baseAutoAttackInterval = 1.0f; // 기본 자동 공격 간격
    private Coroutine autoAttackCoroutine;
    private bool isClicking = false; // 클릭 상태 추적 변수

    void Start()
    {
        StartAutoAttack(); // 자동 공격 시작
    }

    void Update()
    {
        if (isGamePaused) return; // 게임이 일시 정지 상태라면 클릭 무시

        if (Input.GetMouseButtonDown(0) && !isClicking) // 마우스 좌클릭 감지 및 중복 방지
        {
            isClicking = true; // 클릭 상태 활성화
            Debug.Log("클릭 발생!");
            OnAttack(); // 클릭 시 즉시 공격 실행
        }

        if (Input.GetMouseButtonUp(0)) // 마우스 버튼을 뗐을 때 클릭 상태 해제
        {
            isClicking = false; // 클릭 상태 비활성화
        }
    }

    public void StartAutoAttack()
    {
        if (autoAttackCoroutine != null) StopCoroutine(autoAttackCoroutine); // 기존 코루틴 정지
        autoAttackCoroutine = StartCoroutine(AutoAttack()); // 새로운 코루틴 시작
    }

    IEnumerator AutoAttack()
    {
        while (true) // 무한 루프 실행
        {
            if (!isGamePaused) OnAttack(); // 게임이 정지 상태가 아니면 자동 공격 실행

            float attackInterval = baseAutoAttackInterval / autoAttackLevel; // 자동 공격 레벨에 따라 간격 조정
            yield return new WaitForSeconds(attackInterval); // 일정 간격 대기 후 다시 실행
        }
    }

    void OnAttack()
    {
        if (targetEnemy != null)
        {
            targetEnemy.Damaged(); // 클릭 시 몬스터 공격
            Debug.Log(" 데미지 입힘! ");
        }
    }

    public void LevelUp()
    {
        autoAttackLevel++; // 자동 공격 레벨 증가
        Debug.Log($"자동 공격 레벨 업! 현재 레벨: {autoAttackLevel}");
        StartAutoAttack(); // 레벨 업 시 새로운 속도로 자동 공격 재시작
    }
}
