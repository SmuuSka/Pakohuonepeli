using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHighlight : MonoBehaviour
{

    [SerializeField] private GameObject[] wheelObject = new GameObject[3];
    [SerializeField] private GameObject cursor;
    [SerializeField] Color highlightColor;
    [SerializeField] Color defaultColor;

    private int index;
    private bool moveToTask;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;
        cursor.transform.position = mouseWorldPos;

        Debug.Log("Task " + moveToTask);

        if (moveToTask)
        {
            OnMouseEnter();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PeliObjekti") && collision.gameObject == wheelObject[0])
        {
            wheelObject[0].GetComponent<SpriteRenderer>().material.color = highlightColor;
            index = 1;
            moveToTask = true;


        }
        if (collision.gameObject.CompareTag("PeliObjekti") && collision.gameObject == wheelObject[1])
        {
            wheelObject[1].GetComponent<SpriteRenderer>().color = highlightColor;
            index = 2;
            moveToTask = true;

        }
        if (collision.gameObject.CompareTag("PeliObjekti") && collision.gameObject == wheelObject[2])
        {
            wheelObject[2].GetComponent<SpriteRenderer>().color = highlightColor;
            index = 3;
            moveToTask = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        wheelObject[0].GetComponent<SpriteRenderer>().material.color = defaultColor;
        wheelObject[1].GetComponent<SpriteRenderer>().color = defaultColor;
        wheelObject[2].GetComponent<SpriteRenderer>().color = defaultColor;
        moveToTask = false;
    }
    private void OnMouseEnter()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(0);
            moveToTask = false;
        }

    }
}
