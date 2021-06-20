using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //private RobotMoveScript robotData;

    //[SerializeField] private float doorSpeed;
    //[SerializeField] private GameObject rightDoor, leftDoor;
    //[SerializeField] public GameObject[] rightDoorPieces = new GameObject[2];
    //[SerializeField] private GameObject[] leftDoorPieces = new GameObject[2];
    //[SerializeField] private Transform playerPos;

    //private bool doorIsOpenRight, doorIsOpenLeft;
    //private bool closingDoorRight, closingDoorLeft;
    //private bool doorRight, doorLeft;

    //private void Start()
    //{

    //    robotData = GameObject.Find("Robo").GetComponent<RobotMoveScript>();
    //    playerPos = GameObject.Find("Robo").GetComponent<Transform>();

    //}
    //private void Update()
    //{
    //    DistanceCheck();

    //    if (doorIsOpenRight)
    //    {
    //        StartCoroutine(ShutTheDoor());
    //    }

    //    if (doorIsOpenLeft)
    //    {
    //        StartCoroutine(ShutTheDoor());
    //    }

    //    if (closingDoorRight)
    //    {
    //        CloseDoorRight();
    //    }
    //    if (closingDoorLeft)
    //    {
    //        CloseDoorLeft();
    //    }
    //}
    //public void OpenDoorRight()
    //{
    //    int upperDoor = 0;
    //    int lowerDoor = 1;
    //    if (rightDoor)
    //    {
    //        this.rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y + 1f * Time.deltaTime);

    //        this.rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y - 1f * Time.deltaTime);

    //        if (this.rightDoorPieces[upperDoor].transform.localPosition.y > 6.6f)
    //        {
    //            doorIsOpenRight = true;
    //            this.rightDoor.GetComponent<BoxCollider2D>().enabled = false;
    //        }
    //    }
    //}
    //public void OpenDoorLeft()
    //{
    //    int upperDoor = 0;
    //    int lowerDoor = 1;
    //    if (leftDoor)
    //    {
    //        this.leftDoorPieces[upperDoor].transform.position = new Vector2(leftDoorPieces[upperDoor].transform.position.x, leftDoorPieces[upperDoor].transform.position.y + 1f * Time.deltaTime);

    //        this.leftDoorPieces[lowerDoor].transform.position = new Vector2(leftDoorPieces[lowerDoor].transform.position.x, leftDoorPieces[lowerDoor].transform.position.y - 1f * Time.deltaTime);

    //        if (this.leftDoorPieces[upperDoor].transform.localPosition.y > 6.6f)
    //        {
    //            doorIsOpenLeft = true;
    //            this.leftDoor.GetComponent<BoxCollider2D>().enabled = false;
    //        }
    //    }
    //}
    //private void CloseDoorRight()
    //{
    //    Debug.Log(this.rightDoorPieces[0].transform.localPosition.y);
    //    int upperDoor = 0;
    //    int lowerDoor = 1;

    //    this.rightDoorPieces[upperDoor].transform.position = new Vector2(rightDoorPieces[upperDoor].transform.position.x, rightDoorPieces[upperDoor].transform.position.y - 1f * Time.deltaTime);

    //    this.rightDoorPieces[lowerDoor].transform.position = new Vector2(rightDoorPieces[lowerDoor].transform.position.x, rightDoorPieces[lowerDoor].transform.position.y + 1f * Time.deltaTime);

    //    if (this.rightDoorPieces[upperDoor].transform.localPosition.y < 0.9f)
    //    {
    //        closingDoorRight = false;
    //        this.rightDoor.GetComponent<BoxCollider2D>().enabled = true;
    //    }
    //}

    //private void CloseDoorLeft()
    //{
    //    int upperDoor = 0;
    //    int lowerDoor = 1;

    //    this.leftDoorPieces[upperDoor].transform.position = new Vector2(leftDoorPieces[upperDoor].transform.position.x, leftDoorPieces[upperDoor].transform.position.y - 1f * Time.deltaTime);

    //    this.leftDoorPieces[lowerDoor].transform.position = new Vector2(leftDoorPieces[lowerDoor].transform.position.x, leftDoorPieces[lowerDoor].transform.position.y + 1f * Time.deltaTime);

    //    if (this.leftDoorPieces[upperDoor].transform.localPosition.y < 0.9f)
    //    {
    //        closingDoorLeft = false;
    //        this.leftDoor.GetComponent<BoxCollider2D>().enabled = true;
    //    }
    //}
    //private IEnumerator ShutTheDoor()
    //{
    //    if (!robotData.isPlayerInsideDoorZone && doorRight)
    //    {
    //        yield return new WaitForSeconds(1);
    //        doorIsOpenRight = false;
    //        closingDoorRight = true;
    //    }
    //    else if (!robotData.isPlayerInsideDoorZone && doorLeft)
    //    {
    //        yield return new WaitForSeconds(1);
    //        doorIsOpenLeft = false;
    //        closingDoorLeft = true;
    //    }
    //}
    //private void DistanceCheck()
    //{
    //    var distanceRight = Vector2.Distance(playerPos.position, this.rightDoor.transform.position);
    //    var distanceLeft = Vector2.Distance(playerPos.position, this.leftDoor.transform.position);

    //    if (distanceRight < 4)
    //    {
    //        if (robotData.hitOpenableDoorRight && !doorIsOpenRight)
    //        {
    //            doorRight = true;
    //            OpenDoorRight();
    //        }
    //    }

    //    if (distanceLeft < 4)
    //    {
    //        if (robotData.hitOpenableDoorLeft && !doorIsOpenLeft)
    //        {
    //            doorLeft = true;
    //            OpenDoorLeft();
    //        }
    //    }
    //}
}

