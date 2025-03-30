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
    public Button newStartBtn;
    public Button continueBtn;

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
        interactUI = GetComponentInChildren<InteractUI>();
        ErrorMsg = GetComponentInChildren<InteractUI>(true).gameObject;
        ErrorMsgText = interactUI.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
        newStartBtn = buttonUI.gameObject.GetComponentInChildren<Button>();
        continueBtn = buttonUI.gameObject.GetComponentInChildren<Button>();
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
}
