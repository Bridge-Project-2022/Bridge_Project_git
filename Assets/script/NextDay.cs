using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    public int day = 1;

    public void NextDayClick()
    {
        day++;
        if (day == 2)
        {
            SecondDayStart();
        }
    }

    public void SecondDayStart()
    {
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<DialogueRandom>().enabled = false;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }
}
