using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource AmbienceSource;
    public AudioClip killMusic;
    public AudioClip peacefulMusic;
    public AudioClip footstepSFX;
    public AudioClip killSFX;
    public AudioClip plantSFX;

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
        AmbienceSource.Stop();
        musicSource.Play();
    }

    public void SwitchToPeacefulMusic()
    {
        //play peacefulMusic
        musicSource.clip = peacefulMusic;
        AmbienceSource.Play();
        musicSource.Play();
    }

    public void PlayKillSound()
    {
        SFXSource.clip = killSFX;
        SFXSource.PlayOneShot(killSFX);
    }

    public void PlayPlantSound()
    {
        SFXSource.clip = plantSFX;
        SFXSource.PlayOneShot(plantSFX);
    }
}
