using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCheck : MonoBehaviour
{
    public void A_Start_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().A_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().A_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().A_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().A_Start();
        }
    }

    public void C1_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().C_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().C_1_Start();
        }
    }

    public void C2_Check()
    {

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_2_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_2_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().C_2_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().C_2_Start();
        }
    }

    public void ND_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().NextDialogue();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().NextDialogue();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().NextDialogue();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().NextDialogue();
        }
    }
    public void E1_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().E_1_Start();
        }
    }

    public void F2_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().E_1_Start();
        }
    }
}
