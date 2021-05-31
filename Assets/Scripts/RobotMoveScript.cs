using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveScript : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float horizontalInput;
    public float forceMultiplier = 200f, forceMultiplierMinus = -200;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
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
}
