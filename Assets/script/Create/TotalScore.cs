using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int perfumePrice = 0;// 최종 향수 가격
    public int totalScore = 0;//팁 가격

    public GameObject Perfume;

    public bool isStart = false;//모든 과정 끝나면 true됨.

    public float totalTime = 0;//최종 걸린 시간

    public int RightItem = 0;//요구한 향료 썼는지?

    public int originPrice = 0;// 향수 제작에 사용된 향료 원가
    public int rightPrice = 0;// 맞게 사용한 향료 원가
    public int reputNum = 0;// 평판 카운트 숫자

    public string reputation;// 평판

    public FirstDaySetting fd;

    private void Start()
    {
        totalScore = 0;
       
    }
    private void Update()
    {
        if (isCoolFin == true && isPressFin == true && isDistillFin == true)//모든 과정 끝나면 향수 계산
        {
            Perfume.gameObject.SetActive(true);
        }
    }

    public void Calculate()
    {

        Debug.Log("향수 계산중...");
        totalPrice();
        if (originPrice == 0)//하나도 안고르고 바로 향수 제조 선택한 경우
        {
            Debug.Log("하나도 안고르고 바로 향수 제조 선택한 경우");
            perfumePrice = 0;
            float imsiMoney = fd.Money;
            fd.Money += perfumePrice;
            StartCoroutine(Count(imsiMoney, fd.Money));
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;
            Debug.Log("평판 밷");
            float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
            StartCoroutine(Countt(imsiReputation, fd.Reputation));
            reputation = "bad";
        }
        else if (RightItem != 3 && originPrice > 0)// 하나라도 고르긴 했는데 맞는 향료가 아닐 경우
        {
            Debug.Log("하나라도 고르긴 했는데 맞는 향료가 아닐 경우");
            perfumePrice = totalScore;
            float imsiMoney = fd.Money;
            fd.Money += perfumePrice;
            StartCoroutine(Count(imsiMoney, fd.Money));
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().allRevenue += perfumePrice;
            Debug.Log("평판 밷");
            float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
            StartCoroutine(Countt(imsiReputation, fd.Reputation));
            reputation = "bad";
        }

        else if ( RightItem == 3 && originPrice > 0)//3개 향료 다 맞은 경우
        {
            Debug.Log("3개 향료 다 맞은 경우");
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
                    Debug.Log("평판 베리굳");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "verygood";
                }
                else if (reputNum < 35 && reputNum >= 10)
                {
                    Debug.Log("평판 굳");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 6;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "good";
                }
                else if (reputNum < 10 && reputNum >= 0)
                {
                    Debug.Log("평판 노멀");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 1;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "normal";
                }
                else if (reputNum < 0 && reputNum >= -10)
                {
                    Debug.Log("평판 밷");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "bad";
                }
                else if (reputNum < -10 && reputNum >= -35)
                {
                    Debug.Log("평판 베리밷");
                    FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
                    StartCoroutine(Countt(imsiReputation, fd.Reputation));
                    reputation = "verybad";
                }
                Debug.Log("최종 향수 가격 : " + totalScore);
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money += totalScore;
                GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
                //Invoke("ResetAll", 2f);
            }
        }
    }
    public void totalPrice()
    {
        if ((int)totalTime < 30)//굿 판정
        {
            totalScore += rightPrice * 5 / 100;
            reputNum += 5;
        }
        else if ((int)totalTime >= 30 && (int)totalTime < 60)//노멀 판정
        {
            totalScore += 0;
            reputNum += 0;
        }
        else if ((int)totalTime >= 60)//배드 판정
        {
            totalScore += - (rightPrice * 5 / 100);
            reputNum -= 5;
        }
        //여기에 totalScore += 향료 원가; 
        
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
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            fd.GetComponent<Text>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        fd.GetComponent<Text>().text = ((int)current).ToString();

    }

    IEnumerator Countt(float target, float current)

    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            GameObject.Find("reputation_num").GetComponent<Text>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        GameObject.Find("reputation_num").GetComponent<Text>().text = ((int)current).ToString();

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
