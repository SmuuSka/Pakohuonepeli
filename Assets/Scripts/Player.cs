using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform player;

    void Awake()
    {
        //Find the player object and set it
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {   
            player.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
