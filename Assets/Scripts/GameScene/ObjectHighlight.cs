using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight, Screwdriver;
    [SerializeField] private Transform vent;

    private Vector2 playerPos;

    private bool highlightObject;
    public bool mouseOnObject;

    private Camera cam;
    


    void Start()
    {
        Screwdriver.SetActive(false);
        playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;

        cam = Camera.main;

        if (PlayerData.lockerTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Locker"));
        }

        if (PlayerData.ToolboxTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Toolbox"));
            Screwdriver.SetActive(true);
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
                Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                PlayerData.playerTransformPos = pos;                
                SceneManager.LoadScene("Tiirikka");
                PlayerData.ToolboxTaskDone = true;
            }
            if (this.gameObject.tag == "Grill")
            {
                Debug.Log("Grill");
                Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                GameObject.Find("Robo").GetComponent<Transform>().transform.position = vent.position;
                GameObject.Find("Main Camera").GetComponent<CameraScript>().gameCamera.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraScript>().nextPos[1].position.x, GameObject.Find("Main Camera").GetComponent<CameraScript>().target.transform.position.y, -10);
            }


        }
        else
        {
            Debug.Log("Olet liian kaukana");
        }

    }
}