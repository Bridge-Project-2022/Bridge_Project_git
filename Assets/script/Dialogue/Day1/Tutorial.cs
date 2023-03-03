using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI TutCustomerDialogue;
    public TextMeshProUGUI TutDialogue;
    public GameObject SkipSelect;
    public GameObject TutCustomer;
    public GameObject TutorialDialogue;

    public bool isDialogueEnd = false;

    public TutorialScript TS;
    public Store Store;
    public Inventory Inven;
    public GameObject BlackPanel;
    public GameObject MaskPanel;
    public GameObject MaskArrow;
    public RectTransform MaskArrowPos;
    public GameObject DistillWindow;

    bool isArrowTrue = true;//true�϶��� ��ȭ �ѱ�� ȭ��ǥ ������

    bool isTutStart = false;
    bool isTutStore = false;
    public bool isTutBuy = false;
    public bool isTutCreate = false;
    bool isTutResult = false;

    public bool isTutDistill = false;//.Ʃ�丮�� ������ ������ �۵� ������ �� true�� �����
    public bool isTutPress = false;
    public bool isTutCool = false;

    public bool isBuyStart = false;//���� ���� �׽�Ʈ ������ �� ���� -> update������ �Ǵ�

    int startCnt = 0;
    int storeCnt = 0;
    int buyCnt = 0;
    public int createCnt = 0;
    int resultCnt = 0;

    bool isItemFive = false;
    bool isItemZero = false;

    string closeDialogue_1 = "�̷�, ��� 5���� ����⿣ ������ ������ ���̴±�. �� ��Ʈ�� ��ᰡ 5���� �ѵ��� �˳��� �纸�� �� ���?";
    string closeDialogue_2 = "����, �� ��Ḧ ���� ���� ���� ����̱�. ��� ��Ḧ 1�� �̻� �纸�⸦ ��õ�ϳ�.";


    public void Update()
    {
        TS = GameObject.Find("TutorialScript").GetComponent<TutorialScript>();

        if (isBuyStart == true)//���� ���� �׽�Ʈ ����. 
        {
            if ((Inven.Baseslots[0].item.InvenItemNum + Inven.Baseslots[1].item.InvenItemNum + Inven.Baseslots[2].item.InvenItemNum + Inven.Baseslots[3].item.InvenItemNum >= 5) &&
                (Inven.Middleslots[0].item.InvenItemNum + Inven.Middleslots[1].item.InvenItemNum + Inven.Middleslots[2].item.InvenItemNum + Inven.Middleslots[3].item.InvenItemNum >= 5) &&
                (Inven.Topslots[0].item.InvenItemNum + Inven.Topslots[1].item.InvenItemNum + Inven.Topslots[2].item.InvenItemNum + Inven.Topslots[3].item.InvenItemNum >= 5))
            {
                if(Inven.Baseslots[0].item.InvenItemNum > 0 && Inven.Baseslots[1].item.InvenItemNum > 0 && Inven.Baseslots[2].item.InvenItemNum  > 0 &&Inven.Baseslots[3].item.InvenItemNum > 0 &&
                   Inven.Middleslots[0].item.InvenItemNum > 0 && Inven.Middleslots[1].item.InvenItemNum > 0 && Inven.Middleslots[2].item.InvenItemNum > 0 && Inven.Middleslots[3].item.InvenItemNum > 0 &&
                   Inven.Topslots[0].item.InvenItemNum > 0 && Inven.Topslots[1].item.InvenItemNum > 0 && Inven.Topslots[2].item.InvenItemNum > 0 && Inven.Topslots[3].item.InvenItemNum > 0)
                    {
                        isBuyStart = false;
                        TutorialDialogue.SetActive(true);
                        TutorialDialogue.GetComponent<Button>().interactable = true;
                        isArrowTrue = true;
                        BlackPanel.SetActive(true);
                        NextTutDialogue();
                    }
            }
        }
    }
    public void NextTutDialogue()
    {
        if (isTutStart == true)
        {
            if (startCnt == 0)
            {
                StartCoroutine(NormalChat_1(TS.tutStart[0]));
                startCnt++;
            }
            else if(startCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_1(TS.tutStart[startCnt]));
                    startCnt++;
                }

                if (startCnt == 16)//���� ����
                {
                    this.GetComponent<UIOnOff>().StoreOpen();
                    Store.StoreOpen();
                    TutCustomer.SetActive(false);
                    Invoke("StoreDialogue", 1f);
                    BlackPanel.SetActive(true);
                }
            }
        }

        if (isTutStore == true)
        {
            if (storeCnt == 0)//���� Ʃ�丮�� ��ŵ ����
            {
                StartCoroutine(NormalChat_2(TS.tutStore[0]));
                TutorialDialogue.GetComponent<Button>().interactable = false;
                Invoke("DialogueSelectTrue", 5.1f);
                isArrowTrue = false;
                storeCnt++;
            }
            else if (storeCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_2(TS.tutStore[storeCnt]));
                    storeCnt++;
                }
                if (storeCnt == 2)//��ŵ ���� ����
                {
                    isArrowTrue = true;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
                }
                if (storeCnt == 5)//���̽� ��Ʈ ���̶�����
                {
                    MaskPanel.SetActive(true);
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(0).gameObject.SetActive(true);
                }
                if (storeCnt == 7)//���̽� ���̶����� ����, �̵� ���̶�����, �̵� �� �ڵ� �̵�
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(1);//�̵� �ڵ� �̵�
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(true);//�̵� ���̶�����
                    MaskArrowPos.anchoredPosition = new Vector3(-876, 66, 0);//�̵� ȭ��ǥ �̵�
                }
                if (storeCnt == 11)
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(2);//ž �� �ڵ� �̵�
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(true);//ž ���̶�����
                    MaskArrowPos.anchoredPosition = new Vector3(-876, -107, 0);//ž ȭ��ǥ �̵�
                }
                if (storeCnt == 16)
                {
                    MaskArrow.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(false);//���̶����� ����
                }
                if (storeCnt == 17)
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(0);//���̽� �� �̵�
                    MaskPanel.transform.GetChild(3).gameObject.SetActive(true);//ù��° ��� ���� ���̶�����
                    MaskArrow.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (storeCnt == 18)
                {
                    MaskPanel.transform.GetChild(3).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(4).gameObject.SetActive(true);//�ϰ� ���� ��ư ���̶�����
                    MaskArrow.transform.GetChild(1).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(2).gameObject.SetActive(true);
                }
                if (storeCnt == 19)
                {
                    MaskArrow.SetActive(false);
                    MaskPanel.transform.GetChild(4).gameObject.SetActive(false);
                    BuyDialogue();
                }
            }
        }

        if (isTutBuy == true)
        {
            if (buyCnt == 0)
            {
                StartCoroutine(NormalChat_2(TS.tutBuy[0]));
                buyCnt++;
            }
            else if (buyCnt != 0)
            {
                if (buyCnt < 7)
                {
                    //Debug.Log("7���� ����");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_2(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 5)//��� �ѷ������ ���. �б��� ����. 
                    {
                        TutorialDialogue.SetActive(false);//��� â ����
                        BlackPanel.SetActive(false);//���� �г� ����
                        isBuyStart = true;
                    }
                }
                if (buyCnt >= 7 && buyCnt < 17) 
                {
                    //Debug.Log("7���� ũ�ų� ���� 17���� ����");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_1(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 8)//�Ϲ� ���� ���� �Ѿ
                    {
                        isArrowTrue = true;
                        Store.TutClose();
                        TutorialDialogue.SetActive(false);
                        BlackPanel.SetActive(false);
                        TutCustomer.SetActive(true);
                        NextTutDialogue();
                    }
                    if (buyCnt == 14)//���� ��� �³�, ���� Ȱ��ȭ / Ŭ���� �ȵ�
                    {
                        TutCustomer.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
                        isArrowTrue = false;
                        TutCustomer.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
                    }
                    if (buyCnt == 15)//�³� ���� ���̶�����, ȭ��ǥ �߰�
                    {
                        isArrowTrue = true;
                        TutCustomer.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = true;
                        TutCustomer.transform.GetChild(1).GetChild(3).gameObject.SetActive(false); 

                        MaskPanel.transform.GetChild(5).gameObject.SetActive(true);
                        MaskArrow.transform.GetChild(0).gameObject.SetActive(true);
                        BlackPanel.SetActive(true);
                        MaskArrowPos.anchoredPosition = new Vector3(-876, -86, 0);
                    }
                    if (buyCnt == 16)
                    {
                        MaskPanel.transform.GetChild(5).gameObject.SetActive(false);
                        MaskArrow.transform.GetChild(0).gameObject.SetActive(false);
                        BlackPanel.SetActive(false);
                    }
                }
                if (buyCnt >= 17)
                {
                    //Debug.Log("17���� ũ�ų� ����");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_2(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 18)//���۴� �Ѿ, �̴� ��ȭâ���� ����
                    {
                        GameObject.Find("Etc").transform.GetChild(2).GetComponent<DeskTouch>().TouchDesk();
                        TutCustomer.SetActive(false);
                        TutorialDialogue.SetActive(true);
                    }
                    if (buyCnt == 19)//��ŵ ���� ���
                    {
                        TutorialDialogue.GetComponent<Button>().interactable = false;
                        Invoke("DialogueSelect_2True", 5.1f);
                        isArrowTrue = false;
                    }
                }
            }
        }

        if (isTutCreate == true)
        {
            if (createCnt == 0)
            {
                TutorialDialogue.GetComponent<Button>().interactable = true;
                StartCoroutine(NormalChat_2(TS.tutCreate[0]));
                isArrowTrue = true;
                TutorialDialogue.transform.GetChild(3).gameObject.SetActive(false);
                createCnt++;
            }
            else if (createCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    BlackPanel.SetActive(true);
                    StartCoroutine(NormalChat_2(TS.tutCreate[createCnt]));
                    createCnt++;
                }
                if (createCnt == 2)//�κ� ���̶�����
                {
                    MaskPanel.transform.GetChild(6).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (createCnt == 3)
                {
                    MaskPanel.transform.GetChild(6).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(false);
                }
                if (createCnt == 4)//������ ���̶�����
                {
                    MaskPanel.transform.GetChild(7).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(4).gameObject.SetActive(true);
                }
                if (createCnt == 5)
                {
                    MaskPanel.transform.GetChild(7).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(4).gameObject.SetActive(false);
                }
                if (createCnt == 9)//��� ��� �����ϰ� �ϱ�, ��� ����� �� ��ư ���Ƶα�
                {
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Baseslots.Count; i++)
                    {
                        if (Inven.Baseslots[i].item.name != "���")
                        {
                            Inven.Baseslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                        Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Topslots.Count; i++)
                        Inven.Topslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 10)//�ʱ�ȭ ��ư ��Ʈ ������ ���̶����� �۾� �ϱ�
                {
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isArrowTrue = true;
                    Debug.Log("�ʱ�ȭ ��ư ���̶�����");
                }
                if (createCnt == 11)//��� ��� �� ������ ��� ������ ���̶�����
                {
                    BlackPanel.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    isArrowTrue = false;
                    MaskPanel.transform.GetChild(8).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(5).gameObject.SetActive(true);
                }
                if (createCnt == 12)//������ ����, ������ ���� ���̶����� - ���, ������ ���� x
                {
                    BlackPanel.SetActive(true);
                    isArrowTrue = true;
                    TutorialDialogue.transform.Translate(new Vector3(0, 550, 0));
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    MaskPanel.transform.GetChild(8).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(5).gameObject.SetActive(false);
                    GameObject.Find("Wick").GetComponent<Animator>().enabled = false;
                    MaskPanel.transform.GetChild(9).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(6).gameObject.SetActive(true);
                }
                if (createCnt == 14)//���� ���̶�����
                {
                    MaskPanel.transform.GetChild(9).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(10).gameObject.SetActive(true);
                }
                if (createCnt == 15)//�ߺ� ���̶�����
                {
                    MaskPanel.transform.GetChild(10).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(11).gameObject.SetActive(true);
                }
                if (createCnt == 16)//���̶����� ��
                {
                    MaskPanel.transform.GetChild(11).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(6).gameObject.SetActive(false);
                }
                if (createCnt == 18)//������ �׽�Ʈ ����. 
                {
                    TutorialDialogue.SetActive(false);
                    BlackPanel.SetActive(false);
                    isTutDistill = true;
                    GameObject.Find("Wick").GetComponent<Animator>().enabled = true;
                    Invoke("TutDistillStart", 8f);
                }
                if (createCnt == 19)
                {
                    TutorialDialogue.SetActive(true);
                    BlackPanel.SetActive(true);
                    TutorialDialogue.transform.Translate(new Vector3(0, 0, 0));
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isTutDistill = false;
                    isArrowTrue = true;
                }
                if (createCnt == 24)
                {
                    MaskPanel.transform.GetChild(12).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(7).gameObject.SetActive(true);
                }
            }
        }

        if (isTutResult == true)
        {
            if (resultCnt == 0)
            {
                StartCoroutine(NormalChat_2(TS.tutResult[0]));
                resultCnt++;
            }
            else if (resultCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_2(TS.tutResult[resultCnt]));
                    resultCnt++;
                }
                if (resultCnt == 2)
                {

                }
            }
        }
    }
    public void StartDialogue()//��� ������ ���, ����� �� ��� �Ұ�, ���� Ŭ��
    {
        isTutStart = true;
        startCnt = 0;
        NextTutDialogue();
    }

    public void StoreDialogue()//��� ��Ʈ ����. ��ŵ ���� ���� => �� : ���� �Ѿ / �ƴϿ� : ���̽� ���� & �̵��� ���̶�����, �̵� ���� & ž�� ���̶�����, ž ���� & ���̽��� Ŭ������ & ù��° ��� ���� �� ���� / �ϰ����� ����
    {
        isTutStart = false;
        isTutStore = true;
        storeCnt = 0;
        this.transform.GetChild(1).gameObject.SetActive(true);
        NextTutDialogue();
    }

    public void BuyDialogue() // ��� ���� ����, �Ϸ� ���� Ȯ�� -> �Ϸ� �� ���� ����, �մ� �ý��� ����, ���� / ���� ���� �� Ŭ�� ����, ��� ��� ������ ����
    {
        if (SkipSelect.activeSelf == true)
            SkipSelect.SetActive(false);
        if (TutorialDialogue.GetComponent<Button>().interactable == false)
            TutorialDialogue.GetComponent<Button>().interactable = true;

        isArrowTrue = true;
        isTutStart = false;
        isTutStore = false;
        isTutBuy = true;
        buyCnt = 0;
        Debug.Log("���� Ʃ�丮��� ����!");
        NextTutDialogue();
    }

    public void CreateDialogue()//���� ȭ�� �Ѿ. ��ŵ ���� ���� => �� : �������� �Ѿ / �ƴϿ� : �κ� Ŭ�� ����, ���̽� ���� ����, ������ ���� ����, ������ ����, ���� ���� �� �� ���� �ݺ�, ���� �� �絵�� ���, 
                                // �̵� ���� ����, ������ ���� ����, ������ ����, ���� ������ �� ���� �ݺ�, ���� �� �絵�� ���, 
                                // ž ���� ����, ��ħ�� ���� ����, ��ħ�� ����, ��ħ ������ �� ���� �ݺ�, ���� �� �絵�� ���
                                // ���� ȭ�� �ѱ�, �ϼ� ��� ���̶����� �� ���, Ŭ�� ����
    {
        isTutStart = false;
        isTutBuy = false;
        isTutCreate = true;
        createCnt = 0;
        NextTutDialogue();
    }

    public void ResultDialogue()//��� ����, ����, �̵��� ���� ���� ��, �Ϲ� �ϰ��� �Ѿ
    { 
        
    }

    public void DialogueSelectTrue()
    {
        TutorialDialogue.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void DialogueSelect_2True()
    {
        TutorialDialogue.transform.GetChild(3).gameObject.SetActive(true);
    }
    void TutDialogueClose()
    {
        BlackPanel.SetActive(false);
        TutorialDialogue.SetActive(false);
    }
    public void StoreCloseBtnClicked()//���� �ݱ� ��ư Ŭ������ ���
    {
        if (isTutBuy == true)
        {
            //���̽�, �̵�, ž ��� ���� ��� ���鼭 ī��Ʈ ������ �� 5���� ������ 4�� ��� ���

            if ((Inven.Baseslots[0].item.InvenItemNum + Inven.Baseslots[1].item.InvenItemNum + Inven.Baseslots[2].item.InvenItemNum + Inven.Baseslots[3].item.InvenItemNum < 5) ||
                 (Inven.Middleslots[0].item.InvenItemNum + Inven.Middleslots[1].item.InvenItemNum + Inven.Middleslots[2].item.InvenItemNum + Inven.Middleslots[3].item.InvenItemNum < 5) ||
                 (Inven.Topslots[0].item.InvenItemNum + Inven.Topslots[1].item.InvenItemNum + Inven.Topslots[2].item.InvenItemNum + Inven.Topslots[3].item.InvenItemNum < 5))
            {
                isItemFive = true;
                TutorialDialogue.SetActive(true);
                BlackPanel.SetActive(true);
                TutorialDialogue.GetComponent<Button>().interactable = false;
                isArrowTrue = false;
                StartCoroutine(NormalChat_2(closeDialogue_1));
                Invoke("TutDialogueClose", 7f);
            }

            //���̽�, �̵�, ž�� ��� ����� ī��Ʈ ���鼭 0�̸� 5�� ��� ���
            if(Inven.Baseslots[0].item.InvenItemNum == 0 || Inven.Baseslots[1].item.InvenItemNum == 0 || Inven.Baseslots[2].item.InvenItemNum == 0 || Inven.Baseslots[3].item.InvenItemNum == 0 ||
                   Inven.Middleslots[0].item.InvenItemNum == 0 || Inven.Middleslots[1].item.InvenItemNum == 0 || Inven.Middleslots[2].item.InvenItemNum == 0 || Inven.Middleslots[3].item.InvenItemNum == 0 ||
                   Inven.Topslots[0].item.InvenItemNum == 0 || Inven.Topslots[1].item.InvenItemNum == 0 || Inven.Topslots[2].item.InvenItemNum == 0 || Inven.Topslots[3].item.InvenItemNum == 0)
            {
                isItemZero = true;
                TutorialDialogue.SetActive(true);
                BlackPanel.SetActive(true);
                TutorialDialogue.GetComponent<Button>().interactable = false;
                isArrowTrue = false;
                StartCoroutine(NormalChat_2(closeDialogue_2));
                Invoke("TutDialogueClose", 6f);
            }


            if ((isItemFive == true) && (isItemZero = true))
            {
                TutorialDialogue.SetActive(true);
                TutorialDialogue.GetComponent<Button>().interactable = false;
                BlackPanel.SetActive(true);
                isArrowTrue = false;
                StartCoroutine(NormalChat_2(closeDialogue_1));
                Invoke("TutDialogueClose", 7f);
            }

            isItemFive = false; isItemZero = false;
        }
    }

    public void TutDistillBad()
    {
        TutorialDialogue.SetActive(true);
        BlackPanel.SetActive(true);
        TutorialDialogue.GetComponent<Button>().interactable = false;
        isArrowTrue = true;
        string distill = "...�� ���� �ʹ� ������ ������? ���� ���߳�����, �ٽ� �غ��Գ�.";
        StartCoroutine(NormalChat_2(distill));             
        Invoke("reDistill", 5f);
    }
    public void reDistill()
    {
        TutorialDialogue.SetActive(false);
        BlackPanel.SetActive(false);
        isTutDistill = true;
        DistillWindow.SetActive(true);
        createCnt = 17;
        NextTutDialogue();

    }
    public void TutPressBad()
    {

    }
    public void TutCoolBad()
    {

    }
    IEnumerator NormalChat_1(string narration)
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
            {
                isDialogueEnd = true;
                if (isArrowTrue == true)
                    TutCustomer.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                TutCustomer.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            }

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
            TutCustomerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    IEnumerator NormalChat_2(string narration)
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
            {
                isDialogueEnd = true;
                if(isArrowTrue == true)
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);
            }

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
            TutDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }
    public void TutDistillStart()
    {
        Distiller.FindObjectOfType<Distiller>().EndDistiller();
    }
    public void StartSkip()
    {
        this.GetComponent<UIOnOff>().StoreOpen();
        Store.GetComponent<Store>().StoreOpen();
        TutCustomer.SetActive(false);
        Invoke("StoreDialogue", 1f);
        BlackPanel.SetActive(true);
    }

    public void StoreSkip()
    {
        this.GetComponent<UIOnOff>().StoreOpen();
        Store.GetComponent<Store>().StoreOpen();
        TutCustomer.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        BuyDialogue();
        BlackPanel.SetActive(true);
    }
    public void BuySkip()
    {
        TutCustomer.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Etc").transform.GetChild(2).GetComponent<DeskTouch>().TouchDesk();
        CreateDialogue();
        BlackPanel.SetActive(true);
        Inven.BuyItem(GameObject.Find("BaseItemBuffer").GetComponent<ItemBuffer>().items[3]);
        Inven.BuyItem(GameObject.Find("MiddleItemBuffer").GetComponent<ItemBuffer>().items[6]);
        Inven.BuyItem(GameObject.Find("TopItemBuffer").GetComponent<ItemBuffer>().items[1]);
    }
}
