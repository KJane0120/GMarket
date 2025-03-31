using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //이미지 활성화


public class Item : MonoBehaviour
{
    public ItemData data {  get{ return GameManager.Instance.PlayerData.data; } }
    public List<UISlot> Slots = new List<UISlot>();
    public UISlot Slot;
    public List<ItemData> inventory;
    [SerializeField] private Transform Content;

    private void Start()
    {
        InstantiateSlot();
    }

    public void OnClickWeaponUpgradeBtn()
    {
        if (GameManager.Instance.PlayerData.WeaponGold > data.upgradeCost)
        {
            GameManager.Instance.PlayerData.BasicWeaponLevel++;
            data.upgradeCost = GameManager.Instance.PlayerData.BasicWeaponLevel * data.upgradeCost;
            data.baseDamage = data.damegeMultiplier * data.baseDamage;
            data.criticalChance = data.criticalMultiplier + data.criticalChance;
        }
        else
        {
            UIManager.Instance.WeaponErrorMsg();
        }
    }


    public void InstantiateSlot()
    {
        if (Slot == null) return;


        int a = 5;
        for (int i = 0; i < a; i++)
        {
            UISlot newSlot = Instantiate(Slot, Content);
            Slots.Add(newSlot);
        }
        
    }
}
