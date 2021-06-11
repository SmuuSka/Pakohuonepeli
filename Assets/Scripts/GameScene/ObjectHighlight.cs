using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    private Vector3 playerPos;

    [SerializeField] private GameObject highlight;
    [SerializeField] private Transform vent;

    private bool highlightObject, tooFarForInteract;
    public bool mouseOnObject;

    private Camera cam;
    


    void Start()
    {

        

        cam = Camera.main;

        if (PlayerData.lockerTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Locker"));
        }
    }
    private void Update()
    {
        playerPos = new Vector2(GameObject.Find("Robot side-8").GetComponent<Transform>().transform.position.x, GameObject.Find("Robot side-8").GetComponent<Transform>().transform.position.y);

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
            if (this.gameObject.tag == "Locker")
            {
                Vector2 pos = GameObject.Find("Robot side-8").GetComponent<Transform>().transform.position;
                PlayerData.playerTransformPos = pos;
                SceneManager.LoadScene("LockScene");
                PlayerData.lockerTaskDone = true;
            }
            if (this.gameObject.tag == "Toolbox")
            {
                SceneManager.LoadScene("Tiirikka");
            }
            if (this.gameObject.tag == "Grill")
            {
                //playerPos = 
                //PlayerData.playerTransformPos
            }
        }
        else
        {
            Debug.Log("Olet liian kaukana");
        }
    }
}