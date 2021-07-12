using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeze : MonoBehaviour
{
    public Rigidbody2D robo;

    // Start is called before the first frame update
    void Start()
    {
        robo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuScripts.GameIsPaused == true)
        {
            robo.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (PauseMenuScripts.GameIsPaused == false)
        {
            robo.constraints = RigidbodyConstraints2D.None;
        }
        
    }
}
