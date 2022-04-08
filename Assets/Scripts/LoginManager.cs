using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    //public ScriptableObjects so;
    public InputField nameInput;
    //private bool canBeAdded = false;
    MongoDatabase db;

    string userNameInput;


    private void Start()
    {
        db = GameObject.Find("Database").GetComponent<MongoDatabase>();
    }

    public void EnterNameButton()
    {
        userNameInput = nameInput.text;
        db.AddPlayer(userNameInput);        
    }

    public async void LoadButton()
    {
        userNameInput = nameInput.text;
        var playersData = db.LoadPlayer();
        var dict = await playersData;

        foreach (KeyValuePair<string, string> item in dict) 
        {
            Debug.Log(item.Key + ":" + item.Value);
            //playersData.text += item.Key + " : " + item.Value + "\n";
        }

    }


}
