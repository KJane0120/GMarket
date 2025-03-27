using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class ItemManager : MonoBehaviour
{
    public List<ItemData> itemList; //������ ����Ʈ
    public int selectedItemIndex = 0; // ���� ������ ������ �ε���
    private int currentLevel = 1;       // ���� ������ ��ȭ ����
    public int playerGold = 1000;       // ������ ��� - �ӽ�

    //UI ����
    public Image itemIcon; //������ ������
    public TextMeshProUGUI itemNameText; //������ �̸�
    public TextMeshProUGUI itemLevelText; //���� ��ȭ ����
    public TextMeshProUGUI damageText; //���ݷ�
    public TextMeshProUGUI criticalText; //ũ��Ƽ�� Ȯ��
    public TextMeshProUGUI upgradeCostText; //��ȭ ���
    public Button upgradeButton; //��ȭ ��ư

    private void Start()
    {
        UpdateUI(); // ���� ���� �� UI ������Ʈ
    }
    public void SelectItem(int index) //������ ���� = ���� ����Ʈ ��ġ
    {
        selectedItemIndex = index;
        currentLevel = 1; // ���ο� ���⸦ �����ϸ� ��ȭ ���� �ʱ�ȭ
        UpdateUI(); // UI ������Ʈ
    }

    // ���Ⱝȭ ���
    public void UpgradeItem()
    {
        ItemData currentItem = itemList[selectedItemIndex];

        // �ִ� ���� ���� �� ��ȭ �Ұ�
        if (currentLevel >= currentItem.upgrades.Length - 1)
        {
            Debug.Log("�ִ� ���� �Դϴ� ��ȭ �Ұ���.");
            return;
        }

        ItemUpgrade nextUpgrade = currentItem.upgrades[currentLevel + 1];

        // ���� ��� ���� �� ��ȭ �Ұ�
        if (playerGold < nextUpgrade.cost)
        {
            Debug.Log("��尡 �����մϴ�.");
            return;
        }

        // ��ȭ ���� (��� ���� �� ���� ����)
        playerGold -= nextUpgrade.cost;
        currentLevel++;

        UpdateUI(); // UI ������Ʈ
    }


    private void UpdateUI()
    {
        ItemData currentItem = itemList[selectedItemIndex]; // ������ ������ ������ ��������
        ItemUpgrade currentUpgrade = currentItem.upgrades[currentLevel]; //���� ������ ���� ������ ���������

        // UI �ݿ�
        itemIcon.sprite = currentItem.itemIcon;
        itemNameText.text = currentItem.itemName;
        itemLevelText.text = $"Lv. {currentUpgrade.level}";
        damageText.text = $"���ݷ�: {currentUpgrade.damage}";
        criticalText.text = $"ũ��Ƽ�� Ȯ��: {currentUpgrade.criticalRate}%";

        // ���� ��ȭ ��� ǥ�� (�ִ� �����̸� "�ִ� ����" ǥ��)
        upgradeCostText.text = (currentLevel < currentItem.upgrades.Length - 1)
            ? $"��ȭ ���: {currentItem.upgrades[currentLevel + 1].cost}G"
            : "�ִ� ����";

        // �ִ� ���� ���� �� ��ȭ ��ư ��Ȱ��ȭ
        upgradeButton.interactable = currentLevel < currentItem.upgrades.Length - 1;
    }

}


