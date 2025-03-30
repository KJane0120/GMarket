using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

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
