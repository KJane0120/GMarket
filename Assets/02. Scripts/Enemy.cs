using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; // 참조할 적 데이터
    public Image healthBar; // 낮추고 올릴 체력바
    public Image enemyImage; // 표시할 적 스프라이트

    public int maxHealth; //최대 체력
    public int currentHealth; //현재 체력

    public EnemyType enemyType; //제대로 들어와지는지 확인하려고 가져오는 필드

    [Header ("스테이지 변수")]
    public int index; //스테이지 내에서 지정된 고유 값
    public StageManager stageManager; //갖고 있게 될 스테이지매니저

    //이벤트 인스턴스 변수


    public void Start()
    {
        //이벤트 인스턴스 할당하기
        //이벤트.+=Damaged //클릭 이벤트에 공격 메서드 추가하기
        //치명타 이벤트.+=CritDamaged //클릭 이벤트(치명타)에 치명타 메서드 추가하기
    }

    /// <summary>
    /// 공격을 받았을 때 호출될 메서드
    /// </summary>
    public int Damaged()
    {
        //0은 임시로 할당한 값입니다.
        int value=750; // 게임매니저에서 공격 데미지를 가져온 뒤 (GameManager.Instance.CalculateDamage()...)
        currentHealth -= value; //그 값만큼 체력 감소
        if (currentHealth <= 0)
        {
            Die();
        }

        //도전 구현 기능; 입은 데미지 표시하기

        //CurrencyManager.Instance.controller.StatGoldGain(enemyData.StatsGoldOnHit * (int)(1 + 0.25 * GameManager.Instance.PlayerData.NowStage));

        UpdateHealth(); //이후 체력 비율 조정
        return value;
    }

    /// <summary>
    /// 치명타 공격을 받았을 때 호출될 메서드
    /// </summary>
    public void CritDamaged()
    {
        //0은 임시로 할당한 값입니다.
        int value = 0; // 게임매니저에서 공격 데미지를 가져온 뒤 (GameManager.Instance.CalculateDamage()...)
        //value에 치명타 피해량을 곱한 뒤

        currentHealth -= value; //그 값만큼 체력 감소
        if (currentHealth <= 0)
        {
            Die();
        }

        //도전 구현 기능; 입은 데미지 표시하기

        UpdateHealth(); //이후 체력 비율 조정
    }

    /// <summary>
    /// EnemyData에서 값을 불러와 할당하는 메서드
    /// </summary>
    public void SetEnemyData()
    {
        //객체의 값 전부 초기화
        enemyImage.sprite = enemyData.icon;
        maxHealth = enemyData.health;
        currentHealth = enemyData.health;
        enemyType= enemyData.enemyType;

        //이후, 변경된 값만큼 체력 비율 조정
        UpdateHealth();
    }

    /// <summary>
    /// 체력이 0일때 호출할 사망 메서드
    /// </summary>
    public void Die()
    {
        Debug.Log("죽었습니다.");
        this.gameObject.SetActive(false); //오브젝트를 끄고

        GameObject Doll= (GameObject)Resources.Load("RagdollEnemy");

        //데미지오브젝트를 StageManager 안에 복제한 뒤 해당 객체의 텍스트 내용을 damage 매개변수로 변경
        GameObject ragDoll = Instantiate(Doll, this.transform.position, Quaternion.identity, stageManager.transform);
        Enemy ragDollEnemy = ragDoll.GetComponent<Enemy>();
        ragDollEnemy.enemyData =this.enemyData;
        ragDollEnemy.enemyImage.sprite = ragDollEnemy.enemyData.icon;

        ragDoll.SetActive(true);
        Rigidbody2D rb = ragDoll.AddComponent<Rigidbody2D>();

        rb.gravityScale = 100f;

        //그리고 텍스트가 날아갈 무작위 방향 설정
        float randomX = Random.Range(-1f, 1f); // X축 방향 랜덤
        float randomY = Random.Range(0f, 1f); // Y축 방향 랜덤
        Vector2 pushDirection = new Vector2(randomX, randomY).normalized;

        //리지드바디 찾아서 힘만큼 AddForce
        rb.AddForce(pushDirection * 500, ForceMode2D.Impulse);

        //2.5초 뒤 삭제
        Destroy(ragDoll, 2.5f);

        stageManager.NextEnemy();
        //보상 지급(필요하다면);
        //int modifier=(int)(1 + 0.25 * GameManager.Instance.PlayerData.NowStage);
        //CurrencyManager.Instance.controller.CurrencyGainKill(enemyData.StatsGoldOnKill * modifier, enemyData.WeaponGoldOnKill*modifier);
    }

    /// <summary>
    /// 현재 체력 비율을 반환하는 메서드
    /// </summary>
    /// <returns></returns>
    public void UpdateHealth()
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

}
