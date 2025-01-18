using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSrc;
    [SerializeField] private AudioSource SFXsource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip background;

    private bool isMusicMuted = false; // Track mute state for BGM
    private bool isSFXOn = true;   // Track mute state for SFX

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Play music by default
        if (background != null)
        {
            musicSrc.clip = background;
            musicSrc.Play();
        }
    }

    public void ToggleMusic(bool state)
    {
        isMusicMuted = !state; // Invert state because `true` means unmuted

        if (isMusicMuted)
        {
            // Mute music
            musicSrc.volume = 0f;
        }
        else
        {
            // Unmute music
            musicSrc.volume = 1f;
        }
    }

    public void ToggleSFX(bool isOn)
    {
        isSFXOn = isOn;
        // No immediate action needed, SFX logic handled in PlaySFX
    }

    public void PlaySFX(AudioClip clip)
    {
        if (isSFXOn && clip != null)
        {
            SFXsource.PlayOneShot(clip);
        }
    }

}
