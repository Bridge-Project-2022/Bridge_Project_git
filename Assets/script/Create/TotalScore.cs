using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public int RightItemPrice = 0;

    public GameObject Perfume;

    public bool isStart = false;//��� ���� ������ true��.

    public float totalTime = 0;//���� �ɸ� �ð�

    public int RightItem = 0;//�䱸�� ��� �����?
    public int UseItem = 0;//�䱸�� ��� �����?
    public int originPrice = 0;// ��� ���ۿ� ���� ��� ����
    public int rightPrice = 0;// �°� ����� ��� ����
    public int reputNum = 0;// ���� ī��Ʈ ����

    public string reputation;// ����

    public FirstDaySetting fd;

    public ItemProperty baseItem;
    public ItemProperty middleItem;
    public ItemProperty topItem;

    GameObject RC;

    public GameObject ReputationSlider;
    public GameObject ReputationHandle;
    public Sprite ReputationGood;
    public Sprite ReputationNormal;
    public Sprite ReputationBad;

    public bool isAllFinished = false;
    private void Start()
    {
        totalScore = 0;
        RC = GameObject.Find("RC").gameObject;
    }
    private void Update()
    {
        if (isCoolFin == true && isPressFin == true && isDistillFin == true)//��� ���� ������ ��� ���
        {
            Perfume.gameObject.SetActive(true);
        }
        RightItemPrice = baseItem.itemPrice + middleItem.itemPrice + topItem.itemPrice;

        if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation <= 30)
        {
            ReputationHandle.GetComponent<Image>().sprite = ReputationBad;
        }
        else if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation <= 60 && FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation > 30)
        {
            ReputationHandle.GetComponent<Image>().sprite = ReputationNormal;
        }
        else if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation > 60)
        {
            ReputationHandle.GetComponent<Image>().sprite = ReputationGood;
        }

    }

    public void Calculate()
    {
        Debug.Log("��� �����...");
        totalPrice();
        if (originPrice == 0)//�ϳ��� �Ȱ��� �ٷ� ��� ���� ������ ���
        {
            //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "bad";
            Debug.Log("�ϳ��� �Ȱ��� �ٷ� ��� ���� ������ ���");
            perfumePrice = 0;
            float imsiMoney = fd.Money;
            fd.Money += perfumePrice;
            StartCoroutine(Count(imsiMoney, fd.Money));
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;
            Debug.Log("���� �b");
            float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
            ReputationSlider.GetComponent<Slider>().value -= 0.05f;
            StartCoroutine(Countt(imsiReputation, fd.Reputation));
            reputation = "bad";
        }
        else if (RightItem != 3 && originPrice > 0)// �ϳ��� ���� �ߴµ� �´� ��ᰡ �ƴ� ���
        {
            //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "bad";
            Debug.Log("�ϳ��� ���� �ߴµ� �´� ��ᰡ �ƴ� ���");
            perfumePrice = totalScore;
            float imsiMoney = fd.Money;
            fd.Money += perfumePrice;
            StartCoroutine(Count(imsiMoney, fd.Money));
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;
            Debug.Log("���� �b");
            float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
            ReputationSlider.GetComponent<Slider>().value -= 0.05f;
            StartCoroutine(Countt(imsiReputation, fd.Reputation));
            reputation = "bad";
        }

        else if ( RightItem == 3 && originPrice > 0)//3�� ��� �� ���� ���
        {
            Debug.Log("3�� ��� �� ���� ���");
            float imsiMoney = fd.Money;
            perfumePrice = rightPrice + totalScore;
            fd.Money += perfumePrice;
            StartCoroutine(Count(imsiMoney, fd.Money));
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;
            float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            if (RightItem == 3)
            {
                if (reputNum == 35)
                {
                    Debug.Log("���� ������");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
                    ReputationSlider.GetComponent<Slider>().value += 0.1f;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "verygood";
                    //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "good";
                }
                else if (reputNum < 35 && reputNum >= 10)
                {
                    Debug.Log("���� ��");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 6;
                    ReputationSlider.GetComponent<Slider>().value += 0.06f;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "good";
                    //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "good";
                }
                else if (reputNum < 10 && reputNum >= 0)
                {
                    Debug.Log("���� ���");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 1;
                    ReputationSlider.GetComponent<Slider>().value += 0.01f;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "normal";
                    //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "basic";
                }
                else if (reputNum < 0 && reputNum >= -10)
                {
                    Debug.Log("���� �b");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
                    ReputationSlider.GetComponent<Slider>().value -= 0.05f;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "bad";
                    //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "bad";
                }
                else if (reputNum < -10 && reputNum >= -35)
                {
                    Debug.Log("���� �����b");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
                    ReputationSlider.GetComponent<Slider>().value -= 0.08f;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "verybad";
                    //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "bad";
                }
                Debug.Log("���� ��� ���� : " + totalScore);
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money += totalScore;
                GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
                //Invoke("ResetAll", 2f);
            }
        }
    }
    public void totalPrice()
    {
        if ((int)totalTime < 50)//�� ����
        {
            totalScore += rightPrice * 5 / 100;
            reputNum += 5;
        }
        else if ((int)totalTime >= 50 && (int)totalTime < 70)//��� ����
        {
            totalScore += 0;
            reputNum += 0;
        }
        else if ((int)totalTime >= 70)//��� ����
        {
            totalScore += - (rightPrice * 5 / 100);
            reputNum -= 5;
        }
        //���⿡ totalScore += ��� ����; 
        
        if (isCoolGood == true)
        {
            if (FindObjectOfType<Cooler>().ClickedItem.name == FindObjectOfType<Cooler>().TopItemName)
            {
                totalScore += FindObjectOfType<Cooler>().ClickedItem.itemPrice * 10 / 100;
                reputNum += 10;
            }
        }
        if (isPressGood == true)
        {
            if (FindObjectOfType<Presser>().ClickedItem.name == FindObjectOfType<Presser>().MiddleItemName)
            {
                totalScore += FindObjectOfType<Presser>().ClickedItem.itemPrice * 10 / 100;
                reputNum += 10;
            }
        }
        if (isDistillGood == true)
        {
            if (FindObjectOfType<Distiller>().ClickedItem.name == FindObjectOfType<Distiller>().BaseItemName)
            { 
                totalScore += FindObjectOfType<Distiller>().ClickedItem.itemPrice * 10 / 100;
                reputNum += 10;
            }
                
        }

        //////////////////////////////////////
        if (isCoolNormal == true)
        {
            if (FindObjectOfType<Cooler>().ClickedItem.name == FindObjectOfType<Cooler>().TopItemName)
            { 
                totalScore += 0;
                reputNum += 0;
            }
                
        }
        if (isPressNormal == true)
        {
            if (FindObjectOfType<Presser>().ClickedItem.name == FindObjectOfType<Presser>().MiddleItemName)
            { 
                totalScore += 0;
                reputNum += 0;
            }
              
        }
        if (isDistillNormal == true)
        {
            if (FindObjectOfType<Distiller>().ClickedItem.name == FindObjectOfType<Distiller>().BaseItemName)
            { 
                totalScore += 0;
                reputNum += 0;
            }
                
        }
        ///////////////////////////////////
        if (isCoolBad == true)
        {
            if (FindObjectOfType<Cooler>().ClickedItem.name == FindObjectOfType<Cooler>().TopItemName)
            { 
                totalScore += -1 * (FindObjectOfType<Cooler>().ClickedItem.itemPrice * 10 / 100);
                reputNum -= 10;
            }
               
        }
        if (isPressBad == true)
        {
            if (FindObjectOfType<Presser>().ClickedItem.name == FindObjectOfType<Presser>().MiddleItemName)
            { 
                totalScore += -1 * (FindObjectOfType<Presser>().ClickedItem.itemPrice * 10 / 100);
                reputNum -= 10;
            }
           
        }
        if (isDistillBad == true)
        {
            if (FindObjectOfType<Distiller>().ClickedItem.name == FindObjectOfType<Distiller>().BaseItemName)
            { 
                totalScore += -1 * (FindObjectOfType<Distiller>().ClickedItem.itemPrice * 10 / 100);
                reputNum -= 10;
            }
                
        }
        
        Timer.FindObjectOfType<Timer>().TimerStop();
    }

    IEnumerator Count(float target, float current)

    {
        float duration = 0.5f; // ī���ÿ� �ɸ��� �ð� ����. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            fd.GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        fd.GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

    }

    IEnumerator Countt(float target, float current)

    {
        float duration = 0.5f; // ī���ÿ� �ɸ��� �ð� ����. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            //GameObject.Find("reputation_num").GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        //GameObject.Find("reputation_num").GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

    }

    public void ResetAll()
    {
        UseItem = 0;
        isAllFinished = false;
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
