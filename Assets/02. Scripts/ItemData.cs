using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Items/Stat Item")] //ItemData를 여러개 추가 가능
public class ItemData : ScriptableObject
{
    public string ItemName; //아이템 이름
    public Sprite ItemIcon; //무기 아이콘UI
    public WeaponUpgrade[] upgrades; // 무기 강화 단계별 데이터 (배열)

}

[System.Serializable]  // 개별 강화 데이터
public class WeaponUpgrade
{
    public int level;         // 강화 레벨
    public int cost;          // 강화 비용 (필요한 골드)
    public int damage;        // 공격력 증가
    public int criticalRate;  // 크리티컬 확률 증가
}
