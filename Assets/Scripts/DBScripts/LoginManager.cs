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
    int defaultScore = 0;


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
                //var _player = GameObject.Find("Player").GetComponent<>
            }

        }

    }


    private string NameToLower()
    {
        foreach (char item in userNameInput)
        {
            nameToLower += item.ToString().ToLower();
        }
        return nameToLower;
    }



}
