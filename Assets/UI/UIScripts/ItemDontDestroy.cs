using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDontDestroy : MonoBehaviour
{
    public static ItemDontDestroy itemsave;

    void Awake()
    {
        if (itemsave != null && itemsave != this)
            Destroy(this.gameObject);
        else
        {
            itemsave = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
