using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distiller : MonoBehaviour
{
    public float distillerTime = 6.0f;

    public GameObject distillerWindow;
    public GameObject distiller;
    public GameObject clickedItem;
    public ItemProperty ClickedItem;
    public GameObject itemImage;
    public GameObject InvenUI;

    bool isWickDown = false;
    public string DistillerStatus = "";

    public GameObject temperatureSlider;
    int temperature = 0;
    int maxTemperature = 135;
    float maxTemperDuration = 0.0f;
    float minTemperDuration = 0.0f;

    bool DistillGood = false;
    bool DistillNormal = false;
    bool DistillBad = true;

    public string BaseItemName = ""; //손님이 요구하는 베이스 향료 이름

    //public GameObject baseInvenSlots;

    public void OnEnable()
    {
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("boiling");
        Invoke("EndDistiller", distillerTime);
    }

public void DistillerOn(ItemProperty item)
    {
        //this.gameObject.GetComponent<Button>().interactable = true;//증류기 버튼 클릭 가능해짐.
        ClickedItem = item;
        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        if (ClickedItem.name == BaseItemName)
        {
            Debug.Log("베이스 향료 맞음");
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
    }

    public void OnDistillerBtnClick()
    {
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        distillerWindow.SetActive(true);

        if (clickedItem == null)
            return;

        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }

    void Update()
    {
        float curTemper = temperatureSlider.GetComponent<Slider>().value;

        if (isWickDown)
        {
            temperatureSlider.GetComponent<Slider>().value += 1;

            if (curTemper > maxTemperature - 1)
            {
                maxTemperDuration += Time.deltaTime;

                if (maxTemperDuration > 1.5f)
                {
                    itemImage.GetComponent<Image>().color = new Color(1, 0, 0);
                    clickedItem.GetComponent<Image>().color = new Color(1, 0, 0);
                    EndDistiller();
                    maxTemperDuration = 0.0f;
                }
            }
            else
            {
                maxTemperDuration = 0.0f;
            }
        }
        else
        {
            temperatureSlider.GetComponent<Slider>().value -= 1;
        }
    }

    public void EndDistiller()
    {
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
        InvenUI.GetComponent<Button>().interactable = true;
        Invoke("CloseWindow", 0.5f);
        // DistillerResult();
    }

    public void CloseWindow()
    {
        TotalScore.FindObjectOfType<TotalScore>().isDistillFin = true;
        temperature = 0;
        distiller.gameObject.GetComponent<Button>().interactable = false;
        distillerWindow.SetActive(false);
        
    }

    public void DistillerResult()
    {
        if (DistillerStatus == "강함")
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

        else if (DistillerStatus == "보통")
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

        else if (DistillerStatus == "약함")
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

        else if (DistillerStatus == "아무거나")
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
    public void WickDown()
    {
        isWickDown = true;
    }

    public void WickUp()
    {
        isWickDown = false;
    }
}
