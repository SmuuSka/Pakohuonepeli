using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ContactFilter2D doorZoneFilter;
    [SerializeField] public BoxCollider2D[] boxColliders = new BoxCollider2D[0];
    [SerializeField] public CircleCollider2D circleCollider;

    private Collider2D[] doorZoneDetectionResults = new Collider2D[16];
    private Rigidbody2D playerRb;
    public RaycastHit2D hit, hitVent;

    private float horizontalInput;
    private float forceMultiplier = 400f, forceMultiplierMinus = -400;

    private bool crawl;

    public bool setTrueRight, setTrueLeft, isInsideDoorZone, hitOpenableDoorRight, hitOpenableDoorLeft;
    private bool facingRight;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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

        Debug.DrawRay(playerPos.position, transform.TransformDirection(Vector2.right) * 1f, Color.red);
        LayerMask maskRoom = LayerMask.GetMask("Room");
        LayerMask maskVent = LayerMask.GetMask("CrawlZone");
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f, maskRoom);
        hitVent = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f, maskVent);


        if (hit)
        {
            if (hit.rigidbody.CompareTag("OpenableDoorRight"))
            {
                hitOpenableDoorRight = true;

            }
            else if (hit.rigidbody.CompareTag("OpenableDoorLeft"))
            {
                hitOpenableDoorLeft = true;
            }
            else
            {
                hitOpenableDoorRight = false;
                hitOpenableDoorLeft = false;
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

    private void FixedUpdate()
    {
        MoveRobo();
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
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerRb.velocity = Vector2.right * horizontalInput * forceMultiplier * Time.deltaTime;

        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerRb.velocity = Vector2.left * horizontalInput * forceMultiplierMinus * Time.deltaTime;
        }
    }
    private void Crawl()
    {
            boxColliders[0].enabled = false;
            boxColliders[1].enabled = true;
            circleCollider.enabled = false;
    }
}
