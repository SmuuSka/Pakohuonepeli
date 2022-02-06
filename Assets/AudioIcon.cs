using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioIcon : MonoBehaviour
{
    [SerializeField] private Image[] audioIcon = new Image[0];
    [SerializeField] private Slider slider;
    private Color iconColor;
    // Start is called before the first frame update
    void Start()
    {
        iconColor = audioIcon[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        var currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Cutscene")
        {
            audioIcon[0].color = Color.clear;
            audioIcon[1].color = Color.clear;
            slider.gameObject.SetActive(false);
        }
        else
        {
            audioIcon[0].color = iconColor;
            audioIcon[1].color = iconColor;
            slider.gameObject.SetActive(true);
        }

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
