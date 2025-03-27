using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public Player player;
    public PlayerStat playerStat;

    public TMP_Text attackText;
    public TMP_Text goldText;
    public TMP_Text costText;

    void Start()
    {
        UpdateUI();
    }

    public void OnUpgradeButtonClick()
    {
        playerStat.UpgradeAttack();
        UpdateUI();
    }

    void UpdateUI()
    {
        attackText.text = $"{playerStat.attackBonus}"; // ���ݷ�
        goldText.text = $"{player.gold}"; // ���
        costText.text = $"{playerStat.upgradeGold}"; // ���׷��̵� ���
    }
}
