using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private GameObject[] peliObjekti = new GameObject[0];
    [SerializeField] private Texture2D cursorSprite;
    [SerializeField] Color highlightColor;
    [SerializeField] Color defaultColor;

    //private int index = 0;
    private bool moveToTask;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorSprite, new Vector2(0, 0), CursorMode.ForceSoftware);
        //index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;
        //kursori.transform.position = mouseWorldPos;

        Debug.Log("Task " + moveToTask);

        if (moveToTask)
        {
            OnMouseEnter();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PeliObjekti") && collision.gameObject == peliObjekti[0])
        {
            peliObjekti[0].GetComponent<SpriteRenderer>().material.color = highlightColor;
            moveToTask = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        peliObjekti[0].GetComponent<SpriteRenderer>().material.color = defaultColor;
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
