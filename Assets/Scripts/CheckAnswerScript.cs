using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAnswerScript : MonoBehaviour
{
    [SerializeField] private List<Text> slot = new List<Text>();
    [SerializeField] private List<Text> answer = new List<Text>();
    [Space]
    [Space]
    [SerializeField] private Button nextSlot;
    [SerializeField] private Button previousSlot;
    [SerializeField] private Button sendAnswer;

    private CursorScrip cursorManager;

    [SerializeField] private int slotInt;
    private int slotCount;

    private void Start()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorScrip>();

        slot[0].text = " 0 ";
        slot[1].text = " 0 ";
        slot[2].text = " 0 ";
        slot[3].text = " 0 ";
        slot[4].text = " 0 ";

        answer[0].text = Random.Range(0, 35).ToString();
        answer[1].text = Random.Range(0, 35).ToString();
        answer[2].text = Random.Range(0, 35).ToString();
        answer[3].text = Random.Range(0, 35).ToString();
        answer[4].text = Random.Range(0, 35).ToString();

        slotInt = 0;
        slotCount = slot.Count;

        nextSlot.onClick.AddListener(GoNext);
        previousSlot.onClick.AddListener(GoBack);
        sendAnswer.onClick.AddListener(CheckAnswer);

        

        //if (slot.Count > 0)
        //{
        //    LockWheelNumber();
        //    for (int i = 0; i < slotCount; i++)
        //    {
        //        if (slot[slotInt].text == answer[slotInt].text)
        //        {
        //            slot[slotInt].color = Color.green;
        //            slot.Remove(slot[slotInt]);
        //            answer.Remove(answer[slotInt]);
        //        }
        //    }
        //}


    }

    private void CheckAnswer()
    {
        if (slot.Count > 0)
        {
            LockWheelNumber();
            for (int i = 0; i < slotCount; i++)
            {
                Debug.Log("SlotCount" + slotCount);
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    slot.Remove(slot[slotInt]);
                    answer.Remove(answer[slotInt]);
                }
            }
        }
    }

    private void Update()
    {
        if (slotCount > 0)
        {
            LockWheelNumber();
        }
    }

    public void GoNext()
    {
        if (slotInt < slot.Count - 1)
        {
            Debug.Log("Slot Int " + slotInt);
            slotInt += 1;
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
}
