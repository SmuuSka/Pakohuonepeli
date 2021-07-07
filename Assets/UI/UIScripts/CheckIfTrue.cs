using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfTrue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerData.screwdriver)
        {
            Destroy(GameObject.Find("Screwdriver"));
        }
        if (PlayerData.postIt)
        {
            Destroy(GameObject.Find("numerolappu"));
        }
        if (PlayerData.battery)
        {
            Destroy(GameObject.Find("Battery"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ruuvari: " + PlayerData.screwdriver);
        Debug.Log("Lappu: " + PlayerData.postIt);
        Debug.Log("Patteri: " + PlayerData.battery);
    }
}
