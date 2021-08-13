using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject startButton, quitButton;

    public void StartGame()
    {
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().GameMusicClip();
        SceneManager.LoadScene("Cutscene");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
