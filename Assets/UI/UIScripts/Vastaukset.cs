using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vastaukset : MonoBehaviour
{
    public GameObject answers;

    public void Start()
    {
        answers = GameObject.Find("LappuVastaukset");
        answers.SetActive(false);
    }

}
