using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    private bool highlightObject, mouseOnObject;
    private static int sceneIndex;


    void Start()
    {
        Debug.Log("Scene index " + sceneIndex);
    }
    private void Update()
    {
        

        if (mouseOnObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sceneIndex++;
                SceneManager.LoadScene(1);
                
            }
        }


        

        if (!highlightObject)
        {
            highlight.SetActive(false);
        }

        if (highlightObject)
        {
            highlight.SetActive(true);
        }
    }
    private void OnMouseEnter()
    {
        highlightObject = true;
        mouseOnObject = true;

    }
    private void OnMouseExit()
    {
        highlightObject = false;
        mouseOnObject = false;
    }

}