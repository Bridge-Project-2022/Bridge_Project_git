using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThirdDialogueRandom : MonoBehaviour
{
    //public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public GameObject DailyResult;

    GameObject BackGround;
    GameObject WindowBG;

    public TextMeshProUGUI BuyerDialogue;

    public bool isDialogueEnd = false;

    //public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//거절 횟수 -> 평판 영향, 일차 지날 때 마다 리셋되어야 함.

    int C_1_random;
    int C_2_random;

    public string[] SellerSentences = new string[2];// 유저 대화 배열

    ThirdDialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];

    public Sprite[] BG_Sprite = new Sprite[5];

    public bool AStart = false;
    public bool D1Start = false;
    public bool D2Start = false;
    public bool EStart = false;

    int ACount = 0;
    int D1Count = 0;
    int D2Count = 0;
    int ECount = 0;


    public bool isDialogueStart = false;

    bool isSelectStart = false;
    bool isArrowStart = false;

    public void Update()
    {

        DS = GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>();

        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;

        for (int i = 0; i < BuyerOrder.Length; i++)
        {
            BuyerOrder[i] = DS.Customer_PerfumeOrder[i];
        }

        for (int i = 0; i < BuyerIntensity.Length; i++)
        {
            BuyerIntensity[i] = DS.Customer_IntensityOrder[i];
        }

        for (int i = 0; i < BuyerRejectReaction.Length; i++)
        {
            BuyerRejectReaction[i] = DS.Customer_RejectReaction[i];
        }

        for (int i = 0; i < BuyerPerfumeReaction.Length; i++)
        {
            BuyerPerfumeReaction[i] = DS.Customer_PerfumeReaction[i];
        }

        Distiller.GetComponent<Distiller>().BaseItemName = DS.Customer_Flavoring[0];
        Presser.GetComponent<Presser>().MiddleItemName = DS.Customer_Flavoring[1];
        Cooler.GetComponent<Cooler>().TopItemName = DS.Customer_Flavoring[2];

        if (isDialogueEnd == true)
        {
            if (isSelectStart == true)
            {
                Select.gameObject.SetActive(true);
            }
            if (isArrowStart == true)
            {
                arrow.gameObject.SetActive(true);
            }
        }
        else
        {
            if (isSelectStart == false)
            {
                Select.gameObject.SetActive(false);
            }
            if (isArrowStart == false)
            {
                arrow.gameObject.SetActive(false);
            }
        }
    }
    public void NextDialogue()
    {
        StopAll();
        if (AStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerOrder[ACount]));
            ACount++;

            if (BuyerOrder[ACount] == "")
            {
                //Debug.Log("A끝남");
                isSelectStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                ACount = 0;
                AStart = false;
            }
        }
        if (D1Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
            D1Count++;

            if (BuyerIntensity[D1Count] == "")
            {
                //Debug.Log("D1끝남");
                isArrowStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                D1Count = 0;
                D1Start = false;
            }
        }
        if (D2Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
            D2Count++;

            if (BuyerRejectReaction[D2Count] == "")
            {
                //Debug.Log("D2끝남");
                D2Count = 0;
                D2Start = false;
                Invoke("End", 2f);
            }
        }
        if (EStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerPerfumeReaction[ECount]));
            ECount++;

            if (BuyerPerfumeReaction[ECount] == "")
            {
                //Debug.Log("E끝남");
                ECount = 0;
                EStart = false;
                Invoke("End", 2f);
            }
        }
    }

    public void A_Start()//손님 : 입장, 향수 구매 이유 제시
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);

        AStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void C_1_Start()// 유저 : 승낙 - 향 세기 질문
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 0.3f);
    }

    public void C_2_Start()//유저 : 거부 - 거부 이유 제시
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().rejectNum += 1;
        float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        rejectCnt += 1;
        if (rejectCnt == 1)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }


        else if (rejectCnt == 2)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
        if (rejectCnt >= 3)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }

        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 0.3f);
    }

    public void D_1_Start()//손님 : 승낙 - 향 세기 결정
    {
        Buyer.gameObject.SetActive(true);
        //Seller.gameObject.SetActive(false);
        //makeStart = true;
        D1Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void D_2_Start()// 손님 : 거부 - 불만 표출
    {
        //Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);

        D2Start = true;
        isDialogueStart = true;
        NextDialogue();
    }


    public void E_1_Start()//손님 : 향수 받고 반응
    {
        isArrowStart = false;
        EStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void End()
    {
        GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "basic";
        isDialogueStart = false;
        int temp;
        temp = DS.Customer_ID[0];
        for (int i = 0; i < DS.Customer_ID.Length - 1; i++)
        {
            DS.Customer_ID[i] = DS.Customer_ID[i + 1];
        }
        DS.Customer_ID[DS.Customer_ID.Length - 1] = temp;

        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum < 9)
        {
            if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 3)//손님 3명 가고 나서 점심으로 바뀜
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "afternoon";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[4];

            }
            else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 6)//손님 6명 가고 나서 저녁으로 바뀜
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "night";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[5];
            }

            Invoke("A_Start", 5f);//손님 가고 5초 뒤에 다음 손님 등장. 인게임 시간 보고 추가 조건문 달아야 함
        }


        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 9)//손님 9명 가고 나서 최종 창이 뜸.
        {
            Invoke("DailyWindowOpen", 3f);
        }
    }

    public void DailyWindowOpen()
    {
        DailyResult.gameObject.SetActive(true);
    }
    IEnumerator NormalChat(string narration)// 타이핑 효과 -> 여기서 향의 세기에 따른 증류기 로직 결정 가능
    {
        string writerText = "";
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
                isDialogueEnd = true;
            else
                isDialogueEnd = false;
            BuyerDialogue.text = writerText;
            //SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    IEnumerator Count(float target, float current)

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

    public void StopAll()
    {
        StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }
}
