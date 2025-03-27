using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//개별적인 적 종류
//실질적인 계산은 StageManager에서 처리할 것
public enum EnemyType
{
    Normal, //스테이지의 0.5배만큼을 체력에 곱하기
    Elite, //스테이지의 1배만큼 체력에 곱하기
    Boss, //스테이지의 2배만큼 체력에 곱하기
}

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Info")]
    public Sprite icon; // 적 아이콘
    public int health; // 적 체력
    public EnemyType enemyType;


    [Header("Resources")]
    public int StatsGoldOnHit; //피격시 얻는 스탯 재화

    public int WeaponGoldOnKill; // 사망했을 때 얻는 무기 재화
    public int StatsGoldOnKill; // 사망했을 때 얻는 스탯 재화
}
