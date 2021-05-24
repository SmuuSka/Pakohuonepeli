using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    private bool moveToTask;

    void Start()
    {
        highlight.SetActive(false);
    }
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
