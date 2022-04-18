using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{

    public List<Text> player_txt, score_txt = new List<Text>();
    private int items;

    MongoDatabase db;

    private void Start()
    {
        db = GameObject.Find("Database").GetComponent<MongoDatabase>();
        StartCoroutine(WaitForScore());
    }

    public IEnumerator WaitForScore()
    {
        yield return new WaitForSeconds(0.5f);
        GetScores();
        StopCoroutine(WaitForScore());
    }

    public async void GetScores()
    {
        var getHighscore = db.GetAllHighscores();
        var dict = await getHighscore;
        ShowHighScore(dict);
    }

    public void ShowHighScore(Dictionary<string, double> dict)
    {

        foreach (KeyValuePair<string, double> player in dict.OrderBy(key => key.Value))
        {
            if (items >= 5)
            {
                break;
            }

            player_txt[items].text = player.Key;
            int minutes = (int)(player.Value / 60) % 60;
            int seconds = (int)(player.Value % 60);
            int milliseconds = (int)(player.Value * 100) % 100;
            string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            score_txt[items].text = timeString;
            items += 1;
        }
    }
}
