using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class timemanager : MonoBehaviour

{
    public float starttime;
    public TextMeshProUGUI displaytime;
    private bool statustimer = true;

    // Start is called before the first frame update
    void Start()
    {

    }
    /*
    public void increasetime()
    {
        starttime += 7.5f;
    }
    public void decreasetime()
    {
        starttime -= 2.5f;
    }
    */
    // Update is called once per frame
    void Update()
    {
        if (statustimer == true)
        {
            float timer = (int)Math.Floor(Time.timeSinceLevelLoad);
            displaytime.text = $"{timer}";
            GetComponent<EndRunSequence>().enabled = true;
        }
    }
    //public void changeStartTime(int n)
    //{

    //}
}
