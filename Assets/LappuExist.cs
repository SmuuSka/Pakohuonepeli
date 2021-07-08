using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LappuExist : MonoBehaviour
{
    void Update()
    {
        Lappu();
    }
    private void Lappu()
    {
        if (GameObject.Find("LappuVastaukset(Clone)") == null)
        {
            Debug.Log("Lappu does not exist!");
            return;
        }
        else
        {
            GameObject.Find("LappuVastaukset(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }
}
