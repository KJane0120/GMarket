using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUpgrade : MonoBehaviour
{
    public Player player;
    public PlayerStat playerStat;
    public AddStatValue addStat;

    public TMP_Text goldText;
    public TMP_Text curStatText;
    public TMP_Text upStatText;
    public TMP_Text upGoldText;
    //public TMP_Text totalText; - 추후 토탈스탯 관리하는쪽으로 이동예정

    private bool isHolding = false;
    public float repeatRate = 0.2f;
    private Coroutine upgradeCoroutine;


    void Start()
    {
        player.UpdateTotal();
        UpdateUI();
    }

    /// <summary>
    /// 스탯 강화
    /// </summary>
    public void UpgradeClick()
    {
        int gold = playerStat.upgradeGold; // 강화 비용 가져오기

        // player.gold 이부분 나중에 playerData에 있는걸로 가져오기
        if (player.gold >= gold)
        {
            player.gold -= gold;            // 골드 차감
            playerStat.UpgradeBonus();      // 보너스 스탯증가
            player.UpdateTotal();           // 토탈 스탯
            UpdateUI();
        }
        else
        {
            // 추후 ui부분 넣기
            Debug.Log("골드오링");
        }
    }

    /// <summary>
    /// UI 업데이트
    /// </summary>
    void UpdateUI()
    {
        goldText.text = $"{player.gold}";                       // 보유골드- 나중에 다른곳으로 빼기
        curStatText.text = $"{playerStat.stat.statValue}";      // 현 스탯
        upStatText.text = $"{playerStat.addStat.bonusValue}";   // 보너스 스탯
        upGoldText.text = $"{playerStat.upgradeGold}";          // 업그레이드 골드
        //totalText.text = $"+{player.totalCritical}%";          // 합산 치명타 스탯, 다른 스탯도 동일하게 - 추후 토탈스탯 관리하는쪽으로 이동예정
    }

    // 버튼 이벤트트리거 - 누르는 순간 실행
    public void OnButtonDown()
    {
        if (upgradeCoroutine == null) // 실행중일경우 중복실행 방지
        {
            isHolding = true;
            upgradeCoroutine = StartCoroutine(UpgradeLoop()); // 코루틴 시작
        }
    }

    // 버튼 이벤트트리거 - 떼는 순간 실행
    public void OnButtonUp()
    {
        isHolding = false; // false로 변경
        if (upgradeCoroutine != null) // 실행중인 코루틴이 있으면
        {
            StopCoroutine(upgradeCoroutine); // 코루틴 중지
            upgradeCoroutine = null; // 변수 초기화
        }
    }

    // 반복실행
    private IEnumerator UpgradeLoop()
    {
        while (isHolding) // 버튼을 누르고있는동안 실행
        {
            UpgradeClick();
            yield return new WaitForSeconds(repeatRate); // 일정시간 기다림
        }
    }
}
