using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OviScript : MonoBehaviour
{
    public Animator doorAnim;
    public bool isAnimating;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerData.laserTaskDone == true)
        {
            doorAnim.SetBool("isAnimating", true);
        }
        else if (PlayerData.laserTaskDone == false)
        {
            doorAnim.SetBool("isAnimating", false);
        }
    }
}
