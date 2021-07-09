using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Transform vent;

    private RobotMoveScript robotMoveScript;

    private Vector2 playerPos, playerPosIdle;

    private bool highlightObject;
    public bool mouseOnObject, canUse;
    public GameObject floatingTextPrefab, floatingTaustaPrefab;

    private Camera cam;
    private bool runtimer;
    private IEnumerator coroutine;
    private bool timer;
    private bool doNext;

    private void Awake()
    {
        robotMoveScript = GameObject.Find("Robo").GetComponent<RobotMoveScript>();
    }

    void Start()
    {
        coroutine = Sec(0.6f);
        
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
        if (PlayerData.slideTaskDone)
        {
            Destroy(GameObject.FindGameObjectWithTag("SlidePuzzleTausta"));
        }
        if (PlayerData.laserTaskDone)
        {
            //GameObject.Find("LaserTausta").tag = "Untagged";
            Destroy(GameObject.FindGameObjectWithTag("LaserTausta"));
        }
        
    }
    private IEnumerator Sec(float waitTime)
    {
        
        //StartCoroutine(Timer());
        
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
                }
                if (this.gameObject.tag == "SlidePuzzleTausta" && canUse)
                {
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("SlidePuzzle");
                    PlayerData.slideTaskDone = true;
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
            //StartCoroutine(Timer()); 
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
        if (canUse)
        {
            robotMoveScript.roboAnimator.SetTrigger("interact");
            StartCoroutine(coroutine);
        }
        else if(canUse == false)
        {
            ShowFloatingText();
        }
        
        
        //timer = true;
    }
    public void ShowFloatingText()
    {
       var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
       go.GetComponent<TextMesh>().text = ("Olet liian kaukana");
        Instantiate(floatingTaustaPrefab, transform.position, Quaternion.identity);
    }
    private void DistanceCheck()
    {
        //playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;

        //float distance = Vector2.Distance(playerPos, this.gameObject.transform.position);

        //if (distance < 4 && distance > -4)
        //{

        //    Debug.Log(this.gameObject.tag);
        //    canUse = true;
        //}
        //else
        //{
        //    Debug.Log("Olet liian kaukana");
        //    canUse = false;
        //}

        //playerPos = GameObject.Find("Robo_Idle").GetComponent<Transform>().transform.position;

        float distance = Vector2.Distance(GameObject.Find("Robo").GetComponent<Transform>().transform.position, this.gameObject.transform.position);

        if (distance < 5 && distance > -5)
        {
            canUse = true;
        }
        else
        {
            
            canUse = false;
            
        }
    }
    //private IEnumerator Timer()
    //{
    //    
    //    yield return new WaitForSeconds(2f);
    //    StartCoroutine(coroutine);
    //}
}