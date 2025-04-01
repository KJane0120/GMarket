using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    public static SoundLibrary Instance { get; private set; }

    [Header("BGM Clips")]
    public AudioClip bgmStart; //타이틀 화면에서
    public AudioClip bgmMain1; //게임화면에서
    public AudioClip bgmMain2; //스테이지에 따라 다른 bgm 재생
    public AudioClip bgmMain3; //여러개 추가 가능, 랜덤 재생


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
