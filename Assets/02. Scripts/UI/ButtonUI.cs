using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 버튼을 관리하는 클래스입니다.
/// </summary>
public class ButtonUI : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button StartBtn;
    [SerializeField] private Button QuitBtn; //게임종료 버튼
    [SerializeField] private Button pauseButton; //일시정지 버튼
    [SerializeField] private Button continueButton; //계속하기 버튼
    [SerializeField] private Button exitButton; //메인씬에서 나가기 버튼
    [SerializeField] private Button inventoryBtn; // 무기관리 버튼

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 버튼 클릭시 실행되는 함수를 등록합니다.  
    /// </summary>
    private void Init()
    {
        StartBtn.onClick.AddListener(OnClickNewStartBtn);
        pauseButton.onClick.AddListener(OnClickPauseBtn);
        continueButton.onClick.AddListener(OnClickMainContinueBtn);
        exitButton.onClick.AddListener(OnClickExitBtn);
    }

    /// <summary>
    /// 시작씬에서 새로하기 버튼 클릭시 
    /// 저장된 데이터를 초기화 하고
    /// 초기값으로 게임을 시작합니다. 
    /// json 미구현 상태
    /// </summary>
    public void OnClickNewStartBtn()
    {
        StartCoroutine(UIManager.Instance.FadeOut("MainScene", UIManager.Instance.MainSceneLoadInit));
    }

    /// <summary>
    /// 일시정지 버튼 클릭시 호출되는 함수입니다.
    /// 옵션창을 띄웁니다. 
    /// </summary>
    public void OnClickPauseBtn()
    {
        Time.timeScale = 0.0f;
        UIManager.Instance.PausePopup.SetActive(true);
    }

    /// <summary>
    /// 게임씬 옵션 창에서 계속하기 버튼 클릭시 호출되는 함수
    /// </summary>
    public void OnClickMainContinueBtn() 
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.PausePopup.SetActive(false);
    }

    /// <summary>
    /// 옵션창에서 나가기 버튼 클릭 시
    /// 시작화면으로 돌아갑니다.
    /// </summary>
    public void OnClickExitBtn()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.PausePopup.SetActive(false);
        StartCoroutine(UIManager.Instance.FadeOut("StartScene", UIManager.Instance.StartSceneLoadInit));
    }

    /// <summary>
    /// 메인 씬에서 게임 종료 버튼 클릭 시 호출됩니다.
    /// 애플리케이션을 종료합니다.
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
