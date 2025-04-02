using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.bgmManager.PlayBGM(SoundLibrary.Instance.bgmStart, 0.4f);
        }
    }

    private void OnDisable()
    {
        if (SoundManager.Instance != null)
        {
            Debug.Log("게임이 시작되니 브금 바꿉니다.");
            SoundManager.Instance.bgmManager.StopBGM();
        }
    }

}
