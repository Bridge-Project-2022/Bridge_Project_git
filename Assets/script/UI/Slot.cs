using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemProperty item;
    public UnityEngine.UI.Image image;
    public GameObject itemPrice;
    public GameObject itemCount;

    public ItemProperty ClickedItem;
    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = item.name;
            image.sprite = item.sprite;
            itemPrice.gameObject.GetComponent<Text>().text = item.itemPrice.ToString();
            //itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "�� ����";
        }
    }

    public void SetInvenItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = item.name;
            image.sprite = item.sprite;
            itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "�� ����";
        }
    }

    public void ItemClick(Slot ClickedSlot)//���� ������ Ŭ�� ���
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        //Ŭ���� �������� ȭ�鿡 ������.
        Color color = GameObject.Find("ClickedItem").GetComponent<Image>().color;
        color.a = 255;
        GameObject.Find("ClickedItem").GetComponent<Image>().color = color;//Ŭ���� ������ ���� 0�̾��ٰ� �������� �ϴϱ� 255�� ����
        GameObject.Find("ClickedItem").GetComponent<Image>().sprite = this.image.sprite;

        if (ClickedSlot.item.itemType == "Base")//������ ����
        {
            ClickedItem = ClickedSlot.item;

            GameObject.Find("Distiller").GetComponent<Distiller>().GetComponent<Button>().interactable = true;
            GameObject.Find("Distiller").GetComponent<Distiller>().DistillerOn(ClickedItem);
            Debug.Log("������ ����");
        }

        else if (item.itemType == "Middle")//������ ����
        {
            ClickedItem = ClickedSlot.item;
            Debug.Log("������ ����");
            GameObject.Find("Presser").GetComponent<Presser>().GetComponent<Button>().interactable = true;
            GameObject.Find("Presser").GetComponent<Presser>().PresserOn(ClickedItem);
        }
        else if (item.itemType == "Top")//��ħ�� ����
        {
            ClickedItem = ClickedSlot.item;

            GameObject.Find("Cooler").GetComponent<Cooler>().GetComponent<Button>().interactable = true;
            GameObject.Find("Cooler").GetComponent<Cooler>().CoolerOn(ClickedItem);
            Debug.Log("��ħ�� ����");
        }
        else
            Debug.Log("����");

        //Ŭ�� ������ ���� �ϳ� �پ��. -> 0�� ��쿡 ���� �����ǵ��� ����.
        if (ClickedSlot.item.InvenItemNum >= 1)
        {
            ClickedSlot.item.InvenItemNum -= 1;
            ClickedSlot.transform.GetChild(3).GetComponent<Text>().text = ClickedSlot.item.InvenItemNum.ToString() + "�� ����";
            if (ClickedSlot.item.InvenItemNum == 0)
            {
                ClickedSlot.transform.GetChild(3).GetComponent<Text>().text = "";
                ClickedSlot.item = null;
                ClickedSlot.image.enabled = false;
                ClickedSlot.gameObject.name = "Empty";
            }
        }
    }

    public void Update()
    {
        if (this.item != null)
        {
            itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "�� ����";
            if (item.itemCount <= 0)
            {
                this.GetComponent<UnityEngine.UI.Button>().interactable = false;
                itemCount.gameObject.GetComponent<Text>().text = "�Ǹ� �Ϸ�";
            }
            /*if (FindObjectOfType<DeskTouch>().isDeskUp == true)// ����ũ�� �ö�� ���(������ ���� ���� ���)���� �κ� ������ Ŭ�� ���� ���·� ����.
            {
                this.gameObject.GetComponent<Button>().interactable = true;
            }*/
        }
    }
}
