﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    //--------Player Variables--------
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] public Animator roboAnimator;
    private Rigidbody2D playerRb;
    private float horizontalInput;
    private int multiplier = 5;
    private bool facingRight;
    private bool crawl;

    public RaycastHit2D playerRaycastHitDoor, hitVent;
    //--------Player Variables--------

    //--------Door Temp Variables--------
    private GameObject doubleDoorLeft, doubleDoorRight;
    private Animator tempRightAnimator, tempLeftAnimator;
    private Collider2D tempRightBoxCol2D, tempLeftBoxCol2D, doubleDoorCol2D;
    private Vector2 tempRightUpperDoor, tempLeftUpperDoor;
    //--------Door Temp Variables--------

    //--------Colliders & Contacts--------
    [SerializeField] private ContactFilter2D doorZoneFilter;
    [SerializeField] public BoxCollider2D[] boxColliders = new BoxCollider2D[0];
    [SerializeField] public CircleCollider2D circleCollider;
    private Collider2D[] doorZoneDetectionResults = new Collider2D[16];
    //--------Colliders & Contacts--------

    //--------Door Boolean Variables--------
    private bool isPlayerInsideDoorZone;
    private bool rightDoor, leftDoor;
    private bool openDoorPulse, closeDoorPulse;
    //--------Door Boolean Variables--------


    //public bool setTrueRight, setTrueLeft, hitOpenableDoorRight, hitOpenableDoorLeft;
    

    private void Start()
    {
        
        playerRb = GetComponent<Rigidbody2D>();
        transform.position = PlayerData.playerTransformPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roboAnimator.SetBool("lockpick", true);
        }
        else
        {
            roboAnimator.SetBool("lockpick", false);
        }


        horizontalInput = Input.GetAxisRaw("Horizontal");

        //CheckHitRaycast();

        DoorController();

        UpdateIsInsideDoorZone();
        Flip();
        
    }
    private void FixedUpdate()
    {
        MoveRobo();
    }

    private void OpenDoor()
    {
        if (playerRaycastHitDoor.rigidbody.tag == "OpenableDoorRight")
        {

            tempRightAnimator = playerRaycastHitDoor.collider.GetComponent<Animator>();
            tempRightBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempRightUpperDoor = playerRaycastHitDoor.collider.gameObject.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempRightAnimator.SetBool("rightDoorIsOpening", true);
            if (tempRightUpperDoor.y > 3.5f)
            {
                tempRightBoxCol2D.enabled = false;
                closeDoorPulse = true;
                openDoorPulse = false;
            }
        }
        else if (playerRaycastHitDoor.rigidbody.tag == "OpenableDoorLeft")
        {

            tempLeftAnimator = playerRaycastHitDoor.collider.GetComponent<Animator>();
            tempLeftBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempLeftUpperDoor = playerRaycastHitDoor.collider.gameObject.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempLeftAnimator.SetBool("leftDoorIsOpening", true);
            if (tempLeftUpperDoor.y > 3.5f)
            {
                tempLeftBoxCol2D.enabled = false;
                closeDoorPulse = true;
                openDoorPulse = false;
            }
        }
    }

    private void OpenBoth()
    {
        if (playerRaycastHitDoor.rigidbody.tag == "OpenableDoorDouble")
        {
            doubleDoorRight = GameObject.Find("Oik_ovi");
            doubleDoorLeft = GameObject.Find("Vas_ovi");
            doubleDoorCol2D = playerRaycastHitDoor.collider;

            tempRightAnimator = doubleDoorRight.GetComponent<Animator>();
            //tempRightBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempRightUpperDoor = doubleDoorRight.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempRightAnimator.SetBool("rightDoorIsOpening", true);

            tempLeftAnimator = doubleDoorLeft.GetComponent<Animator>();
            //tempLeftBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempLeftUpperDoor = doubleDoorLeft.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempLeftAnimator.SetBool("leftDoorIsOpening", true);

            if (tempRightUpperDoor.y > 3.5f && tempLeftUpperDoor.y > 3.5f)
            {
                doubleDoorCol2D.enabled = false;

                closeDoorPulse = true;
                openDoorPulse = false;
            }
        }
    }
    private void CloseDoorRight()
    {
        tempRightBoxCol2D.enabled = true;
        tempRightAnimator.SetBool("rightDoorIsOpening", false);
    }
    private void CloseDoorLeft()
    {
        tempLeftBoxCol2D.enabled = true;
        tempLeftAnimator.SetBool("leftDoorIsOpening", false);
    }
    private void CloseDoorBoth()
    {
        doubleDoorCol2D.enabled = true;
        tempRightAnimator.SetBool("rightDoorIsOpening", false);
        tempLeftAnimator.SetBool("leftDoorIsOpening", false);
    }


    private void DoorController()
    {
        if (openDoorPulse == false)
        {
            CheckHitRaycastDoor();
        }
        if (playerRaycastHitDoor && openDoorPulse && rightDoor == true && leftDoor == true)
        {
            OpenBoth();
        }

        else if (playerRaycastHitDoor && openDoorPulse == true && rightDoor || playerRaycastHitDoor && openDoorPulse == true && leftDoor)
        {
            //OpenDoor();
        }

        if (closeDoorPulse && !isPlayerInsideDoorZone && rightDoor)
        {
            CloseDoorRight();
        }
        if (closeDoorPulse && !isPlayerInsideDoorZone && leftDoor)
        {
            CloseDoorLeft();
        }
        if (closeDoorPulse && !isPlayerInsideDoorZone && leftDoor && rightDoor)
        {
            CloseDoorBoth();
        }
    }

    private void UpdateIsInsideDoorZone()
    {
        isPlayerInsideDoorZone = playerCollider.OverlapCollider(doorZoneFilter, doorZoneDetectionResults) > 0;
        
    }

    private void CheckHitRaycastDoor()
    {

        Debug.DrawRay(playerPos.position, transform.TransformDirection(Vector2.right) * 2f, Color.red);
        LayerMask maskRoom = LayerMask.GetMask("Room");
        LayerMask maskVent = LayerMask.GetMask("CrawlZone");
        playerRaycastHitDoor = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 2f, maskRoom);
        hitVent = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 2f, maskVent);

        if (playerRaycastHitDoor)
        {
            if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorRight"))
            {
                rightDoor = true;
                openDoorPulse = true;
            }
            else if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorLeft"))
            {
                leftDoor = true;
                openDoorPulse = true;
            }
            else if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorDouble"))
            {
                rightDoor = true;
                leftDoor = true;
                openDoorPulse = true;
            }
        else
            {
                openDoorPulse = false;
            }
        }
        if (hitVent)
        {
            Debug.Log("Et voi nousta");
            Crawl();
        }
        else
        {
            boxColliders[0].enabled = true;
            boxColliders[1].enabled = false;
            circleCollider.enabled = true;
        }
    }



    private void Flip()
    {
        if ((Input.GetAxisRaw("Horizontal") > 0 && facingRight) || (Input.GetAxisRaw("Horizontal") < 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    private void MoveRobo()
    {
        if (horizontalInput > 0)
        {
            roboAnimator.SetBool("move", true);
            playerRb.transform.Translate(Vector2.right * horizontalInput * multiplier * Time.deltaTime);

        }

        else if (horizontalInput < 0)
        {
            roboAnimator.SetBool("move", true);
            playerRb.transform.Translate(Vector2.left * horizontalInput * multiplier * Time.deltaTime);
        }

        else
        {
            roboAnimator.SetBool("move", false);
        }

        //if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    playerRb.velocity = Vector2.right * horizontalInput * forceMultiplier * Time.deltaTime;

        //}

        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    playerRb.velocity = Vector2.left * horizontalInput * forceMultiplierMinus * Time.deltaTime;
        //}
    }
    private void Crawl()
    {
        if (hitVent)
        {
            roboAnimator.SetBool("crawl", true);
            boxColliders[0].enabled = false;
            boxColliders[1].enabled = true;
            circleCollider.enabled = false;
        }
        else
        {
            roboAnimator.SetBool("crawl", false);
            boxColliders[0].enabled = true;
            boxColliders[1].enabled = false;
            circleCollider.enabled = true;
        }
    }
}
