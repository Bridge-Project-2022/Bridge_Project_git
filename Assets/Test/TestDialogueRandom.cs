using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TestDialogueRandom : MonoBehaviour
{
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

    public GameObject arrow;
    public GameObject Declaration;

    public int rejectCnt = 0;//���� Ƚ�� -> ���� ����, ���� ���� �� ���� ���µǾ�� ��.

    int C_1_random;
    int C_2_random;

    public string[] SellerSentences = new string[2];// ���� ��ȭ �迭

    TestDialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];
    public string[] CriminalDeclareReaction = new string[5];

    public string[] BuyerFeel = new string[10];

    public Sprite[] BG_Sprite = new Sprite[5];

    public bool AStart = false;
    public bool D1Start = false;
    public bool D2Start = false;
    public bool EStart = false;
    public bool F2Start = false;

    public int FeelCnt = 0;

    int ACount = 0;
    int D1Count = 0;
    int D2Count = 0;
    int ECount = 0;
    int F2Count = 0;
    int LolenaCnt = 0;


    public bool isDialogueStart = false;
    public bool isLorenaReject = false;


    bool isSelectStart = false;
    bool isArrowStart = false;

    public bool isCriminal = false;
    public bool isCriminalFalse = false;
    public bool isDeclare = false;

    public GameObject Criminal;
    public Sprite Success;
    public Sprite Fail;

    public GameObject CutScene;

    public void Update()
    {
        if (DailyResult.GetComponent<DailyResult>().personNum == 6)
        {
            Invoke("DailyWindowOpen", 3f);
        }
        DS = GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>();

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

        for (int i = 0; i < CriminalDeclareReaction.Length; i++)
        {
            CriminalDeclareReaction[i] = DS.Customer_CriminalDeclareReaction[i];
        }

        Distiller.GetComponent<Distiller>().BaseItemName = DS.Customer_Flavoring[0];
        Presser.GetComponent<Presser>().MiddleItemName = DS.Customer_Flavoring[1];
        Cooler.GetComponent<Cooler>().TopItemName = DS.Customer_Flavoring[2];

        if (isDialogueEnd == true)
        {
            if (isSelectStart == true)
            {
                Select.gameObject.SetActive(true);
                if (isDeclare == false)
                {
                    Declaration.gameObject.SetActive(true);
                }
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
                Declaration.gameObject.SetActive(false);
            }
            if (isArrowStart == false)
            {
                arrow.gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < BuyerFeel.Length; i++)
        {
            BuyerFeel[i] = GameObject.Find("RC").GetComponent<CustomerFeel>().Customer_Feel[i];
        }
    }
    public void NextDialogue()
    {
        StopAll();

        RandomImage.FindObjectOfType<RandomImage>().CurrentFeel = BuyerFeel[FeelCnt];
        FeelCnt++;

        if (DS.Customer_ID[0] == 1010)
        {
            if (AStart == true)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                if (LolenaCnt == 4)
                {
                    GameObject.Find("Dialogue").transform.GetChild(7).gameObject.SetActive(true);
                    StartCoroutine(NormalChat(BuyerOrder[LolenaCnt]));
                    LolenaCnt++;
                }
                else
                {
                    GameObject.Find("Dialogue").transform.GetChild(7).gameObject.SetActive(false);
                    StartCoroutine(NormalChat(BuyerOrder[LolenaCnt]));
                    LolenaCnt++;
                }


                if (BuyerOrder[ACount] == "")
                {
                    isSelectStart = true;
                    Buyer.gameObject.GetComponent<Button>().interactable = false;
                    LolenaCnt = 0;
                    AStart = false;
                }

            }
            if (D1Start == true)
            {
                GameObject.Find("Dialogue").transform.GetChild(7).gameObject.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
                D1Count++;

                if (BuyerIntensity[D1Count] == "")
                {
                    isArrowStart = true;
                    Buyer.gameObject.GetComponent<Button>().interactable = false;
                    D1Count = 0;
                    D1Start = false;
                }
            }
            if (D2Start == true)
            {
                GameObject.Find("Dialogue").transform.GetChild(7).gameObject.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
                D2Count++;

                if (BuyerRejectReaction[D2Count] == "")
                {
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
                    ECount = 0;
                    EStart = false;
                    Invoke("End", 2f);
                }
            }
            if (F2Start == true)
            {
                isSelectStart = false;
                Select.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(CriminalDeclareReaction[F2Count]));
                F2Count++;

                if (CriminalDeclareReaction[F2Count] == "")
                {
                    F2Count = 0;
                    F2Start = false;
                    Invoke("End", 2f);
                }
            }
        }

        if (DS.Customer_ID[0] == 1011)
        {
            if (AStart == true)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                if (ACount == 2)
                {
                    CutScene.gameObject.SetActive(true);
                    ACount++;
                }
                else
                {
                    CutScene.gameObject.SetActive(false);
                    StartCoroutine(NormalChat(BuyerOrder[ACount]));
                    ACount++;
                }


                if (BuyerOrder[LolenaCnt] == "")
                {
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
                    ECount = 0;
                    EStart = false;
                    Invoke("End", 2f);
                }
            }
            if (F2Start == true)
            {
                isSelectStart = false;
                Select.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(CriminalDeclareReaction[F2Count]));
                F2Count++;

                if (CriminalDeclareReaction[F2Count] == "")
                {
                    F2Count = 0;
                    F2Start = false;
                    Invoke("End", 2f);
                }
            }
        }
        if (DS.Customer_ID[0] == 1012)
        {
            if (AStart == true)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                if (ACount == 4)
                {
                    GameObject.Find("Dialogue").transform.GetChild(8).gameObject.SetActive(true);
                    StartCoroutine(NormalChat(BuyerOrder[ACount]));
                    ACount++;
                }
                else
                {
                    GameObject.Find("Dialogue").transform.GetChild(8).gameObject.SetActive(false);
                    StartCoroutine(NormalChat(BuyerOrder[ACount]));
                    ACount++;
                }


                if (BuyerOrder[ACount] == "")
                {
                    isSelectStart = true;
                    Buyer.gameObject.GetComponent<Button>().interactable = false;
                    ACount = 0;
                    AStart = false;
                }

            }

            if (D1Start == true)
            {
                GameObject.Find("Dialogue").transform.GetChild(8).gameObject.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
                D1Count++;

                if (BuyerIntensity[D1Count] == "")
                {
                    isArrowStart = true;
                    Buyer.gameObject.GetComponent<Button>().interactable = false;
                    D1Count = 0;
                    D1Start = false;
                }
            }
            if (D2Start == true)
            {
                GameObject.Find("Dialogue").transform.GetChild(8).gameObject.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
                D2Count++;

                if (BuyerRejectReaction[D2Count] == "")
                {
                    D2Count = 0;
                    D2Start = false;
                    Invoke("End", 2f);
                }
            }
            if (EStart == true)
            {
                if (ECount == 2)
                {
                    CutScene.gameObject.SetActive(true);
                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    ECount++;
                }
                else
                {
                    CutScene.gameObject.SetActive(false);
                    Buyer.gameObject.GetComponent<Button>().interactable = true;
                    StartCoroutine(NormalChat(BuyerPerfumeReaction[ECount]));
                    ECount++;
                }
                if (BuyerPerfumeReaction[ECount] == "")
                {
                    ECount = 0;
                    EStart = false;
                    Invoke("End", 2f);
                }
            }
            if (F2Start == true)
            {
                isSelectStart = false;
                Select.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(CriminalDeclareReaction[F2Count]));
                F2Count++;

                if (CriminalDeclareReaction[F2Count] == "")
                {
                    F2Count = 0;
                    F2Start = false;
                    Invoke("End", 2f);
                }
            }
        }
        if (DS.Customer_ID[0] == 1013)
        {
            if (AStart == true)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                if (ACount == 2)
                {
                    CutScene.gameObject.SetActive(true);
                    ACount++;
                }
                else
                {
                    CutScene.gameObject.SetActive(false);
                    StartCoroutine(NormalChat(BuyerOrder[ACount]));
                    ACount++;
                }


                if (BuyerOrder[LolenaCnt] == "")
                {
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
                    ECount = 0;
                    EStart = false;
                    Invoke("End", 2f);
                }
            }
            if (F2Start == true)
            {
                isSelectStart = false;
                Select.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(CriminalDeclareReaction[F2Count]));
                F2Count++;

                if (CriminalDeclareReaction[F2Count] == "")
                {
                    F2Count = 0;
                    F2Start = false;
                    Invoke("End", 2f);
                }
            }
        }
        else
        {
            if (AStart == true)
            {
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(BuyerOrder[ACount]));
                ACount++;

                if (BuyerOrder[ACount] == "")
                {
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
                    ECount = 0;
                    EStart = false;
                    Invoke("End", 2f);
                }
            }
            if (F2Start == true)
            {
                isSelectStart = false;
                Select.SetActive(false);
                Buyer.gameObject.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat(CriminalDeclareReaction[F2Count]));
                F2Count++;

                if (CriminalDeclareReaction[F2Count] == "")
                {
                    F2Count = 0;
                    F2Start = false;
                    Invoke("End", 2f);
                }
            }
        }
    }

    public void A_Start()//�մ� : ����, ��� ���� ���� ����
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);

        AStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void C_1_Start()// ���� : �³� - �� ���� ����
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        Declaration.gameObject.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 0.3f);
    }

    public void C_2_Start()//���� : �ź� - �ź� ���� ����
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
            GameObject.Find("ReputationSlider").GetComponent<Slider>().value -= 0.08f;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }


        else if (rejectCnt == 2)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
            GameObject.Find("ReputationSlider").GetComponent<Slider>().value -= 0.1f;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
        if (rejectCnt >= 3)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
            GameObject.Find("ReputationSlider").GetComponent<Slider>().value -= 0.15f;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }

        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        Declaration.gameObject.SetActive(false);
        isDialogueStart = false;
        Buyer.gameObject.SetActive(false);
        Invoke("D_2_Start", 0.3f);
    }

    public void D_1_Start()//�մ� : �³� - �� ���� ����
    {
        Buyer.gameObject.SetActive(true);
        D1Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void D_2_Start()// �մ� : �ź� - �Ҹ� ǥ��
    {
        Buyer.gameObject.SetActive(true);

        D2Start = true;
        isDialogueStart = true;
        NextDialogue();
    }


    public void E_1_Start()//�մ� : ��� �ް� ����
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
        Declaration.gameObject.SetActive(false);
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
            if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 2)//�մ� 3�� ���� ���� �������� �ٲ�
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "afternoon";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[4];

            }
            else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 4)//�մ� 6�� ���� ���� �������� �ٲ�
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "night";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[5];
            }

            Invoke("A_Start", 5f);//�մ� ���� 5�� �ڿ� ���� �մ� ����. �ΰ��� �ð� ���� �߰� ���ǹ� �޾ƾ� ��
        }

        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 6)//�մ� 9�� ���� ���� ���� â�� ��.
        {
            Invoke("DailyWindowOpen", 3f);
        }
        FeelCnt = 0;
    }

    public void DailyWindowOpen()
    {
        DailyResult.gameObject.SetActive(true);
    }

    public void PressDeclaration()//�Ű��ư Ŭ�� ��
    {
        if (GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>().Customer_ID[0] == 1003)//������ ����
        {
            Debug.Log("������ �Ű� ����");
            Criminal.GetComponent<Image>().sprite = Success;
            isCriminal = true;
            isCriminalFalse = false;
            isDeclare = true;
        }
        else//�߸� ���� ���
        {
            Debug.Log("�߸� �Ű���");
            Criminal.GetComponent<Image>().sprite = Fail;
            isCriminalFalse = true;
            isCriminal = false;
            isDeclare = true;
        }
        Invoke("DeclareActiveFalse", 3f);
    }

    public void DeclareActiveFalse()
    {
        Declaration.gameObject.SetActive(false);
    }

    IEnumerator NormalChat(string narration)// Ÿ���� ȿ�� -> ���⼭ ���� ���⿡ ���� ������ ���� ���� ����
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
        float duration = 0.5f; // ī���ÿ� �ɸ��� �ð� ����. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            //GameObject.Find("reputation_num").GetComponent<TextMeshPro>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
       // GameObject.Find("reputation_num").GetComponent<TextMeshPro>().text = ((int)current).ToString();

    }

    public void StopAll()
    {
        StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

}

