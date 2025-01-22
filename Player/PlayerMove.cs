using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Timers;
using System.Threading;
using Unity.VisualScripting;
using Image = UnityEngine.UIElements.Image;
using WaitForSeconds = UnityEngine.WaitForSeconds;

public class PlayerMove : MonoBehaviour
{
    //timecountdown timecountdownScript;
    public GameObject timescontdown;
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;
    public float jumpForce = 7f; // The force applied when jumping
    public static bool canMove = false;
    public bool isGrounded = true; // To check if the player is on the ground //private
    public bool isjumping = false; //private
    public float jumpSpeed;
    private float ySpeed;
    public GameObject background;
    public GameObject block1ans;
    public GameObject block2ans;
    public TextMeshProUGUI levelmodecustom;
    public TextMeshProUGUI correctscore;
    public TextMeshProUGUI allscore;
    public TextMeshProUGUI customnum;
    public TextMeshProUGUI num1;
    public TextMeshProUGUI num2;
    public TextMeshProUGUI num3;
    public TextMeshProUGUI num4;
    public TextMeshProUGUI num5;
    public TextMeshProUGUI num6;
    public TextMeshProUGUI collectpoint;
    private TextMeshPro ans1;
    private TextMeshPro ans2;
    public AudioSource coinFX;
    private int answer;
    private CharacterController conn;
    public timecountdown tcd;
    public GenerateLevel gensection;
    public CollactableControl CollactableControl;
    private int correctpoint;
    private float allpoint;
    public float gravity = 9.8f;
    private GameObject charModel;
    private Animator charAnimator;
    private bool cangen = false;
    public timecountdown timecountdown;
    public counttimeFstart CounttimeFstart;
    public LevelDistance LevelDistance;
    public hearthmanager hearthmanager;
    public EndRunSequence EndRunSequence;
    public ObstacleCollision ObstacleCollision;
    public int totalheart;
    public GameObject herth1;
    public GameObject herth2;
    public GameObject herth3;
    public GameObject herth4;
    public GameObject damage;
    public GameObject effect;
    void Start()
    {
        LevelDistance = GameObject.FindGameObjectWithTag("levelcontrol").GetComponent<LevelDistance>();
        timecountdown = GetComponent<timecountdown>();
        ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
        ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
        CollactableControl = GameObject.FindGameObjectWithTag("levelcontrol").GetComponent<CollactableControl>();
        gensection = GameObject.FindGameObjectWithTag("levelcontrol").GetComponent<GenerateLevel>();
        tcd = GameObject.FindGameObjectWithTag("levelcontrol").GetComponent<timecountdown>();
        charModel = GameObject.FindGameObjectWithTag("modelplayer");
        charAnimator = GetComponent<Animator>();
        totalheart = hearthmanager.gettotalheart();
        Debug.Log($"total {totalheart}");
        CollactableControl.resetcoin();

        /*
        if (totalheart == 1)
        {

        }
        if (totalheart == 2)
        {

        }

        if (totalheart == 3)
        {

        }

        if (totalheart == 4)
        {

        }
        if (charModel == null)
        {
            Debug.LogError("modelPlayer GameObject not found!");
        }
        else
        {
            charAnimator = charModel.GetComponent<Animator>();
        }
        */
        //conn = GetComponent<CharacterController>();
        //CollactableControl.resetcoincount();
        timecountdown.chengecount();
    }



    public void run()
    {
        charAnimator.SetBool("run", true);
    }
    public void offdpQ()
    {
        background.SetActive(false);
    }

    public void crash()
    {
        canMove = false;
        charAnimator.SetBool("dead", true);
        Debug.Log("crash dead");
        LevelDistance.stopAddingDis();
        //charAnimator.Play("Stumble Backwards");
    }

