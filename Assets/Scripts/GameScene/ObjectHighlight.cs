using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Transform vent;

    private Vector2 playerPos;

    private bool highlightObject;
    public bool mouseOnObject;

    private Camera cam;
    


    void Start()
    {
        playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;

        cam = Camera.main;

        if (PlayerData.lockerTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Locker"));
        }
    }
    private void Update()
    {
        playerPos = new Vector2(GameObject.Find("Robo").GetComponent<Transform>().transform.position.x, GameObject.Find("Robo").GetComponent<Transform>().transform.position.y);

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

    private void OnMouseDown()
    {
        if (mouseOnObject && this.gameObject.transform.position.x - playerPos.x < 2f)
        {
            if (this.gameObject.tag == "Lock")
            {
                Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                PlayerData.playerTransformPos = pos;
                SceneManager.LoadScene("LockScene");
                PlayerData.lockerTaskDone = true;
            }
            if (this.gameObject.tag == "Toolbox")
            {
                Debug.Log("osuu");                
                SceneManager.LoadScene("Tiirikka");
            }
            if (this.gameObject.tag == "Grill")
            {
                Debug.Log("Grill");
                Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                GameObject.Find("Robo").GetComponent<Transform>().transform.position = vent.position;
            }


        }
        else
        {
            Debug.Log("Olet liian kaukana");
        }

    }
}