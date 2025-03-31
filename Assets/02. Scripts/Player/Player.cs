using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStat playerStat;
    public StatType statType { get; set; }
    public BonusStatType bonusType { get; set; }

    // 스탯은 기본적으로 게임매니저에서 최종스탯 산출, 재화도 게임매니저, 나는 수치증가량에 대한 메서드 만들고 최종뎀은 게임매니저의 뭐다 하고 써야함
    public int totalDamage;             // 공격력
    public int totalCritical;           // 치명타 데미지
    public int totalCriticalRate;       // 치명타 확률
    public int totalGoldGain;           // 골드획득량 - 수치 계산 하기
    public int totalAutoAttack;         // 자동클릭 > 클릭이벤트 기능 가져오기, 초당 a회 진행하는식으로 코드 작성

    public int gold = 10000;            // 임시골드, 나중에 PlayerData에서 

    public void Start()
    {
        UpdateTotal();
    }

    /// <summary>
    /// 스탯 업데이트
    /// </summary>
    public void UpdateTotal()
    {
        // 토탈스탯 부분은 PlayerData부분으로 보내는거 생각해보기
        totalDamage = TotalStat(StatType.damage);
        totalCritical = TotalStat(StatType.critical);
        totalCriticalRate = TotalStat(StatType.criticalRate);
        totalGoldGain = TotalStat(StatType.goldGain);
        totalAutoAttack = TotalStat(StatType.autoAttack); // 자동클릭 부분은 토탈스탯으로 넣을지 말지 고민해보기
    }

    /// <summary>
    /// 토탈 스탯
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    public int TotalStat(StatType statType)
    {
        float baseValue = 0f;
        float bonusValue = 0f;

        if (statType == playerStat.stat.statType)
        {
            baseValue = playerStat.stat.statValue;
        }

        // 보너스스탯
        switch (statType)
        {
            case StatType.damage:
                if (playerStat.addStat.BonusType == BonusStatType.damageBonus)
                {
                    bonusValue = playerStat.addStat.bonusValue;
                }
                break;

            case StatType.critical:
                if (playerStat.addStat.BonusType == BonusStatType.criticalBonus)
                {
                    bonusValue = playerStat.addStat.bonusValue;
                }
                break;

            case StatType.criticalRate:
                if (playerStat.addStat.BonusType == BonusStatType.criticalRateBonus)
                {
                    bonusValue = playerStat.addStat.bonusValue;
                }
                break;

            case StatType.goldGain:
                if (playerStat.addStat.BonusType == BonusStatType.goldGainBonus)
                {
                    bonusValue = playerStat.addStat.bonusValue;
                }
                break;
            case StatType.autoAttack:
                if (playerStat.addStat.BonusType == BonusStatType.autoAttackBonus)
                {
                    bonusValue = playerStat.addStat.bonusValue;
                }
                break;
        }
        return Mathf.RoundToInt(baseValue + bonusValue);
    }
}