    IEnumerator delayjump()
    {
        yield return new WaitForSeconds(0.1f);
        isjumping = false;
        Debug.Log("Gf jF");

    }
    public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("jump");
        StartCoroutine(delayjump());
    }

    void displayQadvance()
    {
        background.SetActive(true);
        int numR1 = UnityEngine.Random.Range(1, 10);
        int numR2 = UnityEngine.Random.Range(1, 10);
        int numR3 = UnityEngine.Random.Range(1, 10);

        int numR4 = UnityEngine.Random.Range(1, 10); // Changed to range (1, 10) to avoid always being 0
        int numR5 = UnityEngine.Random.Range(1, 3);
        int numR6 = UnityEngine.Random.Range(1, 3);
        while (numR4 % (int)Math.Pow(numR5, numR6) != 0)
        {
            numR4 = UnityEngine.Random.Range(1, 10);
            numR5 = UnityEngine.Random.Range(1, 3);
            numR6 = UnityEngine.Random.Range(1, 3);
        }
        int cube = UnityEngine.Random.Range(0, 2);
        int oper = UnityEngine.Random.Range(0, 2);
        int plusdel = UnityEngine.Random.Range(1, 5);

        //customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5} ^ {numR6}";
        /*
        num1.text = $"{numR1}";
        num2.text = $"{numR2}";
        num3.text = $"{numR3}";
        num4.text = $"{numR4}";
        num5.text = $"{numR5}";
        num6.text = $"{numR6}";
        */
        customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5} ^ {numR6}";
        // Calculate the answer
        answer = numR1 + numR2 - numR3 * numR4 / numR5 ^ numR6;
        // If you meant exponentiation
        // answer = (int)(numR1 + numR2 - numR3 * Mathf.Pow(numR4, numR6));

        print(answer);

        if (cube == 1)
        {
            block1ans.tag = "correct";
            block2ans.tag = "incorrect";
            ans1.text = $"{answer}";
            if (oper == 1)
            {
                ans2.text = $"{answer - plusdel}";
            }
            else
            {
                ans2.text = $"{answer + plusdel}";
            }
        }
        else
        {
            block1ans.tag = "incorrect";
            block2ans.tag = "correct";
            ans2.text = $"{answer}";
            if (oper == 1)
            {
                ans1.text = $"{answer - plusdel}";
            }
            else
            {
                ans1.text = $"{answer + plusdel}";
            }
        }
    }
    void displayQhard()
    {
        background.SetActive(true);
        int numR1 = UnityEngine.Random.Range(1, 10);
        int numR2 = UnityEngine.Random.Range(1, 10);
        int numR3 = UnityEngine.Random.Range(1, 10);

        // Ensure numR4 is divisible by numR5
        int numR4 = UnityEngine.Random.Range(1, 10);
        int numR5 = UnityEngine.Random.Range(1, 3);
        while (numR4 % numR5 != 0)
        {
            numR4 = UnityEngine.Random.Range(1, 10);
            numR5 = UnityEngine.Random.Range(1, 3);
        }

        int numR6 = UnityEngine.Random.Range(1, 3);
        int cube = UnityEngine.Random.Range(1, 2);
        int oper = UnityEngine.Random.Range(0, 2);
        int plusdel = UnityEngine.Random.Range(1, 5);

        num1.text = $"{numR1}";
        num2.text = $"{numR2}";
        num3.text = $"{numR3}";
        num4.text = $"{numR4}";
        num5.text = $"{numR5}";

        // Calculate the answer ensuring integer division
        int divisionResult = numR4 / numR5;
        answer = numR1 + numR2 - numR3 * divisionResult;

        print(answer);

        if (cube == 1)
        {
            block1ans.tag = "correct";
            block2ans.tag = "incorrect";
            ans1.text = $"{answer}";
            if (oper == 1)
            {
                ans2.text = $"{answer - plusdel}";
            }
            else
            {
                ans2.text = $"{answer + plusdel}";
            }
        }
        else
        {
            block1ans.tag = "incorrect";
            block2ans.tag = "correct";
            ans2.text = $"{answer}";
            if (oper == 1)
            {
                ans1.text = $"{answer - plusdel}";
            }
            else
            {
                ans1.text = $"{answer + plusdel}";
            }
        }
    }

    void displayQnormal()
    {
        background.SetActive(true);
        int numR1 = UnityEngine.Random.Range(1, 10);
        int numR2 = UnityEngine.Random.Range(1, 10);
        int numR3 = UnityEngine.Random.Range(1, 10);
        int numR4 = UnityEngine.Random.Range(1, 10); // Changed to range (1, 10) to avoid always being 0
        int cube = UnityEngine.Random.Range(1, 2);
        int oper = UnityEngine.Random.Range(0, 2);
        int plusdel = UnityEngine.Random.Range(1, 5);

        num1.text = $"{numR1}";
        num2.text = $"{numR2}";
        num3.text = $"{numR3}";
        num4.text = $"{numR4}";

        // Calculate the answer
        answer = numR1 + numR2 - numR3 * numR4;
        // If you meant exponentiation
        // answer = (int)(numR1 + numR2 - numR3 * Mathf.Pow(numR4, numR6));

        print(answer);

        if (cube == 1)
        {
            block1ans.tag = "correct";
            block2ans.tag = "incorrect";
            ans1.text = $"{answer}";
            if (oper == 1)
            {
                ans2.text = $"{answer - plusdel}";
            }
            else
            {
                ans2.text = $"{answer + plusdel}";
            }
        }
        else
        {
            block1ans.tag = "incorrect";
            block2ans.tag = "correct";
            ans2.text = $"{answer}";
            if (oper == 1)
            {
                ans1.text = $"{answer - plusdel}";
            }
            else
            {
                ans1.text = $"{answer + plusdel}";
            }
        }
    }
    void displayQeasy()
    {
        background.SetActive(true);
        int numR1 = UnityEngine.Random.Range(1, 10);
        int numR2 = UnityEngine.Random.Range(1, 10);
        int numR3 = UnityEngine.Random.Range(1, 10);
        int cube = UnityEngine.Random.Range(0, 2);
        int oper = UnityEngine.Random.Range(0, 2);
        int plusdel = UnityEngine.Random.Range(1, 5);


        num1.text = $"{numR1}";
        num2.text = $"{numR2}";
        num3.text = $"{numR3}";

        // Calculate the answer
        answer = numR1 + numR2 - numR3;
        // If you meant exponentiation
        // answer = (int)(numR1 + numR2 - numR3 * Mathf.Pow(numR4, numR6));

        print(answer);

        if (cube == 1)
        {
            block1ans.tag = "correct";
            block2ans.tag = "incorrect";
            ans1.text = $"{answer}";
            if (oper == 1)
            {
                ans2.text = $"{answer - plusdel}";
            }
            else
            {
                ans2.text = $"{answer + plusdel}";
            }
        }
        else
        {
            block1ans.tag = "incorrect";
            block2ans.tag = "correct";
            ans2.text = $"{answer}";
            if (oper == 1)
            {
                ans1.text = $"{answer - plusdel}";
            }
            else
            {
                ans1.text = $"{answer + plusdel}";
            }
        }
    }

    void customlevel()
    {
        if (correctpoint <= 2) // easy
        {
            // Code for easy level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            customnum.text = $"{numR1} + {numR2} - {numR3}";
            answer = numR1 + numR2 - numR3;
            levelmodecustom.text = "level 1";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }
        }
        if (correctpoint >= 3 && correctpoint <= 4) // easy1
        {
            // Code for easy1 level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 50);
            int numR2 = UnityEngine.Random.Range(1, 50);
            int numR3 = UnityEngine.Random.Range(1, 50);
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            customnum.text = $"{numR1} + {numR2} - {numR3}";
            answer = numR1 + numR2 - numR3;
            levelmodecustom.text = "level 1.5";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }

        }
        if (correctpoint >= 5 && correctpoint <= 7) // normal
        {
            // Code for normal level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);
            int numR4 = UnityEngine.Random.Range(1, 4);
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * numR4;
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4}";
            levelmodecustom.text = "level 2";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }

        }
        if (correctpoint >= 8 && correctpoint <= 10) // normal1
        {
            // Code for normal1 level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);
            int numR4 = UnityEngine.Random.Range(5, 10);
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * numR4;
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4}";
            levelmodecustom.text = "level 2.5";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }
        }
        if (correctpoint >= 11 && correctpoint <= 14) // hard
        {
            // Code for hard level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);

            // Ensure numR4 is divisible by numR5
            int numR4 = UnityEngine.Random.Range(1, 10);
            int numR5 = UnityEngine.Random.Range(1, 3);
            while (numR4 % numR5 != 0)
            {
                numR4 = UnityEngine.Random.Range(1, 10);
                numR5 = UnityEngine.Random.Range(1, 3);
            }

            int numR6 = UnityEngine.Random.Range(1, 3);
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * (numR4 / numR5);
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5}";
            levelmodecustom.text = "level 3";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }
        }
        if (correctpoint >= 15 && correctpoint <= 17) // hard
        {
            // Code for hard1 level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);

            // Ensure numR4 is divisible by numR5
            int numR4 = UnityEngine.Random.Range(1, 20);
            int numR5 = UnityEngine.Random.Range(3, 6);
            while (numR4 % numR5 != 0)
            {
                numR4 = UnityEngine.Random.Range(1, 10);
                numR5 = UnityEngine.Random.Range(3, 6);
            }
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * (numR4 / numR5);
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5}";
            levelmodecustom.text = "level 3.5";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }

        }
        if (correctpoint >= 18 && correctpoint <= 20) // advance
        {
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);

            int numR4 = UnityEngine.Random.Range(1, 10); // Changed to range (1, 10) to avoid always being 0
            int numR5 = UnityEngine.Random.Range(1, 3);
            int numR6 = UnityEngine.Random.Range(1, 3);
            while (numR4 % (int)Math.Pow(numR5, numR6) != 0)
            {
                numR4 = UnityEngine.Random.Range(1, 10);
                numR5 = UnityEngine.Random.Range(1, 3);
                numR6 = UnityEngine.Random.Range(1, 3);
            }
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * (numR4 / (int)Math.Pow(numR5, numR6));
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5} ^ {numR6}";
            levelmodecustom.text = "level 4";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }
        }
        if (correctpoint >= 21) // advance
        {
            // Code for advance1 level
            background.SetActive(true);
            int numR1 = UnityEngine.Random.Range(1, 10);
            int numR2 = UnityEngine.Random.Range(1, 10);
            int numR3 = UnityEngine.Random.Range(1, 10);

            int numR4 = UnityEngine.Random.Range(1, 10); // Changed to range (1, 10) to avoid always being 0
            int numR5 = UnityEngine.Random.Range(1, 3);
            int numR6 = UnityEngine.Random.Range(1, 5);
            while (numR4 % (int)Math.Pow(numR5, numR6) != 0)
            {
                numR4 = UnityEngine.Random.Range(1, 10);
                numR5 = UnityEngine.Random.Range(1, 3);
                numR6 = UnityEngine.Random.Range(1, 5);
            }
            int cube = UnityEngine.Random.Range(1, 2);
            int oper = UnityEngine.Random.Range(0, 2);
            int plusdel = UnityEngine.Random.Range(1, 5);
            answer = numR1 + numR2 - numR3 * (numR4 / (int)Math.Pow(numR5, numR6));
            customnum.text = $"{numR1} + {numR2} - {numR3} x {numR4} / {numR5} ^ {numR6}";
            levelmodecustom.text = "level 5";
            if (cube == 1)
            {
                block1ans.tag = "correct";
                block2ans.tag = "incorrect";
                ans1.text = $"{answer}";
                if (oper == 1)
                {
                    ans2.text = $"{answer - plusdel}";
                }
                else
                {
                    ans2.text = $"{answer + plusdel}";
                }
            }
            else
            {
                block1ans.tag = "incorrect";
                block2ans.tag = "correct";
                ans2.text = $"{answer}";
                if (oper == 1)
                {
                    ans1.text = $"{answer - plusdel}";
                }
                else
                {
                    ans1.text = $"{answer + plusdel}";
                }
            }
        }
    }
    public void setrunF()
    {
        canMove = false;
    }
    public void hideQ()
    {
        background.SetActive(false);
    }
    public void herth1F()
    {
        // Disable the Image component
        //herth1.SetEnabled(false);
        herth1.SetActive(false);
        Debug.Log("herth1");
    }

    public void allhearthF()
    {
        herth1.SetActive(false);
        herth2.SetActive(false);
        herth3.SetActive(false);
        herth4.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("free"))
        {
            cangen = true;
            if (cangen)
            {
                gensection.gensection();
                cangen = false;
            }
            ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            print(cangen);
        }

        if (other.CompareTag("coin"))
        {
            coinFX.Play();
        }

        if (other.CompareTag("advance"))
        {
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            displayQadvance();
            other.gameObject.tag = "Untagged";
            allpoint += 1;
            print(allpoint);
            allscore.text = $"{allpoint}";
            canMove = true;
        }
        else if (other.CompareTag("hard"))
        {
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            displayQhard();
            other.gameObject.tag = "Untagged";
            allpoint += 1;
            print(allpoint);
            allscore.text = $"{allpoint}";
            canMove = true;
        }
        else if (other.CompareTag("normal"))
        {
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            displayQnormal();
            other.gameObject.tag = "Untagged";
            allpoint += 1;
            print(allpoint);
            allscore.text = $"{allpoint}";
            canMove = true;
        }
        else if (other.CompareTag("easy"))
        {
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            displayQeasy();
            other.gameObject.tag = "Untagged";
            allpoint += 1;
            print(allpoint);
            allscore.text = $"{allpoint}";
            canMove = true;
        }
        else if (other.CompareTag("customlevel"))
        {
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            customlevel();
            other.gameObject.tag = "Untagged";
            allpoint += 1;
            print(allpoint);
            allscore.text = $"{allpoint}";
            canMove = true;
        }


        if (other.CompareTag("correct"))
        {
            block1ans.tag = "Untagged";
            Debug.Log("blockuntag1");
            block2ans.tag = "Untagged";
            Debug.Log("blockuntag2");
            cangen = true;
            if (cangen)
            {
                gensection.gensection();
                cangen = false;
            }
            print(cangen);
            tcd.increasetime(15);
            hideQ();
            correctpoint += 1;

            ans1.tag = "Untagged";
            Debug.Log("Untagans1");
            ans2.tag = "Untagged";
            Debug.Log("Untagans2");
            Debug.Log("gennew");
            //lock1ans = GameObject.FindGameObjectWithTag("correct");
            //Debug.Log("in(correct");
            //block2ans = GameObject.FindGameObjectWithTag("incorrect");
            //Debug.Log("in(incorrect");
            ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            StartCoroutine(DelayedAction());
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            hideQ();
            print("correct");
            print("time+15");
            canMove = true;
        }

        if (other.CompareTag("incorrect"))
        {
            block1ans.tag = "Untagged";
            Debug.Log("blockuntag1");
            block2ans.tag = "Untagged";
            Debug.Log("blockuntag2");
            cangen = true;
            if (cangen)
            {
                gensection.gensection();
                cangen = false;
            }
            print(cangen);
            tcd.decreasetime(5);
            hideQ();

            ans1.tag = "Untagged";
            Debug.Log("Untagans1");
            ans2.tag = "Untagged";
            Debug.Log("Untagans2");
            Debug.Log("gennew");
            //lock1ans = GameObject.FindGameObjectWithTag("correct");
            //Debug.Log("in(correct");
            //block2ans = GameObject.FindGameObjectWithTag("incorrect");
            //Debug.Log("in(incorrect");
            ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            StartCoroutine(DelayedAction());
            //ans1 = GameObject.FindGameObjectWithTag("ans1")?.GetComponent<TextMeshPro>();
            //ans2 = GameObject.FindGameObjectWithTag("ans2")?.GetComponent<TextMeshPro>();
            hideQ();
            print("incorrect");
            print("time-2.5");
            canMove = true;
        }

        if (other.CompareTag("Enemy"))
        {
            effect.SetActive(false);
            Debug.Log($"total {totalheart}");
            if (totalheart <= 1)
            {
                //ObstacleCollision.animationtimeout();
                herth1F();
                hideQ();
                crash();
                allhearthF();
                //herth1.SetEnabled(false);
                EndRunSequence.Endrun();
                //CollactableControl.setend();
                ObstacleCollision.setPlayerF();
                CollactableControl.resetcoincount();
                CollactableControl.resetcoin();
                //EndRunSequence.scoreboardT();
                ObstacleCollision.tcdof();

            }
            else
            {
                
            }
            {
                damage.SetActive(true);
                totalheart -= 1;
                damagedelay();
                damage.SetActive(false);
                StartCoroutine(DelayAndRemoveTag(other));
                //EndRunSequence.scoreboardF();
            }
        }
    }

    private IEnumerator damagedelay()
    {
        yield return new WaitForSeconds(0.2f);
    }
    private IEnumerator DelayAndRemoveTag(Collider other)
    {
        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.2f);

        // Remove the tag
        other.gameObject.tag = "Untagged";

        // Decrease totalheart and enable movement
        //totalheart -= 1;
        canMove = true;
    }

    public int total()
    {
        return totalheart;
    }

    public void setEFfalse()
    {
        effect.SetActive(false);
    }

    public void setEFtrue()
    {
        effect.SetActive(true);
    }
    void Update()
    {
        if (totalheart == 0)
        {
            herth1.SetActive(false);
            herth2.SetActive(false);
            herth3.SetActive(false);
            herth4.SetActive(false);
        }
        if (totalheart == 1)
        {
            herth1.SetActive(true);
            herth2.SetActive(false);
            herth3.SetActive(false);
            herth4.SetActive(false);
        }
        if (totalheart == 2)
        {
            herth1.SetActive(true);
            herth2.SetActive(true);
            herth3.SetActive(false);
            herth4.SetActive(false);
        }
        if (totalheart == 3)
        {
            herth1.SetActive(true);
            herth2.SetActive(true);
            herth3.SetActive(true);
            herth4.SetActive(false);
        }

        if (totalheart == 4)
        {
            herth1.SetActive(true);
            herth2.SetActive(true);
            herth3.SetActive(true);
            herth4.SetActive(true);
        }

        print(totalheart);
        correctscore.text = $"{correctpoint}";
        if (canMove)
        {
            //charAnimator.Play("Jump");
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGrounded && !isjumping)
        {
            isjumping = true;
            charAnimator.SetBool("jump", true);
            //StartCoroutine(Delayedjump());
            //charAnimator.SetBool("jump", false);
            print("jump");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator Delayedjump()
    {
        yield return new WaitForSeconds(1);
    }
    void OnCollisionStay(Collision collision)
    {
        if (!isjumping && collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            charAnimator.SetBool("jump", false);
        }
    }


    private IEnumerator DelayedAction()
    {
        // Delay for 1 second (change the delay as needed)
        yield return new WaitForSeconds(1);

        // After the delay, set cangen to true again
        cangen = true;
    }

}



