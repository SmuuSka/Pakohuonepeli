using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WinScript : MonoBehaviour
{
    public Kello time;
    MongoDatabase db;
    PlayerScript playerManager;
    public double baseScore = 600;

    private void Start()
    {
        db = GameObject.Find("Database").GetComponent<MongoDatabase>();
        playerManager = db.GetComponent<PlayerScript>();
        time = GameObject.Find("InGameUI").GetComponent<Kello>();
    }

    public void StopClock()
    {
        playerManager.playerData.score = Convert.ToDouble(baseScore - time.timeValue);
    }

    public async void PlayerData()
    {
        var playersData = db.LoadPlayer();
        var dict = await playersData;

        foreach (KeyValuePair<string, double> player in dict)
        {
            if (player.Key == playerManager.playerData.playerName)
            {
                var defaultScore = player.Value;
                var currentPlayerScore = playerManager.playerData.score;

                if (currentPlayerScore < defaultScore)
                {
                    db.NewHighScore(player.Key, currentPlayerScore);
                }
            }
        }
    }

    public IEnumerator WaitBeforeScore()
    {
        StopClock();
        PlayerData();
        playerManager.playerData.Reset();
        yield return new WaitForSeconds(0.5f);
        //playerManager.playerData.playerName = null;
        //playerManager.playerData.score = 0;
        StopCoroutine(WaitBeforeScore());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(WaitBeforeScore());
        
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("InGameUI"));
        GameObject.Find("-------Sounds-------").GetComponent<SoundController>().WinScreenClip();
        //Destroy(GameObject.Find("SliderCanvas"));
        SceneManager.LoadScene("EndScreen");       
    }   
}
