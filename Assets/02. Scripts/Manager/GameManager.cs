using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        PlayerData = new PlayerData();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;

        //나중에 사용자가 직접 프레임 속도를 조절하는 기능을 추가할 경우
        //QualitySettings.vSyncCount = 0;  // VSync 끄기

        //int targetFPS = PlayerPrefs.GetInt("TargetFPS", 60); // 저장된 FPS 불러오기 (기본값 60)
        //Application.targetFrameRate = targetFPS;
    }

    private void Start()
    {
        SetData();
    }

    private void SetData() // 데이터 초기화 
    {
        PlayerData.NowStage = 1;

        PlayerData.StatGold = 0;
        PlayerData.WeaponGold = 0;

        PlayerData.CriticalDamageLevel = 0;
        PlayerData.AutoAttackLevel = 0;
        PlayerData.GoldGainLevel = 0;
    }
}
