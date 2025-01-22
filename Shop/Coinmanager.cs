using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coinmanager : MonoBehaviour
{
    public TextMeshProUGUI totalcoin;
    public CollactableControl collactableControl;
    public hearthmanager Hearthmanager; 
    public int dpcoin;

    void Start()
    {
        // Load sumcoin from PlayerPrefs when the scene starts
        dpcoin = PlayerPrefs.GetInt("sumcoin", 0);
        totalcoin.text = $"{dpcoin}";

        // Optionally, set this value in CollactableControl if it's in the same scene

    }

    public void callcoin(int coin)
    {
        dpcoin = coin;
    }
    public void updatecoin()
    {
        //GetComponent<hearthmanager>().callcoin(dpcoin);
        //PlayerPrefs.SetInt("sumcoin", dpcoin);
        //PlayerPrefs.Save();
    }
    public int GetDpcoin()
    {
        return dpcoin;
    }


    void Update()
    {
        if (collactableControl != null)
        {
            dpcoin = collactableControl.sumcoin;
            Debug.Log($"dpcoin {dpcoin}");
        }
        totalcoin.text = $"{dpcoin}";
        
        // Optionally, continue updating UI or other elements
    }
}
