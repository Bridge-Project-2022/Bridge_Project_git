using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueRandom : MonoBehaviour
{
    public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public GameObject BackGround;

    public TextMeshProUGUI BuyerDialogue;
    public TextMeshProUGUI SellerDialogue;

    public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//거절 횟수 -> 평판 영향, 일차 지날 때 마다 리셋되어야 함.

    int C_1_random;
    int C_2_random;

    public string[] SellerSentences = new string[2];// 유저 대화 배열

    [SerializeField]
    public DialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];

    public Sprite[] BG_Sprite = new Sprite[3];
    public void Start()
    {
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
    }

    public void Update()
    {

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

        StartCoroutine(A_Script_Start());
    }

    IEnumerator A_Script_Start()
    {

        for (int i = 0; i < BuyerOrder.Length; i++)
        {
            if (BuyerOrder[i] == "")
            {
                break;
            }
            else
            { 
                yield return StartCoroutine(NormalChat(BuyerOrder[i]));
                yield return new WaitForSeconds(1.5f);
            }
        }
        Select.gameObject.SetActive(true);
    }
    public void C_1_Start()// 유저 : 승낙 - 향 세기 질문
    {
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 3f);
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
        Invoke("D_2_Start", 3f);
    }

    public void D_1_Start()//손님 : 승낙 - 향 세기 결정
    {
        Buyer.gameObject.SetActive(true);
        Seller.gameObject.SetActive(false);

        StartCoroutine(D_1_Script_Start());
        makeStart = true;
    }
    IEnumerator D_1_Script_Start()
    {
        for (int i = 0; i < BuyerIntensity.Length; i++)
        {
            if (BuyerIntensity[i] == "")
            {
                break;
            }
            else
            {
                yield return StartCoroutine(NormalChat(BuyerIntensity[i]));
                yield return new WaitForSeconds(1.5f);
            }
        }
        arrow.gameObject.SetActive(true);
    }

    public void D_2_Start()// 손님 : 거부 - 불만 표출
    {
        Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);

        StartCoroutine(D_2_Script_Start());
    }

    IEnumerator D_2_Script_Start()
    {
        for (int i = 0; i < BuyerRejectReaction.Length; i++)
        {
            if (BuyerRejectReaction[i] == "")
            {
                break;
            }
            else
            { 
                yield return StartCoroutine(NormalChat(BuyerRejectReaction[i]));
                yield return new WaitForSeconds(1.5f);
            }
            
        }
        Invoke("End", 1f);
    }

    public void E_1_Start()//손님 : 향수 받고 반응
    {
        StartCoroutine(E_1_Script_Start());
    }

    IEnumerator E_1_Script_Start()
    {
        for (int i = 0; i < BuyerPerfumeReaction.Length; i++)
        {
            if (BuyerPerfumeReaction[i] == "")
            {
                break;
            }
            else
            {
                yield return StartCoroutine(NormalChat(BuyerPerfumeReaction[i]));
                yield return new WaitForSeconds(1.5f);
            }
        }
        Invoke("End", 1f);
    }

    public void End()
    {
        int temp;
        temp = DS.Customer_ID[0];
        for (int i = 0; i < DS.Customer_ID.Length - 1; i++)
        {
            DS.Customer_ID[i] = DS.Customer_ID[i + 1];
        }
        DS.Customer_ID[DS.Customer_ID.Length - 1] = temp;

        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 1)//손님 3명 가고 나서 점심으로 바뀜
        {
            BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
        }
        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 2)//손님 6명 가고 나서 저녁으로 바뀜
        {
            BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
        }

        Invoke("A_Start", 5f);//손님 가고 5초 뒤에 다음 손님 등장. 인게임 시간 보고 추가 조건문 달아야 함
    }

    IEnumerator NormalChat(string narration)// 타이핑 효과 -> 여기서 향의 세기에 따른 증류기 로직 결정 가능
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            BuyerDialogue.text = writerText;
            SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;
        }
    }
}

