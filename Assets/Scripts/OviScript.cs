using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OviScript : MonoBehaviour
{
    public Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerData.laserTaskDone == true)
        {
            doorAnim.SetBool("OviAuki", true);
        }
        else if (PlayerData.laserTaskDone == false)
        {
            doorAnim.SetBool("OviAuki", false);
        }
    }
}
