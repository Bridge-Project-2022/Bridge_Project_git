using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NextDay : MonoBehaviour
{
    public int day = 1;
    public GameObject DailyResult;
    public GameObject RandomBuyer;
    public GameObject buyer;
    public GameObject Customer;
    public TextMeshProUGUI Today;


    public void NextDayClick()
    {
        DailyResult.GetComponent<DailyResult>().personNum = 0;
        DailyResult.GetComponent<DailyResult>().rejectNum = 0;
        DailyResult.GetComponent<DailyResult>().todayReputation = 0;
        DailyResult.GetComponent<DailyResult>().todayRevenue = 0;
        DailyResult.GetComponent<DailyResult>().originCost = 0;
        DailyResult.GetComponent<DailyResult>().allRevenue = 0;

        RandomBuyer.SetActive(false);
        buyer.SetActive(false);
        Customer.SetActive(true);

        day++;
        if (day == 2)
        {
            SecondDayStart();
        }
        if (day == 3)
        {
            ThirdDayStart();
        }
    }

    public void SecondDayStart()
    {
        Today.text = "02";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<DialogueRandom>().enabled = false;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void ThirdDayStart()
    {
        Today.text = "03";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = false;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void FourthDayStart()
    {
        Today.text = "04";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = false;
        //Trigger.GetComponent<FourthDialogueRandom>().enabled = true;
        CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }
}
