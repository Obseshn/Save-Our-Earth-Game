using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglerAudio : MonoBehaviour
{
    [SerializeField] private bool musicAudio, effectsAudio, uiAudio;

    public void Toggle()
    {
        if (musicAudio)
        {
            SoundManager.Instance.ToggleMusicAudio();
        }
        if (effectsAudio)
        {
            SoundManager.Instance.ToggleEffectsAudio();
        }
        if (uiAudio)
        {
            SoundManager.Instance.ToggleUIAudio();
        }
    }
}
