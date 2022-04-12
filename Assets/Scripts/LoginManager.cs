using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField nameInput;
    MongoDatabase db;

    string userNameInput;
    bool userFound;
    string nameToLower;


    private void Start()
    {
        db = GameObject.Find("Database").GetComponent<MongoDatabase>();
    }

    public void EnterNameButton()
    {

        //Tähän tarvitaan tieto, löytyykö pelaaja jo databasesta.

        CheckName();

    }

    private void NameToLower()
    {
        foreach (char item in userNameInput)
        {
            nameToLower += item.ToString().ToLower();
            
        }
        
    }

    private void Update()
    {
        userNameInput = nameInput.text;
        

 
    }

    //public async void LoadButton()
    //{
    //    //userNameInput = nameInput.text;
    //    //var playersData = db.LoadPlayer();
    //    //var dict = await playersData;

    //    //foreach (KeyValuePair<string, string> item in dict)
    //    //{
    //    //    Debug.Log(item.Key + ":" + item.Value);
    //    //    //playersData.text += item.Key + " : " + item.Value + "\n";
    //    //}

    //}

    public async void CheckName()
    {
        NameToLower();
        Debug.Log(nameToLower);
        var playersData = db.LoadPlayer();
        var dict = await playersData;

        Debug.Log("Toimii 1");

        if (dict.Count < 1)
        {
            Debug.Log("Ei löydy");
            db.AddPlayer(nameToLower);
        }
        else
        {
            foreach (KeyValuePair<string, string> item in dict)
            {
                Debug.Log("Toimii 2");

                if (item.Value != nameToLower.ToString())
                {
                    Debug.Log("Ei löydy");
                    db.AddPlayer(userNameInput);
                    nameToLower = "";
                }
                else if (item.Value == nameToLower.ToString())
                {
                    Debug.Log("Löytyy");
                    return;
                }

            }
        }
    }
}
