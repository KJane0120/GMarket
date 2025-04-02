using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoBehaviour
{
    public Player player;
    public PlayerStat playerStat;

    [Header("Text")]
    public TMP_Text curStatText;
    public TMP_Text upStatText;
    public TMP_Text upGoldText;

    public int Gold;
    private bool isHolding = false;
    public float repeatRate = 0.2f;
    public float delayTime = 1f;

    private Coroutine upgradeCoroutine;

    void Start()
    {
        UpdateUI();
    }

    /// <summary>
    /// 스탯 강화
    /// </summary>
    public void UpgradeClick()
    {
        Gold = GameManager.Instance.PlayerData.StatGold;
        int gold = playerStat.upgradeGold; // 강화 비용 가져오기

        if (Gold >= gold)
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxStatUpgrade, 0.4f);
            }
            CurrencyManager.Instance.controller.StatGoldUse(gold);
            playerStat.UpgradeBonus();
        }
        else
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.sfxManager.PlaySFX(SoundLibrary.Instance.sfxError, 0.4f);
            }
            UIManager.Instance.StatsErrorMsg();
        }
        upGoldText.color = (Gold >= gold) ? Color.black : Color.red;
        player.UpdateTotal();
        UpdateUI();
    }

    /// <summary>
    /// UI 업데이트
    /// </summary>
    void UpdateUI()
    {
        curStatText.text = $"<color=#EEA970>{playerStat.stat.statValue}</color>";      // 레벨
        upGoldText.text = $"<color=#EEA970>{playerStat.upgradeGold}</color>";          // 업그레이드 골드

        // 타입에 따라 메세지 다르게 출력
        switch (playerStat.stat.StatType)
        {
            case StatType.critical:
                upStatText.text = $"{GameManager.Instance.PlayerData.CriticalDamageLevel}";
                break;
            case StatType.autoAttack:
                upStatText.text = $"{GameManager.Instance.PlayerData.AutoAttackLevel}";
                break;
            case StatType.goldGain:
                upStatText.text = $"{GameManager.Instance.PlayerData.GoldGainLevel}";
                break;
        }

        switch (playerStat.addStat.BonusType)
        {
            case BonusStatType.criticalBonus:
                upStatText.text = $"치명타 데미지 + <color=#EEA970>{GameManager.Instance.PlayerData.TotalCritDamage * 100} %</color>";
                break;
            case BonusStatType.autoAttackBonus:
                upStatText.text = $"<color=#EEA970>{GameManager.Instance.PlayerData.TotalAutoAttack} 회/초</color>";
                break;
            case BonusStatType.goldGainBonus:
                upStatText.text = $"치즈 획득량 + <color=#EEA970>{GameManager.Instance.PlayerData.TotalGoldGain * 100} %</color>";
                break;
        }
    }

    /// <summary>
    /// 버튼 이벤트트리거 - 누르는 순간 실행
    /// </summary>
    public void OnButtonDown()
    {
        if (upgradeCoroutine == null) // 실행중일경우 중복실행 방지
        {
            isHolding = true;
            upgradeCoroutine = StartCoroutine(UpgradeLoop()); // 코루틴 시작
        }
    }


    /// <summary>
    /// 버튼 이벤트트리거 - 떼는 순간 실행
    /// </summary>
    public void OnButtonUp()
    {
        isHolding = false;                      // false로 변경
        if (upgradeCoroutine != null)           // 실행중인 코루틴이 있으면
        {
            StopCoroutine(upgradeCoroutine);    // 코루틴 중지
            upgradeCoroutine = null;            // 변수 초기화
        }
    }

    /// <summary>
    /// 이벤트트리거 - 반복실행
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpgradeLoop()
    {
        // 일반 클릭과 동시에 진행되지 않게 기다리게 함
        yield return new WaitForSeconds(delayTime);

        while (isHolding) // 버튼을 누르고있는동안 실행
        {
            UpgradeClick();
            yield return new WaitForSeconds(repeatRate); // 일정시간 기다림
        }
    }
}
