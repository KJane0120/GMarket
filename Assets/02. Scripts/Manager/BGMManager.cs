using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource bgmSource;

    float bgmVolume;
    float bgmMult;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 유지

        bgmSource = GetComponent<AudioSource>();
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// 지정된 오디오 클립을 주어진 볼륨으로 재생합니다.
    /// </summary>
    /// <param name="clip">재생할 오디오 클립</param>
    /// <param name="volume">재생할 볼륨 (기본값: 1.0f)</param>
    public void PlayBGM(AudioClip clip, float volume = 1.0f)
    {
        if (bgmSource != null)
        {
            bgmMult = volume;
            bgmSource.clip = clip;
            UpdateVolume(SoundManager.Instance.bgmVolume);
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    /// <summary>
    /// 현재 재생 중인 BGM을 정지합니다.
    /// </summary>
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    /// <summary>
    /// BGM 볼륨을 업데이트합니다.
    /// </summary>
    /// <param name="volume">새로운 볼륨 값</param>
    public void UpdateVolume(float volume)
    {
        if (bgmSource != null)
        {
            bgmVolume = volume;
            bgmSource.volume = bgmVolume * bgmMult;
        }
    }
}
