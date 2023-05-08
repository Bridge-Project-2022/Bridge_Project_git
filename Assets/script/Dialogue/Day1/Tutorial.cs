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

    bool isArrowTrue = true;//true일때만 대화 넘기기 화살표 보여짐

    public bool isTutStart = false;
    public bool isTutStore = false;
    public bool isTutBuy = false;
    public bool isTutCreate = false;
    public bool isTutResult = false;

    public bool isTutDistill = false;//.튜토리얼 내에서 증류기 작동 시작일 때 true로 변경됨
    public bool isTutPress = false;
    public bool isTutCool = false;
    public bool isTutCooling = false;

    public bool isBuyStart = false;//실제 구매 테스트 시작할 때 켜짐 -> update문에서 판단

    int startCnt = 0;
    int storeCnt = 0;
    public int buyCnt = 0;
    public int createCnt = 0;
    public int resultCnt = 0;

    bool isItemFive = false;
    bool isItemZero = false;

    string closeDialogue_1 = "이런, 향수 5개를 만들기엔 부족한 양으로 보이는군. 각 노트의 향료가 5개는 넘도록 넉넉히 사보는 게 어떤가?";
    string closeDialogue_2 = "흐음, 각 향료를 골고루 사지 않은 모양이군. 모든 향료를 1개 이상 사보기를 추천하네.";


    public void Update()
    {
        TS = GameObject.Find("TutorialScript").GetComponent<TutorialScript>();

        if (isBuyStart == true)//실제 구매 테스트 시작. 
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

                if (startCnt == 16)//상점 열기
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
            if (storeCnt == 0)//상점 튜토리얼 스킵 여부
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
                if (storeCnt == 2)//스킵 셀렉 끄기
                {
                    isArrowTrue = true;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
                }
                if (storeCnt == 5)//베이스 노트 하이라이팅
                {
                    MaskPanel.SetActive(true);
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(0).gameObject.SetActive(true);
                }
                if (storeCnt == 7)//베이스 하이라이팅 종료, 미들 하이라이팅, 미들 탭 자동 이동
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(1);//미들 자동 이동
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(true);//미들 하이라이팅
                    MaskArrowPos.anchoredPosition = new Vector3(-876, 66, 0);//미들 화살표 이동
                }
                if (storeCnt == 11)
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(2);//탑 탭 자동 이동
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(true);//탑 하이라이팅
                    MaskArrowPos.anchoredPosition = new Vector3(-876, -107, 0);//탑 화살표 이동
                }
                if (storeCnt == 16)
                {
                    MaskArrow.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(false);//하이라이팅 끄기
                }
                if (storeCnt == 17)
                {
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(0);//베이스 탭 이동
                    MaskPanel.transform.GetChild(3).gameObject.SetActive(true);//첫번째 향료 슬롯 하이라이팅
                    MaskArrow.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (storeCnt == 18)
                {
                    MaskPanel.transform.GetChild(3).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(4).gameObject.SetActive(true);//일괄 구매 버튼 하이라이팅
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
                    //Debug.Log("7보다 작음");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_2(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 5)//향료 둘러보라는 대사. 분기점 나뉨. 
                    {
                        TutorialDialogue.SetActive(false);//대사 창 꺼짐
                        BlackPanel.SetActive(false);//검정 패널 꺼짐
                        isBuyStart = true;
                    }
                }
                if (buyCnt >= 7 && buyCnt < 17)
                {
                    //Debug.Log("7보다 크거나 같고 17보다 작음");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_1(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 8)//일반 상인 대사로 넘어감
                    {
                        isArrowTrue = true;
                        Store.TutClose();
                        TutorialDialogue.SetActive(false);
                        BlackPanel.SetActive(false);
                        TutCustomer.SetActive(true);
                        NextTutDialogue();
                    }
                    if (buyCnt == 14)//상인 향료 승낙, 거절 활성화 / 클릭은 안됨
                    {
                        TutCustomer.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
                        isArrowTrue = false;
                        TutCustomer.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
                    }
                    if (buyCnt == 15)//승낙 거절 하이라이팅, 화살표 추가
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
                    //Debug.Log("17보다 크거나 같음");
                    if (isDialogueEnd == true)
                    {
                        StartCoroutine(NormalChat_2(TS.tutBuy[buyCnt]));
                        buyCnt++;
                    }
                    if (buyCnt == 18)//제작대 넘어감, 미니 대화창으로 변경
                    {
                        GameObject.Find("Etc").transform.GetChild(2).GetComponent<DeskTouch>().TouchDesk();
                       if(isDialogueEnd == false)
                            TutorialDialogue.GetComponent<Button>().interactable = false;
                        BlackPanel.SetActive(true);
                        TutCustomer.SetActive(false);
                        TutorialDialogue.SetActive(true);
                    }
                    if (buyCnt == 19)//스킵 여부 물어봄
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
                if (createCnt == 2)//인벤 하이라이팅
                {
                    MaskPanel.transform.GetChild(6).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (createCnt == 3)
                {
                    MaskPanel.transform.GetChild(6).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(false);
                }
                if (createCnt == 4)//영수증 하이라이팅
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
                if (createCnt == 9)//장소 향료 선택하게 하기, 장소 말고는 다 버튼 막아두기
                {
                    InvenPanel.SetActive(false);
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Baseslots.Count; i++)
                    {
                        if (Inven.Baseslots[i].item.name != "동물")
                        {
                            Inven.Baseslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                        Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Topslots.Count; i++)
                        Inven.Topslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 10)//초기화 버튼 아트 나오면 하이라이팅 작업 하기
                {
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    isArrowTrue = true;
                    MaskPanel.transform.GetChild(20).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(3).gameObject.SetActive(true);
                    InvenUI.GetComponent<Button>().interactable = false;
                }
                if (createCnt == 11)//장소 향료 잘 선택한 경우 증류기 하이라이팅
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
                if (createCnt == 12)//증류기 시작, 증류기 정령 하이라이팅 - 약불, 증류기 시작 x
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
                if (createCnt == 14)//강불 하이라이팅
                {
                    MaskPanel.transform.GetChild(9).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(10).gameObject.SetActive(true);
                }
                if (createCnt == 15)//중불 하이라이팅
                {
                    MaskPanel.transform.GetChild(10).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(11).gameObject.SetActive(true);
                }
                if (createCnt == 16)//하이라이팅 끔
                {
                    MaskPanel.transform.GetChild(11).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(6).gameObject.SetActive(false);
                }
                if (createCnt == 18)//증류기 테스트 시작. 
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

                if (createCnt == 23)//여행지 제외 다 클릭 안되게
                {
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                    {
                        if (Inven.Middleslots[i].item.name != "반려동물")
                        {
                            Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Baseslots.Count; i++)
                        Inven.Baseslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 24)//압착기 하이라이팅
                {
                    MaskPanel.transform.GetChild(12).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(7).gameObject.SetActive(true);
                }
                if (createCnt == 25)//압착기 시작, 압착기 정령 하이라이팅 - 24
                {
                    isArrowTrue = true;
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 348, 0);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    MaskPanel.transform.GetChild(12).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(7).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(13).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(8).gameObject.SetActive(true);
                }
                if (createCnt == 26)//압착기 노트 하이라이팅
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
                if (createCnt == 30)//압착기 테스트 시작
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
                if (createCnt == 32)//탑노트 소개, 제조대로 넘어옴
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

                if (createCnt == 35)//기쁨 선택
                {
                    isArrowTrue = false;
                    BlackPanel.SetActive(false);
                    InvenUI.GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    for (int i = 0; i < Inven.Topslots.Count; i++)
                    {
                        if (Inven.Topslots[i].item.name != "기쁨")
                        {
                            Inven.Topslots[i].GetComponent<Button>().interactable = false;
                        }
                    }
                    for (int i = 0; i < Inven.Middleslots.Count; i++)
                        Inven.Middleslots[i].GetComponent<Button>().interactable = false;
                }
                if (createCnt == 36)//냉침기 하이라이팅 - 35
                {
                    MaskPanel.transform.GetChild(15).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(10).gameObject.SetActive(true);
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, 196, 0);
                }
                if (createCnt == 37)//냉침 화면 켜짐 - 36
                {
                    TutorialDialoguePos.anchoredPosition = new Vector3(0, -352, 0);
                    MaskPanel.transform.GetChild(15).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(10).gameObject.SetActive(false);
                    TutorialDialogue.SetActive(true);
                    isArrowTrue = true;
                    BlackPanel.SetActive(true);
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                }
                if (createCnt == 39)//냉침기 향료 하이라이팅 - 38
                {
                    BlackPanel.SetActive(true);
                    MaskPanel.transform.GetChild(16).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(11).gameObject.SetActive(true);
                }
                if (createCnt == 40)//냉침기 향료 하이라이팅 - 39
                {
                    MaskPanel.transform.GetChild(16).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(11).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(17).gameObject.SetActive(true);
                    MaskArrow.transform.GetChild(12).gameObject.SetActive(true);
                }
                if (createCnt == 41)//냉침기 향료 하이라이팅2 - 40
                {
                    MaskPanel.transform.GetChild(17).gameObject.SetActive(false);
                    MaskArrow.transform.GetChild(12).gameObject.SetActive(false);
                }
                if (createCnt == 42)//냉침기 테스트 시작 - 41
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
                if (createCnt == 46)//향수병 하이라이팅
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
    public void StartDialogue()//향료 아저씨 대사, 세계관 및 향료 소개, 상점 클릭
    {
        isTutStart = true;
        startCnt = 0;
        NextTutDialogue();
    }

    public void StoreDialogue()//향료 노트 설명. 스킵 여부 묻기 => 예 : 다음 넘어감 / 아니오 : 베이스 설명 & 미들탭 하이라이팅, 미들 설명 & 탑탭 하이라이팅, 탑 설명 & 베이스탭 클릭유도 & 첫번째 향료 선택 및 구매 / 일괄구매 설명
    {
        isTutStart = false;
        isTutStore = true;
        storeCnt = 0;
        this.transform.GetChild(1).gameObject.SetActive(true);
        NextTutDialogue();
    }

    public void BuyDialogue() // 향료 구매 유도, 완료 여부 확인 -> 완료 시 상점 끄기, 손님 시스템 설명, 수락 / 거절 설명 및 클릭 유도, 향수 어떻게 고르는지 설명
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
        Debug.Log("구매 튜토리얼로 점프!");
        NextTutDialogue();
    }

    public void CreateDialogue()//제작 화면 넘어감. 스킵 여부 묻기 => 예 : 보상으로 넘어감 / 아니오 : 인벤 클릭 유도, 베이스 선택 유도, 증류기 선택 유도, 증류기 설명, 증류 성공 할 때 까지 반복, 실패 시 재도전 대사, 
                                // 미들 선택 유도, 압착기 선택 유도, 압착기 설명, 압착 성공할 때 까지 반복, 실패 시 재도전 대사, 
                                // 탑 선택 유도, 냉침기 선택 유도, 냉침기 설명, 냉침 성공할 때 까지 반복, 실패 시 재도전 대사
                                // 제작 화면 넘김, 완성 향수 하이라이팅 및 대사, 클릭 유도
    {
        isTutStart = false;
        isTutBuy = false;
        isTutCreate = true;
        createCnt = 0;
        NextTutDialogue();
    }

    public void ResultDialogue()//향수 보상, 평판, 이동맵 설명 이후 끝, 일반 일과로 넘어감
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
    public void StoreCloseBtnClicked()//상점 닫기 버튼 클릭했을 경우
    {
        if (isTutBuy == true)
        {
            //베이스, 미들, 탑 향료 슬롯 모두 돌면서 카운트 더했을 때 5보다 작으면 4번 대사 출력

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

            //베이스, 미들, 탑의 모든 향료의 카운트 돌면서 0이면 5번 대사 출력
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
        string distill = "...이 향은 너무 약하지 않은가? 불이 약했나보군, 다시 해보게나.";
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
        string press = "허허, 아직 미숙한가보군. 조금 더 신중히 지시를 해보지.";
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
        string cool = "흐음, 향이 어딘가 부족하군. 타이밍을 잘 맞춰보지 않겠는가?";
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
