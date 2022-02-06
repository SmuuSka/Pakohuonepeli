using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnswers : MonoBehaviour
{
    [SerializeField] private GameObject rightAnswers;


    private void Awake()
    {
        rightAnswers.SetActive(false);
        
    }

    private void Update()
    {
        if (!PlayerData.lappuIsTrue)
        {
            return;
        }
        else
        {
            rightAnswers.SetActive(true);
        }
    }
}
