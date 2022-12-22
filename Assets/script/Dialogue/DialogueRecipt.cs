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

            foreach (string str in DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<DialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<DialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            foreach (string str in DialogueScript.GetComponent<SecondDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<SecondDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<SecondDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<SecondDialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            foreach (string str in DialogueScript.GetComponent<ThirdDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<ThirdDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<ThirdDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<ThirdDialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            foreach (string str in DialogueScript.GetComponent<FourthDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<FourthDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<FourthDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<FourthDialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }


    }

    public void ReceiptClick()
    {
        Recipt.SetActive(true);
        this.GetComponent<Image>().enabled = false;
    }

    public void CloseBtnClick()
    {
        Recipt.SetActive(false);
        this.GetComponent<Image>().enabled = true;
    }
}
