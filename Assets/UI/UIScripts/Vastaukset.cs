using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vastaukset : MonoBehaviour
{
    public GameObject answers;
    public GameObject vastauksetPrefab;
    public static bool sceneActive = false;

    public void Start()
    {
        answers = GameObject.Find("LappuVastaukset");
        sceneActive = true;
    }

}
