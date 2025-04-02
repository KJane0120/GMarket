using UnityEngine;

/// <summary>
/// 게임의 전반적인 데이터를 관리하는 클래스입니다.
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [field: SerializeField]
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

    /// <summary>
    /// 게임 시작 시 데이터를 초기화합니다.
    /// </summary>
    private void SetData()
    {
        PlayerData.NowStage = 1;

        PlayerData.StatGold = 0;
        PlayerData.WeaponGold = 0;

        PlayerData.CriticalDamageLevel = 0;
        PlayerData.AutoAttackLevel = 0;
        PlayerData.GoldGainLevel = 0;

        PlayerData.inventory = ResourceManager.Instance.item.inventory;
    }
}
