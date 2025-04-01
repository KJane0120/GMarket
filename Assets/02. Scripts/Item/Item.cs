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
    public bool IsEquipped;

    [SerializeField] private Transform Content;
    [SerializeField] private Image currentWeaponImage;
    [SerializeField] private TextMeshProUGUI currentWeaponName;
    [SerializeField] private TextMeshProUGUI currentWeaponLevel;
    [SerializeField] private TextMeshProUGUI currentWeaponDamageText;
    [SerializeField] private TextMeshProUGUI currentWeaponCritText;

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
            GameManager.Instance.PlayerData.TotalAttackPower = data.damegeMultiplier * data.baseDamage; //LevelUp 기본 데미지 증가
            GameManager.Instance.PlayerData.TotalCritChance = data.criticalMultiplier + data.criticalChance; //LevelUp 치명타 확률 증가
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
        int a = 3; //inventory.Count;
        for (int i = 0; i < a; i++)
        {
            UISlot newSlot = Instantiate(Slot, Content);
            Slots.Add(newSlot);
        }

        Slot.RefreshUI();
    }
    /// <summary>
    /// 장착한 아이템을 UI에 반영
    /// 장착할 때 함수 호출
    /// </summary>
    /// <param name="item"></param>
    public void EquipShow(ItemData item)
    {
        data = item;

        GameManager.Instance.PlayerData.CurrentWeapon = data;

        currentWeaponImage.sprite = item.itemIcon;
        currentWeaponName.text = item.itemName;
        currentWeaponLevel.text = string.Format($"{item.level:D2}");
        currentWeaponDamageText.text = string.Format($"{item.baseDamage:F2}");
        currentWeaponCritText.text = string.Format($"{item.criticalChance:F2}");

    }

    //슬롯의 아이템 데이터가 선택한 아이템의 데이터
    public void OnEquip(UISlot slot)
    {
        data = slot.data;

        if (IsEquip(slot))
        {
            UnEquip(slot);
        }
        else
        {
            switch (slot.data.itemType)
            {
                case ItemType.Melee:
                    GameManager.Instance.PlayerData.TotalAttackPower = slot.data.baseDamage;
                    GameManager.Instance.PlayerData.TotalCritChance = slot.data.criticalChance;
                    break;
            }
            IsEquipped = true;
            EquipList.Add(slot.data);
            EquipShow(slot.data);
        }
    }

    /// <summary>
    /// EquipList에 있는지 여부로 장착중인지 검사
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    public bool IsEquip(UISlot slot)
    {
        for (int i = 0; i < EquipList.Count; i++)
        {
            if (EquipList[i] == slot.data)
            {
                return true;
            }
        }
        return false;
    }

    public void UnEquip(UISlot slot)
    {
        switch (slot.data.itemType)
        {
            case ItemType.Melee:

                break;

        }
        IsEquipped = false;
        EquipList.Remove(slot.data);
    }
}
