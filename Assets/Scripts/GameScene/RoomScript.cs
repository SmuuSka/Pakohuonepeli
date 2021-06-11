using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private RobotMoveScript robotData;

    [SerializeField] private float doorSpeed;
    [SerializeField] private GameObject rightDoor, leftDoor;
    [SerializeField] public GameObject[] rightDoorPieces = new GameObject[2];
    [SerializeField] private GameObject[] leftDoorPieces = new GameObject[2];



    private bool sendPulse;
    public bool stop;



    private void Start()
    {
        robotData = GameObject.Find("Robot side-8").GetComponent<RobotMoveScript>();

    }
    private void Update()
    {
        Debug.Log(rightDoorPieces[0].transform.position.y);

        if (rightDoorPieces[0].transform.position.y > 3.5f || leftDoorPieces[0].transform.position.y > 3.5f)
        {
            stop = true;
            rightDoor.GetComponent<BoxCollider2D>().enabled = false;
            leftDoor.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(ShutTheDoor());
        }
        if (!stop)
        {
            OpenDoor();
        }
       


        if (sendPulse)
        {
            
        }
    }
    private void OpenDoor()
    {
        
        if (robotData.hitOpenableDoor && rightDoor.GetComponent<DoorCanBeOpened>().theDoorCanBeOpened)
        {
            robotData.hitOpenableDoor = false;
            int upperDoor = 0;
            int lowerDoor = 1;

            Vector2 startPosRightUpper = rightDoorPieces[upperDoor].transform.position;
            rightDoorPieces[upperDoor].transform.position = Vector2.Lerp(startPosRightUpper, new Vector2(startPosRightUpper.x, startPosRightUpper.y + 4), doorSpeed * Time.deltaTime);

            Vector2 startPosRightLower = rightDoorPieces[lowerDoor].transform.position;
            rightDoorPieces[lowerDoor].transform.position = Vector2.Lerp(startPosRightLower, new Vector2(startPosRightLower.x, startPosRightLower.y - 4), doorSpeed * Time.deltaTime);
        } 
    }
    private void CloseDoor()
    {
        int upperDoor = 0;
        int lowerDoor = 1;
        
        Vector2 startPosRightUpper = rightDoorPieces[upperDoor].transform.position;
        rightDoorPieces[upperDoor].transform.position = Vector2.Lerp(startPosRightUpper, new Vector2(startPosRightUpper.x, startPosRightUpper.y - 10f), doorSpeed * Time.deltaTime);

        Vector2 startPosRightLower = rightDoorPieces[lowerDoor].transform.position;
        rightDoorPieces[lowerDoor].transform.position = Vector2.Lerp(startPosRightLower, new Vector2(startPosRightLower.x, startPosRightLower.y + 10f), doorSpeed * Time.deltaTime);
        
    }
    private IEnumerator ShutTheDoor()
    {
        Debug.Log("Toimii tähän asti");
        if (!robotData.isInsideDoorZone && stop)
        {
            Debug.Log("Toimii tähän asti");
            yield return new WaitForSeconds(1);
            CloseDoor();
            if (rightDoorPieces[0].transform.position.y < 0.5f)
            {
                rightDoor.GetComponent<BoxCollider2D>().enabled = true;
                leftDoor.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}

