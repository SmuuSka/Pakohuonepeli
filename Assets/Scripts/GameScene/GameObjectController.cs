using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    private void Update()
    {
        if (PlayerData.lappuCopy.Count != 0 && GameObject.Find("LappuVastaukset(Clone)") != null)
        {
            if (PlayerData.scene == false)
            {
                PlayerData.lappuCopy[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }

        }

    }
}
