using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public ScriptableObjects so;
    public InputField nameInput;

    public void EnterNameButton()
    {
        var nameInputField = nameInput.text;
        so.nameList.Add(nameInputField);
    }



}
