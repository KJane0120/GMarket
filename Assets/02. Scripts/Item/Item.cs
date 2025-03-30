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
        icon = GetComponentsInChildren<Image>()[1]; //data Image 불러오기
        icon.sprite = data.itemIcon;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>(); //
        textLevel = texts[0];
    }

    void LateUpdate()
    {
        textLevel.text = "Lv." + (level + 1); //초기 level 설정
    }
    
    public void OnClick() //Lv.UP 클릭조건
    {
        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
                break;
            case ItemData.ItemType.Tooth:
                break;
            case ItemData.ItemType.finger:
                break;
            case ItemData.ItemType.helmet:
                break;
            case ItemData.ItemType.shoes:
                break;
            case ItemData.ItemType.Necklace:
                break;
        }

        level++; //클릭 할때마다 1UP

        if (level == data.baseDamageUp.Length) //최대 Lv. 초과 방지 코드
        {
            GetComponent<Button>().interactable = false;   //Inspector -> Boutton Off

        } 

    }


}
