using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dropzone : MonoBehaviour
{
    [SerializeField] private GameObject propel;

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
        zone = GameObject.Find("/Ventti (1)/Dropzone").GetComponent<Transform>().transform.position;
        
        if (propel == null)
        {
            return;
        }
        else
        {
            float dist = Vector2.Distance(playerPos, propel.transform.position);//zone

            if (dist < 10 && dist > -10)
            {
                useable = true;
                //Debug.Log("Ruuvari " + useable);
            }
            else
            {
                useable = false;
            }
        }

    }
    public void OnMouseDown()
    {
        if (GameObject.Find("Hand").GetComponent<Inventory>().isFull[0] == true && GameObject.Find("Canvas").GetComponentInChildren<UICursorScript>().cursorActive == true && useable == true)
        {
            ruuvvari.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            funct.DropItem();
        }

    }
    //public void ScrewDriverDrop()
    //{

    //}
}
