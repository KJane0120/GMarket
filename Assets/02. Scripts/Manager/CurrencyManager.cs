using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance { get { return instance; } }

    public CurrencyController controller;

    public TextMeshProUGUI statGoldText;
    public TextMeshProUGUI weaponGoldText;

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


    private void LateUpdate()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        statGoldText.text = string.Format("{0}", GameManager.Instance.PlayerData.StatGold);
        weaponGoldText.text = string.Format("{0}", GameManager.Instance.PlayerData.WeaponGold);
    }
}
