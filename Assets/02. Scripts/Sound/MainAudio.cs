using UnityEngine;


/// <summary>
/// 메인 씬에서의 배경음악을 관리하는 클래스입니다.
/// </summary>
public class MainAudio : MonoBehaviour
{
    /// <summary>
    /// 메인화면에 진입하면 배경음악을 재생합니다.
    /// </summary>
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmMain1, 0.4f);
        }
    }

    /// <summary>
    /// 메인화면에서 나가면 배경음악을 중지합니다.
    /// </summary>
    private void OnDisable()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("Exit버튼 눌렀으니까 브금 바꿉니다.");
            SoundManager.Instance.bgmManager.StopBGM();
        }
    }
}
