using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Transform slotRoot;
    public Transform MiddleslotRoot;
    public Transform TopslotRoot;

    public ItemBuffer itemBuffer;
    public ItemBuffer MiddleitemBuffer;
    public ItemBuffer TopitemBuffer;

    private List<Slot> slots;
    private List<Slot> Middleslots;
    private List<Slot> Topslots;

    public FirstDaySetting fd;
    public GameObject inven;

    public GameObject ItemDetail;
    public GameObject MiddleItemDetail;
    public GameObject TopItemDetail;

    public UnityEngine.UI.Image image;
    public GameObject DetailPrice;
    public GameObject DetailItemName;
    public GameObject DetailItemNum;

    public UnityEngine.UI.Image Middleimage;
    public GameObject MiddleDetailPrice;
    public GameObject MiddleDetailItemName;
    public GameObject MiddleDetailItemNum;

    public UnityEngine.UI.Image Topimage;
    public GameObject TopDetailPrice;
    public GameObject TopDetailItemName;
    public GameObject TopDetailItemNum;

    public Slider BaseSlider;
    public Slider MiddleSlider;
    public Slider TopSlider;

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
    public Slot Topslot;


    public GameObject BuyAll;
    public GameObject BuyAllPrice;
    public GameObject BuyAllNum;

    public Text alertText;

    public System.Action<ItemProperty> onStoreSlotClick;//��������Ʈ ����
    //public System.Action<ItemProperty> onAllStoreSlotClick;//��������Ʈ ����

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<Slot>();
        Middleslots = new List<Slot>();
        Topslots = new List<Slot>();

        int slotCount = slotRoot.childCount;
        int MiddleslotCount = MiddleslotRoot.childCount;
        int TopslotCount = TopslotRoot.childCount;


        for (int i = 0; i < slotCount; i++)
        {
            slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else // �������� ���� ��� Ŭ�� �Ұ��ϰ� ����.
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
            else // �������� ���� ��� Ŭ�� �Ұ��ϰ� ����.
            {
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }


            Middleslots.Add(Middleslot);
        }

        for (int k = 0; k < TopslotCount; k++)
        {
            Topslot = TopslotRoot.GetChild(k).GetComponent<Slot>();

            if (k < TopitemBuffer.items.Count)
            {
                Topslot.SetItem(TopitemBuffer.items[k]);
            }
            else // �������� ���� ��� Ŭ�� �Ұ��ϰ� ����.
            {
                Debug.Log("��");
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            Topslots.Add(Topslot);
        }
    }
    public void OnClickSlot(Slot clickedSlot)
    {
        BaseSlider.value = 0;
        BuyNum = 0;
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        DetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        slot = clickedSlot;
        BaseSlider.maxValue = clickedSlot.item.itemCount;
      
    }

    public void OnClickMiddleSlot(Slot clickedSlot)
    {
        MiddleSlider.value = 0;
        BuyNum = 0;
        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleItemDetail.gameObject.SetActive(true);
        Middleimage.sprite = clickedSlot.item.sprite;
        MiddleDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        MiddleDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        Middleslot = clickedSlot;
        MiddleSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void OnClickTopSlot(Slot clickedSlot)
    {
        TopSlider.value = 0;
        BuyNum = 0;
        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopItemDetail.gameObject.SetActive(true);
        Topimage.sprite = clickedSlot.item.sprite;
        TopDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        TopDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        Topslot = clickedSlot;
        TopSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void PlusItem()
    {
        BuyNum += 1;
       
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        BaseSlider.value += 1;
    }
    public void MinusItem()
    {
        BuyNum -= 1;
        
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        BaseSlider.value -= 1;
    }

    public void PlusMiddleItem()
    {
        BuyNum += 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleSlider.value += 1;
    }
    public void MinusMiddleItem()
    {
        BuyNum -= 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleSlider.value -= 1;
    }

    public void PlusTopItem()
    {
        BuyNum += 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopSlider.value += 1;
    }
    public void MinusTopItem()
    {
        BuyNum -= 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopSlider.value -= 1;
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
        alertText.GetComponent<Text>().text = slot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyMiddleItem()
    {
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Middleslot.item);
        }

        Middleslot.item.itemCount -= 1 * BuyNum;
        fd.Money -= Middleslot.item.itemPrice * BuyNum;
        alertText.GetComponent<Text>().text = Middleslot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyTopItem()
    {
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Topslot.item);
        }

        Topslot.item.itemCount -= 1 * BuyNum;
        fd.Money -= Topslot.item.itemPrice * BuyNum;
        alertText.GetComponent<Text>().text = Topslot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
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
        BuyAllPrice.GetComponent<Text>().text = " / " + slotItemPrice.ToString() + "$";
    }
   /* public void BuyAllItem()
    {
        if (fd.Money >= slotItemPrice * AllBuyNum)
        {
            fd.Money -= slotItemPrice * AllBuyNum;
            for (int j = 0; j < slotRoot.childCount; j++)
            {
                slots[j].item.itemCount -= 1 * AllBuyNum;
            }
        }
        inven.GetComponent<Inventory>().AllBuyItem();
    }*/
    
    public void Close()
    {
        this.gameObject.SetActive(false);
        ItemDetail.gameObject.SetActive(false);
    }
    public void CloseDetail()
    {
        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }
    public void CloseBuyAll()
    {
        BuyAll.gameObject.SetActive(false);
    }

    public IEnumerator FadeTextToZero()  // ���İ� 1���� 0���� ��ȯ
    {
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, 1);
        while (alertText.color.a > 0.0f)
        {
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alertText.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
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

        if ((BuyNum + 1) * slot.item.itemPrice > fd.Money)
        {
            Debug.Log("�ܵ� ����. ���̻� �߰� �Ұ�");
            PlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        if (fd.Money < slotItemPrice * AllBuyNum)
        {
            Debug.Log("�ܾ� ����");
            BuyAllBtn.gameObject.GetComponent<Button>().interactable = false;
            alertText.GetComponent<Text>().text = "�ܾ��� �����մϴ�.";
            StartCoroutine(FadeTextToZero());
        }
    }

}
