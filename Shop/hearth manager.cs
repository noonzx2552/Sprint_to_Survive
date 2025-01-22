using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class hearthmanager : MonoBehaviour
{
    public int live = 1;
    private int sumcoin;
    private int requescoin;
    public int coin;
    public GameObject green2;
    public GameObject green3;
    public GameObject green4;
    public GameObject max;
    public GameObject morecoin;
    public TextMeshProUGUI price;
    public CollactableControl CollactableControl;
    public GameObject textprice;

    // Method to set or update live value
    public void total(int newLive)
    {
        live = newLive;
    }



    public void clicktobuy()
    {
        Debug.Log("clickbuy");
        Debug.Log(sumcoin);
        Debug.Log(requescoin);
        if (sumcoin >= requescoin && live < 4)
        {

            //sumcoin -= requescoin;
            live += 1;
            PlayerPrefs.SetInt("live", live);
            PlayerPrefs.Save();
            Debug.Log("buy");
            if (live == 2)
            {
                CollactableControl.del500();
                green2.SetActive(true);
                Debug.Log("green2 dp");
            }

            if (live == 3)
            {
                CollactableControl.del1000();
                green3.SetActive(true);
            }

            if (live == 4)
            {
                CollactableControl.del2000();
                green4.SetActive(true);
                max.SetActive(true);
            }
            
            
        }
        else
        {
            Debug.Log("more monkey");
            StartCoroutine(ShowMoneyWithDelay());
        }

        
    }
    private IEnumerator ShowMoneyWithDelay()
    {
        morecoin.SetActive(true);
        
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        morecoin.SetActive(false);
    }
    public void howmuchpay(int requescoin)
    {
        
    }

    public int gettotalheart()
    {
        live = PlayerPrefs.GetInt("live", live);
        Debug.Log(live);
        return live;
    }
    void Start()
    {
        live = PlayerPrefs.GetInt("live", live);
        //live = 1;
        //PlayerPrefs.SetInt("live", live);   
        //PlayerPrefs.Save();
        if (!PlayerPrefs.HasKey("live"))
        {
            // If "live" does not exist, this is the first time the game is played
            live = 1;
            PlayerPrefs.SetInt("live", live);
            PlayerPrefs.Save();
        }
        else
        {
            // If "live" already exists, load its value
            live = PlayerPrefs.GetInt("live");
        }
        //live = 1;
        //GetComponent<Coinmanager>().callcoin(sumcoin);
        //Debug.Log(sumcoin);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"live {live}");
        sumcoin = CollactableControl.getSumCoin();
        Debug.Log(sumcoin);
        Debug.Log(requescoin);
        if (live == 1)
        {
            requescoin = 500;
            price.text = $"{requescoin} coin";
        }

        if (live == 2)
        {
            requescoin = 1000;
            price.text = $"{requescoin} coin";
            green2.SetActive(true);
            Debug.Log("green2 dp");
        }

        if (live == 3)
        {
            requescoin = 2000;
            price.text = $"{requescoin} coin";
            green2.SetActive(true);
            green3.SetActive(true);
        }

        if (live == 4)
        {
            textprice.SetActive(false);
            green2.SetActive(true);
            green3.SetActive(true);
            green4.SetActive(true);
            max.SetActive(true);
        }
    }
}
