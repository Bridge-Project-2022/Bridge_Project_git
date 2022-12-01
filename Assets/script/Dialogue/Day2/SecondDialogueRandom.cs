using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SecondDialogueRandom : MonoBehaviour
{
    public GameObject RC;
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

    public string[] SellerSentences = new string[2];// 유저 대화 배열

    SecondDialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];

    public string[] BuyerOrderFace = new string[5];
    public string[] BuyerIntensityFace = new string[5];
    public string[] BuyerRejectFace = new string[5];
    public string[] BuyerReactFace = new string[5];

    public string[] BuyerFeel = new string[10];
    public Sprite[] BG_Sprite = new Sprite[5];

    bool AStart = false;
    bool D1Start = false;
    bool D2Start = false;
    bool EStart = false;
    bool F2Start = false;

    int ACount = 0;
    int D1Count = 0;
    int D2Count = 0;
    int ECount = 0;

    public bool isDialogueStart = false;

    bool isSelectStart = false;
    bool isArrowStart = false;

    public void Update()
    {

        DS = GameObject.Find("DialogueScript2").GetComponent<SecondDialogueScript>();

        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;

        foreach (string str in DS.Customer_PerfumeOrder)
        {
            BuyerOrder = DS.Customer_PerfumeOrder;
        }

        foreach (string str in DS.Customer_IntensityOrder)
        {
            BuyerIntensity = DS.Customer_IntensityOrder;
        }

        foreach (string str in DS.Customer_RejectReaction)
        {
            BuyerRejectReaction = DS.Customer_RejectReaction;
        }

        foreach (string str in DS.Customer_PerfumeReaction)
        {
            BuyerPerfumeReaction = DS.Customer_PerfumeReaction;
        }

        foreach (string str in DS.OrderFace)
        {
            BuyerOrderFace = DS.OrderFace;
        }

        foreach (string str in DS.IntensityFace)
        {
            BuyerIntensityFace = DS.IntensityFace;
        }

        foreach (string str in DS.RejectFace)
        {
            BuyerRejectFace = DS.RejectFace;
        }

        foreach (string str in DS.ReactFace)
        {
            BuyerReactFace = DS.ReactFace;
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
            if (ACount == 0)
            {
                RC.GetComponent<RandomImage>().CurrentFeel = BuyerOrderFace[0];
                RC.GetComponent<CriminalImage>().CurrentFeel = BuyerOrderFace[0];
                RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerOrderFace[0];

                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerOrder[0]));
                ACount++;
            }
            else
            {
                if (isDialogueEnd == false)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerOrderFace[ACount - 1];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerOrderFace[ACount - 1];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerOrderFace[ACount - 1];

                    BuyerDialogue.text = BuyerOrder[ACount - 1];
                    isDialogueEnd = true;
                }
                else if (isDialogueEnd == true)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerOrderFace[ACount];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerOrderFace[ACount];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerOrderFace[ACount];

                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    StartCoroutine(NormalChat(BuyerOrder[ACount]));
                    ACount++;
                }
            }
            if (ACount == BuyerOrder.Length)
            {
                isSelectStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                ACount = 0;
                AStart = false;
            }
        }
        if (D1Start == true)
        {
            if (D1Count == 0)
            {
                RC.GetComponent<RandomImage>().CurrentFeel = BuyerIntensityFace[0];
                RC.GetComponent<CriminalImage>().CurrentFeel = BuyerIntensityFace[0];
                RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerIntensityFace[0];

                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerIntensity[0]));
                D1Count++;
            }
            else
            {
                if (isDialogueEnd == false)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerIntensityFace[D1Count - 1];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerIntensityFace[D1Count - 1];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerIntensityFace[D1Count - 1];

                    BuyerDialogue.text = BuyerIntensity[D1Count - 1];
                    isDialogueEnd = true;
                }
                else if (isDialogueEnd == true)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerIntensityFace[D1Count];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerIntensityFace[D1Count];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerIntensityFace[D1Count];

                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
                    D1Count++;
                }
            }
            if (D1Count == BuyerIntensity.Length)
            {
                isArrowStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                D1Count = 0;
                D1Start = false;
            }
        }
        if (D2Start == true)
        {

            if (D2Count == 0)
            {
                RC.GetComponent<RandomImage>().CurrentFeel = BuyerRejectFace[0];
                RC.GetComponent<CriminalImage>().CurrentFeel = BuyerRejectFace[0];
                RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerRejectFace[0];

                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerRejectReaction[0]));
                D2Count++;
            }
            else
            {
                if (isDialogueEnd == false)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerRejectFace[D2Count - 1];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerRejectFace[D2Count - 1];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerRejectFace[D2Count - 1];

                    BuyerDialogue.text = BuyerRejectReaction[D2Count - 1];
                    isDialogueEnd = true;
                }
                else if (isDialogueEnd == true)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerRejectFace[D2Count];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerRejectFace[D2Count];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerRejectFace[D2Count];

                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
                    D2Count++;
                }
            }
            if (D2Count == BuyerRejectReaction.Length)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                D2Count = 0;
                D2Start = false;
                Invoke("End", 2f);
            }
        }
        if (EStart == true)
        {
            if (ECount == 0)
            {
                RC.GetComponent<RandomImage>().CurrentFeel = BuyerReactFace[0];
                RC.GetComponent<CriminalImage>().CurrentFeel = BuyerReactFace[0];
                RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerReactFace[0];

                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerPerfumeReaction[0]));
                ECount++;
            }
            else
            {
                if (isDialogueEnd == false)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerReactFace[ECount - 1];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerReactFace[ECount - 1];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerReactFace[ECount - 1];
                    BuyerDialogue.text = BuyerPerfumeReaction[ECount - 1];
                    isDialogueEnd = true;
                }
                else if (isDialogueEnd == true)
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = BuyerReactFace[ECount];
                    RC.GetComponent<CriminalImage>().CurrentFeel = BuyerReactFace[ECount];
                    RC.GetComponent<StoryCustomerImage>().CurrentFeel = BuyerReactFace[ECount];

                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    StartCoroutine(NormalChat(BuyerPerfumeReaction[ECount]));
                    ECount++;
                }
            }
            if (ECount == BuyerPerfumeReaction.Length)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = false;
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
        if (GameObject.Find("CriminalSystem").GetComponent<CriminalSystem>().isDeclareClick == false)
        {
            GameObject.Find("Etc").transform.GetChild(5).gameObject.SetActive(true);
        }
        if (DailyResult.GetComponent<DailyResult>().personNum == 0)
        {
            GameObject.Find("Etc").transform.GetChild(5).gameObject.SetActive(true);
        }
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
        Buyer.gameObject.SetActive(false);
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
        Buyer.gameObject.SetActive(false);
        Invoke("D_2_Start", 0.3f);
    }

    public void D_1_Start()//손님 : 승낙 - 향 세기 결정
    {
        Buyer.gameObject.SetActive(true);
        D1Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void D_2_Start()// 손님 : 거부 - 불만 표출
    {
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

    public void F_1Start()
    {
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        CustomerFeel.FindObjectOfType<CustomerFeel>().GetComponent<CustomerFeel>().declareStart = false;
        isDialogueStart = false;
        Buyer.gameObject.SetActive(false);
        F_2Start();
    }
    public void F_2Start()
    {
        Buyer.gameObject.SetActive(true);
        Select.SetActive(false);
        F2Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void End()
    {
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
                CriminalImage.FindObjectOfType<CriminalImage>().CurrentTime = "afternoon";
                StoryCustomerImage.FindObjectOfType<StoryCustomerImage>().CurrentTime = "afternoon";

                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[4];

            }
            else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 6)//손님 6명 가고 나서 저녁으로 바뀜
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "night";
                CriminalImage.FindObjectOfType<CriminalImage>().CurrentTime = "night";
                StoryCustomerImage.FindObjectOfType<StoryCustomerImage>().CurrentTime = "night";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[5];
            }
            if (isDialogueEnd == true)
            {
                Invoke("A_Start", 5f);//손님 가고 5초 뒤에 다음 손님 등장. 인게임 시간 보고 추가 조건문 달아야 함
            }
        }


        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 9)//손님 9명 가고 나서 최종 창이 뜸.
        {
            Invoke("DailyWindowOpen", 3f);
        }
        GameObject.Find("Etc").transform.GetChild(5).gameObject.SetActive(false);
    }

    public void DailyWindowOpen()
    {
        DailyResult.gameObject.SetActive(true);
    }

    IEnumerator NormalChat(string narration)// 타이핑 효과 -> 여기서 향의 세기에 따른 증류기 로직 결정 가능
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
                isDialogueEnd = true;
            else
                isDialogueEnd = false;

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
            BuyerDialogue.text = writerText;
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
            yield return null;
        }
        current = target;
    }

    public void StopAll()
    {
        StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

}

