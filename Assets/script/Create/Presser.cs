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
    public GameObject PressItem;//압착 재료


    private bool isBtnOn;
    public static bool isHandleUp = true;
    public int PressCount;
    public bool isEnd = false;//끝나서 수거하면 true

    int ResultCount = 0;

    public void Start()
    {
        isBtnOn = false;
        button.GetComponent<Image>().color = Color.red;
        PressCount = 0;
        //handle.GetComponent<PresserDrag>().enabled = false;
    }
    public void PresserOn(ItemProperty item)
    {
        this.gameObject.GetComponent<Button>().interactable = true;//냉침기 버튼 클릭 가능해짐.
        ClickedItem = item;
        Debug.Log(ClickedItem.name);
    }

    public void PresserShow()//압착기 화면 보임.
    {
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        PressItem.GetComponent<Image>().sprite = ClickedItem.sprite;
    }

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


    public void PresserStart()//압착 과정 시작
    {
        if (PressCount == 1|| PressCount == 3 || PressCount == 5)//내려감
        {
            handle.transform.position = new Vector3(985, 600, 0);
            Color color = PressItem.gameObject.GetComponent<Image>().color;
            color.a = 0;
            PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;
            
        }

        else if (PressCount == 0 || PressCount == 2 || PressCount == 4 || PressCount == 6 )//올라감
        {
            if (PressCount == 2)
            {
                Debug.Log("한번 빻음");
                PressItem.GetComponent<Image>().color = Color.red;
            }
            if (PressCount == 4)
            {
                Debug.Log("두번 빻음");
                PressItem.GetComponent<Image>().color = Color.blue;
            }
            handle.transform.position = new Vector3(985, 712, 0);
            Color color = PressItem.gameObject.GetComponent<Image>().color;
            color.a = 255;
            PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;
        }
        if (ClickedItem.name.Equals("human"))
        {
            Debug.Log(PressCount);
            if (PressCount == 5)
            {
                Debug.Log("잘 됨");
                PressItem.tag = "good";
            }
            else if (PressCount == 3)
            {
                Debug.Log("보통");
                PressItem.tag = "normal";
            }

            else
            {
                Debug.Log("망함");
                PressItem.tag = "bad";
            }
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
            TotalScore.isPressGood = true;
            Debug.Log("압착 굿");
        }

        else if (PressResult.gameObject.tag == "normal")
        {
            TotalScore.isPressNormal = true;
            Debug.Log("압착 노멀");
        }
        else if (PressResult.gameObject.tag == "bad")
        {
            TotalScore.isPressBad = true;
            Debug.Log("압착 배드");
        }

    }


    public void PresserEnd()//압착 과정 종료
    {
        PresserDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;
        //GameObject.Find("Desk").GetComponent<Button>().interactable = true;
    }

}
