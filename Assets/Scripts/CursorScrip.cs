using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScrip : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; //Ei liity hiireen
    [SerializeField] private GameObject cursorSprite; // Hiiren kursorin tilalle tuleva kuva
    [SerializeField] private GameObject target; //Ei liity hiireen
    public float value, maxValue = 36f, minValue = 0f; //Ei liity hiireen


    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false; // Piilottaa alkuperäisen kursorin
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Value: " + value);
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;
        cursorSprite.transform.position = mouseWorldPos;
        SpinTheLock();


    }
    private void SpinTheLock()
    {
        var mouseWheel = Input.GetAxisRaw("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            if (value < maxValue)
            {
                value++;

                target.transform.Rotate(new Vector3(0, 0, transform.rotation.z + 10f));
            }
        }
        if (mouseWheel < 0)
        {
            if (value > minValue)
            {
                value--;
                target.transform.Rotate(new Vector3(0, 0, transform.rotation.z - 10f));
            }
        }
    }
}
