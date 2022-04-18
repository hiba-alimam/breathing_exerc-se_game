using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource MusicSource, EffectSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip Clip)
    {
        EffectSource.PlayOneShot(Clip);
    }

    public void ChangeMasterVolume(float Value)
    {
        AudioListener.volume = Value;
    }

    public void ToggleEffects()
    {
        EffectSource.mute = !EffectSource.mute;
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }
}
