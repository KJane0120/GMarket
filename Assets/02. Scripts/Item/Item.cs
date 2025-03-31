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
            GameManager.Instance.PlayerData.BasicWeaponLevel++; //클릭 시 LevelUp
            data.upgradeCost = GameManager.Instance.PlayerData.BasicWeaponLevel * data.upgradeCost; //LevelUp 무기 비용 증가
            data.baseDamage = data.damegeMultiplier * data.baseDamage; //LevelUp 기본 데미지 증가
            data.criticalChance = data.criticalMultiplier + data.criticalChance; //LevelUp 치명타 확률 증가
            CurrencyManager.Instance.controller.WeaponGoldUse(data.upgradeCost); //무기 업그레드 비용 차감
        }
        else
        {
            UIManager.Instance.WeaponErrorMsg(); //에러코드
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
