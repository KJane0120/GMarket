using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //이미지 활성화


public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    //public Weapon weapon;

    Image icon;
    TextMeshProUGUI textLevel;

    void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        textLevel = texts[0];
    }

    void LateUpdate()
    {
        textLevel.text = "Lv." + (level + 1);
    }
    

}
