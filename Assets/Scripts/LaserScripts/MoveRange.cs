using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRange : MonoBehaviour
{
    private bool canMove = true;
    private bool dirUp = true;
    public float speed = 2f;
    public float maxY = 0.15f;
    public float minY = 0f;
    Rigidbody2D rb;
    [SerializeField] GameObject[] haitat = new GameObject[0];
    private int luku = 0;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject[] greens = new GameObject[0];
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = haitat[luku].GetComponent<Rigidbody2D>();
        goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RangeMove();
        }
        Debug.Log("speed" + speed);
        CheckPos();
    }
    private void RangeMove()
    {
        if (dirUp)
        {
            haitat[luku].transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            haitat[luku].transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

        if (haitat[luku].transform.position.y >= 1.5f)
        {
            dirUp = false;
        }

        if (haitat[luku].transform.position.y <= -1.3f)
        {
            dirUp = true;
        }
    }


    private void CheckPos()
    {
        switch (luku)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 2;
                    count++;
                    luku++;
                }
                break;
            case 1:
                canMove = true;
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 2.5f;
                    count++;
                    luku++;
                }
                break;
            case 2:
                canMove = true;
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 3f;
                    count++;
                    luku++;
                }
                break;
            case 3:
                canMove = true;
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 3.5f;
                    count++;
                    luku++;
                }
                break;
            case 4:
                canMove = true;
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 4f;
                    count++;
                    luku++;
                }
                break;
            case 5:
                canMove = true;
                if (Input.GetKeyDown(KeyCode.Space) && haitat[luku].transform.position.y < maxY && haitat[luku].transform.position.y > minY)
                {
                    haitat[luku].transform.position = new Vector2(haitat[luku].transform.position.x, 0.048f);
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    greens[count].SetActive(true);
                    canMove = false;
                    speed = 4.5f;
                    count++;
                    luku++;
                    goal.SetActive(true);
                }
                break;
            default:
                greens[count].SetActive(true);
                break;
        }
        


        //Debug.Log("ei osu");
        //if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.y < maxY && gameObject.transform.position.y > minY)
        //{
        //    transform.position = new Vector2(transform.position.x, 0.048f);
        //    rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //    canMove = false;
        //    Debug.Log("osuu");
        //}
    }

}
