using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour
{
    public bool isGamePaused = false; // ���� �Ͻ� ���� ���� üũ

    public int autoAttackLevel = 1; // �ڵ� ���� ����
    public float baseAutoAttackInterval = 1.0f; // �⺻ �ڵ� ���� ����
    private Coroutine autoAttackCoroutine;

    private bool isClicking = false; // Ŭ�� ���� ���� ����

    void Start()
    {
        StartAutoAttack(); // �ڵ� ���� ����
    }

    void Update()
    {
        if (isGamePaused) return; // ������ �Ͻ� ���� ���¶�� Ŭ�� ����

        if (Input.GetMouseButtonDown(0) && !isClicking) // ���콺 ��Ŭ�� ���� �� �ߺ� ����
        {
            isClicking = true; // Ŭ�� ���� Ȱ��ȭ
            Debug.Log("Ŭ�� �߻�!");
            OnAttack(); // Ŭ�� �� ��� ���� ����
        }

        if (Input.GetMouseButtonUp(0)) // ���콺 ��ư�� ���� �� Ŭ�� ���� ����
        {
            isClicking = false; // Ŭ�� ���� ��Ȱ��ȭ
        }
    }

    public void StartAutoAttack()
    {
        if (autoAttackCoroutine != null) StopCoroutine(autoAttackCoroutine); // ���� �ڷ�ƾ ����
        autoAttackCoroutine = StartCoroutine(AutoAttack()); // ���ο� �ڷ�ƾ ����
    }

    IEnumerator AutoAttack()
    {
        while (true) // ���� ���� ����
        {
            if (!isGamePaused) OnAttack(); // ������ ���� ���°� �ƴϸ� �ڵ� ���� ����

            float attackInterval = baseAutoAttackInterval / autoAttackLevel; // �ڵ� ���� ������ ���� ���� ����
            yield return new WaitForSeconds(attackInterval); // ���� ���� ��� �� �ٽ� ����
        }
    }

    void OnAttack()
    {
        Debug.Log("���� �߻�!"); // ���� �߻� �� �ܼ� ���
        // ���⿡ ������, �ִϸ��̼� �� �߰� ����
    }

    public void LevelUp()
    {
        autoAttackLevel++; // �ڵ� ���� ���� ����
        Debug.Log($"�ڵ� ���� ���� ��! ���� ����: {autoAttackLevel}");
        StartAutoAttack(); // ���� �� �� ���ο� �ӵ��� �ڵ� ���� �����
    }
}
