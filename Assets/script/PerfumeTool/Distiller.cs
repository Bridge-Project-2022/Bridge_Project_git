using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distiller : MonoBehaviour
{
    public GameObject distillerWindow;
    public float distillerTime = 6.0f;
    public GameObject[] temperatureList;
    public int maxTemperature;

    bool isWork = false;
    int temperature = 0;

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

        Debug.Log(temperature);
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
        distillerWindow.SetActive(false);
    }
}
