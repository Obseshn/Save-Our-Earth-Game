using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource, uiSource;

    [SerializeField] private AudioClip onButtonPressedSound;

    private static bool isMute = false;
    

    public static float currentMasterVolume = 0.5f;

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
    private void OnEnable()
    {
        if (!isMute)
        {
            musicSource.clip = Resources.Load<AudioClip>("BGMusic");
            musicSource.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public static void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
        currentMasterVolume = value;
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

    public void PlayUISound(AudioClip clip)
    {
        uiSource.PlayOneShot(clip);
    }
}
