using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform slotRoot;
    public Store store;

    private List<Slot> slots;


    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        int slotCount = slotRoot.childCount;

        for (int i = 0; i < slotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);

        }

        store.onStoreSlotClick += BuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });

        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //Debug.Log(slots[i].item.name);
            //Debug.Log(item.name);

            if (slots[i].item != null)
            {
                Debug.Log("�ϳ��� ����");
                if (store.BuyNum > 1)
                {
                    Debug.Log("�ΰ� �̻� ��� ���");
                    Debug.Log(store.BuyNum);
                    emptySlot.SetInvenItem(item);
                    item.InvenItemNum += store.BuyNum;
                    Debug.Log(item.InvenItemNum);
                    // slotRoot.GetChild(i).GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();


                }
                else
                {
                    Debug.Log(store.BuyNum);
                    emptySlot.SetInvenItem(item);
                }
            }
            /*if (slots[i].item != item)//�������� ��ġ�� �ʴ� ���
            {
                if (emptySlot != null)//������ �������� ���� ���
                {
                    Debug.Log("�ߺ��ƴϴ�");

                    emptySlot.SetInvenItem(item);
                  
                }

                else
                {
                    Debug.Log("���� ����");                
                }
            }// �ߺ��� �ƴ� ��쿡 ���ο� ���� ����

            else 
            {
                Debug.Log("�ߺ��̴�");
                item.InvenItemNum += store.BuyNum;
                slotRoot.GetChild(i).GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();
            }//������ �����۰� ���� �κ��� �ִ� �������� �ߺ��� ��쿡 ���� ������ �ƴ� ī��Ʈ ������ �ٲ�� ��.*/
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
