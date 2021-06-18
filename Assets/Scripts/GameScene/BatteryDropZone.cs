using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDropZone : MonoBehaviour
{
    [SerializeField]
    GameObject patteri;
    public Slot unct;
    GameObject tausta;

    // Start is called before the first frame update
    void Start()
    {
        tausta = GameObject.Find("SlidePuzzleTausta");
        tausta.SetActive(false);
        patteri = GameObject.Find("Patteri");
        patteri.SetActive(false);
        unct = GameObject.Find("Slot").GetComponent<Slot>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (this.gameObject.tag == "DropZoneBattery" && GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true)
        {
            tausta.SetActive(true);
            patteri.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            unct.DropItem();
        }
    }
}
