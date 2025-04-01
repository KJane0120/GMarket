using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //이미지 활성화


public class Item : MonoBehaviour // 삭제 예정
{
    public ItemData data;
    public UISlot Slot;
    public List<UISlot> Slots = new List<UISlot>();
    public List<ItemData> inventory = new List<ItemData>();
    public List<ItemData> EquipList = new List<ItemData>();
    public bool isEquipped;
    
   
    [SerializeField] private Transform Content;
    [SerializeField] private Image currentWeaponImage;
    [SerializeField] private TextMeshProUGUI currentWeaponName;
    [SerializeField] private TextMeshProUGUI currentWeaponLevel;
    [SerializeField] private TextMeshProUGUI currentWeaponDamageText;
    [SerializeField] private TextMeshProUGUI currentWeaponCritText;

    private void Start()
    {
        InstantiateSlot();
    }

    public void AddItem(ItemData item)
    {
        inventory.Add(item);
    }

    public void SortList()
    {
        inventory.Sort((a, b) => a.ItemID.CompareTo(b.ItemID)); 
    }

    public void OnClickWeaponUpgradeBtn() //강화버튼 클릭시 호출되는 함수 수정 예정
    {
        if (GameManager.Instance.PlayerData.WeaponGold > data.upgradeCost)
        {
            GameManager.Instance.PlayerData.BasicWeaponLevel++; //클릭 시 LevelUp
            data.upgradeCost = GameManager.Instance.PlayerData.BasicWeaponLevel * data.upgradeCost; //LevelUp 무기 비용 증가
            data.baseDamage = data.damegeMultiplier * data.baseDamage; //LevelUp 기본 데미지 증가
            data.criticalChance = data.criticalMultiplier + data.criticalChance; //LevelUp 치명타 확률 증가
            CurrencyManager.Instance.controller.WeaponGoldUse(data.upgradeCost); //무기 업그레이드 비용 차감
        }
        else
        {
            UIManager.Instance.WeaponErrorMsg(); //에러코드
        }
    }


    public void InstantiateSlot()
    {
        if (Slot == null) return;
        
        int a = 5; // 인벤토리의 길이로 변경
        for (int i = 0; i < a; i++)
        {
            UISlot newSlot = Instantiate(Slot, Content);
            Slots.Add(newSlot);
        }

        Slot.RefreshUI();
    }

    //public void OnEquip(UISlot slot)
    //{
    //    슬롯의 아이템 데이터가 선택한 아이템의 데이터





    //    선택한 아이템이 이미 장착중이라면 해제
    //    if (IsEquip(slot))
    //    {
    //        UnEquip(slot);
    //    }
    //    선택한 아이템이 장착중이 아니라면 장착
    //    else
    //    {
    //        switch (slot.ResourceManager.Instance.data.type)
    //        {
    //            case ItemType.ATK:
    //                ATK += slot.item.Value;
    //                break;
    //            case ItemType.DEF:
    //                DEF += slot.item.Value;
    //                break;
    //            case ItemType.HP:
    //                HP += slot.item.Value;
    //                break;
    //            case ItemType.Crit:
    //                Crit += slot.item.Value;
    //                break;
    //        }
    //        IsEquipped = true;
    //        EquipList.Add(slot.item);
    //    }
    //}

    /// <summary>
    /// EquipList에 있는지 여부로 장착중인지를 검사합니다.
    /// </summary>
    /// <param name = "slot" ></ param >
    /// < returns ></ returns >
    //public bool IsEquip(UISlot slot)
    //{
    //    for (int i = 0; i < EquipList.Count; i++)
    //    {
    //        if (EquipList[i] == slot.data)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    /// <summary>
    /// 이미 장착중일 때 호출되는 함수입니다.
    /// 장비 스탯을 캐릭터 스탯에 반영합니다.
    /// </summary>
    /// <param name = "slot" ></ param >
    //public void UnEquip(UISlot slot)
    //{
    //    switch (slot.ResourceManager.Instance.ItemData.Itemtype)
    //    {
    //        case ItemType.ATK:
    //            ATK -= slot.item.Value;
    //            break;
    //        case ItemType.DEF:
    //            DEF -= slot.item.Value;
    //            break;
    //        case ItemType.HP:
    //            HP -= slot.item.Value;
    //            break;
    //        case ItemType.Crit:
    //            Crit -= slot.item.Value;
    //            break;
    //    }
    //    IsEquipped = false;
    //    EquipList.Remove(slot.item);
    //}
}
