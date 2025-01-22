using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloasepanel : MonoBehaviour
{
    public GameObject panel;

    public void open()
    {
        panel.SetActive(true);
    }

    public void close()
    {
        panel.SetActive(false);
    }
}
