using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillArea : MonoBehaviour
{
    [SerializeField] private Slider fillSlider;
    [SerializeField] private GameObject referenceValue;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        fillSlider.value = 0;
        
        
        //fillSlider.value = value;
        Debug.Log("Fill Slider Status " + fillSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        value = referenceValue.GetComponent<CursorScrip>().currentValue / 100 * 3.6f;
        Debug.Log(value);
        fillSlider.value = value;
    }
}
