using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAnswerScript : MonoBehaviour
{
    [SerializeField] private Text[] slot = new Text[0];
    [SerializeField] private Text[] answer = new Text[0];

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

        answer[0].text = Random.Range(0, 36).ToString();
        answer[1].text = Random.Range(0, 36).ToString();
        answer[2].text = Random.Range(0, 36).ToString();
        answer[3].text = Random.Range(0, 36).ToString();
        answer[4].text = Random.Range(0, 36).ToString();

        slotInt = 0;
    }

    private void CheckAnswer()
    {
        slot[slotInt].text = cursorManager.value.ToString();

        switch (slotInt)
        {

            case 0:
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    slotInt++;
                }
                break;

            case 1:
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    slotInt++;
                }
                break;

            case 2:
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    slotInt++;
                }
                break;

            case 3:
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    slotInt++;
                }
                break;

            case 4:
                if (slot[slotInt].text == answer[slotInt].text)
                {
                    slot[slotInt].color = Color.green;
                    SceneManager.LoadScene(1);
                }
                break;

        }
    }

    private void Update()
    {
        CheckAnswer();
    }
}
