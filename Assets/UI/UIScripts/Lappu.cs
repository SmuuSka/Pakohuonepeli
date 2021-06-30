using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lappu : MonoBehaviour
{
    [SerializeField]
    private GameObject lappu;

    private void Update()
    {
        lappu = GameObject.Find("LappuVastaukset");
    }
    public void OnMouseDown()
    {
        lappu.SetActive(true);
    }
}
