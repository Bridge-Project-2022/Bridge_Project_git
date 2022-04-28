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

    public int perfumePrice = 0;// ���� ��� ����
    public int totalScore = 0;//�� ����

    public GameObject Perfume;

    public bool isStart = false;//��� ���� ������ true��.

    public float totalTime = 0;//���� �ɸ� �ð�

    public int RightItem = 0;//�䱸�� ��� �����?

    public int originPrice = 0;// ��� ���ۿ� ���� ��� ����
    public int rightPrice = 0;// �°� ����� ��� ����
    public int reputNum = 0;// ���� ī��Ʈ ����

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
            if (originPrice == 0)//�ϳ��� �Ȱ��� �ٷ� ��� ���� ������ ���
            {
                perfumePrice = 0;
            }

            else if(originPrice > 0)//�ϳ��� �� ���
            {
                if (RightItem == 3)// ��� 3���� ��� �䱸�� �´� ���
                {
                    perfumePrice = rightPrice + totalScore;
                    GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;

                }

                else if (RightItem < 3)//�ϳ��� Ʋ�� ��Ḧ �� ���
                {
                    perfumePrice = totalScore;
                    if (perfumePrice < 0)
                        perfumePrice = 0;

                }
            }
         
            if (reputNum == 35)
            {
                Debug.Log("���� ������");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
                reputation = "verygood";
            }
            else if (reputNum < 35 && reputNum >= 10)
            {
                Debug.Log("���� ��");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 6;
                reputation = "good";
            }
            else if (reputNum < 10 && reputNum >= 0)
            {
                Debug.Log("���� ���");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 1;
                reputation = "normal";
            }
            else if (reputNum < 0 && reputNum >= -10)
            {
                Debug.Log("���� �b");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
                reputation = "bad";
            }
            else if(reputNum < -10 && reputNum >= -35)
            {
                Debug.Log("���� �����b");
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
                reputation = "verybad";
            }
            Debug.Log("���� ��� ���� : "+ totalScore);
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money += totalScore;
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            //Invoke("ResetAll", 2f);
        }
    }
    public void totalPrice()
    {
        if ((int)totalTime < 30)//�� ����
        {
            totalScore += rightPrice * 5 / 100;
            reputNum += 5;
        }
        else if ((int)totalTime >= 30 && (int)totalTime < 60)//��� ����
        {
            totalScore += 0;
            reputNum += 0;
        }
        else if ((int)totalTime >= 60)//��� ����
        {
            totalScore += - (rightPrice * 5 / 100);
            reputNum -= 5;
        }
        //���⿡ totalScore += ��� ����; 
        
        if (isCoolGood == true)
        {
            totalScore += FindObjectOfType<Cooler>().ClickedItem.itemPrice * 10 / 100;
            reputNum += 10;
        }
        if (isPressGood == true)
        {
            totalScore += FindObjectOfType<Presser>().ClickedItem.itemPrice * 10 / 100;
            reputNum += 10;
        }
        if (isDistillGood == true)
        {
            totalScore += FindObjectOfType<Distiller>().ClickedItem.itemPrice * 10 / 100;
            reputNum += 10;
        }

        //////////////////////////////////////
        if (isCoolNormal == true)
        {
            totalScore += 0;
            reputNum += 0;
        }
        if (isPressNormal == true)
        {
            totalScore += 0;
            reputNum += 0;
        }
        if (isDistillNormal == true)
        {
            totalScore += 0;
            reputNum += 0;
        }
        ///////////////////////////////////
        if (isCoolBad == true)
        {
            totalScore += -1 * (FindObjectOfType<Cooler>().ClickedItem.itemPrice * 10 / 100);
            reputNum -= 10;
        }
        if (isPressBad == true)
        {
            totalScore += -1 * (FindObjectOfType<Presser>().ClickedItem.itemPrice * 10 / 100);
            reputNum -= 10;
        }
        if (isDistillBad == true)
        {
            totalScore += -1 * (FindObjectOfType<Distiller>().ClickedItem.itemPrice * 10 / 100);
            reputNum -= 10;
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
        rightPrice = 0;

        totalScore = 0;

        reputNum = 0;
        perfumePrice = 0;
    }
}
