using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    [Header("--------------- Audio Source ---------------")]
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioSource SFXSource;


    private void Start()
    {
        musicSource.Play();
    }
    
}
