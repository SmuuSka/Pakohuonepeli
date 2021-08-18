using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Kello : MonoBehaviour
{
    public float timeValue = 600;
    public TMP_Text timeText;

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            StartCoroutine(loppu());
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTime()
    {
        timeValue = 600;
    }

    IEnumerator loppu()
    {
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().gameOverClip();       
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("InGameUI"));

        if (GameObject.Find("LappuVastaukset(Clone)") != null)
        {
            Destroy(GameObject.Find("LappuVastaukset(Clone)"));
        }

    }
}
