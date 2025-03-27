using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]

public class PlayerStat : ScriptableObject
{
    Player player;

    // 무기에 있는 공격력 및 치명타확률은 빼기

    public int attackBonus = 1;             // 공격력
    //public int criticalBonus = 0;           // 치명타 데미지
    //public int criticalChanceBonus = 0;     // 치명타 확률
    //public int goldChanceBonus = 0;         // 골드획득량
    //public int autoClickBonus = 0;          // 자동클릭횟수

    public int upgradeGold = 5; // 임시 초기강화비용

    // 아이템별로 추가 로직 짤것, AddAttack / SubtractAttack 이런식으로
    // 아이템별로 누를때 재화 얼만큼 차감될건지, 업그레이드 하면서 얼만큼 될건지도 추가

    public void UpgradeAttack()
    {
        if (player.gold >= upgradeGold)
        {
            player.gold -= upgradeGold; // 골드 차감
            attackBonus += 1; // 공격력 증가
            upgradeGold = Mathf.RoundToInt(upgradeGold * 1.2f); // 강화 비용 20% 증가
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    //public void IncreaseStat(string statName, int amount)
    //{
    //    if (statName == "Attack") attackBonus += amount;
    //}
}
