using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    /// <summary>
    /// 적 처치 시 재화를 획득합니다. 
    /// </summary>
    /// <param name="StatsGoldOnKill"></param>
    /// <param name="weaponGoldOnKill"></param>
    public void CurrencyGainKill(int StatsGoldOnKill, int weaponGoldOnKill)
    {
        GameManager.Instance.PlayerData.StatGold += StatsGoldOnKill;
        GameManager.Instance.PlayerData.WeaponGold += weaponGoldOnKill;
    }

    /// <summary>
    /// 적 타격 시마다 스탯재화를 획득합니다. 
    /// </summary>
    /// <param name="StatsGoldOnHit"></param>
    public void StatGoldGain(int StatsGoldOnHit)//호출은 CurrencyManager.Instance.controller.StatGoldGain으로 해주시면 됩니다.
    {
        GameManager.Instance.PlayerData.StatGold += StatsGoldOnHit;
    }

    /// <summary>
    /// 스탯재화를 사용할 때 사용하는 함수입니다.
    /// </summary>
    /// <param name="upgradeGold"></param>
    public void StatGoldUse(int upgradeGold)
    {
        GameManager.Instance.PlayerData.StatGold -= upgradeGold;
    }

    /// <summary>
    /// 무기재화를 사용할 때 사용하는 함수입니다.
    /// </summary>
    /// <param name="upgradeGold"></param>
    public void WeaponGoldUse(int upgradeGold)
    {
        GameManager.Instance.PlayerData.WeaponGold -= upgradeGold;
    }
}
