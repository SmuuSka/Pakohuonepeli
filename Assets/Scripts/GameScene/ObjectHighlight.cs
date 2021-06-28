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

    private RobotMoveScript robotMoveScript;

    private Vector2 playerPos;

    private bool highlightObject;
    public bool mouseOnObject, canUse;

    private Camera cam;
    private float secs = 10f;
    private bool runtimer;
    private IEnumerator coroutine;
    private bool timer;
    private bool doNext;

    void Start()
    {
        coroutine = Sec(0.6f);
        
        robotMoveScript = GameObject.Find("Robo").GetComponent<RobotMoveScript>();


        //Screwdriver.SetActive(false);
        

        cam = Camera.main;

        if (PlayerData.lockerTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Locker"));
        }

        if (PlayerData.ToolboxTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("Toolbox"));
            //Screwdriver.SetActive(true);
        }
        
    }
    private IEnumerator Sec(float waitTime)
    {

        
            StartCoroutine(Timer());
        
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (mouseOnObject)
            {
                if (this.gameObject.tag == "Lock" && canUse)
                {
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("LockScene");
                    PlayerData.lockerTaskDone = true;
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "Toolbox" && canUse)
                {
                    
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("Tiirikka");
                    PlayerData.ToolboxTaskDone = true;
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "Grill" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true && canUse)
                {
                    Debug.Log("Grill");
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive = false;
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    GameObject.Find("Robo").GetComponent<Transform>().transform.position = vent.position;
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().gameCamera.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraScript>().nextPos[1].position.x, GameObject.Find("Main Camera").GetComponent<CameraScript>().target.transform.position.y, -10);
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "SlidePuzzleTausta" && canUse)
                {
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("SlidePuzzle");
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "LaserTausta" && canUse)
                {
                    if (GameObject.Find("Patteri") == null)
                    {
                        robotMoveScript.roboAnimator.SetTrigger("interact");
                    }
                    else
                    {
                        Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                        PlayerData.playerTransformPos = pos;
                        SceneManager.LoadScene("LaserLock");
                        robotMoveScript.roboAnimator.SetTrigger("interact");
                    }
                }
            }
            StopCoroutine(coroutine);
            timer = false;
        }
    }
    private void Update()
    {
        DistanceCheck();
        

        if (!highlightObject)
        {
            
            highlight.SetActive(false);
        }

        if (highlightObject)
        {
            
            highlight.SetActive(true);
        }
        if (timer)
        {
            StartCoroutine(Timer()); 
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
        timer = true;
        
    }
    private void DistanceCheck()
    {
        playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;

        float distance = Vector2.Distance(playerPos, this.gameObject.transform.position);
        if (distance < 4 && distance > -4)
        {
            Debug.Log(this.gameObject.tag);
            canUse = true;
        }
        else
        {
            Debug.Log("Olet liian kaukana");
            canUse = false;
        }
    }
    private IEnumerator Timer()
    {
        robotMoveScript.roboAnimator.SetTrigger("interact");
        yield return new WaitForSeconds(1f);
        StartCoroutine(coroutine);
    }
}