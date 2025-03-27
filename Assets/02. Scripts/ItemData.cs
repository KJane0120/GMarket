using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Items/Stat Item")] //ItemData�� ������ �߰� ����
public class ItemData : ScriptableObject
{
    public string ItemName; //������ �̸�
    public Sprite ItemIcon; //���� ������UI
    public WeaponUpgrade[] upgrades; // ���� ��ȭ �ܰ躰 ������ (�迭)

}

[System.Serializable]  // ���� ��ȭ ������
public class WeaponUpgrade
{
    public int level;         // ��ȭ ����
    public int cost;          // ��ȭ ��� (�ʿ��� ���)
    public int damage;        // ���ݷ� ����
    public int criticalRate;  // ũ��Ƽ�� Ȯ�� ����
}
