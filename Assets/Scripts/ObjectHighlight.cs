using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    private bool highlightObject;
  

    void Start()
    {
       
        
    }
    private void Update()
    {
 

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
    }
    private void OnMouseExit()
    {
        highlightObject = false;
    }
    
}
