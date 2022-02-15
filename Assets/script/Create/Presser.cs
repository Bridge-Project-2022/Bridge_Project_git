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
    public GameObject PressItem;//���� ���


    private bool isBtnOn;
    public static bool isHandleUp = true;
    public int PressCount;
    public bool isEnd = false;//������ �����ϸ� true

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
        this.gameObject.GetComponent<Button>().interactable = true;//��ħ�� ��ư Ŭ�� ��������.
        ClickedItem = item;
        Debug.Log(ClickedItem.name);
    }

    public void PresserShow()//������ ȭ�� ����.
    {
        PresserDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        PressItem.GetComponent<Image>().sprite = ClickedItem.sprite;
    }

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


    public void PresserStart()//���� ���� ����
    {
        if (PressCount == 1|| PressCount == 3 || PressCount == 5)//������
        {
            handle.transform.position = new Vector3(985, 600, 0);
            Color color = PressItem.gameObject.GetComponent<Image>().color;
            color.a = 0;
            PressItem.gameObject.GetComponent<Image>().color = color;
            PressCount += 1;
            
        }

        else if (PressCount == 0 || PressCount == 2 || PressCount == 4 || PressCount == 6 )//�ö�
        {
            if (PressCount == 2)
            {
                Debug.Log("�ѹ� ����");
                PressItem.GetComponent<Image>().color = Color.red;
            }
            if (PressCount == 4)
            {
                Debug.Log("�ι� ����");
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
                Debug.Log("�� ��");
                PressItem.tag = "good";
            }
            else if (PressCount == 3)
            {
                Debug.Log("����");
                PressItem.tag = "normal";
            }

            else
            {
                Debug.Log("����");
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
        PressResult.gameObject.GetComponent<Image>().color = color;//������ ����

        if (PressResult.gameObject.tag == "good")
        {
            TotalScore.isPressGood = true;
            Debug.Log("���� ��");
        }

        else if (PressResult.gameObject.tag == "normal")
        {
            TotalScore.isPressNormal = true;
            Debug.Log("���� ���");
        }
        else if (PressResult.gameObject.tag == "bad")
        {
            TotalScore.isPressBad = true;
            Debug.Log("���� ���");
        }

    }


    public void PresserEnd()//���� ���� ����
    {
        PresserDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;
        //GameObject.Find("Desk").GetComponent<Button>().interactable = true;
    }

}
