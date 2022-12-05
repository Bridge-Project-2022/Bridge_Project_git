using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRecipt : MonoBehaviour
{

    public GameObject Recipt;
    GameObject DialogueScript;
    public GameObject ReceiptText;

    public string[] PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] IntensityOrder = new string[5];//향수 강도 대사

    void Update()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            DialogueScript = GameObject.Find("DialogueScript1").gameObject;
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            DialogueScript = GameObject.Find("DialogueScript2").gameObject;
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            DialogueScript = GameObject.Find("DialogueScript3").gameObject;
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            DialogueScript = GameObject.Find("DialogueScript4").gameObject;
        }

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {

            /*foreach (string str in DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder;
            }*/
            for (int i = 0; i < DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder[i] == "")
                    break;

                PerfumeOrder[i] = DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder[i];
            }

            for (int i = 0; i < DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder[i] == "")
                    break;

                IntensityOrder[i] = DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder[i];
            }

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n" + PerfumeOrder[5] + "\n" + PerfumeOrder[6] + "\n" + PerfumeOrder[7] + "\n" + PerfumeOrder[8]
            + "\n" + "\n" + IntensityOrder[0] + "\n" + IntensityOrder[1] + "\n" + IntensityOrder[2] + "\n" + IntensityOrder[3];
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            for (int i = 0; i < DialogueScript.GetComponent<SecondDialogueScript>().Customer_PerfumeOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<SecondDialogueScript>().Customer_PerfumeOrder[i] == "")
                    break;

                PerfumeOrder[i] = DialogueScript.GetComponent<SecondDialogueScript>().Customer_PerfumeOrder[i];
            }

            for (int i = 0; i < DialogueScript.GetComponent<SecondDialogueScript>().Customer_IntensityOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<SecondDialogueScript>().Customer_IntensityOrder[i] == "")
                    break;

                IntensityOrder[i] = DialogueScript.GetComponent<SecondDialogueScript>().Customer_IntensityOrder[i];
            }


            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n" + PerfumeOrder[5] + "\n"
            + "\n" + IntensityOrder[0] + "\n" + IntensityOrder[1] + "\n" + IntensityOrder[2] + "\n" + IntensityOrder[3];
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            for (int i = 0; i < DialogueScript.GetComponent<ThirdDialogueScript>().Customer_PerfumeOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<ThirdDialogueScript>().Customer_PerfumeOrder[i] == "")
                    break;

                PerfumeOrder[i] = DialogueScript.GetComponent<ThirdDialogueScript>().Customer_PerfumeOrder[i];
            }

            for (int i = 0; i < DialogueScript.GetComponent<ThirdDialogueScript>().Customer_IntensityOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<ThirdDialogueScript>().Customer_IntensityOrder[i] == "")
                    break;

                IntensityOrder[i] = DialogueScript.GetComponent<ThirdDialogueScript>().Customer_IntensityOrder[i];
            }


            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n" + PerfumeOrder[5] + "\n"
            + "\n" + IntensityOrder[0] + "\n" + IntensityOrder[1] + "\n" + IntensityOrder[2] + "\n" + IntensityOrder[3];
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            for (int i = 0; i < DialogueScript.GetComponent<FourthDialogueScript>().Customer_PerfumeOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<FourthDialogueScript>().Customer_PerfumeOrder[i] == "")
                    break;

                PerfumeOrder[i] = DialogueScript.GetComponent<FourthDialogueScript>().Customer_PerfumeOrder[i];
            }

            for (int i = 0; i < DialogueScript.GetComponent<FourthDialogueScript>().Customer_IntensityOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<FourthDialogueScript>().Customer_IntensityOrder[i] == "")
                    break;

                IntensityOrder[i] = DialogueScript.GetComponent<FourthDialogueScript>().Customer_IntensityOrder[i];
            }


            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n" + PerfumeOrder[5] + "\n"
            + "\n" + IntensityOrder[0] + "\n" + IntensityOrder[1] + "\n" + IntensityOrder[2] + "\n" + IntensityOrder[3];
        }


    }

    public void ReceiptClick()
    {
        if (Recipt.activeSelf)
            Recipt.SetActive(false);
        else
            Recipt.SetActive(true);
    }
}
