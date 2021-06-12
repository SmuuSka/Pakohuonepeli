using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ContactFilter2D doorZoneFilter;
    [SerializeField] private BoxCollider2D[] boxColliders = new BoxCollider2D[0];

    private Collider2D[] doorZoneDetectionResults = new Collider2D[16];
    private Rigidbody2D playerRb;

    private float horizontalInput;
    private float forceMultiplier = 200f, forceMultiplierMinus = -200;

    private bool crawl;

    public bool setTrueRight, setTrueLeft, isInsideDoorZone, hitOpenableDoorRight;
    private bool facingRight;

    private void Start()
    {
        
        //playerPos.position = PlayerData.playerTransformPos;

        playerRb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crawl = true;
        }
        else
        {
            crawl = false;
        }

        if (!crawl)
        {
            boxColliders[0].enabled = true;
            boxColliders[1].enabled = false;
        }
        else
        {
            boxColliders[0].enabled = false;
            boxColliders[1].enabled = true;
        }
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        CheckHitRaycast();
        UpdateIsInsideDoorZone();
        Flip();
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
        

        if (hit)
        {
            Debug.Log("tag " + hit.rigidbody.gameObject.tag);
            if (hit.rigidbody.CompareTag("OpenableDoorRight"))
            {
                hitOpenableDoorRight = true;
            }
            else
            {
                hitOpenableDoorRight = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerRb.velocity = Vector2.right * horizontalInput * forceMultiplier * Time.deltaTime;
            
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerRb.velocity = Vector2.left * horizontalInput * forceMultiplierMinus * Time.deltaTime;
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
}
