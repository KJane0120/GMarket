using UnityEngine;

/// <summary>
/// 게임의 전반적인 사운드 자원을 관리하는 클래스입니다.
/// </summary>
public class SoundLibrary : MonoBehaviour
{
    public static SoundLibrary Instance { get; private set; }

    [Header("BGM Clips")]
    public AudioClip bgmStart; //타이틀 화면에서
    public AudioClip bgmMain1; //게임화면에서

    [Header("SFX Clips")]
    public AudioClip sfxHit;            //타격시 
    public AudioClip sfxCritHit;        //치명타 타격시
    public AudioClip sfxWeaponUpgrade;  //무기 업그레이드시
    public AudioClip sfxStatUpgrade;    //스탯 업그레이드시
    public AudioClip sfxError;          //재화 부족으로 에러메세지 뜰 때

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
