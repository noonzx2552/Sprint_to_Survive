using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageruseornot : MonoBehaviour
{
    public bool Timmy;
    public bool Allmy;
    public bool haveallmy;
    public GameObject usetimmy;
    public GameObject distimmy;
    public GameObject useallmy;
    public GameObject disallmy;

    public scenemanager Scenemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void useTimmy()
    {
        Scenemanager.usetimmy();
        Timmy = true;
        Allmy = false;
        //usetimmy.SetActive(false);
        //useallmy.SetActive(true);
    }

    public void useAllmy()
    {
        Scenemanager.useallimy();
        Timmy = false;
        Allmy = true;
        //usetimmy.SetActive(true);
        //useallmy.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
