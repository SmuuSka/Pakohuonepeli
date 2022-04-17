using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Otetaan yhteys Scriptableobjects scriptiin.
    public ScriptableObjects playerData;
    // Luodaan playerName muuttuja string muodossa.
    public string playerName;
    // Luodaan playerScore muuttuja double muodossa.
    public double playerScore;

    private void Update()
    {
        // Päivitetään pelaajan tietoja näihin muuttujiin.
        playerName = playerData.playerName;
        playerScore = playerData.score;
    }
}
