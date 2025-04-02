using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 일반 스탯
/// </summary>
[Tooltip("일반 스탯")]
public enum StatType
{
    critical,           // 치명타
    goldGain,           // 골드획득량
    autoAttack          // 자동클릭
}

/// <summary>
/// 추가 스탯(강화)
/// </summary>
[Tooltip("추가 스탯(강화)")]
public enum BonusStatType
{
    criticalBonus,
    goldGainBonus,
    autoAttackBonus
}

[Serializable]
public class StatLevel
{
    [Tooltip("레벨")]
    public StatType statType;
    [Tooltip("레벨 값")]
    public int statValue;
}

[Serializable]
public class AddStatValue
{
    [Tooltip("스탯 설정")]
    public BonusStatType BonusType;
    [Tooltip("스탯 값")]
    public float bonusValue;
    [Tooltip("1회 클릭시 강화스탯 추가 값")]
    public float plusValue;
}

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]

public class PlayerStat : ScriptableObject
{
    [Header("Stat")]
    public StatLevel stat;

    [Header("Add Stat")]
    public AddStatValue addStat;

    // 강화비용 및 증가율
    [Header("Gold")]
    [Tooltip("강화 비용")]
    public int upgradeGold;             // 초기강화비용
    [Tooltip("강화비용 증가 퍼센트")]
    public float upgradePercent;        // 강화비용 증가 퍼센트

    public void UpgradeBonus()
    {
        stat.statValue += 1;                                    // 레벨 증가
        addStat.bonusValue += addStat.plusValue;                        // 보너스 증가
        upgradeGold = Mathf.RoundToInt(upgradeGold * upgradePercent);   // 강화비용 증가
    }
}
