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
                Debug.Log("하나라도 있음");
                if (store.BuyNum > 1)
                {
                    Debug.Log("두개 이상 사는 경우");
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
            /*if (slots[i].item != item)//아이템이 겹치지 않는 경우
            {
                if (emptySlot != null)//슬롯이 꽉차있지 않은 경우
                {
                    Debug.Log("중복아니다");

                    emptySlot.SetInvenItem(item);
                  
                }

                else
                {
                    Debug.Log("슬롯 꽉참");                
                }
            }// 중복이 아닌 경우에 새로운 슬롯 증가

            else 
            {
                Debug.Log("중복이다");
                item.InvenItemNum += store.BuyNum;
                slotRoot.GetChild(i).GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();
            }//구매한 아이템과 기존 인벤에 있는 아이템이 중복인 경우에 슬롯 증가가 아닌 카운트 증가로 바꿔야 함.*/
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
