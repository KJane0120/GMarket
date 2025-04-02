using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //이미지 활성화


public class Item : MonoBehaviour
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

    /// <summary>
    /// 인벤토리 리스트에 아이템을 추가합니다. 
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(ItemData item)
    {
        inventory.Add(item);
    }

    /// <summary>
    /// 인벤토리 리스트를 ID순으로 정렬합니다.
    /// </summary>
    public void SortList()
    {
        inventory.Sort((a, b) => a.ItemID.CompareTo(b.ItemID));
    }

    /// <summary>
    /// 슬롯을 동적 생성합니다. 
    /// </summary>
    public void InstantiateSlot()
    {
        if (Slot == null) return;
        for (int i = 0; i < inventory.Count; i++)
        {
            UISlot newSlot = Instantiate(Slot, Content);
            Button slotBtn = newSlot.EquipBtn;
            slotBtn.onClick.AddListener(() => OnEquip(newSlot));
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
        GameManager.Instance.PlayerData.CurrentWeapon = item;

        currentWeaponImage.sprite = item.itemIcon;
        currentWeaponName.text = item.itemName;
        currentWeaponLevel.text = string.Format($"Lv.{item.level:D2}");
        currentWeaponDamageText.text = string.Format($"공격력: <color=#EEA970>{item.baseDamage:F2}</color>");
        currentWeaponCritText.text = string.Format($"치명타 확률: <color=#EEA970>{item.criticalChance:F2}%</color>");
    }

    /// <summary>
    /// 아이템을 장착합니다.
    /// </summary>
    /// <param name="slot"></param>
    public void OnEquip(UISlot slot)
    {
        if (slot.data == null || !inventory.Contains(slot.data)) return;

        data = slot.data;

        if (GameManager.Instance.PlayerData.CurrentWeapon != null)
        {
            UISlot prevSlot = GetItemSlot(GameManager.Instance.PlayerData.CurrentWeapon.ItemID);
            UnEquip(prevSlot);
        }

        switch (slot.data.itemType)
        {
            case ItemType.Melee:
                GameManager.Instance.PlayerData.TotalAttackPower = slot.data.baseDamage;
                GameManager.Instance.PlayerData.TotalCritChance = slot.data.criticalChance;
                break;
        }

        foreach (var item in inventory)
        {
            item.isEquipped = (item == slot.data); // 선택한 아이템만 true, 나머지는 false
        }

        slot.UIButtonOnOff(slot);

        if (!EquipList.Contains(slot.data))
        {
            EquipList.Add(slot.data);
        }

        EquipShow(data);

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

    /// <summary>
    /// 아이템을 해제합니다.
    /// </summary>
    /// <param name="slot"></param>
    public void UnEquip(UISlot slot)
    {
        switch (slot.data.itemType)
        {
            case ItemType.Melee:
                slot.data.isEquipped = false;
                slot.UIButtonOnOff(slot);
                break;
        }
        EquipList.Remove(slot.data);
    }

    /// <summary>
    /// 아이템 ID를 받아서 해당 아이템의 슬롯을 반환
    /// </summary>
    /// <param name="itemID"></param>
    /// <returns></returns>
    public UISlot GetItemSlot(int itemID)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].data.ItemID == itemID)
            {
                return Slots[i];
            }
        }
        Debug.Log("해당 슬롯이 존재하지 않습니다.");
        return null;
    }
}
