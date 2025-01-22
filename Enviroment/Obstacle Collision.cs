using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ObstacleCollision : MonoBehaviour
{
    private GameObject thePlayer;
    private GameObject charModel;
    private AudioSource crashThud;
    private GameObject levelControl;
    private EndRunSequence endRunSequence;
    private PlayerMove playerMove;
    public counttimeFstart CounttimeFstart;
    public bool cancrash;
    private int crash;
    private int totalhearth;


    void Start()
    {
        crash = 0;
        cancrash = true;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        if (thePlayer == null)
        {
            Debug.LogError("Player GameObject not found!");
        }

        charModel = GameObject.FindGameObjectWithTag("modelplayer");
        if (charModel == null)
        {
            Debug.LogError("modelPlayer GameObject not found!");
        }

        levelControl = GameObject.FindGameObjectWithTag("levelcontrol");
        if (levelControl == null)
        {
            Debug.LogError("levelcontrol GameObject not found!");
        }

        // Find the GameObject with the "crashThud" tag and get its AudioSource component
        GameObject crashThudObject = GameObject.FindGameObjectWithTag("crashThud");
        if (crashThudObject != null)
        {
                crashThud = crashThudObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("crashThud GameObject not found!");
        }

        // Initialize EndRunSequence and PlayerMove
        if (levelControl != null)
        {
            endRunSequence = levelControl.GetComponent<EndRunSequence>();
            if (endRunSequence == null)
            {
                Debug.LogError("EndRunSequence component not found on levelcontrol GameObject!");
            }

            playerMove = thePlayer.GetComponent<PlayerMove>();
            if (playerMove == null)
            {
                Debug.LogError("PlayerMove component not found on Player GameObject!");
            }
        }
    }
    void Update()
    {
        totalhearth = playerMove.total();
    }
    public void cancrashF()
    {
        cancrash = false;
    }
    public void animationtimeout()
    {
        Animator charAnimator = charModel.GetComponent<Animator>();
        if (charAnimator != null)
        {
            charAnimator.Play("Stumble Backwards");
        }
    }

    public void setPlayerF()
    {
        if (thePlayer != null)
        {
            PlayerMove playerMoveComponent = thePlayer.GetComponent<PlayerMove>();
            if (playerMoveComponent != null)
            {
                playerMoveComponent.enabled = false;
            }
            Animator cameraAnimator = Camera.main.GetComponent<Animator>();
            if (cameraAnimator != null)
            {
                cameraAnimator.enabled = true;
            }
        }
    }

    public void tcdof()
    {
        timecountdown timecountdownComponent = levelControl.GetComponent<timecountdown>();
        if (timecountdownComponent != null)
        {
            timecountdownComponent.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.GetComponent<BoxCollider>() != null)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        /*
        if (thePlayer != null)
        {
            PlayerMove playerMoveComponent = thePlayer.GetComponent<PlayerMove>();
            if (playerMoveComponent != null)
            {
                playerMoveComponent.enabled = false;
            }
        }
*/
        if (charModel != null && totalhearth <= 1)
        {
            Animator charAnimator = charModel.GetComponent<Animator>();
            charAnimator.Play("Stumble Backwards");
            
        }

        if (levelControl != null)
        {
            LevelDistance levelDistanceComponent = levelControl.GetComponent<LevelDistance>();
            if (levelDistanceComponent != null)
            {
                levelDistanceComponent.enabled = false;
            }

            if (crashThud != null)
            {
                print(cancrash);
                if (crash < 1 && totalhearth <= 1)
                {
                    crash = 1;
                    crashThud.Play();
                    print("crash1");
                }
                //crashThud.Play();
            }
/*
            Animator cameraAnimator = Camera.main.GetComponent<Animator>();
            if (cameraAnimator != null)
            {
                cameraAnimator.enabled = true;
            }
*/
            EndRunSequence endRunSequenceComponent = levelControl.GetComponent<EndRunSequence>();
            if (endRunSequenceComponent != null)
            {
                endRunSequenceComponent.enabled = false;
            }
            

            timemanager timemanagerComponent = levelControl.GetComponent<timemanager>();
            if (timemanagerComponent != null)
            {
                timemanagerComponent.enabled = false;
            }
            /*
            if (endRunSequence != null)
            {
                endRunSequence.Endrun();
            }
            */
        }
    }
}
