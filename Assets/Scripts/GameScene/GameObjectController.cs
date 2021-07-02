using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    public List<GameObject> playerPrefab = new List<GameObject>();

    private void Start()
    {
        playerPrefab.Add(GameObject.Find("Robo_Idle"));
        playerPrefab.Add(GameObject.Find("Robo"));

        
        playerPrefab[1].GetComponent<SpriteRenderer>().color = Color.clear;


    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            playerPrefab[0].GetComponent<SpriteRenderer>().color = Color.clear;
            playerPrefab[1].GetComponent<SpriteRenderer>().color = Color.white;
            //playerPrefab[0].SetActive(false);
            //playerPrefab[1].SetActive(true);
        }
        else
        {
            playerPrefab[0].GetComponent<SpriteRenderer>().color = Color.white;
            playerPrefab[1].GetComponent<SpriteRenderer>().color = Color.clear;
            //playerPrefab[0].SetActive(true);
            //playerPrefab[1].SetActive(false);
        }
    }
}
