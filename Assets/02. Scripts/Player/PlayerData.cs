using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유저데이터 클래스입니다.
/// 하나로 통합하여 관리합니다.
/// </summary>
[System.Serializable]
public class PlayerData
{
    private int nowStage; //현재 진행중인 스테이지
    public int NowStage
    {
        get => nowStage;
        set
        {
            if(nowStage != value)
            {
                nowStage = value;
                OnStageChanged?.Invoke(nowStage);
            }
        }
    }            
    public ItemData CurrentWeapon;   //현재 장착한 장비

    [Header("Gold")]
    public int StatGold;             // 보유한 스탯재화(시연영상 속 노란 네모)
    public int WeaponGold;           //보유한 무기재화(시연영상 속 파란 네모)

    [Header("StatsUpgrade")]
    public int CriticalDamageLevel;  // 치명타 데미지 레벨
    public int AutoAttackLevel;      //자동 공격 레벨
    public int GoldGainLevel;        // 재화 획득량 증가 레벨

    [Header("WeaponUpgrade")]
    public List<ItemData> inventory;

    [Header("TotalStats")]
    public float TotalAttackPower;  //최종 공격력
    public float TotalCritChance;   //최종 치명타 확률
    public float TotalCritDamage;   //최종 치명타 데미지
    public float TotalGoldGain;     //최종 골드 획득 보너스
    public float TotalAutoAttack;   // 최종 자동 공격 횟수 

    public static event Action<int> OnStageChanged;
}
