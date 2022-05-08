using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueRandom2 : MonoBehaviour
{
    public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public TextMeshProUGUI BuyerDialogue;
    public TextMeshProUGUI SellerDialogue;

    private SpriteRenderer spriteRenderer;

    public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//거절 횟수 -> 평판 영향, 일차 지날 때 마다 리셋되어야 함.

    int A_random;
    int B_random;
    int C_1_random;
    int C_2_random;
    int D_1_random;
    int D_2_random;
    int E_1_random;
    int E_2_random;
    int E_3_random;
   
    int Sprite_random;

    public string[] SellerSentences = new string[2];// 유저 대화 배열
     
    public static DialogueScript2 DS;
    static int OrderLength = DS.Customer_PerfumeOrder.Length;//손님 향수 주문
    static int IntensityLength = DS.Customer_IntensityOrder.Length;//손님 강도 선택
    static int RejectLength = DS.Customer_RejectReaction.Length;//손님 거절 반응
    static int PerfumeLength = DS.Customer_PerfumeReaction.Length;//손님 향수 반응


    public string[] BuyerOrder = new string[OrderLength];
    public string[] BuyerIntensity = new string[IntensityLength];
    public string[] BuyerRejectReaction = new string[RejectLength];
    public string[] BuyerPerfumeReaction = new string[PerfumeLength];


    public void Start()
    {
        for (int i = 0; i < OrderLength; i++)
        {
            BuyerOrder[i] = DS.Customer_PerfumeOrder[i];
        }

        for (int i = 0; i < IntensityLength; i++)
        {
            BuyerIntensity[i] = DS.Customer_IntensityOrder[i];
        }

        for (int i = 0; i < RejectLength; i++)
        {
            BuyerRejectReaction[i] = DS.Customer_RejectReaction[i];
        }

        for (int i = 0; i < PerfumeLength; i++)
        {
            BuyerPerfumeReaction[i] = DS.Customer_PerfumeReaction[i];
        }
    }
    public void RandomDialogue()// 랜덤 함수(대화 랜덤)
    {
        C_1_random = Random.Range(0, DS.Dialogue_C_1.Length);
        C_2_random = Random.Range(0, DS.Dialogue_C_2.Length);

        SellerSentences[0] = DS.Dialogue_C_1[C_1_random];
        SellerSentences[1] = DS.Dialogue_C_2[C_2_random];

    }

    public void A_Start()//손님 : 입장, 향수 구매 이유 제시
    {
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);
        for(int i = 0; i < BuyerOrder.Length; i++)
        {
            StartCoroutine(NormalChat(BuyerOrder[i]));
        }
        Invoke("C_1_Start", 2f);
    }
    public void C_1_Start()// 유저 : 승낙 - 향 세기 질문
    {
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 2f);
    }

    public void C_2_Start()//유저 : 거부 - 거부 이유 제시
    {
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().rejectNum += 1;
        rejectCnt += 1;
        if (rejectCnt == 1)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
        else if (rejectCnt == 2)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
        if (rejectCnt >= 3)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;

        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 2f);
    }

    public void D_1_Start()//손님 : 승낙 - 향 세기 결정
    {
        Buyer.gameObject.SetActive(true);
        Seller.gameObject.SetActive(false);
        for (int i = 0; i < BuyerIntensity.Length; i++)
        {
            StartCoroutine(NormalChat(BuyerIntensity[i]));
        }
        arrow.gameObject.SetActive(true);
        makeStart = true;

    }

    public void D_2_Start()// 손님 : 거부 - 불만 표출
    {
        Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);
        for (int i = 0; i < BuyerRejectReaction.Length; i++)
        {
            StartCoroutine(NormalChat(BuyerRejectReaction[i]));
        }
        Invoke("End", 2f);
    }

    public void E_1_Start()//손님 : 향수 받고 반응
    {
        for (int i = 0; i < BuyerPerfumeReaction.Length; i++)
        {
            StartCoroutine(NormalChat(BuyerPerfumeReaction[i]));
        }
        Invoke("End", 2f);
    }

    /*public void E_2_Start()//손님 : 향수 최종 NORMAL일 경우
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[5]));
        Invoke("End", 2f);
    }

    public void E_3_Start()//손님 : 향수 최종 BAD일 경우
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[6]));
        Invoke("End", 2f);
    }*/

    public void End()
    {
        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);
        Invoke("A_Start", 5f);//손님 가고 5초 뒤에 다음 손님 등장. 인게임 시간 보고 추가 조건문 달아야 함
    }

    IEnumerator NormalChat(string narration)// 타이핑 효과 -> 여기서 향의 세기에 따른 증류기 로직 결정 가능
    {
       /* if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[0])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "인간";
            Presser.GetComponent<Presser>().MiddleItemName = "연인";
            Cooler.GetComponent<Cooler>().TopItemName = "사랑";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[1])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "장소";
            Presser.GetComponent<Presser>().MiddleItemName = "놀이공원";
            Cooler.GetComponent<Cooler>().TopItemName = "행복";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[2])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "동물";
            Presser.GetComponent<Presser>().MiddleItemName = "반려동물";
            Cooler.GetComponent<Cooler>().TopItemName = "슬픔";
        }*/

        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            BuyerDialogue.text = writerText;
            SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.05f);
            yield return null;
        }
    }
}

