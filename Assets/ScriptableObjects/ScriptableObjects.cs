using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerData", menuName = "playerMenu")]
public class ScriptableObjects : ScriptableObject
{
    public string playerName;
    public List<string> nameList = new List<string>();
    

}
