using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    //    - 재화의 획득과 사용을 관리하고, 화면에 보유중인 재화를 표시합니다.
    //- 상호작용에 필요한 재화가 부족한 경우 경고 메세지를 표시한 후, 잠시 후 사라지도록 합니다.

    public int statGold; 
    public int weaponGold;
    public int atkPower;

    private int maxHealth; // Enemy.maxHealth 연결
    private int currentHealth; //Enemy.currentHealth 연결

    private void Start()
    {
        atkPower = GameManager.Instance.PlayerData.TotalAttackPower; //플레이어 공격력 받아옴
    }


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

        if (currentHealth - atkPower > 0)
        {
            statGold += StatsGoldOnHit;
        }
        else
        {
            Debug.Log("적을 처치했습니다."); // 추후 적 처치시 재화 획득 함수 호출?
            return;
        }
    }


    public void StatGoldUse(int value)
    {

    }



}
