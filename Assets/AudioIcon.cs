using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioIcon : MonoBehaviour
{
    [SerializeField] private Image[] audioIcon = new Image[0];
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            audioIcon[0].enabled = true;
            audioIcon[1].enabled = false;
        }
        else
        {
            audioIcon[1].enabled = true;
            audioIcon[0].enabled = false;
        }
    }
}
