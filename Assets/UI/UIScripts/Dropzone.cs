using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("HiiriDropzonella");
        Instantiate(GameObject.Find("Screwdriver"), transform);
    }
}
