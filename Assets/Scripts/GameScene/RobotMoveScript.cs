using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ContactFilter2D doorZoneFilter;

    private Collider2D[] doorZoneDetectionResults = new Collider2D[16];

    
    private Rigidbody2D playerRb;
    private float horizontalInput;
    private float forceMultiplier = 200f, forceMultiplierMinus = -200;
    public bool setTrueRight, setTrueLeft, isInsideDoorZone, hitOpenableDoor;


    private void Start()
    {
        

        if (PlayerData.playerTransformPos == null)
        {
            transform.position = playerPos.position;
        }
        else
        {
            playerPos.position = PlayerData.playerTransformPos;
        }
        playerRb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //playerPos.position = new Vector2(transform.position.x, transform.position.y);
        CheckHitRaycast();
        UpdateIsInsideDoorZone();

    }

    private void UpdateIsInsideDoorZone()
    {
        isInsideDoorZone = playerCollider.OverlapCollider(doorZoneFilter, doorZoneDetectionResults) > 0;
        Debug.Log("Inside" + isInsideDoorZone);
    }

    private void CheckHitRaycast()
    {

        Debug.DrawRay(playerPos.position, transform.TransformDirection(Vector2.right) * 3f, Color.red);
        LayerMask maskRoom = LayerMask.GetMask("Room");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, maskRoom);
        //Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, mask

        if (hit)
        {
            Debug.Log("tag " + hit.rigidbody.gameObject.tag);
            if (hit.rigidbody.CompareTag("OpenableDoor"))
            {
                hitOpenableDoor = true;
                //if (GameObject.FindGameObjectWithTag("Room").GetComponent<RoomScript>().stop)
                //{
                //    hitOpenableDoor = false;
                //}
                //setTrueRight = true;
                //setTrueLeft = true;
            }
            else
            {
                hitOpenableDoor = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerPos.rotation = new Quaternion(0, 0, 0, 0);
            playerRb.velocity = Vector2.right * horizontalInput * forceMultiplier * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerPos.rotation = new Quaternion(0, 180, 0, 0);
            playerRb.velocity = Vector2.left * horizontalInput * forceMultiplierMinus * Time.deltaTime;
        }
    }

  
}
