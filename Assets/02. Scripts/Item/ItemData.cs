using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Scripttable Object/ItemData")] //ItemData를 여러개 추가 가능
public class ItemData : ScriptableObject
{
    public enum ItemType { Melee, Tooth, finger, helmet, shoes, Necklace } //이빨, 손톱, 헬멧, 신발, 목걸이

    [Header("# Main Info")]
    public ItemType itemtype;
    public int ItemID; //아이템 번호
    public string itemName; //아이템 이름
    public string itemDesc; //아이템 설명
    public Sprite itemIcon; //아이템 아이콘



    [Header("# Level Data")]
    public float baseDamage; //기본 공격력
    public float addDamage; //추가 데미지
    public float[] baseDamageUp; //강화 렙 증가 -> 공격력 증가
    public float[] addDamageUp; //강화 렙 증가 ->크리티컬 증가


    [Header("# Weapon")] //
    public GameObject Toothpick;
    



}


