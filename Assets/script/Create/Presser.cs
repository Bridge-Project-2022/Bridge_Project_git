using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Presser : MonoBehaviour
{
    //1. 압착기는 미들 향료만 가능, 전원 키면 변수 true되고 빨 -> 초로 바뀌고 실행 가능
    //2. 손잡이 위 아래로 움직일 수 있음.
    //3. 압착 카운트 변수 생성, 손잡이 위에서 아래로 내려가서 바닥에 닿을 때 재료 잠시 안보였다가 올리면 재료 빻아진 것으로 점점 변경
    //4. 압착은 향료 별로 횟수가 다름.
    //5. 향료는 압착 횟수 상관 없이 언제든 픽업할 수 있음.상태에 따라 굿 노멀 배드 측정. 카운트됨.

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

    //int ResultCount = 0;

    public string MiddleItemName; //손님이 요구하는 미들 향료 이름

    public GameObject middleInvenSlots;
    public GameObject Receipt;
    public void Start()
    {
        isBtnOn = false;
        button.GetComponent<Image>().color = Color.red;
        PressCount = 0;
        //handle.GetComponent<PresserDrag>().enabled = false;
    }
    public void PresserOn(ItemProperty item)
    {
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
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        if (MiddleItemName == "가족")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "연인")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("LoverPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "반려동물")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("PetPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "놀이공원")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("ParkPattern");
            Invoke("PresserEnd", 8f);
        }
        else
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");//이거 지금은 가족패턴 적용인데 그냥 기본 패턴 넣으면 될듯.
        }
        //PressItem.GetComponent<Image>().sprite = ClickedItem.sprite;
    }

    /*
    public void PresserBtnClick()//버튼 클릭해야 압착기 돌아감. on = 초록 / off = 빨강
    {
        if (isBtnOn == false)//꺼진 상태
        {
            button.GetComponent<Image>().color = Color.green;
            isBtnOn = true;
            PresserStart();
        }
        else if (isBtnOn == true)
        {
            button.GetComponent<Image>().color = Color.red;
            isBtnOn = false;
            this.GetComponent<Button>().interactable = false;
            Invoke("PresserEnd", 2);
        }
    }

    /*
    public void PresserStart()//압착 과정 시작
    {
        if (PressCount == 1 || PressCount == 3 || PressCount == 5 || PressCount == 7 || PressCount == 9 || PressCount == 11)//내려감
        {
            handle.transform.position = new Vector3(985, 600, 0);
            //Color color = PressItem.gameObject.GetComponent<Image>().color;
            color.a = 0;
            //PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;

        }

        else if (PressCount == 0 || PressCount == 2 || PressCount == 4 || PressCount == 6 || PressCount == 8 || PressCount == 10 || PressCount == 12)//올라감
        {
            if (PressCount == 2)
            {
                //PressItem.GetComponent<Image>().color = Color.red;
            }
            if (PressCount == 4)
            {
                //PressItem.GetComponent<Image>().color = Color.blue;
            }
            if (PressCount == 6)
            {
                //PressItem.GetComponent<Image>().color = Color.blue;
            }
            if (PressCount == 8)
            {
                //PressItem.GetComponent<Image>().color = Color.blue;
            }
            if (PressCount == 10)
            {
                //PressItem.GetComponent<Image>().color = Color.blue;
            }
            if (PressCount == 12)
            {
                //PressItem.GetComponent<Image>().color = Color.blue;
            }
            handle.transform.position = new Vector3(985, 712, 0);
            //Color color = PressItem.gameObject.GetComponent<Image>().color;
            //color.a = 255;
            //PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;
        }
        if (ClickedItem.name.Equals("친구"))
        {
            if (PressCount == 1)
                //PressItem.tag = "good";
            else if (PressCount == 3)
                //PressItem.tag = "normal";
            else if (PressCount == 5)
                //PressItem.tag = "bad";
        }

        else if (ClickedItem.name.Equals("연인"))
        {
            if (PressCount == 2)
                //PressItem.tag = "good";
            else if (PressCount == 4)
                //PressItem.tag = "normal";
            else if (PressCount == 6)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("가족"))
        {
            if (PressCount == 3)
                //PressItem.tag = "good";
            else if (PressCount == 5)
                //PressItem.tag = "normal";
            else if (PressCount == 7)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("반려동물"))
        {
            if (PressCount == 2)
                //PressItem.tag = "good";
            else if (PressCount == 5)
                //PressItem.tag = "normal";
            else if (PressCount == 8)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("장난감"))
        {
            if (PressCount == 1)
                //PressItem.tag = "good";
            else if (PressCount == 4)
                //PressItem.tag = "normal";
            else if (PressCount == 9)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("인형"))
        {
            if (PressCount == 2)
                PressItem.tag = "good";
            else if (PressCount == 3)
                PressItem.tag = "normal";
            else if (PressCount == 4)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("학교"))
        {
            if (PressCount == 5)
                PressItem.tag = "good";
            else if (PressCount == 8)
                PressItem.tag = "normal";
            else if (PressCount == 10)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("놀이터"))
        {
            if (PressCount == 4)
                PressItem.tag = "good";
            else if (PressCount == 7)
                PressItem.tag = "normal";
            else if (PressCount == 11)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("놀이공원"))
        {
            if (PressCount == 6)
                PressItem.tag = "good";
            else if (PressCount == 8)
                PressItem.tag = "normal";
            else if (PressCount == 13)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("여행지"))
        {
            if (PressCount == 3)
                PressItem.tag = "good";
            else if (PressCount == 10)
                PressItem.tag = "normal";
            else if (PressCount == 14)
                PressItem.tag = "bad";
        }

    }

    public void PressResult(GameObject PressResult)
    {
        isEnd = true;
        PressResult.gameObject.GetComponent<Image>().sprite = null;
        Color color = PressResult.gameObject.GetComponent<Image>().color;
        color.a = 0;
        PressResult.gameObject.GetComponent<Image>().color = color;//아이템 제거

        if (PressResult.gameObject.tag == "good")
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressGood = true;
        }

        else if (PressResult.gameObject.tag == "normal")
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressNormal = true;
        }
        else if (PressResult.gameObject.tag == "bad")
        {
            TotalScore.FindObjectOfType<TotalScore>().isPressBad = true;
        }

    }
    */

    public void PresserEnd()//압착 과정 종료
    {
        /*for (int i = 0; i < middleInvenSlots.transform.childCount; i++)
        {
            middleInvenSlots.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }*/
        if (ClickedItem.name == "가족")
        {
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
        }

        if (ClickedItem.name == "연인")
        {
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
        }

        if (ClickedItem.name == "반려동물")
        {
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
        }

        if (ClickedItem.name == "놀이공원")
        {
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
        }
        Receipt.gameObject.SetActive(true);
        TotalScore.FindObjectOfType<TotalScore>().isPressFin = true;
        //TotalScore.isPressFin = true;
        PresserDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;
        //GameObject.Find("Desk").GetComponent<Button>().interactable = true;
    }

}
