using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    public InteractUI interactUI;
    public ButtonUI buttonUI;

    [Header("Components")]
    public GameObject ErrorMsg;
    public TextMeshProUGUI ErrorMsgText;
    public GameObject PausePopup;
    [SerializeField] private GameObject statGold;
    [SerializeField] private GameObject weaponGold;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject startUI;


    private void Awake()
    {
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
    }

    private void Start()
    {
        interactUI = GetComponentInChildren<InteractUI>(true);
        ErrorMsg = GetComponentInChildren<InteractUI>(true).gameObject;
        ErrorMsgText = ErrorMsg.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
        PausePopup = GetComponentInChildren<SoundUI>(true).gameObject;
    }

    public void StatsErrorMsg()
    {
        ErrorMsgText.text = "골드가 부족합니다.";
        StartCoroutine(interactUI.FadeOutErrorMsg());
    }

    public void WeaponErrorMsg()
    {
        ErrorMsgText.text = "포인트가 부족합니다.";
        StartCoroutine(interactUI.FadeOutErrorMsg());
    }

    public void StartSceneLoadInit()
    {
        statGold.SetActive(false);
        weaponGold.SetActive(false);
        pauseBtn.SetActive(false);
        startUI.SetActive(true);
    }

    public void MainSceneLoadInit()
    {
        statGold.SetActive(true);
        weaponGold.SetActive(true);
        pauseBtn.SetActive(true);
        startUI.SetActive(false);
    }
}
