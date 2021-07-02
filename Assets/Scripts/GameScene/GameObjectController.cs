using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    private int playerObjectCountAngle, playerObjectCountSide;
    private List<GameObject> playerPrefab = new List<GameObject>();

    private void Start()
    {
        playerPrefab.Add(GameObject.Find("Robo_Idle"));
        playerPrefab.Add(GameObject.Find("Robo"));

        playerPrefab[0].SetActive(true);
        playerPrefab[1].SetActive(false);
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            playerPrefab[0].SetActive(false);
            playerPrefab[1].SetActive(true);
        }
        else
        {
            playerPrefab[0].SetActive(true);
            playerPrefab[1].SetActive(false);
        }
    }
}
