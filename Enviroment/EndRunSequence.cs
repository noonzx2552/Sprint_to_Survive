using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject livetime;
    public GameObject fadein;
    public GameObject timemanager;
    public GameObject scoreboard;
    public counttimeFstart CounttimeFstart;
    public LevelDistance LevelDistance;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Endrun()
    {
        StartCoroutine(EndSequence());
    }
    
    IEnumerator EndSequence()
    {
        fadein.SetActive(false);
        yield return new WaitForSeconds(0);
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        livetime.SetActive(false);
        //endScreen.SetActive(true);
        scoreboard.SetActive(true);
        //yield return new WaitForSeconds(5);
        //fadeOut.SetActive(true);
        GetComponent<timecountdown>().enabled = false;
        CounttimeFstart.addingDisT();
    }

    public void scoreboardT()
    {
        scoreboard.SetActive(true);
    }
    public void scoreboardF()
    {
        scoreboard.SetActive(false);
    }
}