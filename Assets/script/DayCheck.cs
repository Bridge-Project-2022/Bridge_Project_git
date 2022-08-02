using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCheck : MonoBehaviour
{
    GameObject RC;
    // Start is called before the first frame update
    void Start()
    {
        RC = GameObject.Find("RC").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void A_Start_Check()
    {
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().intensityStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().reactionStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().rejectStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().orderStart = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().A_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            //GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().A_Start();
        }
    }

    public void C1_Check()
    {
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().orderStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().reactionStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().rejectStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().intensityStart = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            //GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_1_Start();
        }
    }

    public void C2_Check()
    {
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().orderStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().intensityStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().reactionStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().rejectStart = true;

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_2_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            //GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_2_Start();
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
    }
    public void E1_Check()
    {
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().orderStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().intensityStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().rejectStart = false;
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().reactionStart = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().FeelCnt = 0;GameObject.Find("Trigger").GetComponent<DialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().E_1_Start();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            //GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().FeelCnt = 0;
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().E_1_Start();
        }
    }
}
