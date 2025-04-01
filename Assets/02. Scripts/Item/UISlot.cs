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
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private Button EquipBtn;
    [SerializeField] private Image icon;
    //[SerializeField] private Button BuyBtn;

    public void Start()
    {
        upgradeBtn.onClick.AddListener(OnClickWeaponUpgradeBtn);
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
            icon.sprite = item.itemIcon;
            levelText.text = $"LV.{item.level:D2}";
            itemNameText.text = data.itemName;
            damageText.text = $"공격력: {data.baseDamage:F2}";
            criticalText.text = $"치명타 확률: {data.criticalChance:F2}";
            upgradeCostText.text = string.Format("{0:D2}",data.upgradeCost);
        }
    }

    /// <summary>
    /// 각 슬롯마다 아이템 데이터를 할당합니다. 
    /// </summary>
    public void RefreshUI()
    {
        for (int i = 0; i < ResourceManager.Instance.item.Slots.Count; i++)
        {
            ResourceManager.Instance.item.Slots[i].SetItem(ResourceManager.Instance.item.inventory[i]);
        }
    }
    public void OnClickWeaponUpgradeBtn() //강화버튼 클릭시 호출되는 함수 수정 예정
    {
        if (GameManager.Instance.PlayerData.WeaponGold > data.upgradeCost)
        {
            GameManager.Instance.PlayerData.BasicWeaponLevel++; //클릭 시 LevelUp
            data.upgradeCost = GameManager.Instance.PlayerData.BasicWeaponLevel * data.upgradeCost; //LevelUp 무기 비용 증가
            GameManager.Instance.PlayerData.TotalAttackPower = data.damegeMultiplier * data.baseDamage; //LevelUp 기본 데미지 증가
            GameManager.Instance.PlayerData.TotalCritChance = data.criticalMultiplier + data.criticalChance; //LevelUp 치명타 확률 증가
            CurrencyManager.Instance.controller.WeaponGoldUse(data.upgradeCost); //무기 업그레이드 비용 차감
        }
        else
        {
            UIManager.Instance.WeaponErrorMsg(); //에러코드
        }
    }
    /// <summary>
    /// 보유중이라면 아이콘 정상표시, 구매버튼 비활성화, 강화/장착 버튼 활성화(장착중이 아니라면)
    /// 보유중이지 않다면 아이콘 실루엣 표시, 구매버튼 활성화, 아이템이름/스탯 ??? 표시
    /// </summary>
    public void UIButtonOnOff(UISlot slot)
    {
        data = slot.data;
        if (data.isOwned)
        {
            icon.color = Color.white; // 보유 시 아이콘 정상 표시
            //BuyBtn.gameObject.SetActive(false);
            upgradeBtn.gameObject.SetActive(true);
            EquipBtn.gameObject.SetActive(!data.isEquipped);
        }
        else
        {
            icon.color = new Color(1, 1, 1, 0.5f);
            //BuyBtn.gameObject.SetActive(true);
            upgradeBtn.gameObject.SetActive(false);
            EquipBtn.gameObject.SetActive(false);
            itemNameText.text = "???";
            damageText.text = "???";
            criticalText.text = "???";
            levelText.text = "???";
        }
    }
}
