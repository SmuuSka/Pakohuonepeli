using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public ScriptableObjects so;
    public InputField nameInput;
    private bool canBeAdded = false;



    public void EnterNameButton()
    {
        var userNameInput = nameInput.text;

        if (so.nameList.Count < 1)
        {
            so.nameList.Add(userNameInput);
        }
        else if (canBeAdded == false)
        {
            foreach (var name in so.nameList)
            {
                if (name == userNameInput)
                {
                    Debug.Log("Käyttäjä on olemassa");
                    break;
                }
                else
                {
                    Debug.Log("Käyttäjä on luotu");
                    so.nameList.Add(userNameInput);
                    canBeAdded = true;
                }
            }
        }                 
    }
}
