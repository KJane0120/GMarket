using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public Player player;
    public PlayerStat playerStat;
    public AddStatValue addStat;

    public TMP_Text goldText;
    public TMP_Text curStatText;
    public TMP_Text upStatText;
    public TMP_Text upGoldText;
    public TMP_Text criticalText;

    void Start()
    {
        UpdateUI();
    }

    /// <summary>
    /// 스탯 강화
    /// </summary>
    public void UpgradeClick()
    {
        int gold = playerStat.upgradeGold; // 강화 비용 가져오기

        // player.gold 이부분 나중에 playerData에 있는걸로 가져오기
        if (player.gold >= gold)
        {
            player.gold -= gold;            // 골드 차감
            playerStat.UpgradeBonus();      // 보너스 스탯증가
            player.UpdateTotal();           // 토탈 스탯
            UpdateUI();
        }
        else
        {
            // 추후 ui부분 넣기
            Debug.Log("골드오링");
        }
    }

    /// <summary>
    /// UI 업데이트
    /// </summary>
    void UpdateUI()
    {
        goldText.text = $"{player.gold}";                       // 보유골드- 나중에 다른곳으로 빼기
        curStatText.text = $"{playerStat.stat.statValue}";      // 현 스탯
        upStatText.text = $"{playerStat.addStat.bonusValue}";   // 보너스 스탯
        upGoldText.text = $"{playerStat.upgradeGold}";          // 업그레이드 골드
        criticalText.text = $"{player.totalCritical}";          // 합산 치명타 스탯
    }
}
