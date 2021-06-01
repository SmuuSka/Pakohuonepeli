using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Button buttonObject;

    private void Start()
    {
        buttonObject.onClick.AddListener(GoGame);
    }

    private void GoGame()
    {
        SceneManager.LoadScene(0);
    }
}
