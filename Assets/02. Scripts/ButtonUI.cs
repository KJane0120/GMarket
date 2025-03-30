using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private Button newStartBtn;
    [SerializeField] private Button continueBtn; //시작씬에서 계속하기 버튼
    [SerializeField] private Button pauseButton; //일시정지 버튼
    [SerializeField] private Button continueButton; //메인씬에서 계속하기 버튼
    [SerializeField] private Button exitButton; //메인씬에서 나가기 버튼

    private void Start()
    {
        Debug.Log("이벤트 등록 완료");
        Init();
    }

    private void Init()
    {
        newStartBtn.onClick.AddListener(OnClickNewStartBtn);
        continueBtn.onClick.AddListener(OnClickContinueBtn);
        pauseButton.onClick.AddListener(OnClickPauseBtn);
        continueButton.onClick.AddListener(OnClickMainContinueBtn);
        exitButton.onClick.AddListener(OnClickExitBtn);
    }

    /// <summary>
    /// 시작씬에서 새로하기 버튼 클릭시 
    /// 저장된 데이터를 초기화 하고
    /// 초기값으로 게임을 시작합니다. 
    /// </summary>
    public void OnClickNewStartBtn()
    {
        //초기값으로 데이터 초기화
        Debug.Log("시작하기");
        UIManager.Instance.MainSceneLoadInit();
        SceneManager.LoadScene("GMScene");
    }

    /// <summary>
    /// 시작씬에서 계속하기 버튼 클릭시
    /// 저장된 데이터 상태로 이어서 할 수 있습니다. 
    /// </summary>
    public void OnClickContinueBtn()
    {
        //저장된 데이터 로드
        Debug.Log("계속하기");
        UIManager.Instance.MainSceneLoadInit();
        SceneManager.LoadScene("GMScene");
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

    public void OnClickExitBtn()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.PausePopup.SetActive(false);
        UIManager.Instance.StartSceneLoadInit();
        SceneManager.LoadScene("StartSampleScene");
    }
}
