using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject meisseli;
    private GameObject patteri;

    private void Start()
    {
        meisseli = GameObject.Find("Screwdriver");
        patteri = GameObject.Find("Battery");
    
        if (!PlayerData.ToolboxTaskDone)
        {
            meisseli.SetActive(false);
        }
        else
        {
            meisseli.SetActive(true);
        }
        if (!PlayerData.lockerTaskDone)
        {
            patteri.SetActive(false);
        }
        else
        {

          patteri.SetActive(true);
        }
    }
}