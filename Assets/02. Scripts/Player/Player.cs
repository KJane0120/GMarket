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

    public int levelCritical;           // 치명타 레벨
    public int levelGoldGain;           // 골드획득 레벨
    public int levelAutoAttack;         // 자동클릭 레벨

    public float totalCritical;         // 치명타 데미지
    public float totalGoldGain;         // 골드획득량
    public float totalAutoAttack;       // 자동클릭

    public int gold;                    // 골드, PlayerData

    public void Start()
    {
        gold = GameManager.Instance.PlayerData.StatGold;
        Init(); // 추후 필요없을경우 삭제
        UpdateTotal();
    }

    /// <summary>
    /// 플레이어 스탯 초기화 및 PlayerData와 연결
    /// </summary>
    private void Init()
    {
        levelCritical = GameManager.Instance.PlayerData.CriticalDamageLevel;        // 치명타 레벨
        levelGoldGain = GameManager.Instance.PlayerData.GoldGainLevel;              // 골드획득 레벨
        levelAutoAttack = GameManager.Instance.PlayerData.AutoAttackLevel;          // 자동공격 레벨

        totalCritical = GameManager.Instance.PlayerData.TotalCritDamage;            // 최종 치명타 데미지
        totalGoldGain = GameManager.Instance.PlayerData.TotalGoldGain;              // 최종 골드획득량
        totalAutoAttack = GameManager.Instance.PlayerData.TotalAutoAttack;         // 최종 자동클릭횟수
    }

    /// <summary>
    /// 스탯 업데이트 및 타입 분류
    /// </summary>
    public void UpdateTotal()
    {
        levelCritical = LevelStat(StatType.critical);
        levelGoldGain = LevelStat(StatType.goldGain);
        levelAutoAttack = LevelStat(StatType.autoAttack);

        totalCritical = BonusStat(BonusStatType.criticalBonus);
        totalGoldGain = BonusStat(BonusStatType.goldGainBonus);
        totalAutoAttack = BonusStat(BonusStatType.autoAttackBonus); 
    }

    /// <summary>
    /// 스탯 레벨
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    public int LevelStat (StatType statType)
    {
        float levelValue = 0f;

        switch (statType)
        {
            case StatType.critical:
                levelValue = playerStat.stat.statValue;
                return GameManager.Instance.PlayerData.CriticalDamageLevel;
            case StatType.goldGain:
                levelValue = playerStat.stat.statValue;
                return GameManager.Instance.PlayerData.GoldGainLevel;
            case StatType.autoAttack:
                levelValue = playerStat.stat.statValue;
                return GameManager.Instance.PlayerData.AutoAttackLevel;
            default:
                return 0;
        }
    }


    /// <summary>
    /// 보너스 스탯
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    public float BonusStat(BonusStatType bonusType)
    {
        float bonusValue = 0f;

        switch (bonusType)
        {
            case BonusStatType.criticalBonus:
                bonusValue = playerStat.addStat.bonusValue;
                return GameManager.Instance.PlayerData.TotalCritChance;
            case BonusStatType.goldGainBonus:
                bonusValue = playerStat.addStat.bonusValue;
                return GameManager.Instance.PlayerData.TotalGoldGain;
            case BonusStatType.autoAttackBonus:
                bonusValue = playerStat.addStat.bonusValue;
                return GameManager.Instance.PlayerData.TotalCritChance;
            default:
                return 0;
        }
    }
}
