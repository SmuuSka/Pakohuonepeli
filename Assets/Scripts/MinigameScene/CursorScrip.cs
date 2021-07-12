using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScrip : MonoBehaviour
{
    public float currentValue, maxValue, minValue; 

    void Update()
    {

        SpinTheLock();


    }
    private void SpinTheLock()
    {
        var mouseWheel = Input.GetAxisRaw("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            currentValue++;
            if (currentValue == 36)
            {
                currentValue = 0;
            }
        }
        if (mouseWheel < 0)
        {
            currentValue--;

            if (currentValue == -1)
            {
                currentValue = 35;
            }
        }
    }
}
