using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform BaseslotRoot;
    public Transform MiddleslotRoot;
    public Transform TopslotRoot;

    public Transform storeSlotRoot;
    public Store store;

    private List<Slot> Baseslots;
    private List<Slot> Middleslots;
    private List<Slot> Topslots;

    private List<Slot> storeSlots;

    //public bool isNew;//���ο� �������� ���� ��� true
    public bool isSame;
    public bool isAllsame;

    ItemProperty allItem;
    // Start is called before the first frame update
    void Start()
    {
        isSame = false;
        isAllsame = false;

        Baseslots = new List<Slot>();
        Middleslots = new List<Slot>();
        Topslots = new List<Slot>();

        storeSlots = new List<Slot>();

        int BaseslotCount = BaseslotRoot.childCount;
        int MiddleslotCount = MiddleslotRoot.childCount;
        int TopslotCount = TopslotRoot.childCount;


        for (int i = 0; i < BaseslotCount; i++)
        {
            var slot = BaseslotRoot.GetChild(i).GetComponent<Slot>();

            Baseslots.Add(slot);
        }

        for (int i = 0; i < MiddleslotCount; i++)
        {
            var slot = MiddleslotRoot.GetChild(i).GetComponent<Slot>();

            Middleslots.Add(slot);
        }

        for (int i = 0; i < TopslotCount; i++)
        {
            var slot = TopslotRoot.GetChild(i).GetComponent<Slot>();

            Topslots.Add(slot);
        }

        for (int i = 0; i < storeSlotRoot.childCount; i++)
        {
            var Storeslot = storeSlotRoot.GetChild(i).GetComponent<Slot>();

            storeSlots.Add(Storeslot);
        }
        store.onStoreSlotClick += BuyItem;//�����ϱ� ��ư ������ ���� �Լ� ����.
        //store.onAllStoreSlotClick += AllBuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        if (item.itemType == "Base")
        {
            var emptySlot = Baseslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//��� �����߿� �������� �� ������ emptyslot�̶�� ���� �Ҵ�.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < BaseslotRoot.childCount; i++)
            {
                if (Baseslots[i].item == item)//�ߺ��� ���
                {
                    Debug.Log(i + "��° ���� �������� ��ħ");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;
                    Baseslots[i].transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";

                    break;
                }

                if (Baseslots[i].item != item)//�ߺ��� �ƴ� ���
                {
                    if (emptySlot != null)//���� ������ ���� ���
                    {
                        isSame = false;
                    }
                    else
                    {
                        Debug.Log("���� ����");
                    }
                }
            }

            if (isSame == false)//�ߺ��� �������� ���� ��� -> ���� �߰�
            {
                //Debug.Log("����");
                emptySlot.SetInvenItem(item);
                item.InvenItemNum += store.BuyNum;
                emptySlot.transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";
            }
        }

        else if (item.itemType == "Middle")
        {
            var emptySlot = Middleslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//��� �����߿� �������� �� ������ emptyslot�̶�� ���� �Ҵ�.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Middleslots[i].item == item)//�ߺ��� ���
                {
                    Debug.Log(i + "��° ���� �������� ��ħ");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;
                    Middleslots[i].transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";

                    break;
                }

                if (Middleslots[i].item != item)//�ߺ��� �ƴ� ���
                {
                    if (emptySlot != null)//���� ������ ���� ���
                    {
                        isSame = false;
                    }
                    else
                    {
                        Debug.Log("���� ����");
                    }
                }
            }

            if (isSame == false)//�ߺ��� �������� ���� ��� -> ���� �߰�
            {
                //Debug.Log("����");
                emptySlot.SetInvenItem(item);
                item.InvenItemNum += store.BuyNum;
                emptySlot.transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";
            }
        }

        else if (item.itemType == "Top")
        {
            var emptySlot = Topslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//��� �����߿� �������� �� ������ emptyslot�̶�� ���� �Ҵ�.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Topslots[i].item == item)//�ߺ��� ���
                {
                    Debug.Log(i + "��° ���� �������� ��ħ");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;
                    Topslots[i].transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";

                    break;
                }

                if (Topslots[i].item != item)//�ߺ��� �ƴ� ���
                {
                    if (emptySlot != null)//���� ������ ���� ���
                    {
                        isSame = false;
                    }
                    else
                    {
                        Debug.Log("���� ����");
                    }
                }
            }

            if (isSame == false)//�ߺ��� �������� ���� ��� -> ���� �߰�
            {
                //Debug.Log("����");
                emptySlot.SetInvenItem(item);
                item.InvenItemNum += store.BuyNum;
                emptySlot.transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString() + "�� ����";
            }
        }

    }

    /*public void AllBuyItem()//�ϰ� ����
    {
        Debug.Log("����");
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });//��� �����߿� �������� �� ������ emptyslot�̶�� ���� �Ҵ�.
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            for (int j = 0; j < storeSlotRoot.childCount; j++)
            {
                if (slots[i].item != storeSlots[i].item)//�ߺ��� �ƴ� ���
                {
                    Debug.Log("�ߺ�����");
                    //Debug.Log(storeSlots[i].item.name);
                    if (emptySlot != null)//���� ������ ���� ���
                    {
                        Debug.Log(storeSlots[i].item.name);
                        emptySlot.SetInvenItem(storeSlots[i].item);
                        //storeSlots[i].item = allItem;
                        isAllsame = false;
                    }
                    else
                    {
                        Debug.Log("���� ����");
                    }
                }

                if (slots[i].item == storeSlots[i].item)
                {
                    Debug.Log("�ߺ�����");
                    isAllsame = true;
                    slots[i].item.InvenItemNum += store.AllBuyNum;
                    slots[i].transform.GetChild(3).GetComponent<Text>().text = slots[i].item.InvenItemNum.ToString();

                    break;
                }
            }
        }

        if (isAllsame == false)//�ߺ��� �������� ���� ��� -> ���� �߰�
        {
            emptySlot.SetInvenItem(allItem);
            //allItem.InvenItemNum = 0;
            //allItem.InvenItemNum += store.AllBuyNum;
            //emptySlot.transform.GetChild(3).GetComponent<Text>().text = allItem.InvenItemNum.ToString();
        }
    }*/
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
