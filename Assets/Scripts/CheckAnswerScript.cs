using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAnswerScript : MonoBehaviour
{
    [SerializeField] private List<Text> slot = new List<Text>();
    [SerializeField] private List<Text> answer = new List<Text>();
    [SerializeField] private List<Text> isAllRight = new List<Text>();
    [Space]
    [Space]
    [SerializeField] private Button nextSlot;
    [SerializeField] private Button previousSlot;
    [SerializeField] private Button sendAnswer;

    private CursorScrip cursorManager;

    [SerializeField] private int slotInt, answerInt;

    [SerializeField] private int slotCount, answersGiven;

    private bool checkAnswerIsClicked;

    private void Start()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorScrip>();

        for (int i = 0; i < slot.Count; i++)
        {
            slot[i].text = " 0 ";
        }

        for (int i = 0; i < answer.Count; i++)
        {
            answer[i].text = Random.Range(0, 35).ToString();
        }

        slotInt = 0;
        slotCount = slot.Count;

        nextSlot.onClick.AddListener(GoNext);
        previousSlot.onClick.AddListener(GoBack);
        sendAnswer.onClick.AddListener(CheckAnswer2);

        sendAnswer.gameObject.SetActive(false);

    }

    //private void CheckAnswer()
    //{

    //    if (slot.Count != 0)
    //    {
    //        LockWheelNumber();
    //        for (int i = 0; i < slotCount; i++)
    //        {
    //            Debug.Log("SlotCount" + slotCount);
    //            if (slot[slotInt].text == answer[slotInt].text)
    //            {
    //                slot[slotInt].color = Color.green;
    //                isAllRight.Add(slot[slotInt]);
    //                slot.Remove(slot[slotInt]);
    //                answer.Remove(answer[slotInt]);
    //                slotInt--;
    //                if (slotInt < 0)
    //                {
    //                    slotInt += 1;
    //                }
    //            }
    //        }
    //    }
    //}


    private void Update()
    {
        
        if (slot.Count > 0)
        {
            LockWheelNumber();
        }

        if (answersGiven >= 4)
        {
            sendAnswer.gameObject.SetActive(true);

        }
    }

    public void GoNext()
    {
        if (slotInt < slot.Count - 1)
        {
            Debug.Log("Slot Int " + slotInt);
            slotInt += 1;
            answersGiven += 1;
        }
        
    }
    public void GoBack()
    {
        if (slotInt > 0)
        {
            Debug.Log("Slot Int " + slotInt);
            slotInt -= 1;
        }
    }

    private void LockWheelNumber()
    {
        slot[slotInt].text = cursorManager.currentValue.ToString();
        slot[slotInt].color = Color.yellow;
        Debug.Log("Current Slot " + slotInt);
    }

    private void CheckAnswer2()
    {
        for (int i = 0; i < 4; i++)
        {
            if (slot[i].text == answer[i].text)
            {
                Debug.Log("Oikein " + i);
            }
            else
            {
                Debug.Log("Reset");
                slotInt = 0;
                answersGiven = 0;
                sendAnswer.gameObject.SetActive(false);
                cursorManager.currentValue = 0;
                cursorManager.target.transform.rotation = Quaternion.Euler(0,0,0);
                for (int t = 0; t < slot.Count; t++)
                {
                    slot[t].text = " 0 ";
                }
                break;
            }
        }
    }
}
