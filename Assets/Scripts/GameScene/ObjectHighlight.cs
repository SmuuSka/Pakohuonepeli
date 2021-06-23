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
    public bool mouseOnObject;

    private Camera cam;
    private float secs = 10f;
    private bool runtimer;
    private IEnumerator coroutine;



    void Start()
    {
        coroutine = Sec(0.6f);
        
        robotMoveScript = GameObject.Find("Robo").GetComponent<RobotMoveScript>();


        //Screwdriver.SetActive(false);
        playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;

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
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (mouseOnObject && this.gameObject.transform.position.x - playerPos.x < 3.5f)
            {
                



                if (this.gameObject.tag == "Lock")
                {
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    //Vector3 cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    //PlayerData.gameCameraTransformPos = cameraPos;
                    SceneManager.LoadScene("LockScene");
                    //PlayerData.lockerTaskDone = true;
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "Toolbox")
                {
                    
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("Tiirikka");
                    PlayerData.ToolboxTaskDone = true;
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "Grill" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true)
                {
                    Debug.Log("Grill");
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive = false;
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    GameObject.Find("Robo").GetComponent<Transform>().transform.position = vent.position;
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().gameCamera.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraScript>().nextPos[1].position.x, GameObject.Find("Main Camera").GetComponent<CameraScript>().target.transform.position.y, -10);
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "SlidePuzzleTausta")
                {
                    Vector2 pos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
                    PlayerData.playerTransformPos = pos;
                    SceneManager.LoadScene("SlidePuzzle");
                    robotMoveScript.roboAnimator.SetTrigger("interact");
                }
                if (this.gameObject.tag == "LaserTausta")
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
            else
            {
                Debug.Log("Olet liian kaukana" + (this.gameObject.transform.position.x - playerPos.x));
               
            }
            StopCoroutine(coroutine);
            



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
        if (Input.GetMouseButtonDown(0))
        {
            robotMoveScript.roboAnimator.SetTrigger("interact");
        }

    }
    private void OnMouseEnter()
    {
        Debug.Log("Positio: " + (this.gameObject.transform.position.x - playerPos.x));
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
        

        StartCoroutine(coroutine);
        
    }
}