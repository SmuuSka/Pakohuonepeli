using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    private bool isOpened;
    private bool canClose = false;
    public GameObject infoPanel;
    public GameObject plyr;

    private void Start()
    {
        infoPanel.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void OpenInfo()
    {
         isOpened = true;
        if(isOpened == true && canClose == false)
        {
            infoPanel.SetActive(true);
            canClose = true;
        }
        else if(canClose == true && isOpened == true)
        {

            infoPanel.SetActive(false);
            isOpened = false;
            canClose = false;
        }
    }
}
