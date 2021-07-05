using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScripts : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, UIcanvas, InGameUserInterface;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //UIcanvas.SetActive(true);
        //InGameUserInterface.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        UIcanvas.SetActive(false);
        InGameUserInterface.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //Time.timeScale = 0f;
        
    }

    public void Restart()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameView");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
