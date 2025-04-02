using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �� ����
//�������� ����� StageManager���� ó���� ��
public enum EnemyType
{
    Normal, //1+���������� 0.25�踸ŭ�� ü�¿� ���ϱ�
    Elite, //1+���������� 0.5�踸ŭ ü�¿� ���ϱ�
    Boss, //1+���������� 1�踸ŭ ü�¿� ���ϱ�
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
