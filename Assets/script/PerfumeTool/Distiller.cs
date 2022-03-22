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

    bool isWork = false;

    int temperature = 0;

    float lowTempTime = 0;
    float middleTempTime = 0;
    float HighTempTime = 0;

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
    }

    public void OnWickBtnClick()
    {
        if(isWork)
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
    }

    public void CloseWindow()
    {
        isWork = false;
        temperature = 0;
        distillerWindow.SetActive(false);
    }

    public void Update()
    {
        
    }
}
