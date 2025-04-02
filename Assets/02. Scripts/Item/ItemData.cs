using UnityEngine;

public enum ItemType { Melee, Tooth, finger, helmet, shoes, Necklace } //근접, 이빨, 손톱, 헬멧, 신발, 목걸이

[CreateAssetMenu(fileName = "New ItemData", menuName = "Scripttable Object/ItemData")] //ItemData를 여러개 추가 가능
public class ItemData : ScriptableObject
{
    [Header("# Main Info")]
    public ItemType itemType;
    public int ItemID; //아이템 번호
    public string itemName; //아이템 이름
    public string itemDesc; //아이템 설명
    public Sprite itemIcon; //아이템 아이콘
    public int level;

    [Header("# Level Data")]
    public float baseDamage; //기본 공격력
    public float damegeMultiplier; //공격력 Up비율
    public float criticalChance; //치명타 확률
    public float criticalMultiplier; //치명타 Up비율

    [Header("# Cost")]
    public int upgradeCost; //무기 Up 비용
    public int purchaseGold; //구매 비용

    [Header("Equip")]
    public bool isEquipped; //장착 여부

    [Header("Have")]
    public bool isOwned; //보유 여부

}


