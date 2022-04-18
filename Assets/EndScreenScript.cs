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
        SceneManager.LoadScene("LoginScreen");
        PlayerData.ResetData();
        Destroy(GameObject.Find("GameMusic"));
        Destroy(GameObject.Find("Hand"));
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
