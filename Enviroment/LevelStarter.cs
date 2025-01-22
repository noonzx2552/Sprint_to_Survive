using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject FadeIn;
    public AudioSource readyFX;
    public AudioSource goFX;
    public timecountdown Timecountdown;
    public PlayerMove PlayerMove;
    public LevelDistance LevelDistance;
    // Start is called before the first frame update
    
    void Start()
    {
        
        LevelDistance = GetComponent<LevelDistance>();
        Timecountdown = GetComponent<timecountdown>();
        PlayerMove.canMove = false;
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        //yield return new WaitForSeconds(1.5f); oldcode
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDownGo.SetActive(true);
        goFX.Play();
        PlayerMove.canMove = true;
        Timecountdown.chengecount();
        PlayerMove.setEFtrue();
        PlayerMove.run();
        LevelDistance.addingDisT();
    }

}
