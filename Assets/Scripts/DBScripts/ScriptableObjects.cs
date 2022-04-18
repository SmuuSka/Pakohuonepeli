using UnityEngine;

[CreateAssetMenu(fileName = "playerData", menuName = "playerMenu")]
public class ScriptableObjects : ScriptableObject
{
    public string playerName;
    public double score;

    public void Reset()
    {
        playerName = null;
        score = 0;
    }
}
