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

    public bool stop;

    private bool closeDoor;



    private void Start()
    {
        robotData = GameObject.Find("Robo").GetComponent<RobotMoveScript>();

    }
    private void Update()
    {
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
        Debug.Log("Oven y pos " + rightDoorPieces[0].transform.position.y);

        if (closeDoor)
        {
            CloseDoor();
            if (rightDoorPieces[0].transform.position.y <= 0.43f)
            {
                closeDoor = false;
                rightDoor.GetComponent<BoxCollider2D>().enabled = true;
                stop = false;
            }
        }



    }
    private void OpenDoor()
    {

        if (robotData.hitOpenableDoor && rightDoor.CompareTag("OpenableDoor"))
        {
            robotData.hitOpenableDoor = false;
            int upperDoor = 0;
            int lowerDoor = 1;

            
            rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y + 1f * Time.deltaTime);
            
            rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y - 1f * Time.deltaTime);

        } 
    }
    private void CloseDoor()
    {
        int upperDoor = 0;
        int lowerDoor = 1;

        rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y - 1f * Time.deltaTime);

        rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y + 1f * Time.deltaTime);

    }
    private IEnumerator ShutTheDoor()
    {
        
        if (!robotData.isInsideDoorZone && stop)
        {
            yield return new WaitForSeconds(1);
            closeDoor = true;
        }
    }
}

