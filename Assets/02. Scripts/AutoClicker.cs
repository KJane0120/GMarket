using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private ClickManager clickManager;
    private PlayerData playerData;
    private Coroutine autoClickCoroutine;

    private void Start()
    {
        clickManager = FindObjectOfType<ClickManager>(); // ClickManager 참조
        playerData = GameManager.Instance.PlayerData; // PlayerData 참조

        if (playerData.AutoAttackLevel > 0)
        {
            StartAutoClick(); // 자동 공격 레벨이 0보다 클 때만 시작
        }
    }

    public void StartAutoClick()
    {
        if (autoClickCoroutine != null)
            StopCoroutine(autoClickCoroutine);

        autoClickCoroutine = StartCoroutine(AutoClick());
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            float attackRate = playerData.TotalAutoAttack; // 초당 자동 공격 횟수
            if (attackRate > 0)
            {
                float interval = 1f / attackRate; // 공격 간격 설정 (예: 5회/초 -> 0.2초 간격)

                // 자동 공격이 활성화되면 타겟이 존재하는지 확인
                if (clickManager.targetEnemy != null)
                {
                    clickManager.targetEnemy.Damaged();  // 자동 공격 실행
                }

                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return null;
            }
        }
    }
}
