using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField] private Transform playerFlip;

    [SerializeField] private Transform castPoint;

    private Rigidbody2D playerRb;
    private float horizontalInput;
    private float forceMultiplier = 200f, forceMultiplierMinus = -200;
    private bool setTrue;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        Debug.Log(setTrue);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.red);
        LayerMask mask = LayerMask.GetMask("Room");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, mask);
        //Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, mask
        if (hit)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Oik_ovi" && GameObject.Find("Huone_Final").GetComponent<RoomScript>().rightDoorCanBeOpened == true)
            {
                setTrue = true;
            }
            if (hit.collider.name == "Oik_ovi" && GameObject.Find("Huone_Final").GetComponent<RoomScript>().rightDoorCanBeOpened == false)
            {
                Debug.Log("Ovea ei voi avata");
            }
 
            //if (hit.distance <= 3f)
            //{
            //    Debug.Log("Vasen Ovi");
            //}
        }
        OpenDoor();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerFlip.rotation = new Quaternion(0, 0, 0, 0);
            playerRb.velocity = Vector2.right * horizontalInput * forceMultiplier * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerFlip.rotation = new Quaternion(0, 180, 0, 0);
            playerRb.velocity = Vector2.left * horizontalInput * forceMultiplierMinus * Time.deltaTime;
        }
    }

    private void OpenDoor()
    {
        if (setTrue)
        {
            GameObject.Find("/Huone_Final/Oik_ovi").transform.position = new Vector2(GameObject.Find("/Huone_Final/Oik_ovi").transform.position.x, GameObject.Find("/Huone_Final/Oik_ovi").transform.position.y - 1f * Time.deltaTime);
            if (GameObject.Find("/Huone_Final/Oik_ovi").transform.position.y < -6.5f)
            {
                setTrue = false;
            }
        }
    }
}
