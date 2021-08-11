using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameMusic, winScreen;
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
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameObject.Find("SliderCanvas/MusicSlider/Slider").GetComponent<Slider>().value;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    public void ChangeClip()
    {
        audioSource.clip = winScreen;
        audioSource.Play();
      
    }


}
