using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Object Asset/PlayerStat")]

public class Player : MonoBehaviour
{
    // �̱���ó�� �ϱ�

    public PlayerStat playerStat; // ScriptableObject ����

    // ������ �⺻������ ���ӸŴ������� �������� ����, ��ȭ�� ���ӸŴ���, ���� ��ġ�������� ���� �޼��� ����� �������� ���ӸŴ����� ���� �ϰ� �����
    public int attack;              // ���ݷ�
    public int critical;            // ġ��Ÿ ������
    public int criticalChance;      // ġ��Ÿ Ȯ��
    public int goldChance;          // ���ȹ�淮
    public int autoClick;           // �ڵ�Ŭ�� > Ŭ���̺�Ʈ ��� ��������

    public int gold = 10000;

    // �������� > ���ӸŴ���
    // ���⺯��

    //void Start()
    //{
          // �÷��̾���� ��������
    //    UpgradeStat();
    //}

    //public void UpgradeStat()
    //{
    //    int totalAttack = attack + playerStat.attackBonus;

    //    Debug.Log($"���� ���ݷ�: {totalAttack}");
    //}
}
