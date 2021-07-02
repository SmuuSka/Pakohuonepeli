using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerData 
{
    public static bool facingStatic;
    public static Vector2 playerTransformPos;
    public static Vector3 gameCameraTransformPos;
    public static bool lockerTaskDone, ToolboxTaskDone, laserTaskDone;

    public static List<GameObject> lappuPrefab = new List<GameObject>();
}
