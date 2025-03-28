using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public int maxSFXSources = 10;
    private List<AudioSource> sfxSources = new List<AudioSource>();

    float sfxVolume;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 유지

        for (int i = 0; i < maxSFXSources; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            sfxSources.Add(source);
        }
    }

    /// <summary>
    /// 지정된 오디오 클립을 주어진 볼륨으로 재생합니다.
    /// </summary>
    /// <param name="clip">재생할 오디오 클립</param>
    /// <param name="volume">재생할 볼륨 (기본값: 1.0f)</param>
    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        foreach (var source in sfxSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.volume = sfxVolume * volume;
                source.Play();
                return;
            }
        }
    }

    /// <summary>
    /// 모든 SFX AudioSource의 볼륨을 업데이트합니다.
    /// </summary>
    /// <param name="volume">새로운 볼륨 값</param>
    public void UpdateVolume(float volume)
    {
        foreach (var source in sfxSources)
        {
            sfxVolume = volume;
        }
    }
}
