using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �� ����
//�������� ����� StageManager���� ó���� ��
public enum EnemyType
{
    Normal, //���������� 0.5�踸ŭ�� ü�¿� ���ϱ�
    Elite, //���������� 1�踸ŭ ü�¿� ���ϱ�
    Boss, //���������� 2�踸ŭ ü�¿� ���ϱ�
}

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Info")]
    public Sprite icon; // �� ������
    public int health; // �� ü��
    public EnemyType enemyType;


    [Header("Resources")]
    public int StatsGoldOnHit; //�ǰݽ� ��� ���� ��ȭ

    public int WeaponGoldOnKill; // ������� �� ��� ���� ��ȭ
    public int StatsGoldOnKill; // ������� �� ��� ���� ��ȭ
}
