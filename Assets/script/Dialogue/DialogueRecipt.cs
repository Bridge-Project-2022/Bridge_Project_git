using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRecipt : MonoBehaviour
{

    public GameObject Recipt;
    public GameObject DialogueScript;
    public GameObject ReceiptText;

    public string[] PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] IntensityOrder = new string[5];//향수 강도 대사

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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

        /*
        if (PerfumeOrder.Length == 4)
        {
            ReceiptText.GetComponent<Text>().text = PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n";
        }

        else if (PerfumeOrder.Length == 5)
        {
            ReceiptText.GetComponent<Text>().text = PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n";
        }
        */

        ReceiptText.GetComponent<Text>().text =  "\n" + PerfumeOrder[0] + "\n" + PerfumeOrder[1] + "\n" + PerfumeOrder[2] + "\n" + PerfumeOrder[3] + "\n" + PerfumeOrder[4] + "\n" + PerfumeOrder[5] + "\n"
        + "\n" + IntensityOrder[0] + "\n" + IntensityOrder[1] + "\n" + IntensityOrder[2] + "\n" + IntensityOrder[3];
    }

    public void ReceiptClick()
    {
        if (Recipt.activeSelf)
            Recipt.SetActive(false);
        else
            Recipt.SetActive(true);
    }
}
