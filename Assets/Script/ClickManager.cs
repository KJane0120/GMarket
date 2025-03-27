using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    public bool isGamePaused = false; // 게임 일시 정지 상태 체크

    void Update()
    {
        // 게임이 일시 정지 상태라면 클릭 무시
        if (isGamePaused) return;

        // 마우스 클릭 감지 (터치 이벤트도 동일하게 처리)
        if (Input.GetMouseButtonDown(0))
        {
            // UI 클릭 시 무시
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Debug.Log("클릭 발생!");
        }
    }
}
