using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerData 
{
    public static bool firstPos = false, facingStatic;
    public static Vector2 playerTransformPos = new Vector2(-6.36f, -1.61f);
    public static Vector3 gameCameraTransformPos;
    public static bool lockerTaskDone, ToolboxTaskDone, laserTaskDone, slideTaskDone, lockerScene;
    public static bool screwdriver, battery, postIt;
    public static GameObject[] lappuVastaukset = new GameObject[1];

    public static List<GameObject> lappuPrefab = new List<GameObject>();
    public static List<TMP_Text> tempAnswers = new List<TMP_Text>();

    public static void ResetData()
    {
        firstPos = false;
        playerTransformPos = new Vector2(-6.36f, -1.61f);
        gameCameraTransformPos = new Vector3(0, 0, -10);
        lockerTaskDone = false;
        ToolboxTaskDone = false;
        laserTaskDone = false;
        slideTaskDone = false;
        lappuPrefab = null;
        screwdriver = false;
        battery = false;
        postIt = false;
        
        
    }
}
