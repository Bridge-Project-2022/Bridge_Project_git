using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distiller : MonoBehaviour
{
    public GameObject distillerWindow;
    public GameObject clickedItem;
    public float distillerTime = 6.0f;
    public GameObject[] temperatureList;
    public int maxTemperature;
    public GameObject itemImage;

    public ItemProperty ClickedItem;

    bool isWork = false;

    int temperature = 0;

    /*float lowTempTime = 0;
    float middleTempTime = 0;
    float HighTempTime = 0;*/

    public string DistillerStatus = "";

    bool DistillGood = false;
    bool DistillNormal = false;
    bool DistillBad = true;

    public int DistillCnt;

    public string BaseItemName;//�մ��� �䱸�ϴ� ���̽� ��� �̸�

    public GameObject baseInvenSlots;

    public void Start()
    {
        DistillCnt = 0; 
    }

public void DistillerOn(ItemProperty item)
    {
        this.gameObject.GetComponent<Button>().interactable = true;//������ ��ư Ŭ�� ��������.
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        ClickedItem = item;
        if (ClickedItem.name == BaseItemName)
        {
            Debug.Log("���̽� ��� ����");
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
        }
            
        //Debug.Log(ClickedItem.name);
    }


    public void OnDistillerBtnClick()
    {
        distillerWindow.SetActive(true);

        if (clickedItem == null)
            return;

        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
    }

    public void StartDistiller()
    {
        Invoke("EndDistiller", distillerTime);
        isWork = true;

        Invoke("DistillerNormal",2f);
        Invoke("DistillerGood", 4f);
    }
    void DistillerGood()
    {
        DistillGood = true;
    }
    void DistillerNormal()
    {
        DistillNormal = true;
    }

    public void OnWickBtnClick()
    {
        DistillCnt += 1;
        //Debug.Log(DistillCnt);
        if (isWork)
        {
            RasieTemperature();
        }
        else
        {
            StartDistiller();
        }
    }

    void RasieTemperature()
    {
        if (temperature >= maxTemperature)
            return;

        temperatureList[temperature].SetActive(true);
        temperature++;
    }

    public void EndDistiller()
    {
        foreach (GameObject temp in temperatureList)
        {
            temp.SetActive(false);
        }

        Invoke("CloseWindow", 0.5f);
        DistillerResult();
    }

    public void CloseWindow()
    {
        /*for (int i = 0; i < baseInvenSlots.transform.childCount; i++)
        {
            baseInvenSlots.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }*/
        TotalScore.FindObjectOfType<TotalScore>().isDistillFin = true;
        //TotalScore.isDistillFin = true;
        isWork = false;
        temperature = 0;
        distillerWindow.SetActive(false);
        this.gameObject.GetComponent<Button>().interactable = false;
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;
    }

    public void DistillerResult()
    {
        if (DistillerStatus == "����" && DistillCnt == 4)
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
            }
        }

        else if (DistillerStatus == "����" && DistillCnt == 3)
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
            }
        }

        else if (DistillerStatus == "����" && DistillCnt == 2)
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
            }
        }

        else if (DistillerStatus == "�ƹ��ų�")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
            }
        }

        else
        {
            TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
        }
    }

}
