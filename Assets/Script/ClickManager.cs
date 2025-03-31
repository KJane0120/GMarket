using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy; // Enemy 오브젝트

    public bool isGamePaused = false; // 게임 일시 정지 상태 체크
    public bool isOptionOpen = false; // 옵션 창 열림 상태 체크

    public int autoAttackLevel = 1; // 자동 공격 레벨

    public float baseAutoAttackInterval = 1.0f; // 기본 자동 공격 간격

    private Coroutine autoAttackCoroutine;
    private bool isClicking = false;

    public UnityAction onClick;

    void Start()
    {
        StartAutoAttack(); // 자동 공격 시작
        onClick += OnAttack;
    }

    void Update()
    {
        if (isGamePaused || isOptionOpen) return; // 게임이 일시 정지 상태이거나 옵션 창이 열려 있으면 클릭 무시


        if (Input.GetMouseButtonDown(0) && !isClicking)
        {
            isClicking = true;
            Debug.Log("클릭 발생!");
            onClick.Invoke(); // 클릭 시 즉시 공격 실행
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClicking = false;
        }
    }

    public void StartAutoAttack()
    {
        if (autoAttackCoroutine != null) StopCoroutine(autoAttackCoroutine);
        autoAttackCoroutine = StartCoroutine(AutoAttack());
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            // 게임이 일시 정지 상태이거나 옵션 창이 열려 있으면 자동 공격 중단
            if (!isGamePaused && !isOptionOpen) OnAttack();

            float attackInterval = baseAutoAttackInterval / autoAttackLevel;
            yield return new WaitForSeconds(attackInterval);
        }
    }

    void OnAttack()
    {
        if (targetEnemy != null)
        {
            targetEnemy.Damaged(); // 공격 실행
            Debug.Log("공격 발생!");
        }
    }

    public void LevelUp()
    {
        autoAttackLevel++;
        Debug.Log($"자동 공격 레벨 업! 현재 레벨: {autoAttackLevel}");
        StartAutoAttack(); // 레벨 업 시 새로운 속도로 자동 공격 재시작
    }
}
