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

    //public bool isNew;//새로운 아이템이 들어온 경우 true
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
        store.onStoreSlotClick += BuyItem;//구매하기 버튼 누르면 다음 함수 실행.
        //store.onAllStoreSlotClick += AllBuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
        //var imsiSlot = imsiSlots[0];
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            if (slots[i].item == item)//중복인 경우
            {
                Debug.Log(i + "번째 슬롯 아이템이 겹침");
                isSame = true;
                item.InvenItemNum += store.BuyNum;
                slots[i].transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();

                break;
            }

            if (slots[i].item != item)//중복이 아닌 경우
            {
                if (emptySlot != null)//슬롯 꽉차지 않은 경우
                {
                    isSame = false;
                }
                else
                {
                    Debug.Log("슬롯 꽉참");
                }
            }
        }

        if (isSame == false)//중복인 아이템이 없는 경우 -> 슬롯 추가
        {
            Debug.Log("실행");
            emptySlot.SetInvenItem(item);
            item.InvenItemNum += store.BuyNum;
            emptySlot.transform.GetChild(3).GetComponent<Text>().text = item.InvenItemNum.ToString();
        }
    }

    public void AllBuyItem()//일괄 구매
    {
        Debug.Log("시작");
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            for (int j = 0; j < storeSlotRoot.childCount; j++)
            {
                if (slots[i].item != storeslots[i].item)//중복이 아닌 경우
                {
                    Debug.Log("중복없음");
                    //Debug.Log(storeslots[i].item.name);
                    if (emptySlot != null)//슬롯 꽉차지 않은 경우
                    {
                        Debug.Log(storeslots[i].item.name);
                        emptySlot.SetInvenItem(storeslots[i].item);
                        //storeslots[i].item = allItem;
                        isAllsame = false;
                    }
                    else
                    {
                        Debug.Log("슬롯 꽉참");
                    }
                }

                if (slots[i].item == storeslots[i].item)
                {
                    Debug.Log("중복있음");
                    isAllsame = true;
                    slots[i].item.InvenItemNum += store.AllBuyNum;
                    slots[i].transform.GetChild(3).GetComponent<Text>().text = slots[i].item.InvenItemNum.ToString();

                    break;
                }
            }
        }

        /*if (isAllsame == false)//중복인 아이템이 없는 경우 -> 슬롯 추가
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
