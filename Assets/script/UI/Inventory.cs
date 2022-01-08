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
            Debug.Log(slots[i].item.name);
            Debug.Log(item.name);
            if (emptySlot != null)
            {
                emptySlot.SetInvenItem(item);
            }
            /* if (slots[i].item.name == item.name)
             {
                 Debug.Log("�ߺ��̴�");


             }//������ �����۰� ���� �κ��� �ִ� �������� �ߺ��� ��쿡 ���� ������ �ƴ� ī��Ʈ ������ �ٲ�� ��.
             else if(slots[i].item.name != item.name)
             {
                 Debug.Log("�ߺ��ƴϴ�");
                 if (emptySlot != null)
                 {
                     emptySlot.SetInvenItem(item);
                 }
             }// �ߺ��� �ƴ� ��쿡 ���ο� ���� ����
            */
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
