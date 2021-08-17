using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject mainMenuButton, quitButton;

    public void MainMenu()
    {
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().MainMenuClip();
        SceneManager.LoadScene("MainMenu");
        PlayerData.ResetData();
        Destroy(GameObject.Find("GameMusic"));
        Destroy(GameObject.Find("Hand"));
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
