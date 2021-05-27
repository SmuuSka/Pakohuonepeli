using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiirikka : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float moveHorizontal, moveVertical;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);        
    }
}
