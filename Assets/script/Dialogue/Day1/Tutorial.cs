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

    public GameObject BlackPanel;
    public GameObject MaskPanel;
    public GameObject MaskArrow;
    public RectTransform MaskArrowPos;

    bool isTutStart = false;
    bool isTutStore = false;

    int startCnt = 0;
    public int storeCnt = 0;

    public void Update()
    {
        TS = GameObject.Find("TutorialScript").GetComponent<TutorialScript>();
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

                if (startCnt == 6)
                {
                    this.GetComponent<UIOnOff>().StoreOpen();
                    GameObject.Find("Canvas").transform.GetChild(8).gameObject.GetComponent<Store>().StoreOpen();
                    TutCustomer.SetActive(false);
                    Invoke("StoreDialogue", 1f);
                    BlackPanel.SetActive(true);
                }
            }
        }

        if (isTutStore == true)
        {
            if (storeCnt == 0)
            {
                StartCoroutine(NormalChat_2(TS.tutStore[0]));
                storeCnt++;
            }
            else if (storeCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_2(TS.tutStore[storeCnt]));
                    storeCnt++;
                }
                if (storeCnt == 2)//스킵 여부 묻기
                {
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(true);
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);
                }
                if (storeCnt == 3)
                {
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
                    MaskPanel.SetActive(true);
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(true);
                    MaskArrow.SetActive(true);
                }
                if (storeCnt == 4)
                {
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(true);//하이라이팅 마스크 활성화
                    MaskArrowPos.anchoredPosition = new Vector3(-876,66,0);
                    TutorialDialogue.GetComponent<Button>().interactable = false;//하이라이팅 부분 클릭해야 하는데 대화창 클릭되면 안되므로 비활성화 
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);// 대화 넘기기 애니메이션도 비활성화
                    MaskPanel.transform.GetChild(1).GetComponent<Button>().interactable = true;//하이라이팅 부분 클릭 가능하게 활성화
                }
                if (storeCnt == 5)
                {
                    MaskArrow.SetActive(false);
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(1);
                    MaskPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                }
                if (storeCnt == 6)
                {
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(true);
                    MaskArrow.SetActive(true);
                    MaskArrowPos.anchoredPosition = new Vector3(-876, -107, 0);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).GetComponent<Button>().interactable = true;
                }
                if (storeCnt == 7)
                {
                    MaskArrow.SetActive(false);
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(2);
                    MaskPanel.transform.GetChild(2).GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
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
        Debug.Log("구매 튜토리얼로 점프!");
        TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void CreateDialogue()//제작 화면 넘어감. 스킵 여부 묻기 => 예 : 보상으로 넘어감 / 아니오 : 인벤 클릭 유도, 베이스 선택 유도, 증류기 선택 유도, 증류기 설명, 증류 성공 할 때 까지 반복, 실패 시 재도전 대사, 
                                // 미들 선택 유도, 압착기 선택 유도, 압착기 설명, 압착 성공할 때 까지 반복, 실패 시 재도전 대사, 
                                // 탑 선택 유도, 냉침기 선택 유도, 냉침기 설명, 냉침 성공할 때 까지 반복, 실패 시 재도전 대사
                                // 제작 화면 넘김, 완성 향수 하이라이팅 및 대사, 클릭 유도
    { 
        
    }

    public void ResultDialogue()//향수 보상, 평판, 이동맵 설명 이후 끝, 일반 일과로 넘어감
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
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
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
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
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
}
