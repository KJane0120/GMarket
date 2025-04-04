using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public float pushForce = 500f;
    public Enemy[] enemy; //적 객체가 담겨지게 될 배열
    public Transform enemies; //enemy가 담긴 부모 객체

    private ClickManager clickManager;
    public bool isCrit;

    [Header("적 데이터")]
    public EnemyData[] enemydataTable; //적 데이터가 담겨있을 배열
    public int currentEnemyIndex; //현재 적이 몇 번째 적인지를 확인할 필드

    [Header("UI")]
    public GameObject stageUI; //스테이지 데이터를 표시할 UI
    public GameObject damagePrefab; //인스턴시에이트 한 뒤 데미지를 표시할 텍스트 프리팹
    public TextMeshProUGUI stageText; //스테이지 UI에 표시할 텍스트
    public TextMeshProUGUI enemyText; //적 UI에 표시할 텍스트
    public SpriteRenderer backgroundImage;

    private void Awake()
    {
        //만약 적 클래스가 담긴 부모 객체가 없다면 찾아온 뒤 할당하고
        if (enemies == null)
        {
            enemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RectTransform>();
        }
        //만약 클릭매니저가 없다면 찾아온 뒤 할당하고
        if (clickManager == null)
        {
            clickManager = GameObject.Find("Click").GetComponent<ClickManager>();
        }
        //만약 적 데이터 테이블이 없다면
        if (enemydataTable == null)
        {
            //Resources 폴더 안 EnemyData 안의 모든 EnemyData 클래스를 불러온 뒤 할당하기
            enemydataTable = Resources.LoadAll<EnemyData>("EnemyData");
        }

        clickManager.onClick += AddDamage;

        //스테이지UI가 비어있다면
        if (stageUI == null)
        {
            //찾아서 할당
            stageUI = GameObject.Find("StageUI");
        }
        //스테이지UI가 비어있지 않은데 stageText와 enemyText가 비어있다면
        if (stageUI != null && (stageText == null && enemyText == null))
        {
            Debug.Log(stageUI.name);
            // stageUI 안에서 "StageText"와 "EnemyText"라는 이름의 자식 객체를 찾아 할당
            Transform stageTextTransform = stageUI.transform.Find("StageBox/StageText");
            Transform enemyTextTransform = stageUI.transform.Find("EnemyBox/EnemyText");

            if (stageTextTransform != null)
                stageText = stageTextTransform.GetComponent<TextMeshProUGUI>();

            if (enemyTextTransform != null)
                enemyText = enemyTextTransform.GetComponent<TextMeshProUGUI>();
        }


        //enemies에 담긴 객체만큼 배열 길이를 정한 뒤 반복문 시작
        enemy = new Enemy[enemies.childCount];
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = enemies.GetChild(i).GetComponent<Enemy>(); //객체 안에서 enemy 클래스를 찾아 지정하고 
            enemy[i].index = i; //고유 식별값을 지정한 뒤
            if (enemy[i].stageManager == null)
            {
                enemy[i].stageManager = this; //해당 객체가 이 객체를 참조할 수 있게 하기
            }
        }
        if (enemies.gameObject.activeInHierarchy == false)
        {
            ToggleEnemyGrid();
        }
    }
    void Start()
    {
        ResetEnemies(); //이후 적 초기화
        PlayerData.OnStageChanged += ChangeBackGround;

    }

    private void OnEnable()
    {
        UpdateUI();
    }

    /// <summary>
    /// 적 객체를 담아둔 그리드를 비활성화/활성화시키는 토글 메서드
    /// </summary>
    public void ToggleEnemyGrid()
    {
        enemies.gameObject.SetActive(!enemies.gameObject.activeInHierarchy);
    }

    public void ResetEnemies()
    {
        if (GameManager.Instance?.PlayerData == null)
        {
            Debug.Log("PlayerData가 없습니다!");
            return;
        }

        EnemyData desiredEnemy = enemydataTable[GameManager.Instance.PlayerData.NowStage % enemydataTable.Length];
        currentEnemyIndex = 0;

        for (int i = 0; i < enemy.Length; i++)
        {
            //혹시라도 객체가 켜져있다면 꺼두고
            if (enemy[i].gameObject.activeInHierarchy == true)
            {
                enemy[i].gameObject.SetActive(false);
            }
            //이후 순서에 따른 적 구분 (5번째에 엘리트, 10번째에 보스, 그 외는 전부 일반)
            switch (enemy[i].index)
            {
                case 4:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth = (int)(enemy[i].maxHealth * (1 + (0.5 * GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].currentHealth = (int)(enemy[i].currentHealth * (1 + (0.5 * GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].enemyType = EnemyType.Elite;
                    break;

                case 9:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth = (int)(enemy[i].maxHealth * (1 + (GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].currentHealth = (int)(enemy[i].currentHealth * (1 + (GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].enemyType = EnemyType.Boss;
                    break;

                default:
                    enemy[i].enemyData = desiredEnemy;
                    enemy[i].SetEnemyData();
                    enemy[i].maxHealth = (int)(enemy[i].maxHealth * (1 + (0.25 * GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].currentHealth = (int)(enemy[i].currentHealth * (1 + (0.25 * GameManager.Instance.PlayerData.NowStage)));
                    enemy[i].enemyType = EnemyType.Normal;
                    break;
            }
            //그리고 만약 적의 순서가 0번(맨 처음) 이라면 활성화시키기 
            if (enemy[i].index == currentEnemyIndex)
            {
                enemy[i].gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 다음 적으로 객체를 변경시키는 메서드
    /// </summary>
    public void NextEnemy()
    {
        //만약 현재 적이 스테이지의 마지막 적인 경우, 다음 스테이지로 가는 메서드 실행
        if (currentEnemyIndex >= 9)
        {
            //다음 스테이지로 이동, 적 초기화, UI 갱신
            GameManager.Instance.PlayerData.NowStage++;
            ResetEnemies();
            UpdateUI();
            //그리고 보상 지급
        }
        //만약 현재 적이 스테이지의 마지막 적이 아닌 경우, 수치 올리고 다음 적 활성화
        //현재 적 객체 비활성화는 Die 메서드에서 실행될 것
        else
        {
            currentEnemyIndex++;
            enemy[currentEnemyIndex].gameObject.SetActive(true);

            UpdateUI();
        }

    }

    public void ChangeBackGround(int stage)
    {
        if (ResourceManager.Instance == null)
        {
            Debug.LogError("ResourceManager.Instance가 null입니다!");
            return;
        }

        int length = ResourceManager.Instance.stageBackgrounds.Length;

        if (length < 3)  // 최소 3개 이상의 배경이 필요함
        {
            Debug.LogError($"배경 이미지가 부족합니다! 현재 개수: {length}");
            return;
        }

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "MainScene")
        {
            if(stage % 2 == 0)
                backgroundImage.sprite = ResourceManager.Instance.stageBackgrounds[0];
            else
                backgroundImage.sprite = ResourceManager.Instance.stageBackgrounds[1];
        }

        Debug.Log($"스테이지 {stage} - 배경 변경 완료!");
    }

    public void AddDamage()
    {
        if (enemy[currentEnemyIndex] != null)
        {
            if (clickManager.critical < 50)
            {
                isCrit = true;
                DamageOutput(enemy[currentEnemyIndex].Damaged());
            }
            else
            {
                isCrit = false;
                DamageOutput(enemy[currentEnemyIndex].Damaged());
            }
        }
    }
    public void DamageOutput(int damage)
    {
        //데미지오브젝트를 StageManager 안에 복제한 뒤 해당 객체의 텍스트 내용을 damage 매개변수로 변경
        GameObject damageObject = Instantiate(damagePrefab, enemy[currentEnemyIndex].transform.position, Quaternion.identity, this.transform);
        //크리티컬인지 확인한 뒤 텍스트 수정
        if (isCrit)
        {
            damageObject.GetComponent<TextMeshProUGUI>().text = $"<color=#FF4421>{damage}</color>";
        }
        else
        {
            damageObject.GetComponent<TextMeshProUGUI>().text = $"{damage}";
        }

        //그리고 텍스트가 날아갈 무작위 방향 설정
        float randomX = Random.Range(-1f, 1f); // X축 방향 랜덤
        float randomY = Random.Range(0f, 1f); // Y축 방향 랜덤
        Vector2 pushDirection = new Vector2(randomX, randomY).normalized;

        //리지드바디 찾아서 힘만큼 AddForce
        Rigidbody2D rb = damageObject.GetComponent<Rigidbody2D>();
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

        //2.5초 뒤 삭제
        Destroy(damageObject, 2.5f);
    }


    private void UpdateUI()
    {
        if (stageText == null && enemyText == null)
        {
            Debug.Log("스테이지텍스트와 에너미텍스트가 할당되지 않았습니다.");
        }
        else
        {
            stageText.text = string.Format("현재 스테이지: <color=#EEA970>{0}</color>", GameManager.Instance.PlayerData.NowStage);
            enemyText.text = string.Format("처치한 적: <color=#EEA970>{0}</color> / 10", currentEnemyIndex);
        }
    }

}
