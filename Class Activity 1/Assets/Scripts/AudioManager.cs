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

    private bool isMusicMuted = false; 
    private bool isSFXOn = true;   

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
        if (background != null)
        {
            musicSrc.clip = background;
            musicSrc.Play();
        }
    }

    public void ToggleMusic(bool state)
    {
        isMusicMuted = !state; 

        if (isMusicMuted)
        {
            musicSrc.volume = 0f;
        }
        else
        {
            musicSrc.volume = 1f;
        }
    }

    public void ToggleSFX(bool isOn)
    {
        isSFXOn = isOn;
       
    }

    public void PlaySFX(AudioClip clip)
    {
        if (isSFXOn && clip != null)
        {
            SFXsource.PlayOneShot(clip);
        }
    }

}
