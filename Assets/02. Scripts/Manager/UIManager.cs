using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private Image fadePanel;
    private float fadeDuration = 1.0f;


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

    /// <summary>
    /// 스탯강화 실패 시 에러메세지를 표시합니다. 
    /// </summary>
    public void StatsErrorMsg()
    {
        ErrorMsgText.text = "골드가 부족합니다.";
        StartCoroutine(interactUI.FadeOutErrorMsg());
    }

    /// <summary>
    /// 무기강화 실패 시 에러메세지를 표시합니다.
    /// </summary>
    public void WeaponErrorMsg()
    {
        ErrorMsgText.text = "포인트가 부족합니다.";
        StartCoroutine(interactUI.FadeOutErrorMsg());
    }

    /// <summary>
    /// 시작씬이 로드될 때 UI를 초기화합니다.
    /// </summary>
    public void StartSceneLoadInit()
    {
        statGold.SetActive(false);
        weaponGold.SetActive(false);
        pauseBtn.SetActive(false);
        startUI.SetActive(true);
    }
    /// <summary>
    /// 메인씬이 로드될 때 UI를 초기화합니다. 
    /// </summary>
    public void MainSceneLoadInit()
    {
        statGold.SetActive(true);
        weaponGold.SetActive(true);
        pauseBtn.SetActive(true);
        startUI.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t >= 0)
        {
            t -= Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
    }

    private IEnumerator FadeIn(Action init)
    {
        init?.Invoke();
        float t = fadeDuration;
        while (t >= 0)
        {
            t -= Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut(string ScneneName)
    {
        fadePanel.gameObject.SetActive(true);

        float t = 0;
        while (t <= fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        SceneManager.LoadScene(ScneneName);
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut(string ScneneName, Action init)
    {
        fadePanel.gameObject.SetActive(true);

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        SceneManager.LoadScene(ScneneName);
        StartCoroutine(FadeIn(init));
    }
}
