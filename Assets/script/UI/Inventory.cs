using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform slotRoot;
    public Transform storeSlotRoot;
    public Store store;

    private List<Slot> slots;
    private List<Slot> storeslots;

    //public bool isNew;//���ο� �������� ���� ��� true
    public bool isSame;
    public bool isAllsame;

    ItemProperty allItem;
    // Start is called before the first frame update
    void Start()
    {
        isSame = false;
        isAllsame = false;

        slots = new List<Slot>();
        storeslots = new List<Slot>();

        int slotCount = slotRoot.childCount;

        for (int i = 0; i < slotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }

        for (int i = 0; i < storeSlotRoot.childCount; i++)
        {
            var Storeslot = storeSlotRoot.GetChild(i).GetComponent<Slot>();

            storeslots.Add(Storeslot);
        }
        store.onStoreSlotClick += BuyItem;//�����ϱ� ��ư ������ ���� �Լ� ����.
        //store.onAllStoreSlotClick += AllBuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });//��� �����߿� �������� �� ������ emptyslot�̶�� ���� �Ҵ�.
        //var imsiSlot = imsiSlots[0];
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            if (slots[i].item == item)//�ߺ��� ���
            {
                Debug.Log(i + "��° ���� �������� ��ħ");
                isSame = true;
                item.InvenItemNum += store.BuyNum;
                slots[i].transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();

                break;
            }

            if (slots[i].item != item)//�ߺ��� �ƴ� ���
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
            Debug.Log("����");
            emptySlot.SetInvenItem(item);
            item.InvenItemNum += store.BuyNum;
            emptySlot.transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();
        }
    }

    public void AllBuyItem()//�ϰ� ����
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
                if (slots[i].item != storeslots[i].item)//�ߺ��� �ƴ� ���
                {
                    Debug.Log("�ߺ�����");
                    //Debug.Log(storeslots[i].item.name);
                    if (emptySlot != null)//���� ������ ���� ���
                    {
                        Debug.Log(storeslots[i].item.name);
                        emptySlot.SetInvenItem(storeslots[i].item);
                        //storeslots[i].item = allItem;
                        isAllsame = false;
                    }
                    else
                    {
                        Debug.Log("���� ����");
                    }
                }

                if (slots[i].item == storeslots[i].item)
                {
                    Debug.Log("�ߺ�����");
                    isAllsame = true;
                    slots[i].item.InvenItemNum += store.AllBuyNum;
                    slots[i].transform.GetChild(3).GetComponent<Text>().text = slots[i].item.InvenItemNum.ToString();

                    break;
                }
            }
        }

        /*if (isAllsame == false)//�ߺ��� �������� ���� ��� -> ���� �߰�
        {
            emptySlot.SetInvenItem(allItem);
            //allItem.InvenItemNum = 0;
            //allItem.InvenItemNum += store.AllBuyNum;
            //emptySlot.transform.GetChild(3).GetComponent<Text>().text = allItem.InvenItemNum.ToString();
        }*/
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
