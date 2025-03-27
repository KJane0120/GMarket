using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]

public class PlayerStat : ScriptableObject
{
    Player player;

    // ���⿡ �ִ� ���ݷ� �� ġ��ŸȮ���� ����

    public int attackBonus = 1;             // ���ݷ�
    //public int criticalBonus = 0;           // ġ��Ÿ ������
    //public int criticalChanceBonus = 0;     // ġ��Ÿ Ȯ��
    //public int goldChanceBonus = 0;         // ���ȹ�淮
    //public int autoClickBonus = 0;          // �ڵ�Ŭ��Ƚ��

    public int upgradeGold = 5; // �ӽ� �ʱⰭȭ���

    // �����ۺ��� �߰� ���� ©��, AddAttack / SubtractAttack �̷�������
    // �����ۺ��� ������ ��ȭ ��ŭ �����ɰ���, ���׷��̵� �ϸ鼭 ��ŭ �ɰ����� �߰�

    public void UpgradeAttack()
    {
        if (player.gold >= upgradeGold)
        {
            player.gold -= upgradeGold; // ��� ����
            attackBonus += 1; // ���ݷ� ����
            upgradeGold = Mathf.RoundToInt(upgradeGold * 1.2f); // ��ȭ ��� 20% ����
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }

    //public void IncreaseStat(string statName, int amount)
    //{
    //    if (statName == "Attack") attackBonus += amount;
    //}
}
