using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Camera gameCamera;
    [SerializeField] public Transform[] nextPos = new Transform[0];

    private void Start()
    {
        gameCamera.transform.position = new Vector3(nextPos[0].position.x, nextPos[0].position.y, -10);
    }


    private void Update()
    {

    }
    private void LateUpdate()
    {
        if (target.transform.position.x > 12 && target.transform.position.x < 27)
        {
            gameCamera.transform.position = new Vector3(nextPos[1].position.x, nextPos[1].position.y, -10);
        }

        if (target.transform.position.x > 27 && target.transform.position.x < 40)
        {
            gameCamera.transform.position = new Vector3(nextPos[2].position.x, nextPos[2].position.y, -10);
        }
        if (target.transform.position.x > 40 && target.transform.position.x < 62.5f)
        {
            gameCamera.transform.position = new Vector3(nextPos[3].position.x, nextPos[3].position.y, -10);

            if (target.transform.position.y < -2)
            {
                target.position = GameObject.Find("Huone_Final (1)/SpawnPos").transform.position;
            }

        }
        if (target.transform.position.x > 62.5f && target.transform.position.x < 80.7f)
        {
            gameCamera.transform.position = new Vector3(nextPos[4].position.x, nextPos[4].position.y, -10);
        }
        if (target.transform.position.x > 80.7f)
        {
            gameCamera.transform.position = new Vector3(nextPos[5].position.x, nextPos[5].position.y, -10);
        }
    }
}

