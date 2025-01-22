using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollactableControl : MonoBehaviour
{
    public bool endgame = false;
    public static int coinCount;
    public static int totalcoin;
    public int sumcoin;
    private bool resetcoinstart = true;
    public TextMeshProUGUI coinCountDisplay;
    public TextMeshProUGUI coinCountscore;
    private int dpcoin;
    private bool getcoinFsatrt = false;

    void Start()
    {
        sumcoin = PlayerPrefs.GetInt("sumcoin", sumcoin);
        //recoin
        //PlayerPrefs.SetInt("getcoinStarted", 0); 
        //PlayerPrefs.Save();
        // ตรวจสอบว่าฟังก์ชัน setcoin5k() เคยทำงานหรือยัง
        if (PlayerPrefs.GetInt("getcoinStarted", 0) == 0)
        {
            setcoin5k(); // เรียกใช้งานฟังก์ชัน setcoin5k
            PlayerPrefs.SetInt("getcoinStarted", 1); // บันทึกว่าได้ทำงานแล้ว
            PlayerPrefs.Save(); // บันทึกการเปลี่ยนแปลงใน PlayerPrefs
        }

        //GetComponent<Coinmanager>().callcoin(sumcoin);
    }

    public void setcoin5k()
    {
        sumcoin = 3000;
        PlayerPrefs.SetInt("sumcoin", sumcoin);
        PlayerPrefs.Save();
    }
    public void SetEnd()
    {
        endgame = true;
    }

    public void resetcoincount()
    {

        sumcoin += coinCount;
        dpcoin = coinCount;
        PlayerPrefs.SetInt("sumcoin", sumcoin);
        PlayerPrefs.Save();
        GetComponent<Coinmanager>().callcoin(sumcoin);
        Debug.Log(sumcoin);
        coinCount = 0;
    }

    public void resetcoin()
    {
        coinCount = 0;
    }
    public int getSumCoin()
    {
        return sumcoin;
    }

    public void del500()
    {
        sumcoin -= 500;
        //dpcoin = coinCount;
        PlayerPrefs.SetInt("sumcoin", sumcoin);
        PlayerPrefs.Save();
        Debug.Log($"sumcoin {sumcoin}");
    }
    
    public void del1000()
    {
        sumcoin -= 1000;
        //dpcoin = coinCount;
        PlayerPrefs.SetInt("sumcoin", sumcoin);
        PlayerPrefs.Save();
        Debug.Log($"sumcoin {sumcoin}");
    }

    public void del2000()
    {
        sumcoin -= 2000;
        //dpcoin = coinCount;
        PlayerPrefs.SetInt("sumcoin", sumcoin);
        PlayerPrefs.Save();
        Debug.Log($"sumcoin {sumcoin}");
    }
    void Update()
    {
        //Debug.Log(sumcoin);
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + coinCount;
        coinCountscore.GetComponent<TMPro.TextMeshProUGUI>().text = "" + dpcoin;
        /*
        if (resetcoinstart == true)
        {
            sumcoin = PlayerPrefs.GetInt("sumcoin", 0);
            resetcoinstart = false;
            // Your other code
        }
    */
    }
}