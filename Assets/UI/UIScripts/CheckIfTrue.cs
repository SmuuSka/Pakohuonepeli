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

    private void Update()
    {
        Debug.Log("Pukukaappi status: " + PlayerData.lockerTaskDone);
    }
}
