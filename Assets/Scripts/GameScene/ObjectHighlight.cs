using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectHighlight : MonoBehaviour
{
    private Vector3 player;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Color stroke;
    private bool highlightObject, tooFarForInteract;
    public bool mouseOnObject;

    private Camera cam;
    


    void Start()
    {
        player = GameObject.Find("Robot side-8").GetComponent<Transform>().position;

        cam = Camera.main;

        if (PlayerData.lockerTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Locker"));
        }
    }
    private void Update()
    {
        
        RobotTooFar();
        
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
        highlight.GetComponent<SpriteRenderer>().color = stroke;

    }
    private void OnMouseExit()
    {
        highlightObject = false;
        mouseOnObject = false;
    }

    private void OnMouseDown()
    {
        if (mouseOnObject && this.gameObject.tag == "Locker")
        {
            Vector2 pos = GameObject.Find("Robot side-8").GetComponent<Transform>().transform.position;
            PlayerData.playerTransformPos = pos;
            SceneManager.LoadScene("LockScene");
            PlayerData.lockerTaskDone = true;
        }
        if (mouseOnObject && this.gameObject.tag == "Toolbox")
        {
            SceneManager.LoadScene("Tiirikka");
        }   
    }
    

    

    private void RobotTooFar()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(cam.transform.position, mousePos);
        Debug.DrawRay(cam.transform.position, mousePos, Color.green);
    }
}