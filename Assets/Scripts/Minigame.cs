using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    [SerializeField]
    private bool interactable = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Minigame"))
        {
            interactable = true;
            
        }
        if (Input.GetMouseButtonDown(0) && interactable)
        {
            SceneManager.LoadScene("SlidePuzzle");
        }
    }
}
