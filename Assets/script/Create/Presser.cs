using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Presser : MonoBehaviour
{
    //1. ������� �̵� ��Ḹ ����, ���� Ű�� ���� true�ǰ� �� -> �ʷ� �ٲ�� ���� ����
    //2. ������ �� �Ʒ��� ������ �� ����.
    //3. ���� ī��Ʈ ���� ����, ������ ������ �Ʒ��� �������� �ٴڿ� ���� �� ��� ��� �Ⱥ����ٰ� �ø��� ��� ������ ������ ���� ����
    //4. ������ ��� ���� Ƚ���� �ٸ�.
    //5. ���� ���� Ƚ�� ��� ���� ������ �Ⱦ��� �� ����.���¿� ���� �� ��� ��� ����. ī��Ʈ��.

    public GameObject PresserDetail;
    public ItemProperty ClickedItem;

    public GameObject body;// ���� ��ǰ�� ��� �ٴ� ��ǰ
    public GameObject handle;// ������ �����̴� �ڵ�
    public GameObject button;// ������ ���� �Ѱ� ���� ��ư
    //public GameObject PressItem;//���� ���
    public GameObject NotePattern;

    public int PressureScore = 0;
    private bool isBtnOn;
    public static bool isHandleUp = true;
    public int PressCount;
    public bool isEnd = false;//������ �����ϸ� true

    //int ResultCount = 0;

    public string MiddleItemName; //�մ��� �䱸�ϴ� �̵� ��� �̸�

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
        this.gameObject.GetComponent<Button>().interactable = true;//��ħ�� ��ư Ŭ�� ��������.
        ClickedItem = item;
        if (ClickedItem.name == MiddleItemName)
        {
            Debug.Log("�̵� ��� ����");
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

    public void PresserShow()//������ ȭ�� ����.
    {
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        if (MiddleItemName == "����")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "����")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("LoverPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "�ݷ�����")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("PetPattern");
            Invoke("PresserEnd", 8f);
        }
        if (MiddleItemName == "���̰���")
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("ParkPattern");
            Invoke("PresserEnd", 8f);
        }
        else
        {
            //NotePattern.gameObject.SetActive(true);
            NotePattern.GetComponent<NotePatterns>().StartCoroutine("FamilyPattern");//�̰� ������ �������� �����ε� �׳� �⺻ ���� ������ �ɵ�.
        }
        //PressItem.GetComponent<Image>().sprite = ClickedItem.sprite;
    }

    /*
    public void PresserBtnClick()//��ư Ŭ���ؾ� ������ ���ư�. on = �ʷ� / off = ����
    {
        if (isBtnOn == false)//���� ����
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
    public void PresserStart()//���� ���� ����
    {
        if (PressCount == 1 || PressCount == 3 || PressCount == 5 || PressCount == 7 || PressCount == 9 || PressCount == 11)//������
        {
            handle.transform.position = new Vector3(985, 600, 0);
            //Color color = PressItem.gameObject.GetComponent<Image>().color;
            color.a = 0;
            //PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;

        }

        else if (PressCount == 0 || PressCount == 2 || PressCount == 4 || PressCount == 6 || PressCount == 8 || PressCount == 10 || PressCount == 12)//�ö�
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
        if (ClickedItem.name.Equals("ģ��"))
        {
            if (PressCount == 1)
                //PressItem.tag = "good";
            else if (PressCount == 3)
                //PressItem.tag = "normal";
            else if (PressCount == 5)
                //PressItem.tag = "bad";
        }

        else if (ClickedItem.name.Equals("����"))
        {
            if (PressCount == 2)
                //PressItem.tag = "good";
            else if (PressCount == 4)
                //PressItem.tag = "normal";
            else if (PressCount == 6)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("����"))
        {
            if (PressCount == 3)
                //PressItem.tag = "good";
            else if (PressCount == 5)
                //PressItem.tag = "normal";
            else if (PressCount == 7)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("�ݷ�����"))
        {
            if (PressCount == 2)
                //PressItem.tag = "good";
            else if (PressCount == 5)
                //PressItem.tag = "normal";
            else if (PressCount == 8)
                //PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("�峭��"))
        {
            if (PressCount == 1)
                //PressItem.tag = "good";
            else if (PressCount == 4)
                //PressItem.tag = "normal";
            else if (PressCount == 9)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("����"))
        {
            if (PressCount == 2)
                PressItem.tag = "good";
            else if (PressCount == 3)
                PressItem.tag = "normal";
            else if (PressCount == 4)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("�б�"))
        {
            if (PressCount == 5)
                PressItem.tag = "good";
            else if (PressCount == 8)
                PressItem.tag = "normal";
            else if (PressCount == 10)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("������"))
        {
            if (PressCount == 4)
                PressItem.tag = "good";
            else if (PressCount == 7)
                PressItem.tag = "normal";
            else if (PressCount == 11)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("���̰���"))
        {
            if (PressCount == 6)
                PressItem.tag = "good";
            else if (PressCount == 8)
                PressItem.tag = "normal";
            else if (PressCount == 13)
                PressItem.tag = "bad";
        }
        else if (ClickedItem.name.Equals("������"))
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
        PressResult.gameObject.GetComponent<Image>().color = color;//������ ����

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

    public void PresserEnd()//���� ���� ����
    {
        /*for (int i = 0; i < middleInvenSlots.transform.childCount; i++)
        {
            middleInvenSlots.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }*/
        if (ClickedItem.name == "����")
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

        if (ClickedItem.name == "����")
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

        if (ClickedItem.name == "�ݷ�����")
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

        if (ClickedItem.name == "���̰���")
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
