using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public Enemy targetEnemy;  // 타겟 적
    public bool isGamePaused;
    public UnityAction onClick;
    public UnityAction onCritClick;
    private AutoClicker autoClicker; // AutoClicker 참조
    public int critical;

    public GameObject UIPrefab;

    private RectTransform WindowUI;

    public ParticleSystem impactParticleSystem; //클릭 시 재생할 파티클시스템

    private void Start()
    {
        autoClicker = FindObjectOfType<AutoClicker>(); // AutoClicker 찾기
    }

    /// <summary>
    /// 게임이 일시정지 상태인지 확인
    /// UI가 활성화되어 있거나, 일시정지 팝업이 활성화되어 있으면 클릭을 하지 아니 함
    /// </summary>
    private void Update()
    {
        if (UIManager.Instance.inventoryPanel.activeInHierarchy || UIManager.Instance.PausePopup.activeInHierarchy)
        {
            isGamePaused = true;
        }
        else
        {
            isGamePaused = false;
        }

        if (isGamePaused) return;

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            //IndowUI 렉트트랜스폼을 찾은 뒤, 그 안에 마우스가 있는지 확인
            WindowUI = UIManager.Instance.transform.Find("WindowUI").GetComponent<RectTransform>();
            bool isMouseOnUI = RectTransformUtility.RectangleContainsScreenPoint(WindowUI, Input.mousePosition);
            
            // 만약 있다면, 실행시키지 않고 돌아가기
            if (isMouseOnUI)
            {
                //onClick 이벤트를 수행하지 않고 그냥 돌아가기
                return;
            }
            CritCheck();
        }
    }

    /// <summary>
    /// 현재 공격이 크리티컬인지 확인하는 메서드
    /// </summary>
    public void CritCheck()
    {
        critical = Random.Range(0, 101);
        CreateImpactParticlesAtPosition(FindObjectOfType<StageManager>().GetComponent<StageManager>().backgroundImage.transform.position);
        onClick.Invoke(); // 공격 실행
        Debug.Log("공격 감지");
        SoundManager.Instance?.sfxManager.PlaySFX(SoundLibrary.Instance.sfxHit, 0.1f);
    }

    /// <summary>
    /// 클릭 이펙트를 생성하는 메서드
    /// </summary>
    /// <param name="position"></param>
    public void CreateImpactParticlesAtPosition(Vector3 position)
    {
        impactParticleSystem.transform.position = position;
        impactParticleSystem.Play();
    }

}
