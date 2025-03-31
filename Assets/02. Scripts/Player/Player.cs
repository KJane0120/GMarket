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
    public int levelAutoAttacl;         // 자동클릭 레벨

    public int totalCritical;           // 치명타 데미지
    public int totalGoldGain;           // 골드획득량
    // 자동클릭 부분은 토탈스탯으로 넣을지 말지 고민해보기
    public int totalAutoAttack;         // 자동클릭 > 클릭이벤트 기능 가져오기, 초당 a회 진행하는식으로 코드 작성

    public int gold;                    // 골드, PlayerData

    public void Start()
    {
        gold = GameManager.Instance.PlayerData.StatGold;
        Init();
        UpdateTotal();
    }

    private void Init()
    {
        levelCritical = GameManager.Instance.PlayerData.TotalCritDamage;       // 치명타 레벨
        levelGoldGain = GameManager.Instance.PlayerData.TotalCritDamage;       // 골드획득 레벨
        levelAutoAttacl = GameManager.Instance.PlayerData.TotalCritDamage;

        totalCritical = GameManager.Instance.PlayerData.TotalCritDamage;
        totalGoldGain = GameManager.Instance.PlayerData.TotalGoldGain;
    }

    /// <summary>
    /// 스탯 업데이트
    /// </summary>
    public void UpdateTotal()
    {
        levelCritical = LevelStat(StatType.critical);       // 치명타 레벨
        levelGoldGain = LevelStat(StatType.goldGain);        // 골드획득 레벨
        levelAutoAttacl = LevelStat(StatType.autoAttack);

        totalCritical = BonusStat(BonusStatType.criticalBonus);
        totalGoldGain = BonusStat(BonusStatType.goldGainBonus);
        //totalAutoAttack = BonusStat(BonusStatType.autoAttackBonus); 
    }

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
    /// 토탈 스탯, 최종은 PlayerData로
    /// </summary>
    /// <param name="statType"></param>
    /// <returns></returns>
    // 추후 int > float로 바꿔주기
    public int BonusStat(BonusStatType bonusType)
    {
        float bonusValue = 0f;

        // 보너스스탯
        switch (bonusType)
        {
            case BonusStatType.criticalBonus:
                bonusValue = playerStat.addStat.bonusValue;
                return GameManager.Instance.PlayerData.TotalCritChance;
            case BonusStatType.goldGainBonus:
                bonusValue = playerStat.addStat.bonusValue;
                return GameManager.Instance.PlayerData.TotalGoldGain;
            //case BonusStatType.autoAttackBonus:
            //    bonusValue = playerStat.addStat.bonusValue;
            //    return GameManager.Instance.PlayerData.TotalCritChance;
            default:
                return 0;
        }
    }
}
