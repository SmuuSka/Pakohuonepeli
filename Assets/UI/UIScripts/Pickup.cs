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
        //Ennen klikkausta static bool on false, jos static bool on false, voit noukkia lapun.
        //Kun lappu on kerran noukittu, asetetaan static bool trueksi.
        //Ladatessaan scene uudestaan, tarkistetaan static bool ehto if lauseella.
        //Jos static bool on true, palautetaan(=return)
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
            if (gameObject.name == "Screwdriver")
            {
                gameObject.SetActive(false);
                PlayerData.screwdriver = true;
            }

            if (gameObject.name == "Battery")
            {
                gameObject.SetActive(false);
                PlayerData.battery = true;
            }

            if (gameObject.name == "numerolappu")
            {
                gameObject.SetActive(false);
                PlayerData.postIt = true;
            }
            
        }
    }
}
