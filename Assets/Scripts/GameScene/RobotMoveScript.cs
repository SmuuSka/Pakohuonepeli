using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ContactFilter2D doorZoneFilter;
    

    //[SerializeField] private Transform castPoint;

    private Rigidbody2D playerRb;
    private float horizontalInput;
    private float forceMultiplier = 200f, forceMultiplierMinus = -200;
    private bool setTrueRight, setTrueLeft, isInsideDoorZone;
    private Collider2D[] doorZoneDetectionResults = new Collider2D[16] ;
    private bool sendPulse;

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
        playerPos.position = new Vector2(transform.position.x, transform.position.y);
        //Debug.Log("Player Pos " + playerPos.position);
        DoorLogic();
        OpenDoor();
        UpdateIsInsideDoorZone();

        if (sendPulse)
        {
            StartCoroutine(ShutTheDoor());
        }
    }

    private void UpdateIsInsideDoorZone()
    {
        isInsideDoorZone = playerCollider.OverlapCollider(doorZoneFilter, doorZoneDetectionResults) > 0;
        Debug.Log("Inside" + isInsideDoorZone);
    }

    private void DoorLogic()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.red);
        LayerMask maskRoom = LayerMask.GetMask("Room");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, maskRoom);
        //Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, mask

        if (hit)
        {
            if (hit.rigidbody.CompareTag("OpenableDoor"))
            {
                setTrueRight = true;
                setTrueLeft = true;
                if (GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position.y > 4f && GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ala").transform.position.y < -4f && GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ylä").transform.position.y > 4f && GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ala").transform.position.y < -4f)
                {
                    setTrueRight = false;
                    setTrueLeft = false;
                    GameObject.Find("/Huone_Final/Oik_ovi").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("/Huone_Final_1/Vas_ovi").GetComponent<BoxCollider2D>().enabled = false;
                    sendPulse = true;
                }
            }
        }
    }
            //if (hit.collider.name == "Oik_ovi" && GameObject.Find("Huone_Final").GetComponent<RoomScript>().rightDoorCanBeOpened == false)
            //{
            //    Debug.Log("Ovea ei voi avata");
            //}


            //if (hit.collider.name == "Vas_ovi" && GameObject.Find("Huone_Final_1").GetComponent<RoomScript>().leftDoorCanBeOpened == true)
            //{
            //    setTrueLeft = true;
            //    if (GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ylä").transform.position.y > 4f && GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ala").transform.position.y < -4f)
            //    {
            //        setTrueLeft = false;
            //        GameObject.Find("/Huone_Final_1/Vas_ovi").GetComponent<BoxCollider2D>().enabled = false;
            //    }
            //}
       
    

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

    private void OpenDoor()
    {
        if (setTrueRight)
        {
            //GameObject.Find("/Huone_Final/Oik_ovi").transform.position = new Vector2(GameObject.Find("/Huone_Final/Oik_ovi").transform.position.x, GameObject.Find("/Huone_Final/Oik_ovi").transform.position.y - 1f * Time.deltaTime);
            GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position = new Vector2(GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position.x, GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position.y + 1f * Time.deltaTime);
            GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ala").transform.position = new Vector2(GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ala").transform.position.x, GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ala").transform.position.y - 1f * Time.deltaTime);
        }
        if (setTrueLeft)
        {
            GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ylä").transform.position = new Vector2(GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ylä").transform.position.x, GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ylä").transform.position.y + 1f * Time.deltaTime);
            GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ala").transform.position = new Vector2(GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ala").transform.position.x, GameObject.Find("/Huone_Final_1/Vas_ovi/Ovi_ala").transform.position.y - 1f * Time.deltaTime);
        }
            //if (GameObject.Find("/Huone_Final/Oik_ovi").transform.position.y < -6.5f)
            //{
            //    setTrue = false;
            //}
    }
    private IEnumerator ShutTheDoor()
    {
        
        if (!isInsideDoorZone)
        {
            
            yield return new WaitForSeconds(1);
            
            GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position = new Vector2(GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position.x, GameObject.Find("/Huone_Final/Oik_ovi/Ovi_ylä").transform.position.y - 1f * Time.deltaTime);
            
        }
    }
}
