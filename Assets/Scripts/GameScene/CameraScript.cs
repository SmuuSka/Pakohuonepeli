using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera playerCamera;

    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0,1.5f,-10);
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        Debug.Log(playerCamera.fieldOfView);
    }


    private void LateUpdate()
    {
        playerCamera.transform.position = target.position + offset;

        if (target.transform.position.x < 0)
        {
            playerCamera.transform.position = new Vector3(0,playerCamera.transform.position.y,-10);

        }
        else if (target.transform.position.x >= 0)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}

