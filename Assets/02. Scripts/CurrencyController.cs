using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public int statGold;
    public int weaponGold;

    private int maxHealth; // Enemy.maxHealth 연결
    private int currentHealth; //Enemy.currentHealth 연결


    /// <summary>
    /// 적 처치 시 재화를 획득합니다. 
    /// </summary>
    /// <param name="StatsGoldOnKill"></param>
    /// <param name="weaponGoldOnKill"></param>
    public void CurrencyGainKill(int StatsGoldOnKill, int weaponGoldOnKill)
    {
        statGold += StatsGoldOnKill;
        weaponGold += weaponGoldOnKill;
    }

    /// <summary>
    /// 적 타격 시마다 스탯재화를 획득합니다. 
    /// </summary>
    /// <param name="StatsGoldOnHit"></param>
    public void StatGoldGain(int StatsGoldOnHit)
    {
        if (currentHealth == maxHealth) return; //안 때린 상태라면 호출x

        if (currentHealth > 0)
        {
            statGold += StatsGoldOnHit;
        }
        else
        {
            Debug.Log("적을 처치했습니다."); // 추후 적 처치시 재화 획득 함수 호출?
            return;
        }
    }

    public void StatGoldUse(int upgradeGold) //호출은 CurrencyManager.Instance.controller.StatGoldUse로 해주시면 됩니다.
    {
        if (statGold >= upgradeGold)
        {
            statGold -= upgradeGold;
        }
        else
            UIManager.Instance.StatsErrorMsg(); //에러 메세지 표시
    }


    public void WeaponGoldUse(int upgradeGold) //호출은 CurrencyManager.Instance.controller.WeaponGoldUse 해주시면 됩니다.
    {
        if (weaponGold >= upgradeGold)
        {
            weaponGold -= upgradeGold;
        }
        else
            UIManager.Instance.WeaponErrorMsg(); //에러 메세지 표시
    }
}
