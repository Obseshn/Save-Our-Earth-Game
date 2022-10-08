using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglerAudio : MonoBehaviour
{
    [SerializeField] private bool isMute;

    public void Toggle()
    {
        if (isMute)
        {
            AudioListener.volume = 0;
            SoundManager.currentMasterVolume = 0;
        }
        else
        {
            AudioListener.volume = FindObjectOfType<VolumeSlider>().GetSliderValue();
        }
    }
}
