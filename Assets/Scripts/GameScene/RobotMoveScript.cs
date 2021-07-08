using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    //--------Player Variables--------
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] public Animator roboAnimator;
    private Vector2 playerVectorPos;
    private Rigidbody2D playerRb;
    private float horizontalInput;
    private int multiplier = 5;
    private bool facingRight;
    private bool crawl;

    public RaycastHit2D playerRaycastHitDoor, hitVent;
    //--------Player Variables--------

    //--------Door Temp Variables--------
    private GameObject doubleDoorLeft, doubleDoorRight;
    private Animator tempRightAnimator, tempLeftAnimator, tempRightAnimatorDoubleDoors, tempLeftAnimatorDoubleDoors;
    private Collider2D tempRightBoxCol2D, tempLeftBoxCol2D, doubleDoorCol2D;
    private Vector2 tempRightUpperDoor, tempLeftUpperDoor, tempRightUpperDoubleDoor, tempLeftUpperDoubleDoor;
    //--------Door Temp Variables--------

    //--------Colliders & Contacts--------
    [SerializeField] private ContactFilter2D doorZoneFilter;
    [SerializeField] public BoxCollider2D[] boxColliders = new BoxCollider2D[0];
    [SerializeField] public CircleCollider2D circleCollider;
    private Collider2D[] doorZoneDetectionResults = new Collider2D[16];
    //--------Colliders & Contacts--------

    //--------Door Boolean Variables--------
    private bool isPlayerInsideDoorZone;
    private bool rightDoor, leftDoor, rightDoubleDoor, leftDoubleDoor;
    private bool openDoorPulse, closeDoorPulse;
    //--------Door Boolean Variables--------


    //public bool setTrueRight, setTrueLeft, hitOpenableDoorRight, hitOpenableDoorLeft;

    private void Awake()
    {
        PlayerData.facingStatic = true;
        if (PlayerData.playerTransformPos != null)
        {
            transform.position = PlayerData.playerTransformPos;
            
        }
        
        if (PlayerData.facingStatic == true)
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if (PlayerData.facingStatic == false)
        {            
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }


    }

    private void Start()
    {
        Debug.Log("First Pos " + PlayerData.firstPos);
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Debug.Log(PlayerData.ToolboxTaskDone + "toimii jeejee");

        Debug.Log(!PlayerData.ToolboxTaskDone + "toimii");

        playerVectorPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

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
            if (playerRaycastHitDoor.rigidbody.GetComponent<DoorIndex>().doorIndex == 1)
            {
                doubleDoorRight = GameObject.Find("/DoubleDoorCollider/Oik_ovi");
                doubleDoorLeft = GameObject.Find("/DoubleDoorCollider/Vas_ovi");
            }
            else if (playerRaycastHitDoor.rigidbody.GetComponent<DoorIndex>().doorIndex == 2)
            {
                doubleDoorRight = GameObject.Find("/DoubleDoorCollider_1/Oik_ovi");
                doubleDoorLeft = GameObject.Find("/DoubleDoorCollider_1/Vas_ovi");
            }


            doubleDoorCol2D = playerRaycastHitDoor.collider;

            tempRightAnimatorDoubleDoors = doubleDoorRight.GetComponent<Animator>();
            //tempRightBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempRightUpperDoubleDoor = doubleDoorRight.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempRightAnimatorDoubleDoors.SetBool("rightDoorIsOpening", true);

            tempLeftAnimatorDoubleDoors = doubleDoorLeft.GetComponent<Animator>();
            //tempLeftBoxCol2D = playerRaycastHitDoor.collider.GetComponent<BoxCollider2D>();
            tempLeftUpperDoubleDoor = doubleDoorLeft.GetComponentInChildren<Transform>().Find("Ovi_ylä").GetComponent<Transform>().position;
            tempLeftAnimatorDoubleDoors.SetBool("leftDoorIsOpening", true);

            if (tempRightUpperDoubleDoor.y > 3.5f && tempLeftUpperDoubleDoor.y > 3.5f)
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
        tempRightAnimatorDoubleDoors.SetBool("rightDoorIsOpening", false);
        tempLeftAnimatorDoubleDoors.SetBool("leftDoorIsOpening", false);
    }


    private void DoorController()
    {
        if (openDoorPulse == false)
        {
            CheckHitRaycastDoor();
        }
        if (openDoorPulse == true && rightDoubleDoor == true && leftDoubleDoor == true)
        {
            Debug.Log("Avaa molemmat");
            OpenBoth();
        }
        if (closeDoorPulse == true && !isPlayerInsideDoorZone == true && leftDoubleDoor == true && rightDoubleDoor == true)
        {
            CloseDoorBoth();
        }
        //Left Door
        if (playerRaycastHitDoor && openDoorPulse && leftDoor == true)
        {
            OpenDoor();
        }
        if (closeDoorPulse && !isPlayerInsideDoorZone && leftDoor)
        {
            CloseDoorLeft();
        }
        //Right Door

        if (playerRaycastHitDoor && openDoorPulse && rightDoor == true)
        {
            OpenDoor();
        }

        if (closeDoorPulse && !isPlayerInsideDoorZone && rightDoor)
        {
            CloseDoorRight();
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
            if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorDouble"))
            {
                openDoorPulse = true;
                rightDoubleDoor = true;
                leftDoubleDoor = true;

            }
            else if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorRight"))
            {
                rightDoor = true;
                openDoorPulse = true;
            }
            else if (playerRaycastHitDoor.rigidbody.CompareTag("OpenableDoorLeft"))
            {
                leftDoor = true;
                openDoorPulse = true;
            }

        }
        if (hitVent)
        {
            Debug.Log("Et voi nousta");
            
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
        if (horizontalInput > 0)
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            facingRight = true;
            PlayerData.facingStatic = true;
        }
        if (horizontalInput < 0)
        {
            transform.localRotation = new Quaternion(0, 180, 0, 0);
            facingRight = false;
            PlayerData.facingStatic = false;
        }
    }
    private void MoveRobo()
    {
        if (horizontalInput > 0)
        {
            Flip();
            roboAnimator.SetBool("move", true);
            playerRb.transform.Translate(Vector2.right * horizontalInput * multiplier * Time.deltaTime);
            Crawl();

        }

        else if (horizontalInput < 0)
        {
            Flip();
            roboAnimator.SetBool("move", true);
            playerRb.transform.Translate(Vector2.left * horizontalInput * multiplier * Time.deltaTime);
            Crawl();
        }

        else
        {
            roboAnimator.SetBool("move", false);
        }
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
