using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillArea : MonoBehaviour
{
    [SerializeField] private Image fillSlider;
    [SerializeField] private GameObject referenceValue;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        fillSlider.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        value = referenceValue.GetComponent<CursorScrip>().currentValue / 100 * 2.7777f;
        fillSlider.fillAmount = value;
    }
}
