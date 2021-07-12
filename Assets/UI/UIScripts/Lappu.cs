using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lappu : MonoBehaviour
{
    public GameObject vastaukset;
    public Slot drop;

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
            Vastaukset.sceneActive = true;
        }
    }
    public void OnMouseDown()
    {
        if(Vastaukset.sceneActive == true)
        {
            //LappuVastaukset(Clone)
            //Instantiate(vastaukset, new Vector3(5.77f, 2.35f, 0f), Quaternion.identity);
            var lappuVastaukset = Instantiate(vastaukset, GameObject.Find("IfLappuExist").transform.position, Quaternion.identity) as GameObject;
            PlayerData.lappuVastaukset[0] = lappuVastaukset;
            drop.DropItem();
        }
        
    }
}
