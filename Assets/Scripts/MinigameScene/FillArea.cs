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
        
        
        
        
        //fillSlider.value = value;
        //Debug.Log("Fill Slider Status " + fillSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        value = referenceValue.GetComponent<CursorScrip>().currentValue / 100 * 2.7777f;
        fillSlider.fillAmount = value;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerData.lappuPrefab != null)
            {
                Instantiate(PlayerData.lappuPrefab[0], GameObject.Find("/Lock Wheel/LockSceneCanvas/Lappu").transform);
            }
            else
            {
                return;
            }
        }
    }
}
