using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStat playerStat;

    // 스탯은 기본적으로 게임매니저에서 최종스탯 산출, 재화도 게임매니저, 나는 수치증가량에 대한 메서드 만들고 최종뎀은 게임매니저의 뭐다 하고 써야함
    public int attack;              // 공격력
    public int critical;            // 치명타 데미지
    public int criticalChance;      // 치명타 확률
    public int goldChance;          // 골드획득량 - 수치 계산 하기
    public int autoClick;           // 자동클릭 > 클릭이벤트 기능 가져오기, 초당 a회 진행하는식으로 코드 작성

    public int gold = 10000;        // 임시골드, 나중에 PlayerData에서 

    void Start()
    {
        // 플레이어 스탯쪽이랑 합산된 수치 계산
        //UpdateStat()
    }

    public void UpdateStat()
    {
        //int totalAttack = attack + playerStat.attackBonus;
        // switch case로 타입에 따른 스탯값 가져오기로 일반스탯+보너스스탯 값 가져오기
    }
}
