using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField nameInput;
    MongoDatabase db;

    string userNameInput;
    string nameToLower;
    double defaultScore = 600;


    private void Start()
    {
        db = GameObject.Find("Database").GetComponent<MongoDatabase>();
    }   
    private void Update()
    {
        userNameInput = nameInput.text;
    }

    public async void UserCheck()
    {
        var playerName = NameToLower();
        var playersData = db.LoadPlayer();
        var dict = await playersData;

        foreach (var player in dict)
        {
            if (playerName.Equals(player.Key))
            {
                var database = GameObject.Find("Database").GetComponent<PlayerScript>().playerData;

                database.playerName = player.Key;
                database.score = player.Value;

                SceneManager.LoadScene(2);
                return;
            }
        }

        Debug.Log("Pelaajaa ei löytynyt" + playerName);
        nameInput.Select();
        nameInput.text = null;
        userNameInput = null;
        nameToLower = null;
        playerName = null;
    }


    private string NameToLower()
    {
        foreach (char item in userNameInput)
        {
            nameToLower += item.ToString().ToLower().Trim();
        }
        return nameToLower;
    }

    public void AddUserToDatabase()
    {
        var playerName = NameToLower();
        db.AddPlayer(playerName, defaultScore);

        SceneManager.LoadScene(2);

        nameInput.Select();
        nameInput.text = null;
        userNameInput = null;
        nameToLower = null;
        playerName = null;
    }


}
