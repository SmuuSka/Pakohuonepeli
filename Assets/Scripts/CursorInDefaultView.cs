using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInDefaultView : MonoBehaviour
{
    [SerializeField] private Texture2D cursorSprite;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorSprite, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = mouseWorldPos;
    }
}
