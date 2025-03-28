using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Stage : MonoBehaviour
{
    public Enemy[] enemy; //�� ��ü�� ������� �� �迭
    public Transform enemies; //enemy�� ��� �θ� Ŭ����

    //���ӸŴ��� Ŭ����;
    //



    [Header("�� ������")]
    public EnemyData[] enemydataTable; //�� �����Ͱ� ������� �迭
    public int currentEnemyIndex; //���� ���� �� ��° �������� Ȯ���� �ʵ�


    void Start()
    {

        //enemies�� ��� ��ü��ŭ �迭 ���̸� ���� �� �ݺ��� ����
        enemy = new Enemy[enemies.childCount];
        for (int i=0;i<enemy.Length; i++)
        {
            enemy[i] = enemies.GetChild(i).GetComponent<Enemy>(); //��ü �ȿ��� enemy Ŭ������ ã�� �����ϰ� 
            enemy[i].index = i; //���� �ĺ����� ������ ��
            enemy[i].stageManager = this; //�ش� ��ü�� �� ��ü�� ������ �� �ְ� �ϱ�
        }

        NextStage(); //���� �� �ʱ�ȭ
    }

    /// <summary>
    /// ������ ���� �ʱ�ȭ�� �� 
    /// </summary>
    public void NextStage()
    {
        //���ӸŴ����� ���������� �ø��� (GameManager.instance.stage++);
        //�� ���������̺� �ȿ��� ������ �����͸� ������ ���� ���� ���������� �� �����ͷ� ����
        EnemyData desiredEnemy = enemydataTable[Random.Range(0,enemydataTable.Length)];

        currentEnemyIndex = 0;

        for (int i = 0; i < enemy.Length; i++)
        {
            //Ȥ�ö� ��ü�� �����ִٸ� ���ΰ�
            if (enemy[i].gameObject.activeInHierarchy == true)
            {
                enemy[i].gameObject.SetActive(false);
            }
            //���� ������ ���� �� ���� (5��°�� ����Ʈ, 10��°�� ����, �� �ܴ� ���� �Ϲ�)
            switch(enemy[i].index)
            {
                case 3:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+0.5*���� ��������
                    enemy[i].currentHealth *= 1;//+0.5*���� ��������
                    enemy[i].enemyData.enemyType = EnemyType.Elite;
                    break;

                case 8:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+���� ��������
                    enemy[i].currentHealth *= 1;//+���� ��������
                    enemy[i].enemyData.enemyType = EnemyType.Boss;
                    break;

                default:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+0.25*���� ��������
                    enemy[i].currentHealth *= 1;//+0.25*���� ��������
                    enemy[i].enemyData.enemyType = EnemyType.Normal;
                    break;
            }
            //�׸��� ���� ���� ������ 0��(�� ó��) �̶�� Ȱ��ȭ��Ű�� 
            if (enemy[i].index == currentEnemyIndex)
            {
                enemy[i].gameObject.SetActive(true);
            }
        }
    }

    //public void Modify

}
