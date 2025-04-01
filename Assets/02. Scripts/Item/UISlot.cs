using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData data;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI criticalText;
    public Button upgradeBtn;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    public Button EquipBtn;
    [SerializeField] private Image icon;
    public Button BuyBtn;

    public void Start()
    {
        upgradeBtn.onClick.AddListener(() => OnClickWeaponUpgradeBtn(this));
    }

    /// <summary>
    /// 슬롯에 아이템 데이터를 추가합니다. 
    /// </summary>
    /// <param name="item"></param>
    public void UpdateSlot(ItemData item)
    {
        data = item;

        if (data != null)
        {
            icon.sprite = item.itemIcon;
            levelText.text = $"LV.{item.level:D2}";
            itemNameText.text = data.itemName;
            damageText.text = $"공격력: {data.baseDamage:F2}";
            criticalText.text = $"치명타 확률: {data.criticalChance:F2}";
            upgradeCostText.text = string.Format("{0:D2}", data.upgradeCost);
        }
    }

    /// <summary>
    /// 각 슬롯마다 아이템 데이터를 할당합니다. 
    /// </summary>
    public void RefreshUI()
    {
        for (int i = 0; i < ResourceManager.Instance.item.Slots.Count; i++)
        {
            ResourceManager.Instance.item.Slots[i].UpdateSlot(ResourceManager.Instance.item.inventory[i]);
        }
    }
    public void OnClickWeaponUpgradeBtn(UISlot slot) //강화버튼 클릭시 호출되는 함수 수정 예정
    {
        ItemData data = slot.data;
        if (data == null)
        {
            Debug.LogWarning("강화할 무기 데이터가 존재하지 않습니다.");
            return;
        }

        //무기 재화가 강화비용보다 많다면
        if (GameManager.Instance.PlayerData.WeaponGold >= data.upgradeCost)
        {
            int currentUpgradeCost = data.upgradeCost;
            data.level++;
            data.upgradeCost = data.level * data.upgradeCost;
            data.baseDamage = data.damegeMultiplier * data.baseDamage;
            data.criticalChance = data.criticalMultiplier + data.criticalChance;
            CurrencyManager.Instance.controller.WeaponGoldUse(data.upgradeCost); //무기 업그레이드 비용 차감

            UpdateSlot(data);
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
            UIManager.Instance.WeaponErrorMsg(); //에러코드
            return;
        }
    }
    /// <summary>
    /// 보유중이라면 아이콘 정상표시, 구매버튼 비활성화, 강화/장착 버튼 활성화(장착중이 아니라면)
    /// 보유중이지 않다면 아이콘 실루엣 표시, 구매버튼 활성화, 아이템이름/스탯 ??? 표시
    /// </summary>
    public void UIButtonOnOff(UISlot slot)
    {
        if (slot.data == null || !ResourceManager.Instance.item.inventory.Contains(slot.data))
        {
            Debug.Log("버튼 실행 안돼요");
            return;
        }
        data = slot.data;
        if (slot.data.isOwned)
        {
            icon.color = Color.white; // 보유 시 아이콘 정상 표시
            BuyBtn.gameObject.SetActive(false);
            upgradeBtn.gameObject.SetActive(true);
            EquipBtn.gameObject.SetActive(!data.isEquipped);
        }
        else
        {
            icon.color = new Color(1, 1, 1, 0.5f);
            BuyBtn.gameObject.SetActive(true);
            upgradeBtn.gameObject.SetActive(false);
            EquipBtn.gameObject.SetActive(false);
            itemNameText.text = "???";
            damageText.text = "???";
            criticalText.text = "???";
            levelText.text = "???";
        }
    }
}
