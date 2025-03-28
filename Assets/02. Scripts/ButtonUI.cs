using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private Button newStartBtn;
    [SerializeField] private Button continueBtn;

    private void Start()
    {
        Debug.Log("이벤트 등록 완료");
        newStartBtn.onClick.AddListener(OnClickNewStartBtn);
        continueBtn.onClick.AddListener(OnClickContinueBtn);
    }
    public void OnClickNewStartBtn()
    {
        //초기값으로 데이터 초기화
        Debug.Log("시작하기");
        SceneManager.LoadScene("GMScene");
    }

    public void OnClickContinueBtn()
    {
        //저장된 데이터 로드
        Debug.Log("계속하기");
        SceneManager.LoadScene("GMScene");
    }
}
