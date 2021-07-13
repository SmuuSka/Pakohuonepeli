using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vastaukset : MonoBehaviour
{
    public GameObject answers;
    public GameObject vastauksetPrefab;
    
    private Lappu lappuScript;

    public void Start()
    {
        if (PlayerData.lappuCopy.Count != 0 && PlayerData.lappuCopy.Count < 1)
        {
            Instantiate(PlayerData.lappuCopy[0]);
        }
        else if (GameObject.Find("Canvas/Slot/LappuPrefab(Clone)") != null)
        {
            answers = GameObject.Find("LappuVastaukset");
            answers.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            lappuScript = GameObject.Find("/Canvas/Slot/LappuPrefab(Clone)").GetComponent<Lappu>();
        }
        else
        {
            answers = GameObject.Find("LappuVastaukset");
            answers.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            return;
        }
    }
    private void Update()
    {
        if (lappuScript != null)
        {
            LappuMethod();
            
        }
        else if (PlayerData.lappuCopy.Count > 0 && lappuScript == null)
        {
            PlayerData.lappuCopy[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            return;
        }
        else
        {
            return;
        }
        
    }
    private void LappuMethod()
    {
        if (lappuScript.isPressedLappu)
        {
            var lappu = Instantiate(answers);
            lappu.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            if (lappu.GetComponent<DontDestroyLappuClone>() == null)
            {
                lappu.AddComponent<DontDestroyLappuClone>();
            }
            PlayerData.lappuCopy.Add(lappu);
            lappuScript.isPressedLappu = false;
        }
    }
}
