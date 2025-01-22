using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------------- Audio Source ---------------")]
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioSource SFXSource;

    [Header("--------------- Audio Clip ---------------")]
    public AudioClip background;
    public AudioClip crash;
    public AudioClip coin;
    public AudioClip GoSFX;
    public AudioClip Ready;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlayCrashSFX()
    {
        PlaySFX(crash);
    }

    public void PlayCoinSFX()
    {
        PlaySFX(coin);
    }

    public void PlayGoSFX()
    {
        PlaySFX(GoSFX);
    }

    public void PlayReadySFX()
    {
        PlaySFX(Ready);
    }
    private void PlaySFX(AudioClip clip)
    {
        //SFXSource.PlayOneShot(clip);
    }
}
