using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private void Start()
    {
        volumeSlider.value = SoundManager.currentMasterVolume;
        SoundManager.ChangeMasterVolume(volumeSlider.value);
        volumeSlider.onValueChanged.AddListener(val => SoundManager.ChangeMasterVolume(val));
    }

    public float GetSliderValue()
    {
        return volumeSlider.value;
    }

}
