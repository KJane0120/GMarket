using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        item = FindFirstObjectByType<Item>();

        items = Resources.LoadAll<ItemData>("ItemData");
        for (int i = 0; i < items.Length; i++)
        {
            item.AddItem(Instantiate(items[i]));
        }
        item.SortList();

        if (item != null)
        {
            item.InstantiateSlot();
            item.EquipList.Add(item.inventory[0]);
            item.inventory[0].isEquipped = true;

            GameManager.Instance.PlayerData.CurrentWeapon = item.inventory[0];
            GameManager.Instance.PlayerData.CurrentWeapon.level = 0;

            item.EquipShow(item.inventory[0]);
        }
    }
}
