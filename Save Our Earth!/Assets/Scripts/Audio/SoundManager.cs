using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource, uiSource;

    [SerializeField] private AudioClip onButtonPressedSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleEffectsAudio()
    {
        effectSource.mute = !effectSource.mute;
    }

    public void ToggleMusicAudio()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleUIAudio()
    {
        uiSource.mute = !uiSource.mute;
    }

    public void PlayButtonSound()
    {
        uiSource.PlayOneShot(onButtonPressedSound);
        
    }
}
