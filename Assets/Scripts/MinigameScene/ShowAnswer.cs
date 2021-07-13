using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnswer : MonoBehaviour
{
    [SerializeField] private GameObject rightAnswers;
    void Update()
    {
        if (PlayerData.lappuIsTrue)
        {
            rightAnswers.SetActive(true);
        }
    }
}
