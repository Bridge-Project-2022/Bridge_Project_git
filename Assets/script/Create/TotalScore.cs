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

    public int totalScore;//���� ��� ����

    public GameObject Perfume;

    public bool isStart = false;//��� ���� ������ true��.

    public float totalTime = 0;//���� �ɸ� �ð�

    public int RightItem = 0;//�䱸�� ��� �����?

    public int originPrice = 0;//����
    public int reputationPrice = 0;//���ǿ� ����

    public string reputation;// ����

    private void Start()
    {
        totalScore = 0;
       
    }
    private void Update()
    {
        if (isCoolFin == true && isPressFin == true && isDistillFin == true)//��� ���� ������ ��� ���
        {
            isStart = true;
            Perfume.gameObject.SetActive(true);
        }
    }

    public void Calculate()
    {
        if (isStart == true)
        {
            Debug.Log("��� �����...");
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
                Debug.Log("���� ������");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
                reputation = "verygood";
            }
            else if (totalScore >= reputationPrice + 190 && totalScore < reputationPrice + 260)
            {
                Debug.Log("���� ��");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 6;
                reputation = "good";
            }
            else if (totalScore >= reputationPrice + 120 && totalScore < reputationPrice + 190)
            {
                Debug.Log("���� ���");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 1;
                reputation = "normal";
            }
            else if (totalScore >= reputationPrice + 60 && totalScore < reputationPrice + 120)
            {
                Debug.Log("���� �b");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
                reputation = "bad";
            }
            else
            {
                Debug.Log("���� �����b");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
                reputation = "verybad";
            }

            Debug.Log("���� ��� ���� : "+ totalScore);
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money += totalScore;

            //Invoke("ResetAll", 2f);
        }
    }
    public void totalPrice()
    {
        if ((int)totalTime < 30)//�� ����
        {
            totalScore += 50;
        }
        else if ((int)totalTime >= 30 && (int)totalTime < 60)//��� ����
        {
            totalScore += 30;
        }
        else if ((int)totalTime >= 60)//��� ����
        {
            totalScore -= 30;
        }
        //���⿡ totalScore += ��� ����; 

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
