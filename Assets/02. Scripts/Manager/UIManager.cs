using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// UI를 관리하는 클래스입니다.
/// </summary>
public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    public InteractUI interactUI;
    public ButtonUI buttonUI;
    public UISlot slot;

    [Header("Text")]
    public TextMeshProUGUI ErrorMsgText;
    [SerializeField] private TextMeshProUGUI statGoldTxt;
    [SerializeField] private TextMeshProUGUI weaponGoldTxt;

    [Header("GameObject")]
    public GameObject PausePopup;
    public GameObject inventoryPanel;
    public GameObject ItemUI;
    public GameObject currentWeaponWindow;
    public GameObject ErrorMsg;
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

    /// <summary>
    /// UI를 초기화합니다.
    /// </summary>
    private void Start()
    {
        interactUI = GetComponentInChildren<InteractUI>(true);
        ErrorMsg = GetComponentInChildren<InteractUI>(true).gameObject;
        ErrorMsgText = ErrorMsg.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
        PausePopup = GetComponentInChildren<SoundUI>(true).gameObject;
    }


    private void Update()
    {
        RefreshUI();
    }

    /// <summary>
    /// UI를 업데이트합니다.
    /// </summary>
    private void RefreshUI()
    {
        statGoldTxt.text = string.Format("{0}", GameManager.Instance.PlayerData.StatGold);
        weaponGoldTxt.text = string.Format("{0}", GameManager.Instance.PlayerData.WeaponGold);
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
        inventoryPanel.SetActive(false);
        currentWeaponWindow.SetActive(false);
        ItemUI.SetActive(false);
        PausePopup.SetActive(false);

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
        currentWeaponWindow.SetActive(true);
        ItemUI.SetActive(true);
    }

    /// <summary>
    /// 페이드인 효과를 줍니다.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 페이드인 효과를 줍니다.
    /// 오버로드 함수
    /// </summary>
    /// <param name="init"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 페이드아웃 효과를 줍니다.
    /// </summary>
    /// <param name="ScneneName"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 페이드아웃 효과를 줍니다.
    /// 오버로드 함수
    /// </summary>
    /// <param name="ScneneName"></param>
    /// <param name="init"></param>
    /// <returns></returns>
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
