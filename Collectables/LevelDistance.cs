using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI enddisplay;
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;
    private bool canadd = true;

    // Update is called once per frame
    void Update()
    {
        print(addingDis);
        display.text = $"{disRun}";
        enddisplay.text = $"{disRun}";
        // Check if the coroutine is already running
        if (addingDis)
        {
            StartCoroutine(AddingDis());
            Debug.Log("startcoroutine");
        }
    }

    IEnumerator AddingDis()
    {
        addingDis = false;
        while (canadd)
        {
            disRun += 1;
            display.text = $"{disRun}";  // Update the display here as well
            yield return new WaitForSeconds(disDelay);
        }
        addingDis = true;
    }

    // Method to start adding distance
    public void addingDisT()
    {
        addingDis = true;
    }

    // Method to stop adding distance
    public void stopAddingDis()
    {
        addingDis = false;
        canadd = false;
    }
}