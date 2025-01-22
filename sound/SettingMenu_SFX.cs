using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingMenu_SFX : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void SetVolume_SFX(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    void Update()
    {
        // Get the current volume level
        float currentVolume;
        audioMixer.GetFloat("volume", out currentVolume);

        // If the current volume is -40, set it to -80
        if (currentVolume == -40f)
        {
            audioMixer.SetFloat("volume", -80f);
        }
    }
}
