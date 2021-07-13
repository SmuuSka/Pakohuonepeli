using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lappu : MonoBehaviour
{
    public GameObject vastaukset;
    public Slot drop;
    public bool isPressedLappu;

    private void Start()
    {
        drop = GameObject.Find("Slot").GetComponent<Slot>();
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "LockScene")
        {
            PlayerData.scene = true;
        }
    }
    public void OnMouseDown()
    {
        if(PlayerData.scene == true)
        {
            isPressedLappu = true;
            PlayerData.lappuIsTrue = true;
            PlayerData.scene = false;
            drop.DropItem();
        }
        
    }
}
