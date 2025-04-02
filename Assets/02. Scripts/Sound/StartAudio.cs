using UnityEngine;

/// <summary>
/// 게임 시작 시 배경음악을 재생하는 클래스입니다.
/// </summary>
public class StartAudio : MonoBehaviour
{
    /// <summary>
    /// 시작화면에서 배경음악을 재생합니다.
    /// </summary>
    void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmStart, 0.4f);
        }
    }

    /// <summary>
    /// 시작화면에서 나가면 배경음악을 중지합니다.
    /// </summary>
    private void OnDisable()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("게임이 시작되니 브금 바꿉니다.");
            SoundManager.Instance.bgmManager.StopBGM();
        }
    }

}
