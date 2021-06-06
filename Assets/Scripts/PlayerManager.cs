using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject currentInterObj = null;

    public GameObject currentPickObj = null;

    public Pickup currentPickupScript = null;

    public Inventory inventory; 


    //public GameObject itemButton;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentInterObj) { 
            if (currentPickupScript.inventory)
            {
                currentPickupScript.Additem(currentInterObj);
                
            }
        }
        else if (Input.GetMouseButtonDown(0) && currentPickObj)
        {
            SceneManager.LoadScene("SlidePuzzle");
            
            
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentPickupScript = currentInterObj.GetComponent<Pickup>();
            
        }
        else if (other.CompareTag("Minigame"))
        {
            currentPickObj = other.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
                currentPickupScript = null;
            }
        }
        else if (other.CompareTag("Minigame"))
        {
            currentPickObj = null;
        }
    }
   
}
