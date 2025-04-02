using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 사운드 설정을 관리하는 클래스입니다.
/// </summary>
public class SoundUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    /// <summary>
    /// 배경음악과 효과음의 볼륨을 조절합니다.
    /// </summary>
    void Start()
    {
        bgmSlider.value = SoundManager.Instance.bgmVolume;
        sfxSlider.value = SoundManager.Instance.sfxVolume;
        bgmSlider.onValueChanged.AddListener(value => SoundManager.Instance.bgmVolume = value);
        sfxSlider.onValueChanged.AddListener(value => SoundManager.Instance.sfxVolume = value);
    }

    private void Update()
    {
        bgmSlider.onValueChanged.AddListener(value => SoundManager.Instance.bgmVolume = value);
        sfxSlider.onValueChanged.AddListener(value => SoundManager.Instance.sfxVolume = value);
    }
}
