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

    private void Start()
    {
        highlight.SetActive(false);
    }
}
