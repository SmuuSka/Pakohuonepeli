﻿using UnityEngine;

[CreateAssetMenu(fileName = "playerData", menuName = "playerMenu")]
public class ScriptableObjects : ScriptableObject
{
    public string playerName;
    public double score;
}