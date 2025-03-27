using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]

public class Player : MonoBehaviour
{
    // 싱글톤처리 하기

    public PlayerStat playerStat; // ScriptableObject 연결

    // 스탯은 기본적으로 게임매니저에서 최종스탯 산출, 재화도 게임매니저, 나는 수치증가량에 대한 메서드 만들고 최종뎀은 게임매니저의 뭐다 하고 써야함
    public int attack;              // 공격력
    public int critical;            // 치명타 데미지
    public int criticalChance;      // 치명타 확률
    public int goldChance;          // 골드획득량
    public int autoClick;           // 자동클릭 > 클릭이벤트 기능 가져오기

    public int gold = 10000;

    // 무기장착 > 게임매니저
    // 무기변경

    //void Start()
    //{
          // 플레이어스탯쪽 가져오기
    //    UpgradeStat();
    //}

    //public void UpgradeStat()
    //{
    //    int totalAttack = attack + playerStat.attackBonus;

    //    Debug.Log($"현재 공격력: {totalAttack}");
    //}
}
