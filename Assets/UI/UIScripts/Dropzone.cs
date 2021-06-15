using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    [SerializeField]
    Transform center;
    GameObject ruuvvari;
    private void Start()
    {
        ruuvvari = GameObject.Find("Scruuvvari");
        ruuvvari.SetActive(false);
    }
    private void OnMouseEnter()
    {
        Debug.Log("HiiriDropzonella");
        ruuvvari.SetActive(true);

    }
}
