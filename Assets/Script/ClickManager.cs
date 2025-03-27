using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    public bool isGamePaused = false; // ���� �Ͻ� ���� ���� üũ

    void Update()
    {
        // ������ �Ͻ� ���� ���¶�� Ŭ�� ����
        if (isGamePaused) return;

        // ���콺 Ŭ�� ���� (��ġ �̺�Ʈ�� �����ϰ� ó��)
        if (Input.GetMouseButtonDown(0))
        {
            // UI Ŭ�� �� ����
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Debug.Log("Ŭ�� �߻�!");
        }
    }
}
