using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Items/StatItem")] //ItemData를 여러개 추가 가능
public class ItemData : ScriptableObject
{
    public string itemName; //아이템 이름
    public Sprite itemIcon; //무기 아이콘UI
    //public ItemUpgrade[] upgrades; // 무기 강화 단계별 데이터 (배열)

}

[System.Serializable]  // 개별 강화 데이터
public class ItemUpgrade
{
    public int level;         // 강화 레벨
    public int cost;          // 강화 비용 (필요한 골드)
    public int damageUp;        // 공격력 증가
    public int criticalRate;  // 크리티컬 확률 증가
}
