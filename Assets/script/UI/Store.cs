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
    public GameObject DetailItemNum;

    public Button MinusBtn;
    public Button PlusBtn;

    public int BuyNum;

    public Slot slot;

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        int slotCount = slotRoot.childCount;

        for (int i = 0; i < slotCount; i++)
        {
            slot = slotRoot.GetChild(i).GetComponent<Slot>();

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
    public void OnClickSlot(Slot clickedSlot)
    {
        BuyNum = 1;
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        DetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        slot = clickedSlot;

       

        /*if (onStoreSlotClick != null)
        {
            onStoreSlotClick(slot.item);
        }

        slot.item.itemCount -= 1;
        fd.Money -= slot.item.itemPrice;
        */
    }

    public void PlusItem()
    {
        BuyNum += 1;
       
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
    }
    public void MinusItem()
    {
        BuyNum -= 1;
        
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
    }

    public void BuyItem()
    {
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(slot.item);
        }

        slot.item.itemCount -= 1 * BuyNum;
        fd.Money -= slot.item.itemPrice * BuyNum;
        
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

    public void Update()
    {

        if (BuyNum == 0)
        {
            MinusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            MinusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        if (BuyNum * slot.item.itemPrice >= fd.Money)
        {
            Debug.Log("잔돈 없음. 더이상 추가 불가");
            PlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }
    }

}
