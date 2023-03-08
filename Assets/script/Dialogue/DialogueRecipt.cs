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
        else if (NextDay.FindObjectOfType<NextDay>().day == 5)
        {
            DialogueScript = GameObject.Find("DialogueScript5").gameObject;
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 6)
        {
            DialogueScript = GameObject.Find("DialogueScript6").gameObject;
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 7)
        {
            DialogueScript = GameObject.Find("DialogueScript7").gameObject;
        }

        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
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
            else//튜토리얼일 경우
            {
                ReceiptText.GetComponent<Text>().text = "\n" + "\n" + "\n" + "나는 향료를 구하는 여정 중에 만났던 작은 산새 하나가 떠오르는군. 우연한 계기로 여정을 함께 하게 됐었다네." + "\n" + "그 조그만 새와 함께 있다보면 꽤 행복했어. 콩 한쪽도 나누어 먹었지, 허허. 지금은 어찌 지내는지 궁금하구만." + "\n" + "아무튼, 부디 그 때의 기억을 언제고 다시 추억할 수 있게끔 해주게나." + "\n" + "\n" + "아, 향은 강한 편이 좋겠어. 나의 기억만큼 진한 향 말이야." + "\n";
            }
            
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

        else if (NextDay.FindObjectOfType<NextDay>().day == 5)
        {
            foreach (string str in DialogueScript.GetComponent<FifthDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<FifthDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<FifthDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<FifthDialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 6)
        {
            foreach (string str in DialogueScript.GetComponent<SixthDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<SixthDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<SixthDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<SixthDialogueScript>().Customer_IntensityOrder;
            }

            string PerfumeOrderText = string.Join("", PerfumeOrder);
            string IntensityOrderText = string.Join("", IntensityOrder);

            ReceiptText.GetComponent<Text>().text = "\n" + PerfumeOrderText + "\n" + "\n" + IntensityOrderText + "\n";
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 7)
        {
            foreach (string str in DialogueScript.GetComponent<SeventhDialogueScript>().Customer_PerfumeOrder)
            {
                PerfumeOrder = DialogueScript.GetComponent<SeventhDialogueScript>().Customer_PerfumeOrder;
            }

            foreach (string str in DialogueScript.GetComponent<SeventhDialogueScript>().Customer_IntensityOrder)
            {
                IntensityOrder = DialogueScript.GetComponent<SeventhDialogueScript>().Customer_IntensityOrder;
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
        RectTransform down = GameObject.Find("Etc").transform.GetChild(4).GetChild(3).GetComponent<RectTransform>();
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == true)
        {
            down.anchoredPosition = new Vector3(48, -370, 0);
        }
        else
            down.anchoredPosition = new Vector3(48, -263, 0);
    }

    public void CloseBtnClick()
    {
        Recipt.SetActive(false);
        this.GetComponent<Image>().enabled = true;
    }
}
