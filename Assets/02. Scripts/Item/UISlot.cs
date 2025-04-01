using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData data;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI criticalText;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private Button EquipBtn;

    public delegate void WeaponUpgradeBtn();


    public void Start()
    {
        upgradeBtn.onClick.AddListener(ResourceManager.Instance.item.OnClickWeaponUpgradeBtn);
        Debug.Log("무기 강화버튼 추가");
    }

    /// <summary>
    /// 슬롯에 아이템 데이터를 추가합니다. 
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(ItemData item)
    {
        data = item;

        if (data != null)
        {
            levelText.text = $"LV.{item.level:D2}";
            itemNameText.text = data.itemName;
            damageText.text = $"공격력: {data.baseDamage:F2}";
            criticalText.text = $"치명타 확률: {data.criticalChance:F2}";
            upgradeCostText.text = string.Format("{0:D2}",data.upgradeCost);
        }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < ResourceManager.Instance.item.Slots.Count; i++)
        {
            ResourceManager.Instance.item.Slots[i].SetItem(ResourceManager.Instance.item.inventory[i]);
        }
    }
}
