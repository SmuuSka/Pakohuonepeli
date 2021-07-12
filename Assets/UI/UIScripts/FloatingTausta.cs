using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTausta : MonoBehaviour
{
    public float Destroytime = 3f;
    public Vector3 Offset = new Vector3(0, 2, -1);
    
    void Start()
    {     
        Destroy(gameObject, Destroytime);
        transform.localPosition += Offset;
    }
}
