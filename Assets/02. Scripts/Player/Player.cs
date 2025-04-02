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
    public PlayerData playerData;

    // 변수명도 삭제
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
        UpdateTotal();
    }

    /// <summary>
    /// 스탯 업데이트 및 타입 분류
    /// </summary>
    public void UpdateTotal()
    {
        GameManager.Instance.PlayerData.CriticalDamageLevel = LevelStat(StatType.critical);
        GameManager.Instance.PlayerData.GoldGainLevel = LevelStat(StatType.goldGain);
        GameManager.Instance.PlayerData.AutoAttackLevel = LevelStat(StatType.autoAttack);

        GameManager.Instance.PlayerData.TotalCritDamage = BonusStat(BonusStatType.criticalBonus);
        GameManager.Instance.PlayerData.TotalGoldGain = BonusStat(BonusStatType.goldGainBonus);
        GameManager.Instance.PlayerData.TotalAutoAttack = BonusStat(BonusStatType.autoAttackBonus);
    }

    /// <summary>
    /// 스탯 레벨
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    public int LevelStat (StatType statType)
    {
        int levelValue = 0;

        switch (statType)
        {
            case StatType.critical:
                levelValue = playerStat.stat.statValue;
                GameManager.Instance.PlayerData.CriticalDamageLevel = levelValue;
                return GameManager.Instance.PlayerData.CriticalDamageLevel;
            case StatType.goldGain:
                levelValue = playerStat.stat.statValue;
                GameManager.Instance.PlayerData.GoldGainLevel = levelValue;
                return GameManager.Instance.PlayerData.GoldGainLevel;
            case StatType.autoAttack:
                levelValue = playerStat.stat.statValue;
                GameManager.Instance.PlayerData.AutoAttackLevel = levelValue;
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
                GameManager.Instance.PlayerData.TotalCritDamage = bonusValue;
                return GameManager.Instance.PlayerData.TotalCritDamage;
            case BonusStatType.goldGainBonus:
                bonusValue = playerStat.addStat.bonusValue;
                GameManager.Instance.PlayerData.TotalGoldGain = bonusValue;
                return GameManager.Instance.PlayerData.TotalGoldGain;
            case BonusStatType.autoAttackBonus:
                bonusValue = playerStat.addStat.bonusValue;
                GameManager.Instance.PlayerData.TotalAutoAttack = bonusValue;
                return GameManager.Instance.PlayerData.TotalAutoAttack;
            default:
                return 0;
        }
    }
}
