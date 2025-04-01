using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private ClickManager clickManager;
    private Coroutine autoClickCoroutine;
    public float AALevel;

    private void Start()
    {
        clickManager = FindObjectOfType<ClickManager>();
        AALevel = 0f;
        AALevel = GameManager.Instance.PlayerData.AutoAttackLevel;

        UpAutoAttack();
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
            float attackRate = AALevel; // 초당 자동 공격 횟수
            if (attackRate > 0)
            {
                float interval = 1f / attackRate; // 공격 간격 설정 (예: 5회/초 -> 0.2초 간격)

                Debug.Log("입력 확인");
                clickManager.onClick.Invoke();

                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void UpAutoAttack()
    {
        AALevel++;
        if (AALevel > 0)
        {
                StartAutoClick();
        }
    }

}
