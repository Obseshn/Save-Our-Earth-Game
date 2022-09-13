using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private void Start()
    {
        SoundManager.Instance.ChangeMasterVolume(volumeSlider.value);
        volumeSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }
}
