using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Presser : MonoBehaviour
{
    public GameObject PresserDetail;
    public ItemProperty ClickedItem;

    public GameObject NotePattern;

    public int PressureScore = 0;
    public int PressCount;
    public bool isEnd = false;//끝나서 수거하면 true

    public string MiddleItemName; //손님이 요구하는 미들 향료 이름

    public GameObject middleInvenSlots;
    public GameObject Receipt;
    public bool isMiddleRight = false;
    public void Start()
    {
        PressCount = 0;
    }
    public void PresserOn(ItemProperty item)
    {
        ClickedItem = item;
        if (ClickedItem.name == MiddleItemName)
        {
            Debug.Log("미들 향료 맞음");
            isMiddleRight = true;
        }
        else
        {
            isMiddleRight = false;
        }
    }

    public void PresserShow()//압착기 화면 보임.
    {
        Receipt.gameObject.SetActive(false);
        if (isMiddleRight == true)
        {
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
        }
        else if (isMiddleRight == false)
        {
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
        }
        GameObject.Find("Manufacture").transform.GetChild(7).gameObject.SetActive(false);
        GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("CatPress").gameObject.GetComponent<Image>().sprite = PresserTap.FindObjectOfType<PresserTap>().PressReaction[0];
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
        isMiddleRight = false;
        TotalScore.FindObjectOfType<TotalScore>().PressCnt++;
        for (int i = 0; i < GameObject.Find("MiddleInvenSlots").transform.childCount; i++)
        {
            GameObject.Find("MiddleInvenSlots").transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
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
