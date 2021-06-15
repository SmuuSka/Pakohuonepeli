using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverScript : MonoBehaviour
{
    private void Start()
    {
        

        if (!PlayerData.ToolboxTaskDone)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
