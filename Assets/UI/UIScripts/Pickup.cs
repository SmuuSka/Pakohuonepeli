using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameObject itemButton;
    public Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Hand").GetComponent<Inventory>();
    }
    public void Additem(GameObject item)
    {
        bool itemAdded = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                
                Instantiate(itemButton, inventory.slots[i].transform, false);
                itemAdded = true;
                if (itemButton.name == "LappuPrefab")
                {
                    PlayerData.lappuPrefab.Add(itemButton);
                }
                
                break;
            }
        }

        if (itemAdded)
        {
            Debug.Log("Added to inventory");
            gameObject.SetActive(false);
        }
    }
}
