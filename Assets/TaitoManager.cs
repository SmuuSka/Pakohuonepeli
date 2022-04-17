using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaitoManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(kek());
    }


    void Update()
    {
        kek();
    }

    public IEnumerator kek()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
