using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TamaScripti : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(asd());
    }

    void Update()
    {
        asd();
    }

    public IEnumerator asd()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("GameView");
        //GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuScripts>().UIcanvas.SetActive(true);
    }

}
