using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dropzone : MonoBehaviour
{
    [SerializeField]
    Transform center;
    GameObject ruuvvari;
    public Slot funct;
    private Vector2 playerPos, zone;
    private bool useable = false;


    private void Start()
    {
        ruuvvari = GameObject.Find("Scruuvvari");
        ruuvvari.SetActive(false);
        funct = GameObject.Find("Slot").GetComponent<Slot>();
    }

    private void Update()
    {
        playerPos = GameObject.Find("Robo").GetComponent<Transform>().transform.position;
        zone = GameObject.Find("Dropzone").GetComponent<Transform>().transform.position;
        float dist = Vector2.Distance(playerPos, zone);

        if (dist < 3 && dist > -3)
        {
            useable = true;
        }
        else
        {
            useable = false;
        }
    }
    private void OnMouseDown()
    {
        if (this.gameObject.tag == "DropZone" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true && useable == true) 
        {
            ruuvvari.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            funct.DropItem();
        }
    }
}
