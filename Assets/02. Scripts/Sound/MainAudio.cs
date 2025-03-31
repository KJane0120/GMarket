using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmMain1, 0.4f);
        }
    }

    private void OnDisable()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("Exit버튼 눌렀으니까 브금 바꿉니다.");
            SoundManager.Instance.bgmManager.StopBGM();
        }
    }
}
