using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("InGameUI"));
        SceneManager.LoadScene("EndScreen");       
    }   
}
