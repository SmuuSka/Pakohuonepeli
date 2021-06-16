using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    [SerializeField]
    Transform center;
    GameObject ruuvvari;
    public Slot funct;
    private void Start()
    {
        ruuvvari = GameObject.Find("Scruuvvari");
        ruuvvari.SetActive(false);
        funct = GameObject.Find("Slot").GetComponent<Slot>();
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
    }
}
