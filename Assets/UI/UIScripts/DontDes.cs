using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes : MonoBehaviour
{
    public static DontDes singleton = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(singleton == null)
        {
            singleton = this;
        }
    }
}
