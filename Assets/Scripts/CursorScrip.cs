using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScrip : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; //Ei liity hiireen
    [SerializeField] private Texture2D cursorSprite;
    [SerializeField] private GameObject target; //Ei liity hiireen
    
    public float currentValue, maxValue, minValue; //Ei liity hiireen


    // Start is called before the first frame update
    void Start()
    {

        //Cursor.visible = false; // Piilottaa alkuperäisen kursorin
        Cursor.SetCursor(cursorSprite, new Vector2(0,0),CursorMode.ForceSoftware);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Value: " + currentValue);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;
        //cursorSprite.transform.position = mouseWorldPos;
        SpinTheLock();


    }
    private void SpinTheLock()
    {
        var mouseWheel = Input.GetAxisRaw("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            currentValue++;
            target.transform.Rotate(new Vector3(0, 0, transform.rotation.z + 10f));
            if (currentValue == 36)
            {
                currentValue = 0;
            }
        }
        if (mouseWheel < 0)
        {
            currentValue--;
            target.transform.Rotate(new Vector3(0, 0, transform.rotation.z - 10f));

            if (currentValue == -1)
            {
                currentValue = 35;
            }
        }
    }
}
