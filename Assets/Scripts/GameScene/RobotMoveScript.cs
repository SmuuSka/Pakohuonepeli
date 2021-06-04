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
    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.red);
        LayerMask mask = LayerMask.GetMask("Room");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, 9);
        
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f, mask))
        {
            if (hit.distance <= 3f && GameObject.Find("/Huone_Final_1/Oik_ovi").tag == "Door")
            {
                GameObject.Find("/Huone_Final_1/Oik_ovi").SetActive(false);
            }
        }  
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

    }
}
