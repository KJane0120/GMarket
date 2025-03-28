using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; // 참조할 적 데이터
    public Image healthBar; // 낮추고 올릴 체력바
    public Image enemyImage; // 표시할 적 스프라이트

    public int maxHealth; //최대 체력
    public int currentHealth; //현재 체력

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
    public void Damaged()
    {
        //0은 임시로 할당한 값입니다.
        int value=1; // 게임매니저에서 공격 데미지를 가져온 뒤 (GameManager.Instance.CalculateDamage()...)
        currentHealth -= value; //그 값만큼 체력 감소
        if (currentHealth <= 0)
        {
            Die();
        }

        //도전 구현 기능; 입은 데미지 표시하기

        UpdateHealth(); //이후 체력 비율 조정
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
        //보상 지급(필요하다면);
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
