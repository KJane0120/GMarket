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

        UpAutoAttack();
    }

    private void Update()
    {
        if (AALevel > 0)
        {
            StartAutoClick();
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
            float attackRate = AALevel * 0.3f; // 1레벨당 0.3번 공격
            if (attackRate > 0)
            {
                float interval = 1f / attackRate; // 공격 간격 설정

                Debug.Log("자동 공격");
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
        //AALevel++;
        GameManager.Instance.PlayerData.AutoAttackLevel++;
        if (AALevel > 0)
        {
            StartAutoClick();
        }
    }
}
