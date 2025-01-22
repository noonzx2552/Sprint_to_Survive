using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to use UI elements

public class testSFX : MonoBehaviour
{
    [Header("--------------- Audio Clip ---------------")]
    public AudioClip crash;
    public AudioClip coin;
    public AudioClip GoSFX;
    public AudioClip Ready;

    private AudioSource musicSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        musicSource = GetComponent<AudioSource>();

        // Optionally, you can play the background music at the start
        // Loop background music
            musicSource.loop = true;
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
        if (clip != null)
        {
            musicSource.PlayOneShot(clip);
        }
    }
}   