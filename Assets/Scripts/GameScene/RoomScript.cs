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
    [SerializeField] private Transform playerPos;
    
    private bool doorIsOpen;
    

    private void Start()
    {
        robotData = GameObject.Find("Robo").GetComponent<RobotMoveScript>();
        playerPos = GameObject.Find("Robo").GetComponent<Transform>();
        
    }
    private void Update()
    {
        
        var distance = Vector2.Distance(playerPos.position, this.rightDoor.transform.position);
        Debug.Log(distance);

        if (distance < 4)
        {
            if (robotData.hitOpenableDoorRight && !doorIsOpen)
            {
                OpenDoor();
            }
        }
    }
    public void OpenDoor()
    {
            int upperDoor = 0;
            int lowerDoor = 1;

            this.rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y + 1f * Time.deltaTime);
            
            this.rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y - 1f * Time.deltaTime);

            if (this.rightDoorPieces[upperDoor].transform.localPosition.y > 6.6f)
            {
                doorIsOpen = true;
                this.rightDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
    }
    private void CloseDoor()
    {
        int upperDoor = 0;
        int lowerDoor = 1;

        rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y - 1f * Time.deltaTime);

        rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y + 1f * Time.deltaTime);

        if (rightDoorPieces[0].transform.position.y < 0.4f)
        {
            
            
        }
    }
    private IEnumerator ShutTheDoor()
    {
        if (!robotData.isInsideDoorZone)
        {
            yield return new WaitForSeconds(1);
        }
    }
}

