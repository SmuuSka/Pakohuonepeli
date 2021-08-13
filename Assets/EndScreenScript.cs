using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public GameObject mainMenuButton, quitButton;


    public void MainMenu()
    {
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().MainMenuClip();
        SceneManager.LoadScene("MainMenu");
        PlayerData.ResetData();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
