using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISlot : MonoBehaviour
{
   public ItemData data;
   [SerializeField] private TextMeshProUGUI levelText;
   [SerializeField] private TextMeshProUGUI itemNameText;
   [SerializeField] private TextMeshProUGUI damageText;
   [SerializeField] private TextMeshProUGUI criticalText;
   [SerializeField] private TextMeshProUGUI buttonText;
   [SerializeField] private TextMeshProUGUI upgradeCostText;


    public void Start()
    {
        data = GameManager.Instance.PlayerData.data;

    }


    public void SetItem(ItemData item)
    {
        data = item;

       if (data != null)
        {
            levelText.text = string.Format( "{0;D2}", $"LV.{ GameManager.Instance.PlayerData.BasicWeaponLevel}");
            itemNameText.text = data.itemName;
            //damageText.text = 


        }
    }

}
