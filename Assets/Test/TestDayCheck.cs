using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDayCheck : MonoBehaviour
{
    public void A_Start_Check()
    {
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().intensityStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().reactionStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().rejectStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().orderStart = true;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().declareStart = false;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().A_Start();
        }
    }

    public void C1_Check()
    {
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().orderStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().reactionStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().rejectStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().intensityStart = true;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().declareStart = false;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().C_1_Start();
            if (GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>().Customer_ID[0] == 1003)
            {
                Debug.Log("범죄자 향수 판매");
            }
        }
    }

    public void C2_Check()
    {
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().orderStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().intensityStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().reactionStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().rejectStart = true;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().declareStart = false;

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().C_2_Start();
        }
    }

    public void ND_Check()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().NextDialogue();
        }
    }
    public void E1_Check()
    {
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().orderStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().intensityStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().rejectStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().reactionStart = true;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().declareStart = false;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().E_1_Start();
        }
    }

    public void F2_Check()
    {
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().orderStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().intensityStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().rejectStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().reactionStart = false;
        TestCustomerFeel.FindObjectOfType<TestCustomerFeel>().GetComponent<TestCustomerFeel>().declareStart = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<TestDialogueRandom>().E_1_Start();
        }
    }
}
