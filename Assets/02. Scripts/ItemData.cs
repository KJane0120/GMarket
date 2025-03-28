using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Items/StatItem")] //ItemData�� ������ �߰� ����
public class ItemData : ScriptableObject
{
    public string itemName; //������ �̸�
    public Sprite itemIcon; //���� ������UI
    //public ItemUpgrade[] upgrades; // ���� ��ȭ �ܰ躰 ������ (�迭)

}

[System.Serializable]  // ���� ��ȭ ������
public class ItemUpgrade
{
    public int level;         // ��ȭ ����
    public int cost;          // ��ȭ ��� (�ʿ��� ���)
    public int damageUp;        // ���ݷ� ����
    public int criticalRate;  // ũ��Ƽ�� Ȯ�� ����
}
