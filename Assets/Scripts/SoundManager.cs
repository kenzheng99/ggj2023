using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource musicSource;
    public AudioClip killMusic;
    public AudioClip peacefulMusic;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchToKillMusic()
    {
        //play killMusic
        musicSource.clip = killMusic;
        musicSource.Play();
    }

    public void SwitchToPeacefulMusic()
    {
        //play peacefulMusic
        musicSource.clip = peacefulMusic;
        musicSource.Play();
    }

    public void PlayKillSound()
    {

    }

    public void PlayPlantSound()
    {

    }

    public void PlayFootstepSound()
    {

    }
}
