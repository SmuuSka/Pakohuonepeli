using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Camera gameCamera;
    [SerializeField] public Transform[] nextPos = new Transform[0];

    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0,0,-10);
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        gameCamera.transform.position = new Vector3(nextPos[0].position.x, target.transform.position.y, -10);
    }

    private void Update()
    {
        Debug.Log("targetPos " + nextPos[0].transform.position);
    }
    private void LateUpdate()
    {
        //gameCamera.transform.position = nextPos[0].position + offset;

        //if (target.transform.position.x < 0)
        //{
            //gameCamera.transform.position = new Vector3(nextPos[0].position.x, gameCamera.transform.position.y,-10);

        //}
        if (target.transform.position.x > 27 && target.transform.position.x < 40)
        {
            gameCamera.transform.position = new Vector3(nextPos[2].position.x, nextPos[2].position.y, -10);
            //Vector3 desiredPosition = target.position + offset;
            //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
            //transform.position = smoothedPosition;
        }
        if (target.transform.position.x > 40 && target.transform.position.y < -2)
        {
            gameCamera.transform.position = new Vector3(nextPos[3].position.x, nextPos[3].position.y, -10);
            target.position = new Vector2(GameObject.Find("/Huone_Final (1)/SpawnPos").transform.position.x, GameObject.Find("/Huone_Final (1)/SpawnPos").transform.position.y);
            
        }
    }
}

