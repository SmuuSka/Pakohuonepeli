using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerData 
{
    public static bool firstPos = false;
    public static Vector2 playerTransformPos;
    public static Vector3 gameCameraTransformPos;
    public static bool lockerTaskDone, ToolboxTaskDone, laserTaskDone, slideTaskDone;
    public static bool screwdriver, battery, postIt;

    public static List<GameObject> lappuPrefab = new List<GameObject>();

    public static void ResetData()
    {
        firstPos = false;
        playerTransformPos = new Vector2(0,0);
        gameCameraTransformPos = new Vector3(0, 0, -10);
        lockerTaskDone = false;
        ToolboxTaskDone = false;
        laserTaskDone = false;
        slideTaskDone = false;
        lappuPrefab = null;
    }
}
