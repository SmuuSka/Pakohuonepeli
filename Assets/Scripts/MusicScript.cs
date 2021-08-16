using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().GameMusicClip();
        Debug.Log("Latas");
    }
}
