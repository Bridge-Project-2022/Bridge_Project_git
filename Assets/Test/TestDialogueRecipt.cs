using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDialogueRecipt : MonoBehaviour
{
    // Start is called before the first frame update
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
      

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            for (int i = 0; i < DialogueScript.GetComponent<TestDialogueScript>().Customer_PerfumeOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<TestDialogueScript>().Customer_PerfumeOrder[i] == "")
                    break;

                PerfumeOrder[i] = DialogueScript.GetComponent<TestDialogueScript>().Customer_PerfumeOrder[i];
            }

            for (int i = 0; i < DialogueScript.GetComponent<TestDialogueScript>().Customer_IntensityOrder.Length; i++)
            {
                if (DialogueScript.GetComponent<TestDialogueScript>().Customer_IntensityOrder[i] == "")
                    break;

                IntensityOrder[i] = DialogueScript.GetComponent<TestDialogueScript>().Customer_IntensityOrder[i];
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
