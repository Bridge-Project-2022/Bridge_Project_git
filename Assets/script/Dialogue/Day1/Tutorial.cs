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
    public GameObject PressWindow;
    public GameObject CoolWindow;
    public GameObject InvenUI;
    public RectTransform TutorialDialoguePos;
    public GameObject InvenPanel;
    public GameObject Customer;
    public GameObject Manufacture;
    public Sprite alpa;

    bool isArrowTrue = true;//true�϶��� ��ȭ �ѱ�� ȭ��ǥ ������

    public bool isTutStart = false;
    public bool isTutStore = false;
    public bool isTutBuy = false;
    public bool isTutCreate = false;
    public bool isTutResult = false;

    public bool isTutDistill = false;//.Ʃ�丮�� ������ ������ �۵� ������ �� true�� �����
    public bool isTutPress = false;
    public bool isTutCool = false;
    public bool isTutCooling = false;

    public bool isBuyStart = false;//���� ���� �׽�Ʈ ������ �� ���� -> update������ �Ǵ�

    int startCnt = 0;
    int storeCnt = 0;
    public int buyCnt = 0;
    public int createCnt = 0;
    public int resultCnt = 0;

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
                if (Inven.Baseslots[0].item.InvenItemNum > 0 && Inven.Baseslots[1].item.InvenItemNum > 0 && Inven.Baseslots[2].item.InvenItemNum > 0 && Inven.Baseslots[3].item.InvenItemNum > 0 &&
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
        if (buyCnt == 18)
        {
            if (isDialogueEnd == true)
                TutorialDialogue.GetComponent<Button>().interactable = true;
        }
        if (createCnt == 9)
        {
            if (isDialogueEnd == true)
            {
                InvenUI.GetComponent<Button>().interactable = true;
                InvenPanel.SetActive(false);
            }
        }
        if (createCnt == 11)
        {
            if (isDialogueEnd == true)
                GameObject.Find("MaskPanel").transform.GetChild(8).GetComponent<Button>().interactable = true;
        }
        if (createCnt == 23)
        {
            if (isDialogueEnd == true)
            {
                InvenUI.GetComponent<Button>().interactable = true;
                InvenPanel.SetActive(false);
            }
        }
        if (createCnt == 24)
        {
            if (isDialogueEnd == true)
                GameObject.Find("MaskPanel").transform.GetChild(12).GetComponent<Button>().interactable = true;
        }
        if (createCnt == 35)
        {
            if (isDialogueEnd == true)
            {
                InvenUI.GetComponent<Button>().interactable = true;
                InvenPanel.SetActive(false);
            }
        }
        if (createCnt == 36)
        {
            if (isDialogueEnd == true)
                GameObject.Find("MaskPanel").transform.GetChild(15).GetComponent<Button>().interactable = true;
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
            else if (startCnt != 0)
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
                    MaskArrow.transform.GetChild(2).gameObject.SetActive(false);
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
                       if(isDialogueEnd == false)
                            TutorialDialogue.GetComponent<Button>().interactable = false;
                        BlackPanel.SetActive(true);
                        TutCustomer.SetActive(false);
                        TutorialDialogue.SetActive(true);
                    }
                    if (buyCnt == 19)//��ŵ ���� ���
                    {
                        GameObject.Find("Perfume").GetComponent<Button>().interactable = false;
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
                    BlackPanel.SetActive(false);
                    this.GetComponent<UIOnOff>().InvenOpen();
                    InvenPanel.SetActive(true);
                    InvenUI.GetComponent<Button>().interactable = false;
                }
                if (createCnt == 6 || createCnt == 7 || createCnt == 8)
                {
                    BlackPanel.SetActive(false);
                }
                if (createCnt == 9)//��� ��� �����ϰ� �ϱ�, ��� ����� �� ��ư ���Ƶα�
                {
                    InvenPanel.SetActive(false);
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Baseslots.Count; i++)
                    {
                        if (Inven.Baseslots[i].item.name != "����")
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
                    MaskPanel.transform.GetChild(20).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(true);
                    InvenUI.GetComponent<Button>().interactable = false;
                }
                if (createCnt == 11)//��� ��� �� ������ ��� ������ ���̶�����
                {
                    GameObject.Find("MaskPanel").transform.GetChild(8).GetComponent<Button>().interactable = false;
                    BlackPanel.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    isArrowTrue = false;
                    MaskPanel.transform.GetChild(20).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(8).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(5).gameObject.SetActive(true);
                }
                if (createCnt == 12)//������ ����, ������ ���� ���̶����� - ���, ������ ���� x
                {
                    GameObject.Find("MaskPanel").transform.GetChild(8).GetComponent<Button>().interactable = false;
                    BlackPanel.SetActive(true);
                    isArrowTrue = true;
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 196, 0);
                    MaskPanel.transform.GetChild(8).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(5).gameObject.SetActive(false);
                    GameObject.Find("Wick").GetComponent<Animator>().enabled = false;
                    MaskPanel.transform.GetChild(9).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(6).gameObject.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
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
                    Invoke("TutDistillStart", 10f);
                }
                if (createCnt == 19)
                {
                    TutorialDialogue.SetActive(true);
                    BlackPanel.SetActive(true);
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, -352, 0);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isTutDistill = false;
                    isArrowTrue = true;
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                    {
                        Inven.Middleslots[i].GetComponent<Button>().interactable = true;
                    }
                }
                if (createCnt == 21)
                {
                    BlackPanel.SetActive(false);
                    this.GetComponent<UIOnOff>().InvenOpen();
                    Inven.GetComponent<StoreTab>().ClickInvenTab(1);
                    InvenPanel.SetActive(true);
                    InvenUI.GetComponent<Button>().interactable = false;
                }
                if (createCnt == 22)
                    BlackPanel.SetActive(false);

                if (createCnt == 23)//������ ���� �� Ŭ�� �ȵǰ�
                {
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                    {
                        if (Inven.Middleslots[i].item.name != "�ݷ�����")
                        {
                            Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Baseslots.Count; i++)
                        Inven.Baseslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 24)//������ ���̶�����
                {
                    MaskPanel.transform.GetChild(12).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(7).gameObject.SetActive(true);
                }
                if (createCnt == 25)//������ ����, ������ ���� ���̶����� - 24
                {
                    isArrowTrue = true;
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 348, 0);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    MaskPanel.transform.GetChild(12).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(7).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(13).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(8).gameObject.SetActive(true);
                }
                if (createCnt == 26)//������ ��Ʈ ���̶�����
                {
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, -352, 0);
                    MaskPanel.transform.GetChild(13).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(8).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(14).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(9).gameObject.SetActive(true);
                }
                if (createCnt == 27)
                {
                    MaskPanel.transform.GetChild(14).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(9).gameObject.SetActive(false);
                }
                if (createCnt == 30)//������ �׽�Ʈ ����
                {
                    TutorialDialogue.SetActive(false);
                    BlackPanel.SetActive(false);
                    isTutPress = true;
                    Invoke("TutPressStart", 1f);
                    InvenUI.GetComponent<Image>().sprite = Inventory.FindObjectOfType<Inventory>().InvenOrigin;
                }
                if (createCnt == 31)
                {
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isTutDistill = false;
                    TutorialDialogue.SetActive(true);
                    BlackPanel.SetActive(true);
                }
                if (createCnt == 32)//ž��Ʈ �Ұ�, ������� �Ѿ��
                {
                    PressWindow.SetActive(false);
                    TutorialDialogue.SetActive(true);
                    BlackPanel.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isTutPress = false;
                    isArrowTrue = true;
                    for (int i = 0; i < Inven.Topslots.Count; i++)
                    {
                        Inven.Topslots[i].GetComponent<Button>().interactable = true;
                    }
                }
                if (createCnt == 33)
                {
                    BlackPanel.SetActive(false);
                    this.GetComponent<UIOnOff>().InvenOpen();
                    Inven.GetComponent<StoreTab>().ClickInvenTab(2);
                    InvenPanel.SetActive(true);
                    InvenUI.GetComponent<Button>().interactable = false;
                }
                if (createCnt == 34)
                    BlackPanel.SetActive(false);

                if (createCnt == 35)//��� ����
                {
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    InvenUI.GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Topslots.Count; i++)
                    {
                        if (Inven.Topslots[i].item.name != "���")
                        {
                            Inven.Topslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                        Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 36)//��ħ�� ���̶����� - 35
                {
                    MaskPanel.transform.GetChild(15).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(10).gameObject.SetActive(true);
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 196, 0);
                }
                if (createCnt == 37)//��ħ ȭ�� ���� - 36
                {
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, -352, 0);
                    MaskPanel.transform.GetChild(15).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(10).gameObject.SetActive(false);
                    TutorialDialogue.SetActive(true);
                    isArrowTrue = true;
                    BlackPanel.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                }
                if (createCnt == 39)//��ħ�� ��� ���̶����� - 38
                {
                    BlackPanel.SetActive(true);
                    MaskPanel.transform.GetChild(16).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(11).gameObject.SetActive(true);
                }
                if (createCnt == 40)//��ħ�� ��� ���̶����� - 39
                {
                    MaskPanel.transform.GetChild(16).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(11).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(17).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(12).gameObject.SetActive(true);
                }
                if (createCnt == 41)//��ħ�� ��� ���̶�����2 - 40
                {
                    MaskPanel.transform.GetChild(17).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(12).gameObject.SetActive(false);
                }
                if (createCnt == 42)//��ħ�� �׽�Ʈ ���� - 41
                {
                    TutorialDialogue.SetActive(false);
                    BlackPanel.SetActive(false);
                    isTutCool = true;
                    Invoke("TutCoolStart", 2f);
                }
                if (createCnt == 43)
                {
                    CoolWindow.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isTutCool = false;
                    TutorialDialogue.SetActive(true);
                    BlackPanel.SetActive(true);
                }
                if (createCnt == 46)//����� ���̶�����
                {
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 196, 0);
                    MaskPanel.transform.GetChild(18).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(13).gameObject.SetActive(true);
                }
                if (createCnt == 48)
                {
                    MaskPanel.transform.GetChild(18).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(13).gameObject.SetActive(false);
                    ResultDialogue();
                }
            }
        }

        if (isTutResult == true)
        {
            if (resultCnt == 0)
            {
                StartCoroutine(NormalChat_1(TS.tutResult[0]));
                TotalScore.FindObjectOfType<TotalScore>().ResetAll();
                Timer.FindObjectOfType<Timer>().isTimerStart = false;
                resultCnt++;
            }
            else if (resultCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_1(TS.tutResult[resultCnt]));
                    resultCnt++;
                }
                if (resultCnt == 3)
                {
                    MaskPanel.transform.GetChild(19).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(14).gameObject.SetActive(true);
                }
                if (resultCnt == 7)
                {
                    MaskPanel.transform.GetChild(19).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(14).gameObject.SetActive(false);
                }
                if (resultCnt == 12)
                {
                    GameObject.Find("TutorialPanel").gameObject.SetActive(false);
                    BlackPanel.SetActive(false);
                    isTutResult = false;
                    isTutCreate = false;
                    GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(true);
                    GameObject.Find("Etc").transform.GetChild(7).gameObject.GetComponent<Image>().sprite = alpa;
                    GameObject.Find("Etc").transform.GetChild(6).gameObject.SetActive(false);
                    GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
                    Manufacture.transform.GetChild(3).GetComponent<Button>().interactable = true;
                    DayCheck.FindObjectOfType<DayCheck>().A_Start_Check();
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
        isTutStart = false;
        isTutBuy = false;
        isTutCreate = false;
        isTutResult = true;
        resultCnt = 0;
        BlackPanel.SetActive(true);
        TotalScore.FindObjectOfType<TotalScore>().Calculate();
        GameObject.Find("Etc").transform.GetChild(2).GetComponent<DeskTouch>().TouchPerfume();
        TutorialDialogue.SetActive(false);
        TutorialDialogue.transform.GetChild(3).gameObject.SetActive(false);
        TutCustomer.SetActive(true);
        NextTutDialogue();
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
            if (Inven.Baseslots[0].item.InvenItemNum == 0 || Inven.Baseslots[1].item.InvenItemNum == 0 || Inven.Baseslots[2].item.InvenItemNum == 0 || Inven.Baseslots[3].item.InvenItemNum == 0 ||
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
        TutorialDialogue.SetActive(true);
        BlackPanel.SetActive(true);
        TutorialDialogue.GetComponent<Button>().interactable = false;
        isArrowTrue = true;
        string press = "����, ���� �̼��Ѱ�����. ���� �� ������ ���ø� �غ���.";
        StartCoroutine(NormalChat_2(press));
        Invoke("rePress", 4f);
    }
    public void rePress()
    {
        TutorialDialogue.SetActive(false);
        BlackPanel.SetActive(false);
        isTutPress = true;
        PressWindow.SetActive(true);
        createCnt = 29;
        NextTutDialogue();
    }
    public void TutCoolBad()
    {
        TutorialDialogue.SetActive(true);
        BlackPanel.SetActive(true);
        TutorialDialogue.GetComponent<Button>().interactable = false;
        isArrowTrue = true;
        string cool = "����, ���� ��� �����ϱ�. Ÿ�̹��� �� ���纸�� �ʰڴ°�?";
        StartCoroutine(NormalChat_2(cool));
        Invoke("reCool", 6f);
    }
    public void reCool()
    {
        isTutCooling = false;
        TutorialDialogue.SetActive(false);
        BlackPanel.SetActive(false);
        isTutCool = true;
        CoolWindow.SetActive(true);
        createCnt = 41;
        NextTutDialogue();
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
                if (isArrowTrue == true)
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
    public void TutPressStart()
    {
        Presser.FindObjectOfType<Presser>().TutPressStart();
    }
    public void TutCoolStart()
    {
        if (isTutCooling == false)
        {
            Cooler.FindObjectOfType<Cooler>().Cooling();
        }
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
        Inven.BuyItem(GameObject.Find("BaseItemBuffer").GetComponent<ItemBuffer>().items[1]);
        Inven.BuyItem(GameObject.Find("MiddleItemBuffer").GetComponent<ItemBuffer>().items[1]);
        Inven.BuyItem(GameObject.Find("TopItemBuffer").GetComponent<ItemBuffer>().items[1]);
    }

    public void CreateSkip()
    {
        ResultDialogue();
    }
}
