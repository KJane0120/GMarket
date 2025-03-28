using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("StageManager").AddComponent<StageManager>();
            }
            return instance;
        }

    }

    public Enemy[] enemy; //적 객체가 담겨지게 될 배열
    public Transform enemies; //enemy가 담긴 부모 클래스

    //게임매니저 클래스;
    //



    [Header("적 데이터")]
    public EnemyData[] enemydataTable; //적 데이터가 담겨있을 배열
    public int currentEnemyIndex; //현재 적이 몇 번째 적인지를 확인할 필드

    private void Awake()
    {
        //싱글톤
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

        //만약 적 클래스가 담긴 부모 객체가 없다면 찾아온 뒤 할당하고
        if (enemies == null)
        {
            GameObject go = GameObject.Find("Stage").transform.Find("Enemies").gameObject;
            enemies = go.GetComponent<RectTransform>();
        }
        //만약 적 데이터 테이블이 없다면
        if (enemydataTable == null)
        {
            //Resources 폴더 안 EnemyData 안의 모든 EnemyData 클래스를 불러온 뒤 할당하기
            enemydataTable = Resources.LoadAll<EnemyData>("EnemyData");
        }
    }

    void Start()
    {

        //enemies에 담긴 객체만큼 배열 길이를 정한 뒤 반복문 시작
        enemy = new Enemy[enemies.childCount];
        for (int i=0;i<enemy.Length; i++)
        {
            enemy[i] = enemies.GetChild(i).GetComponent<Enemy>(); //객체 안에서 enemy 클래스를 찾아 지정하고 
            enemy[i].index = i; //고유 식별값을 지정한 뒤
            if (enemy[i].stageManager == null)
            {
                enemy[i].stageManager = this; //해당 객체가 이 객체를 참조할 수 있게 하기
            }
        }

        NextStage(); //이후 적 초기화
    }

    /// <summary>
    /// 적들을 전부 초기화한 뒤 값을 재설정하는 메서드
    /// </summary>
    public void NextStage()
    {
        //게임매니저의 스테이지를 올리고 (GameManager.instance.stage++);
        //적 데이터테이블 안에서 무작위 데이터를 가져온 다음 다음 스테이지의 적 데이터로 저장
        EnemyData desiredEnemy = enemydataTable[Random.Range(0,enemydataTable.Length)];

        currentEnemyIndex = 0;

        for (int i = 0; i < enemy.Length; i++)
        {
            //혹시라도 객체가 켜져있다면 꺼두고
            if (enemy[i].gameObject.activeInHierarchy == true)
            {
                enemy[i].gameObject.SetActive(false);
            }
            //이후 순서에 따른 적 구분 (5번째에 엘리트, 10번째에 보스, 그 외는 전부 일반)
            switch(enemy[i].index)
            {
                case 3:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+0.5*현재 스테이지
                    enemy[i].currentHealth *= 1;//+0.5*현재 스테이지
                    enemy[i].enemyData.enemyType = EnemyType.Elite;
                    break;

                case 8:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+현재 스테이지
                    enemy[i].currentHealth *= 1;//+현재 스테이지
                    enemy[i].enemyData.enemyType = EnemyType.Boss;
                    break;

                default:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth *= 1;//+0.25*현재 스테이지
                    enemy[i].currentHealth *= 1;//+0.25*현재 스테이지
                    enemy[i].enemyData.enemyType = EnemyType.Normal;
                    break;
            }
            //그리고 만약 적의 순서가 0번(맨 처음) 이라면 활성화시키기 
            if (enemy[i].index == currentEnemyIndex)
            {
                enemy[i].gameObject.SetActive(true);
            }
        }
    }

    public void NextEnemy()
    {
        currentEnemyIndex++;
        enemy[currentEnemyIndex].gameObject.SetActive(true);
    }


}
