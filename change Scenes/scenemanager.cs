using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//namespace script.change_Scenes
public class scenemanager : MonoBehaviour
{
    public bool timmy;
    public bool allmy;
    public GameObject usetimmymodel;
    public GameObject distimmymodel;
    public GameObject useallmymodel;
    public GameObject disallmymodel;
    public GameObject timmymodel;
    public GameObject mousemodel;
    private void Start()
    {
        // Load the saved values when the scene starts
        LoadValues();
        Debug.Log($"timmy {timmy}");
        Debug.Log($"allmy {allmy}");
        if (timmy)
        {
            timmymodel.SetActive(true);
            mousemodel.SetActive(false);
        }

        if (allmy)
        {
            timmymodel.SetActive(false);
            mousemodel.SetActive(true);
        }
    }

    public void selectmodeeasy_sand()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_easy");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_easy_timmy");
        }
    }

    public void selectmodenormal_sand()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_normal");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_normal_timmy");
        }
    }
    public void selectmodehard_sand()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_hard");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_hard_timmy");
        }
    }
    public void selectmodeadvance_sand()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_advance");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_advance_timmy");
        }
    }
    public void selectmodecustom_sand()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_custom");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("DesertRunLvl1_custom_timmy");
        }
    }

    public void selectmodeeasy_jungle()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("green_easy");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("green_easy_timmy");
        }
    }
    public void selectmodenormal_jungle()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("green_normal");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("green_normal_timmy");
        }
    }
    public void selectmodehard_jungle()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("green_hard");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("green_hard_timmy");
        }
    }
    public void selectmodeadvance_jungle()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("green_advance");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("green_advance_timmy");
        }
    }
    public void selectmodecustom_jungle()
    {
        if (allmy == true)
        {
            SceneManager.LoadScene("green_custom");
        }
        if (timmy == true)
        {
            SceneManager.LoadScene("green_custom_timmy");
        }
    }
    public void usetimmy()
    {
        timmy = true;
        allmy = false;
        SaveValues(); // Save values after they are changed
    }

    public void useallimy()
    {
        timmy = false;
        allmy = true;
        SaveValues(); // Save values after they are changed
    }

    private void SaveValues()
    {
        PlayerPrefs.SetInt("Timmy", timmy ? 1 : 0);
        PlayerPrefs.SetInt("Allmy", allmy ? 1 : 0);
        PlayerPrefs.Save(); // Ensure the values are saved to disk
    }

    private void LoadValues()
    {
        // Load the saved values when the scene starts
        timmy = PlayerPrefs.GetInt("Timmy", 0) == 1;
        allmy = PlayerPrefs.GetInt("Allmy", 0) == 1;
    }
    void Update()
    {

        if (timmy == true && allmy == false)
        {
            usetimmymodel.SetActive(false);
            useallmymodel.SetActive(true);

        }
        if (timmy == false && allmy == true)
        {
            usetimmymodel.SetActive(true);
            useallmymodel.SetActive(false);
        }
    }
}
