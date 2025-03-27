using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class ItemManager : MonoBehaviour
{
    public List<ItemData> itemList; //아이템 리스트
    public int selectedItemIndex = 0; // 현재 선택한 아이템 인덱스
    private int currentLevel = 1;       // 현재 무기의 강화 레벨
    public int playerGold = 1000;       // 보유한 골드 - 임시

    //UI 연결
    public Image itemIcon; //아이템 아이콘
    public TextMeshProUGUI itemNameText; //아이템 이름
    public TextMeshProUGUI itemLevelText; //현재 강화 레벨
    public TextMeshProUGUI damageText; //공격력
    public TextMeshProUGUI criticalText; //크리티컬 확률
    public TextMeshProUGUI upgradeCostText; //강화 비용
    public Button upgradeButton; //강화 버튼

    private void Start()
    {
        UpdateUI(); // 게임 시작 시 UI 업데이트
    }
    public void SelectItem(int index) //아이템 선택 = 무기 리스트 위치
    {
        selectedItemIndex = index;
        currentLevel = 1; // 새로운 무기를 선택하면 강화 레벨 초기화
        UpdateUI(); // UI 업데이트
    }

    // 무기강화 기능
    public void UpgradeItem()
    {
        ItemData currentItem = itemList[selectedItemIndex];

        // 최대 레벨 도달 시 강화 불가
        if (currentLevel >= currentItem.upgrades.Length - 1)
        {
            Debug.Log("최대 레벨 입니다 강화 불가능.");
            return;
        }

        ItemUpgrade nextUpgrade = currentItem.upgrades[currentLevel + 1];

        // 보유 골드 부족 시 강화 불가
        if (playerGold < nextUpgrade.cost)
        {
            Debug.Log("골드가 부족합니다.");
            return;
        }

        // 강화 진행 (골드 차감 및 레벨 증가)
        playerGold -= nextUpgrade.cost;
        currentLevel++;

        UpdateUI(); // UI 업데이트
    }


    private void UpdateUI()
    {
        ItemData currentItem = itemList[selectedItemIndex]; // 선택한 아이템 데이터 가져오기
        ItemUpgrade currentUpgrade = currentItem.upgrades[currentLevel]; //현재 아이템 레벨 데이터 가지고오기

        // UI 반영
        itemIcon.sprite = currentItem.itemIcon;
        itemNameText.text = currentItem.itemName;
        itemLevelText.text = $"Lv. {currentUpgrade.level}";
        damageText.text = $"공격력: {currentUpgrade.damage}";
        criticalText.text = $"크리티컬 확률: {currentUpgrade.criticalRate}%";

        // 다음 강화 비용 표시 (최대 레벨이면 "최대 레벨" 표시)
        upgradeCostText.text = (currentLevel < currentItem.upgrades.Length - 1)
            ? $"강화 비용: {currentItem.upgrades[currentLevel + 1].cost}G"
            : "최대 레벨";

        // 최대 레벨 도달 시 강화 버튼 비활성화
        upgradeButton.interactable = currentLevel < currentItem.upgrades.Length - 1;
    }

}


