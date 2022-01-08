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
                 Debug.Log("중복이다");


             }//구매한 아이템과 기존 인벤에 있는 아이템이 중복인 경우에 슬롯 증가가 아닌 카운트 증가로 바꿔야 함.
             else if(slots[i].item.name != item.name)
             {
                 Debug.Log("중복아니다");
                 if (emptySlot != null)
                 {
                     emptySlot.SetInvenItem(item);
                 }
             }// 중복이 아닌 경우에 새로운 슬롯 증가
            */
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
