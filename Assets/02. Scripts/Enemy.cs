using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; // ������ �� ������
    public Image healthBar; // ���߰� �ø� ü�¹�
    public Image enemyImage; // ǥ���� �� ��������Ʈ

    public int maxHealth; //�ִ� ü��
    public int currentHealth; //���� ü��

    public EnemyType enemyType; //����� ���������� Ȯ���Ϸ��� �������� �ʵ�

    [Header ("�������� ����")]
    public int index; //�������� ������ ������ ���� ��
    public StageManager stageManager; //���� �ְ� �� ���������Ŵ���

    //�̺�Ʈ �ν��Ͻ� ����


    public void Start()
    {
        //�̺�Ʈ �ν��Ͻ� �Ҵ��ϱ�
        //�̺�Ʈ.+=Damaged //Ŭ�� �̺�Ʈ�� ���� �޼��� �߰��ϱ�
        //ġ��Ÿ �̺�Ʈ.+=CritDamaged //Ŭ�� �̺�Ʈ(ġ��Ÿ)�� ġ��Ÿ �޼��� �߰��ϱ�
    }

    /// <summary>
    /// ������ �޾��� �� ȣ��� �޼���
    /// </summary>
    public void Damaged()
    {
        //0�� �ӽ÷� �Ҵ��� ���Դϴ�.
        int value=1; // ���ӸŴ������� ���� �������� ������ �� (GameManager.Instance.CalculateDamage()...)
        currentHealth -= value; //�� ����ŭ ü�� ����
        if (currentHealth <= 0)
        {
            Die();
        }

        //���� ���� ���; ���� ������ ǥ���ϱ�

        UpdateHealth(); //���� ü�� ���� ����
    }

    /// <summary>
    /// ġ��Ÿ ������ �޾��� �� ȣ��� �޼���
    /// </summary>
    public void CritDamaged()
    {
        //0�� �ӽ÷� �Ҵ��� ���Դϴ�.
        int value = 0; // ���ӸŴ������� ���� �������� ������ �� (GameManager.Instance.CalculateDamage()...)
        //value�� ġ��Ÿ ���ط��� ���� ��

        currentHealth -= value; //�� ����ŭ ü�� ����
        if (currentHealth <= 0)
        {
            Die();
        }

        //���� ���� ���; ���� ������ ǥ���ϱ�

        UpdateHealth(); //���� ü�� ���� ����
    }

    /// <summary>
    /// EnemyData���� ���� �ҷ��� �Ҵ��ϴ� �޼���
    /// </summary>
    public void SetEnemyData()
    {
        //��ü�� �� ���� �ʱ�ȭ
        enemyImage.sprite = enemyData.icon;
        maxHealth = enemyData.health;
        currentHealth = enemyData.health;
        enemyType= enemyData.enemyType;

        //����, ����� ����ŭ ü�� ���� ����
        UpdateHealth();
    }

    /// <summary>
    /// ü���� 0�϶� ȣ���� ��� �޼���
    /// </summary>
    public void Die()
    {
        Debug.Log("�׾����ϴ�.");
        this.gameObject.SetActive(false); //������Ʈ�� ����
        //���� ����(�ʿ��ϴٸ�);
    }

    /// <summary>
    /// ���� ü�� ������ ��ȯ�ϴ� �޼���
    /// </summary>
    /// <returns></returns>
    public void UpdateHealth()
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

}
