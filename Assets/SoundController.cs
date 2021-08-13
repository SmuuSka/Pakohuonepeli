using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameMusic, winScreen, mainMenu;
    public static SoundController Instance;

    private int sceneIndex;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenuClip();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameObject.Find("SliderCanvas/MusicSlider/Slider").GetComponent<Slider>().value;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    public void GameMusicClip()
    {
        audioSource.clip = gameMusic;
        audioSource.PlayDelayed(7f);
      
    }
    public void WinScreenClip()
    {
        audioSource.clip = winScreen;
        audioSource.Play();
    }
    public void MainMenuClip()
    {
        audioSource.clip = mainMenu;
        audioSource.Play();
    }


}
