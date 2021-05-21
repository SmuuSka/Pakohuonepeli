using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAnswerScript : MonoBehaviour
{
    [SerializeField] private Text[] slot = new Text[0];
    [SerializeField] private Text[] answer = new Text[0];
    [Space]
    [Space]
    [SerializeField] private Button nextSlot;
    [SerializeField] private Button previousSlot;
    [SerializeField] private Button sendAnswer;

    private CursorScrip cursorManager;

    private int slotInt;

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

        nextSlot.onClick.AddListener(GoNext);
        previousSlot.onClick.AddListener(GoBack);
        sendAnswer.onClick.AddListener(CheckAnswerIsPressed);
    }

    private void CheckAnswer()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (slot[i].text == answer[i].text)
            {
                slot[i].color = Color.green;
            }
            else
            {
                slot[i].color = Color.red;
            }
        }
    }

    private void Update()
    {
        LockWheelNumber();
    }

    public void GoNext()
    {
        if (slotInt < 4)
        {

            slotInt++;
        }
        
    }
    public void GoBack()
    {
        if (slotInt > 0)
        {
            slotInt--;
        }
    }
    public void CheckAnswerIsPressed()
    {
        CheckAnswer();
    }

    private void LockWheelNumber()
    {
        slot[slotInt].text = cursorManager.currentValue.ToString();
        Debug.Log("Current Slot " + slotInt);
    }
}
