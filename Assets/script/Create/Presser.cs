using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Presser : MonoBehaviour
{
    public GameObject PresserDetail;
    public ItemProperty ClickedItem;

    public GameObject body;// 압착 부품이 닿는 바닥 부품
    public GameObject handle;// 압착기 움직이는 핸들
    public GameObject button;// 압착기 전원 켜고 끄는 버튼
    //public GameObject PressItem;//압착 재료
    public GameObject NotePattern;

    public int PressureScore = 0;
    private bool isBtnOn;
    public static bool isHandleUp = true;
    public int PressCount;
    public bool isEnd = false;//끝나서 수거하면 true

    public string MiddleItemName; //손님이 요구하는 미들 향료 이름

    public GameObject middleInvenSlots;
    public GameObject Receipt;

    public void Start()
    {
        isBtnOn = false;
        button.GetComponent<Image>().color = Color.red;
        PressCount = 0;
    }
    public void PresserOn(ItemProperty item)
    {
        TotalScore.FindObjectOfType<TotalScore>().PressCnt++;
        for (int i = 0; i < GameObject.Find("MiddleInvenSlots").transform.childCount; i++)
        {
            GameObject.Find("MiddleInvenSlots").transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        Receipt.gameObject.SetActive(false);
        this.gameObject.GetComponent<Button>().interactable = true;//냉침기 버튼 클릭 가능해짐.
        ClickedItem = item;
        if (ClickedItem.name == MiddleItemName)
        {
            Debug.Log("미들 향료 맞음");
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
        }
        else
        {
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
        }
            
        //Debug.Log(ClickedItem.name);
    }

    public void PresserShow()//압착기 화면 보임.
    {
        GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        if (ClickedItem.name == "가족")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");
            Invoke("PresserEnd", 8f);
        }
        if (ClickedItem.name == "연인")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("LoverPattern");
            Invoke("PresserEnd", 8f);
        }
        if (ClickedItem.name == "반려동물")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("PetPattern");
            Invoke("PresserEnd", 8f);
        }
        if (ClickedItem.name == "놀이공원")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("ParkPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "친구")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FriendPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "장난감")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("ToyPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "인형")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("DollPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "학교")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("SchoolPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "놀이터")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("PlayGroundPattern");
            Invoke("PresserEnd", 8f);
        }

        if (ClickedItem.name == "여행지")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("TravelPattern");
            Invoke("PresserEnd", 8f);
        }
        else
        {
            Debug.Log("else");
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");//이거 지금은 가족패턴 적용인데 그냥 기본 패턴 넣으면 될듯.
            Invoke("PresserEnd", 8f);
        }
        //PressItem.GetComponent<Image>().sprite = ClickedItem.sprite;
    }
    public void PresserEnd()//압착 과정 종료
    {
        Debug.Log("압착 끝");
        if ((PressureScore / 9) >= 3)
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressGood = true;
        }

        if ((PressureScore / 9) < 3 && (PressureScore / 9) >= 2)
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressNormal = true;
        }

        if ((PressureScore / 9) < 2 && (PressureScore / 9) >= 1)
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressBad = true;
        }

        Receipt.gameObject.SetActive(true);
        TotalScore.FindObjectOfType<TotalScore>().isPressFin = true;
        this.gameObject.GetComponent<Button>().interactable = false;
        PresserDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;
    }

}
