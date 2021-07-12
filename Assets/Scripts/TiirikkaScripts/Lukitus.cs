using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lukitus : MonoBehaviour
{
    [SerializeField] GameObject[] sylinterit = new GameObject[0];
    Rigidbody2D rb;
    private int luku = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = sylinterit[luku].GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnLukossa();
    }

    private void OnLukossa()
    {
        switch (luku)
        {
            case 0:
                if (sylinterit[luku].transform.position.y > 0.35f)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                }
                break;
            case 1:
                if (sylinterit[luku].transform.position.y > 0.36f)
                {
                    rb = sylinterit[luku].GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                }
                break;
            case 2:
                if (sylinterit[luku].transform.position.y > 0.36f)
                {
                    rb = sylinterit[luku].GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                }
                break;
            case 3:
                if (sylinterit[luku].transform.position.y > 0.36f)
                {
                    rb = sylinterit[luku].GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                }
                break;
            case 4:
                if (sylinterit[luku].transform.position.y > 0.36f)
                {
                    rb = sylinterit[luku].GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                }
                break;
            case 5:
                if (sylinterit[luku].transform.position.y > 0.36f)
                {
                    rb = sylinterit[luku].GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    luku++;
                    StartCoroutine(Delay());

                }
                break;           
            default:
                break;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameView");
    }
}
