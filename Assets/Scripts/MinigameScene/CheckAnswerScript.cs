using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckAnswerScript : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> slot = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> answer = new List<TMP_Text>();
    [Space]
    [Space]
    [SerializeField] private Button nextSlot;
    [SerializeField] private Button previousSlot;
    [SerializeField] private Button sendAnswer;
    [SerializeField] private Button goBack;

    private CursorScrip cursorManager;

    [SerializeField] private int slotInt, currentSlotInt;

    [SerializeField] private int slotCount, answersGiven;

    private Color slotDefaultColor;


    //private bool checkAnswerIsClicked;
    private bool okAll;
    //private bool switchScene = false;
    [SerializeField] private int rightAnswers;

    private void Start()
    {
        slotDefaultColor = slot[slotInt].color;
        currentSlotInt = slotInt;
        cursorManager = GameObject.Find("näyttö").GetComponent<CursorScrip>();

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
        goBack.onClick.AddListener(GoBackGameScene);

        sendAnswer.gameObject.SetActive(false);

    }

    private void GoBackGameScene()
    {
        SceneManager.LoadScene(0);
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
        AllOkay();

        if (!okAll)
        {
            switch (currentSlotInt)
            {
                case 0:
                    slot[slotInt].color = Color.yellow;
                    slot[1].color = slotDefaultColor;
                    slot[4].color = slotDefaultColor;
                    break;
                case 1:
                    slot[0].color = slotDefaultColor;
                    slot[slotInt].color = Color.yellow;
                    slot[2].color = slotDefaultColor;
                    break;
                case 2:
                    slot[1].color = slotDefaultColor;
                    slot[slotInt].color = Color.yellow;
                    slot[3].color = slotDefaultColor;
                    break;
                case 3:
                    slot[2].color = slotDefaultColor;
                    slot[slotInt].color = Color.yellow;
                    slot[4].color = slotDefaultColor;
                    break;
                case 4:
                    slot[3].color = slotDefaultColor;
                    slot[slotInt].color = Color.yellow;
                    break;
            }
        }


        currentSlotInt = slotInt;
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
            slotInt += 1;
            answersGiven += 1;
        }
    }
    public void GoBack()
    {
        if (slotInt > 0)
        {
            slotInt -= 1;
        }
    }

    private void LockWheelNumber()
    {
        slot[slotInt].text = cursorManager.currentValue.ToString();
    }

    private void CheckAnswer2()
    {
        
        for (int i = 0; i < answer.Count; i++)
        {
            if (slot[i].text == answer[i].text)
            {
                slot[i].color = Color.green;
                rightAnswers++;
                
                
                //okAll = true;
                //StartCoroutine(delay());
                
            }
            else
            {
                ResetAnswers();
                rightAnswers = 0;
                //break;
            }
        }
    }

    private void AllOkay()
    {
        while (rightAnswers > answersGiven)
        {
            okAll = true;
            StartCoroutine(delay());
            break;
        }
    }

    private void ResetAnswers()
    {
        slotInt = 0;
        answersGiven = 0;
        sendAnswer.gameObject.SetActive(false);
        cursorManager.currentValue = 0;
        //cursorManager.target.transform.rotation = Quaternion.Euler(0, 0, 0);
        for (int t = 0; t < slot.Count; t++)
        {
            slot[t].text = " 0 ";
        }
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
        PlayerData.lockerTaskDone = true;
    }
}
