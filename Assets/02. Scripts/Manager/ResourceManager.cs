using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 게임의 전반적인 자원을 관리하는 클래스입니다.
/// </summary>
public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public static ResourceManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public ItemData[] items;
    public Item item;
    public Sprite[] stageBackgrounds = new Sprite[3];
    public List<Sprite> backgrounds = new List<Sprite>();

    private void Start()
    {
        LoadItemData();
        LoadBackGroundImage();
        SetData();
    }

    /// <summary>
    /// 아이템 데이터를 로드합니다.
    /// </summary>
    private void LoadItemData()
    {
        item = FindFirstObjectByType<Item>();

        items = Resources.LoadAll<ItemData>("ItemData");
        for (int i = 0; i < items.Length; i++)
        {
            item.AddItem(Instantiate(items[i]));
        }
        item.SortList();
    }

    /// <summary>
    /// 배경 이미지를 로드합니다.
    /// </summary>
    private void LoadBackGroundImage()
    {
        stageBackgrounds = Resources.LoadAll<Sprite>("BackGround")
        .OrderBy(sprite => sprite.name)  // 이름 순서대로 정렬
        .ToArray();
        
        Debug.Log(stageBackgrounds[0]);
        Debug.Log(stageBackgrounds[1]);
        Debug.Log(stageBackgrounds[2]);
    }

    /// <summary>
    /// 게임 시작 시 데이터를 초기화합니다.
    /// </summary>
    private void SetData()
    {
        if (item != null)
        {
            item.InstantiateSlot();
            item.EquipList.Add(item.inventory[0]);
            item.inventory[0].isEquipped = true;
            item.inventory[0].isOwned = true;

            GameManager.Instance.PlayerData.CurrentWeapon = item.inventory[0];
            GameManager.Instance.PlayerData.CurrentWeapon.level = 0;

            item.EquipShow(item.inventory[0]);

            for (int i = 0; items.Length > i; i++)
            {
                if (items[i] != items[0])
                {
                    items[i].isEquipped = false;
                    items[i].isOwned = false;
                }
                item.Slots[i].UIButtonOnOff(item.Slots[i]);
            }
        }
    }
}
