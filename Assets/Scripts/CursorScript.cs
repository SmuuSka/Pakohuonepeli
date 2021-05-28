using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public void OnMouseDown()
    {
        Image image = GetComponentInChildren<Image>();
        
        Cursor.SetCursor(image.sprite.texture, Vector2.zero, CursorMode.ForceSoftware);
        
    }
}
