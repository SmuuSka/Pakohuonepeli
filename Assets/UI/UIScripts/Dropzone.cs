using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    [SerializeField]
    Transform center;
    GameObject ruuvvari;
    public Slot funct;

    [SerializeField]
    GameObject patteri;
    public Slot unct;

    private void Start()
    {
        ruuvvari = GameObject.Find("Scruuvvari");
        ruuvvari.SetActive(false);
        funct = GameObject.Find("Slot").GetComponent<Slot>();

        patteri = GameObject.Find("Patteri");
        patteri.SetActive(false);
        unct = GameObject.Find("Slot").GetComponent<Slot>();

    }
    private void OnMouseDown()
    {
        Debug.Log("HiiriDropzonella");

        if (this.gameObject.tag == "DropZone" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true) 
        {
            ruuvvari.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            funct.DropItem();
        }

        if (this.gameObject.tag == "DropZoneBattery" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true)
        {
            patteri.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            unct.DropItem();
        }
    }
}
