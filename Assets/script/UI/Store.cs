using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Transform slotRoot;
    public ItemBuffer itemBuffer;
    private List<Slot> slots;
    public FirstDaySetting fd;

    public GameObject ItemDetail;
    public UnityEngine.UI.Image image;
    public GameObject DetailPrice;
    public GameObject DetailItemName;

    public GameObject BuyBtn;

    public int BuyNum = 1;

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        int slotCount = slotRoot.childCount;

        for (int i = 0; i < slotCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else//아이템이 없는 경우 클릭 불가하게 만듦.
            {
                slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }


            slots.Add(slot);
        }
    }
    public void OnClickSlot(Slot slot)
    {
        
        ItemDetail.gameObject.SetActive(true);
        image.sprite = slot.item.sprite;
        DetailItemName.GetComponent<Text>().text = slot.item.name;
        DetailPrice.GetComponent<Text>().text = BuyNum + " / " + slot.item.itemPrice.ToString() + "$";

        /*if (onStoreSlotClick != null)
        {
            onStoreSlotClick(slot.item);
        }

        slot.item.itemCount -= 1;
        fd.Money -= slot.item.itemPrice;
        */
    }

    public void PlusItem(Slot slot)
    {
        Debug.Log(slot.item.name);
        BuyNum += 1;
        DetailPrice.GetComponent<Text>().text = BuyNum + " / " + slot.item.itemPrice.ToString() + "$";
    }
    public void MinusItem(Slot slot)
    {
        Debug.Log(slot.item.name);
        BuyNum -= 1;
        DetailPrice.GetComponent<Text>().text = BuyNum + " / " + slot.item.itemPrice.ToString() + "$";
    }
    
    public void Close()
    {
        this.gameObject.SetActive(false);
        ItemDetail.gameObject.SetActive(false);
    }
    public void CloseDetail()
    {
        ItemDetail.gameObject.SetActive(false);
    }

}
