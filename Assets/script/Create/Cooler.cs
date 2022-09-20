using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooler : MonoBehaviour
{
    public GameObject CoolerDetail;

    public ItemProperty ClickedItem;

    public GameObject CoolerOne;//��ħ ������ 1
    public GameObject CoolerTwo;// ��ħ ������ 2
    public GameObject CoolerThree;// ��ħ ������ 3

    public GameObject Particle1;
    public GameObject Particle2;
    public GameObject Particle3;

    public GameObject topInvenSlots;

    public string TopItemName;//�մ��� �䱸�ϴ� ž ��� �̸�

    int ResultCount = 0;
    int goodCount;

    public Sprite[] ItemSprites = new Sprite[4];
    public Sprite[] ItemBurnSprites = new Sprite[1];//ź ������ �̹��� �迭

    public GameObject Receipt;
    public void Start()
    {
        goodCount = 0;
    }
    public void CoolerOn(ItemProperty item)
    {
        this.gameObject.GetComponent<Button>().interactable = true;//��ħ�� ��ư Ŭ�� ��������.
        ClickedItem = item;
        Color color = CoolerOne.gameObject.GetComponent<Image>().color;
        color.a = 255;
        CoolerOne.gameObject.GetComponent<Image>().color = color;//������ ����

        Color color2 = CoolerTwo.gameObject.GetComponent<Image>().color;
        color2.a = 255;
        CoolerTwo.gameObject.GetComponent<Image>().color = color2;//������ ����

        Color color3 = CoolerThree.gameObject.GetComponent<Image>().color;
        color3.a = 255;
        CoolerThree.gameObject.GetComponent<Image>().color = color3;//������ ����
        if (ClickedItem.name == TopItemName)
        {
            Debug.Log("ž ��� ����");
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

    public void CoolerStart()//��ħ�� �ڼ��� �������� ��� ����. 
    {
        Receipt.gameObject.SetActive(false);
        CoolerDetail.gameObject.SetActive(true);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        //GameObject.Find("Desk").GetComponent<Button>().interactable = false;

        if (ClickedItem.name == "���")
        {
            CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
            CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
            CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
        }
        if (ClickedItem.name == "���")
        {
            CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
            CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
            CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
        }
        if (ClickedItem.name == "����")
        {
            CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
            CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
            CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
        }
        if (ClickedItem.name == "�ູ")
        {
            CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
            CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
            CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
        }
        // ������ ž ������ ��ħ 123�� ���� �Ϸ�
        Invoke("Cooling", 3.5f);
    }

    public void Cooling()
    {
        if (ClickedItem.name.Equals("�ູ"))
        {
            Invoke("ParticleShow", 4f);
            Invoke("BurnItem", 6f);
        }
        else if (ClickedItem.name.Equals("���"))
        {
            Invoke("ParticleShow", 2f);
            Invoke("BurnItem", 4f);
        }
        else if (ClickedItem.name.Equals("���"))
        {
            Invoke("ParticleShow", 4f);
            Invoke("BurnItem", 6f);
        }
        else if (ClickedItem.name.Equals("����"))
        {
            Invoke("ParticleShow", 1f);
            Invoke("BurnItem", 3f);
        }
        else if (ClickedItem.name.Equals("�̿�"))
        {
            Invoke("ParticleShow", 8f);
            Invoke("BurnItem", 10f);
        }
        else if (ClickedItem.name.Equals("�β�����"))
        {
            Invoke("ParticleShow", 6f);
            Invoke("BurnItem", 8f);
        }
        else if (ClickedItem.name.Equals("��å��"))
        {
            Invoke("ParticleShow", 5f);
            Invoke("BurnItem", 7f);
        }
        else if (ClickedItem.name.Equals("�ǽ�"))
        {
            Invoke("ParticleShow", 4f);
            Invoke("BurnItem", 6f);
        }
        else if (ClickedItem.name.Equals("����"))
        {
            Invoke("ParticleShow", 3f);
            Invoke("BurnItem", 5f);
        }
    }
    public void CoolerClose()//��ħ�� ����
    {
        Receipt.gameObject.SetActive(true);
        for (int i = 0; i < topInvenSlots.transform.childCount; i++)
        {
            topInvenSlots.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        TotalScore.FindObjectOfType<TotalScore>().isCoolFin = true;
        CoolerDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;

    }

    public void ParticleShow()//�� �� �Ŀ� ��ƼŬ ����� Ŭ�� ��������.
    {
        Particle1.gameObject.SetActive(true);
        Particle2.gameObject.SetActive(true);
        Particle3.gameObject.SetActive(true);

        CoolerOne.GetComponent<Button>().interactable = true;
        CoolerTwo.GetComponent<Button>().interactable = true;
        CoolerThree.GetComponent<Button>().interactable = true;

        CoolerOne.gameObject.tag = "good";
        CoolerTwo.gameObject.tag = "good";
        CoolerThree.gameObject.tag = "good";
    }

    public void BurnItem()//��ƼŬ ���� �� 2�� �ڿ� ������ ź �̹����� ��ȯ,
    {
        //���⿡ ������ �̸����� �ٸ��� ź �̹��� �����ϵ��� ���ǹ� �߰��ؾ���.

        Particle1.gameObject.SetActive(false);
        Particle2.gameObject.SetActive(false);
        Particle3.gameObject.SetActive(false);

        CoolerOne.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];
        CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];
        CoolerThree.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];

        CoolerOne.gameObject.tag = "bad";
        CoolerTwo.gameObject.tag = "bad";
        CoolerThree.gameObject.tag = "bad";

    }

    public void ItemResult(GameObject itemResult)//������ ����
    {
        if (itemResult.gameObject.tag == "good")
        {
            if (itemResult.name == "Cool1")
            {
                Particle1.gameObject.SetActive(false);
            }
            else if (itemResult.name == "Cool2")
            {
                Particle2.gameObject.SetActive(false);
            }

            else if (itemResult.name == "Cool3")
            {
                Particle3.gameObject.SetActive(false);
            }
            goodCount += 1;
        }

        itemResult.gameObject.GetComponent<Image>().sprite = null;
        Color color = itemResult.gameObject.GetComponent<Image>().color;
        color.a = 0;
        itemResult.gameObject.GetComponent<Image>().color = color;//������ ����


        if (itemResult.gameObject.tag == "bad")
        {
            goodCount += 0;
        }//���̸� 1 �߰�, ���� 0 �߰�

        ResultCount += 1;

        if (ResultCount == 3)
        {
            CoolTotalScore();
            this.GetComponent<Button>().interactable = false;
            Invoke("CoolerClose", 2);
            ResultCount = 0;
        }
    }

    public void CoolTotalScore()
    {
        if (goodCount == 3)
        {
            TotalScore.FindObjectOfType<TotalScore>().isCoolGood = true;
        }

        else if (goodCount == 2)
        {
            TotalScore.FindObjectOfType<TotalScore>().isCoolNormal = true;
        }
        else
        {
            TotalScore.FindObjectOfType<TotalScore>().isCoolBad = true;

        }
    }
}
