using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Transform slotRoot;
    public Transform MiddleslotRoot;

    public ItemBuffer itemBuffer;
    public ItemBuffer MiddleitemBuffer;

    private List<Slot> slots;
    private List<Slot> Middleslots;

    public FirstDaySetting fd;
    public GameObject inven;

    public GameObject ItemDetail;
    public UnityEngine.UI.Image image;
    public GameObject DetailPrice;
    public GameObject DetailItemName;
    public GameObject DetailItemNum;

    public Slider slider;
    public Slider AllBuyslider;

    public Button MinusBtn;
    public Button PlusBtn;

    public Button BuyAllBtn;
    public Button AllBuyMinusBtn;
    public Button AllBuyPlusBtn;

    public int BuyNum;
    public int AllBuyNum;
    int slotItemPrice = 0;

    public Slot slot;
    public Slot Middleslot;

    public GameObject BuyAll;
    public GameObject BuyAllPrice;
    public GameObject BuyAllNum;

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수
    //public System.Action<ItemProperty> onAllStoreSlotClick;//델리게이트 변수

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        int slotCount = slotRoot.childCount;
        int MiddleslotCount = MiddleslotRoot.childCount;


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

        for (int j = 0; j < MiddleslotCount; j++)
        {
            Middleslot = MiddleslotRoot.GetChild(j).GetComponent<Slot>();

            if (j < MiddleitemBuffer.items.Count)
            {
                Middleslot.SetItem(MiddleitemBuffer.items[j]);
            }
            else//아이템이 없는 경우 클릭 불가하게 만듦.
            {
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }


            slots.Add(slot);
        }
    }
    public void OnClickSlot(Slot clickedSlot)
    {
        slider.value = 0;
        BuyNum = 0;
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        DetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        slot = clickedSlot;
        slider.maxValue = clickedSlot.item.itemCount;
      
    }

    public void PlusItem()
    {
        BuyNum += 1;
       
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        slider.value += 1;
    }
    public void MinusItem()
    {
        BuyNum -= 1;
        
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        slider.value -= 1;
    }

    public void PlusAllItem()
    {
        AllBuyNum += 1;

        BuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value += 1;
    }
    public void MinusAllItem()
    {
        AllBuyNum -= 1;

        BuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value -= 1;
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

    public void BuyAllItemUI()
    {
        AllBuyNum = 0;
        slotItemPrice = 0;
        BuyAll.gameObject.SetActive(true);
        for (int i = 0; i < slots.Count; i++)
        {
            slotItemPrice += slots[i].item.itemPrice;
        }
        //Debug.Log(slotItemPrice);
        BuyAllPrice.GetComponent<Text>().text = " / " + slotItemPrice.ToString() + "$";
    }
    public void BuyAllItem()
    {
        inven.GetComponent<Inventory>().AllBuyItem();
        if (fd.Money >= slotItemPrice * AllBuyNum)
        {
            fd.Money -= slotItemPrice * AllBuyNum;
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].item.itemCount -= 1 * AllBuyNum;
            }
        }
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
    public void CloseBuyAll()
    {
        BuyAll.gameObject.SetActive(false);
    }

    public void Update()
    {

        if (BuyNum <= 0)
        {
            MinusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            MinusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        /*if ((BuyNum + 1) * slot.item.itemPrice > fd.Money)
        {
            Debug.Log("잔돈 없음. 더이상 추가 불가");
            PlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }*/

        if (fd.Money < slotItemPrice * AllBuyNum)
        {
            Debug.Log("잔액 부족");
            BuyAllBtn.gameObject.GetComponent<Button>().interactable = false;
        }
    }

}
