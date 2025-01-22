using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using TMPro;
using UnityEditor;


public class timecountdown : MonoBehaviour
{
    public float starttime;
    public TextMeshProUGUI displaytime;
    public bool cancount;
    public bool statustimer = true;
    public EndRunSequence EndRunSequence;
    public PlayerMove PlayerMove;
    private GameObject charModel;
    public counttimeFstart CounttimeFstart;
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject livetime;
    public ObstacleCollision Obs;
    public CollactableControl CollactableControl;
    // Start is called before the first frame update
    void Start()
    {
        Obs = GetComponent<ObstacleCollision>();
        CounttimeFstart = GetComponent<counttimeFstart>();
        EndRunSequence = GetComponent<EndRunSequence>();
        PlayerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        charModel = GameObject.FindGameObjectWithTag("modelplayer");
    }
    public void increasetime(int a)
    {
        starttime += a;
    }
    public void decreasetime(int a)
    {
        starttime -= a;
    }

    public void chengecountF()
    {
        cancount = false;
    }
    public void chengecount()
    {
        cancount = true;
        Debug.Log("tcd");
    }
    // Update is called once per frame
    void Update()
    {
        if(cancount)
            if (statustimer == true) 
            { 
                float timer = starttime - (int)Math.Floor(Time.timeSinceLevelLoad) + 4;
                if (timer <= 0)
                {
                    PlayerMove.setEFfalse();
                    EndRunSequence.Endrun();
                    PlayerMove.allhearthF();
                    PlayerMove.crash();
                    //liveCoins.SetActive(false);
                    //liveDis.SetActive(false);
                    //livetime.SetActive(false);
                    //CounttimeFstart.stopcount();
                    Animator charAnimator = charModel.GetComponent<Animator>();
                    Obs.animationtimeout();
                    Debug.Log("time0");
                    //EndRunSequence.Endrun();
                    //charAnimator.Play("Stumble Backwards");
                    statustimer = false;
                    PlayerMove.hideQ();
                    CollactableControl.resetcoincount();
                    CollactableControl.resetcoin();
                }
            
                displaytime.text = $"{timer}";
            //GetComponent<EndRunSequence>().enabled = true;
            }
    }
        public void changeStartTime(int n)
        {
        
        }
}