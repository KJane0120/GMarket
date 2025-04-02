using TMPro;
using UnityEngine;

/// <summary>
/// 플레이어의 재화를 관리하는 클래스입니다.
/// </summary>
public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance { get { return instance; } }

    public CurrencyController controller;

    [Header("UI")]
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

    /// <summary>
    /// UI를 업데이트합니다.
    /// </summary>
    public void UpdateUI()
    {
        if (statGoldText != null)
        {
            statGoldText.text = string.Format("{0}", GameManager.Instance.PlayerData.StatGold);
        }
        else
        {
            Debug.Log("스탯골드텍스트가 할당되어 있지 않습니다.");
        }
        if (weaponGoldText != null)
        {
            weaponGoldText.text = string.Format("{0}", GameManager.Instance.PlayerData.WeaponGold);
        }
        else
        {
            Debug.Log("웨폰골드텍스트가 할당되어 있지 않습니다.");
        }
    }
}
