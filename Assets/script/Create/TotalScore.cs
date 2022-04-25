using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScore : MonoBehaviour
{

    public bool isCoolGood = false;
    public bool isCoolNormal = false;
    public bool isCoolBad = false;

    public bool isPressGood = false;
    public bool isPressNormal = false;
    public bool isPressBad = false;

    public bool isDistillGood = false;
    public bool isDistillNormal = false;
    public bool isDistillBad = false;


    public bool isCoolFin = false;
    public bool isPressFin = false;
    public bool isDistillFin = false;

    public int totalScore;//최종 향수 가격

    public GameObject Perfume;

    public bool isStart = false;//모든 과정 끝나면 true됨.

    public float totalTime = 0;//최종 걸린 시간

    public int RightItem = 0;//요구한 향료 썼는지?

    public int originPrice = 0;//원가
    public int reputationPrice = 0;//평판용 원가

    public string reputation;// 평판

    private void Start()
    {
        totalScore = 0;
       
    }
    private void Update()
    {
        if (isCoolFin == true && isPressFin == true && isDistillFin == true)//모든 과정 끝나면 향수 계산
        {
            isStart = true;
            Perfume.gameObject.SetActive(true);
        }
    }

    public void Calculate()
    {
        if (isStart == true)
        {
            Debug.Log("향수 계산중...");
            totalPrice();
            if (RightItem == 3)
            {
                totalScore += originPrice + 50;
            }

            else if (RightItem == 2)
            {
                totalScore += originPrice + 30;
            }

            else if (RightItem == 1)
            {
                totalScore += originPrice + 10;
            }

            else if (RightItem == 0)
            {
                totalScore += originPrice - 50;
            }

            if (totalScore == reputationPrice + 260)
            {
                Debug.Log("평판 베리굳");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
                reputation = "verygood";
            }
            else if (totalScore >= reputationPrice + 190 && totalScore < reputationPrice + 260)
            {
                Debug.Log("평판 굳");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 6;
                reputation = "good";
            }
            else if (totalScore >= reputationPrice + 120 && totalScore < reputationPrice + 190)
            {
                Debug.Log("평판 노멀");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 1;
                reputation = "normal";
            }
            else if (totalScore >= reputationPrice + 60 && totalScore < reputationPrice + 120)
            {
                Debug.Log("평판 밷");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
                reputation = "bad";
            }
            else
            {
                Debug.Log("평판 베리밷");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
                reputation = "verybad";
            }

            Debug.Log("최종 향수 가격 : "+ totalScore);
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money += totalScore;

            //Invoke("ResetAll", 2f);
        }
    }
    public void totalPrice()
    {
        if ((int)totalTime < 30)//굿 판정
        {
            totalScore += 50;
        }
        else if ((int)totalTime >= 30 && (int)totalTime < 60)//노멀 판정
        {
            totalScore += 30;
        }
        else if ((int)totalTime >= 60)//배드 판정
        {
            totalScore -= 30;
        }
        //여기에 totalScore += 향료 원가; 

        if (isCoolGood == true)
        {
            totalScore += 70;
        }
        if (isPressGood == true)
        {
            totalScore += 70;
        }
        if (isDistillGood == true)
        {
            totalScore += 70;
        }

        //////////////////////////////////////
        if (isCoolNormal == true)
        {
            totalScore += 20;
        }
        if (isPressNormal == true)
        {
            totalScore += 20;
        }
        if (isDistillNormal == true)
        {
            totalScore += 20;
        }
        ///////////////////////////////////
        if (isCoolBad == true)
        {
            totalScore -= 30;
        }
        if (isPressBad == true)
        {
            totalScore -= 30;
        }
        if (isDistillBad == true)
        {
            totalScore -= 30;
        }

        Timer.FindObjectOfType<Timer>().TimerStop();
    }

    public void ResetAll()
    {
        isCoolGood = false;
        isCoolNormal = false;
        isCoolBad = false;

        isPressGood = false;
        isPressNormal = false;
        isPressBad = false;

        isDistillGood = false;
        isDistillNormal = false;
        isDistillBad = false;


        isCoolFin = false;
        isPressFin = false;
        isDistillFin = false;

        isStart = false;

        totalTime = 0;

        RightItem = 0;

        originPrice = 0;
        reputationPrice = 0;

        totalScore = 0;
    }
}
