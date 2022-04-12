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

    public int totalScore;

    public GameObject Perfume;

    public bool isStart = false;

    public float totalTime = 0;


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
            Debug.Log("최종 향수 가격 : "+ totalScore);

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
}
