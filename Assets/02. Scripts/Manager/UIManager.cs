using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    public InteractUI interactUI;

    public GameObject errorMsg;

    public TextMeshProUGUI ErrorMsgText;

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
        errorMsg = GetComponentInChildren<InteractUI>(true).gameObject;
        ErrorMsgText = interactUI.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);

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
