using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Transform hand;

    void Awake()
    {
        //Find the player object and set it
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
    }

    void Update()
    {   
            hand.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
