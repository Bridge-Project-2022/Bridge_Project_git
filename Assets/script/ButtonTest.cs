using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonTest : MonoBehaviour
{
    public int day = 3;
    public NextDay nd;
    public void DaySkipBtn()
    {
        if (GameObject.Find("Panels").transform.GetChild(2).gameObject.activeSelf)
        {
            GameObject.Find("Panels").transform.GetChild(2).gameObject.SetActive(false);
        }

        if (GameObject.Find("Panels").transform.GetChild(9).gameObject.activeSelf)
        {
            GameObject.Find("Panels").transform.GetChild(9).gameObject.SetActive(false);
        }
        GameObject.Find("DialogueScript1").GetComponent<DialogueScript>().enabled = false;
        GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;

        nd.day = day - 1;
        //nd.DayCheckTest();
    }
}
