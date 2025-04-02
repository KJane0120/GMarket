using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private ClickManager clickManager;
    private Coroutine autoClickCoroutine;
    private void Start()
    {
        clickManager = FindObjectOfType<ClickManager>();
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
            float attackRate = GameManager.Instance.PlayerData.TotalAutoAttack * 0.3f; // 1레벨당 0.3번 공격
            if (attackRate > 0)
            {
                float interval = 1f / attackRate; // 공격 간격 설정
                if (!(clickManager.isGamePaused))
                {

                    Debug.Log("자동 공격");
                    SoundManager.Instance?.sfxManager.PlaySFX(SoundLibrary.Instance.sfxHit, 0.1f);
                    clickManager.onClick.Invoke();
                }

                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void CheckAutoAttack()
    {
        if (GameManager.Instance.PlayerData.TotalAutoAttack > 0)
        {
            StartAutoClick();
        }
    }
}
