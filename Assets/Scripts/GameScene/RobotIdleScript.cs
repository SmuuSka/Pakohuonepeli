using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotIdleScript : MonoBehaviour
{
    private void LateUpdate()
    {
        Flip();
        transform.position = PlayerData.playerTransformPos;
        
    }
    private void Flip()
    {
        if (PlayerData.facingStatic == true)
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        if (PlayerData.facingStatic == false)
        {
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
