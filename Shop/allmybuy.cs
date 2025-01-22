using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allmybuy : MonoBehaviour
{
    private int sumcoin;
    public CollactableControl collactableControl;
    public GameObject moremoney;
    public bool haveallmy;
    public bool Ftimebuy;

    public GameObject buy;

    void Start()
    {
        //ResetHaveAllmy();
        // Load the purchase status from PlayerPrefs
        haveallmy = PlayerPrefs.GetInt("haveallmy", 0) == 1;

        // Initialize sumcoin from the CollactableControl script
        sumcoin = collactableControl.getSumCoin();

        // Show the buy button if the item hasn't been purchased yet
        if (!haveallmy)
        {
            buy.SetActive(true);
        }
        else
        {
            buy.SetActive(false); // Hide the buy button if the item was already purchased
        }
    }

    public void clicktobuy()
    {
        if (sumcoin >= 1000)
        {
            collactableControl.del1000();
            buy.SetActive(false); // Hide the buy button permanently after purchase
            haveallmy = true;     // Set the purchase flag
            // Save the purchase status to PlayerPrefs
            PlayerPrefs.SetInt("haveallmy", 1);
            PlayerPrefs.Save();
        }
        else
        {
            StartCoroutine(ShowMoneyWithDelay()); // Show a warning if not enough coins
        }
    }

    private IEnumerator ShowMoneyWithDelay()
    {
        moremoney.SetActive(true);
        
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        moremoney.SetActive(false);
    }

    void Update()
    {
        sumcoin = collactableControl.getSumCoin();

        // Ensure the buy button stays hidden after purchase
        if (haveallmy)
        {
            buy.SetActive(false);
        }
    }

    // Method to reset haveallmy to false and update PlayerPrefs
    public void ResetHaveAllmy()
    {
        haveallmy = false;
        PlayerPrefs.SetInt("haveallmy", 0); // Reset PlayerPrefs value
        PlayerPrefs.Save();

        buy.SetActive(true); // Show the buy button again after reset (if needed)
    }
}
