using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance { get { return instance; } }

    public CurrencyController controller;

    public TextMeshProUGUI goldText;
    private int statGold;

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
        statGold = GameManager.Instance.PlayerData.StatGold;
    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        goldText.text = string.Format("{0}", statGold);
    }
}
