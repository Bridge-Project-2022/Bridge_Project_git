using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Store : MonoBehaviour
{
    public Transform slotRoot;
    public Transform MiddleslotRoot;
    public Transform TopslotRoot;

    ItemBuffer itemBuffer;
    ItemBuffer MiddleitemBuffer;
    ItemBuffer TopitemBuffer;

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
    public TextMeshProUGUI DetailItemExplanation;

    public UnityEngine.UI.Image Middleimage;
    public GameObject MiddleDetailPrice;
    public GameObject MiddleDetailItemName;
    public GameObject MiddleDetailItemNum;
    public TextMeshProUGUI MiddleDetailItemExplanation;

    public UnityEngine.UI.Image Topimage;
    public GameObject TopDetailPrice;
    public GameObject TopDetailItemName;
    public GameObject TopDetailItemNum;
    public TextMeshProUGUI TopDetailItemExplanation;

    /*public Slider BaseSlider;
    public Slider MiddleSlider;
    public Slider TopSlider;

    public Slider AllBuyslider;*/

    public Button BaseMinusBtn;
    public Button BasePlusBtn;
    public Button MiddleMinusBtn;
    public Button MiddlePlusBtn;
    public Button TopMinusBtn;
    public Button TopPlusBtn;


    public Button BaseBuyAllBtn;
    public Button BaseAllBuyMinusBtn;
    public Button BaseAllBuyPlusBtn;

    public Button MiddleBuyAllBtn;
    public Button MiddleAllBuyMinusBtn;
    public Button MiddleAllBuyPlusBtn;

    public Button TopBuyAllBtn;
    public Button TopAllBuyMinusBtn;
    public Button TopAllBuyPlusBtn;

    public int BuyNum = 1;
    public int AllBuyNum = 1;
    int slotItemPrice = 0;
    int MiddleslotItemPrice = 0;
    int TopslotItemPrice = 0;

    public Slot slot;
    public Slot Middleslot;
    public Slot Topslot;


    public GameObject BaseBuyAll;
    public GameObject BaseBuyAllPrice;
    public GameObject BaseBuyAllNum;

    public GameObject MiddleBuyAll;
    public GameObject MiddleBuyAllPrice;
    public GameObject MiddleBuyAllNum;

    public GameObject TopBuyAll;
    public GameObject TopBuyAllPrice;
    public GameObject TopBuyAllNum;

    public GameObject BaseBuyBtn;
    public GameObject MiddleBuyBtn;
    public GameObject TopBuyBtn;

    public Text alertText;

    public System.Action<ItemProperty> onStoreSlotClick;//��������Ʈ ����
    //public System.Action<ItemProperty> onAllStoreSlotClick;//��������Ʈ ����

    public ItemProperty[] BaseItemList = new ItemProperty[10];
    public ItemProperty[] MiddleItemList = new ItemProperty[10];
    public ItemProperty[] TopItemList = new ItemProperty[10];

    int BaseAllPrice = 0;
    int MiddleAllPrice = 0;
    int TopAllPrice = 0;

    int ItemCurPrice = 0;

    public int maxItemNum = 0;

    public void Start()
    {

        itemBuffer = GameObject.Find("ItemBuffer").transform.GetChild(0).gameObject.GetComponent<ItemBuffer>();
        MiddleitemBuffer = GameObject.Find("ItemBuffer").transform.GetChild(1).gameObject.GetComponent<ItemBuffer>();
        TopitemBuffer = GameObject.Find("ItemBuffer").transform.GetChild(2).gameObject.GetComponent<ItemBuffer>();

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
                slot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (itemBuffer.items[i].isNew == true)
                {
                    GameObject.Find("Canvas").transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(i).GetChild(5).gameObject.SetActive(true);
                }
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
            Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
            if (j < MiddleitemBuffer.items.Count)
            {
                Middleslot.SetItem(MiddleitemBuffer.items[j]);

                if (MiddleitemBuffer.items[j].isNew == true)
                {
                    GameObject.Find("Canvas").transform.GetChild(8).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(j).GetChild(5).gameObject.SetActive(true);
                }
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
            Topslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
            if (k < TopitemBuffer.items.Count)
            {
                Topslot.SetItem(TopitemBuffer.items[k]);

                if (TopitemBuffer.items[k].isNew == true)
                {
                    GameObject.Find("Canvas").transform.GetChild(8).GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(k).GetChild(5).gameObject.SetActive(true);
                }
            }
            else // �������� ���� ��� Ŭ�� �Ұ��ϰ� ����.
            {
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
            Topslots.Add(Topslot);
        }
    }
    public void OnClickSlot(Slot clickedSlot)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        //BaseSlider.value = 0;
        BuyNum = 1;
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        DetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        DetailItemExplanation.text = clickedSlot.item.itemExplanation;
        ItemCurPrice = clickedSlot.item.itemPrice;
        maxItemNum = clickedSlot.item.itemCount;
        slot = clickedSlot;
        //BaseSlider.maxValue = clickedSlot.item.itemCount;
      
    }

    public void OnClickMiddleSlot(Slot clickedSlot)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        //MiddleSlider.value = 0;
        BuyNum = 1;
        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleItemDetail.gameObject.SetActive(true);
        Middleimage.sprite = clickedSlot.item.sprite;
        MiddleDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        MiddleDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        MiddleDetailItemExplanation.text = clickedSlot.item.itemExplanation;
        ItemCurPrice = clickedSlot.item.itemPrice;
        maxItemNum = clickedSlot.item.itemCount;
        Middleslot = clickedSlot;
        //MiddleSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void OnClickTopSlot(Slot clickedSlot)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        //TopSlider.value = 0;
        BuyNum = 1;
        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopItemDetail.gameObject.SetActive(true);
        Topimage.sprite = clickedSlot.item.sprite;
        TopDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        TopDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        TopDetailItemExplanation.text = clickedSlot.item.itemExplanation;
        ItemCurPrice = clickedSlot.item.itemPrice;
        maxItemNum = clickedSlot.item.itemCount;
        Topslot = clickedSlot;
        //TopSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void PlusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;
       
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //BaseSlider.value += 1;

    }
    public void MinusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;
        
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //BaseSlider.value -= 1;
    }

    public void PlusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //MiddleSlider.value += 1;
    }
    public void MinusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";

        //MiddleSlider.value -= 1;
    }

    public void PlusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //TopSlider.value += 1;
    }
    public void MinusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        DetailPrice.GetComponent<Text>().text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //TopSlider.value -= 1;
    }

    public void PlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        slotItemPrice = BaseAllPrice * AllBuyNum;

        BaseBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        BaseBuyAllPrice.GetComponent<Text>().text = " / " +  slotItemPrice.ToString() + "$";

        //AllBuyslider.value += 1;
    }

    public void MiddlePlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        MiddleslotItemPrice = MiddleAllPrice * AllBuyNum;

        MiddleBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        MiddleBuyAllPrice.GetComponent<Text>().text = " / " + MiddleslotItemPrice.ToString() + "$";
        //AllBuyslider.value += 1;
    }

    public void TopPlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        TopslotItemPrice = TopAllPrice * AllBuyNum;

        TopBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        TopBuyAllPrice.GetComponent<Text>().text = " / " + TopslotItemPrice.ToString() + "$";
        //AllBuyslider.value += 1;
    }
    public void MinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;

        slotItemPrice = BaseAllPrice * AllBuyNum;


        BaseBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        BaseBuyAllPrice.GetComponent<Text>().text = " / " + slotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void MiddleMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;

        MiddleslotItemPrice = MiddleAllPrice * AllBuyNum;

        MiddleBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        MiddleBuyAllPrice.GetComponent<Text>().text = " / " + MiddleslotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void TopMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;

        TopslotItemPrice = TopAllPrice * AllBuyNum;

        TopBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        TopBuyAllPrice.GetComponent<Text>().text = " / " + TopslotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void BuyItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(slot.item);
        }

        slot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= slot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        alertText.GetComponent<Text>().text = slot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Middleslot.item);
        }

        Middleslot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= Middleslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        alertText.GetComponent<Text>().text = Middleslot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Topslot.item);
        }

        Topslot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= Topslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        alertText.GetComponent<Text>().text = Topslot.item.name + " ��� " + BuyNum + "�� ���� �Ϸ��߽��ϴ�.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (slots[i].item.itemCount == 0)
            {
                continue;
            }

            BaseItemList[i] = slots[i].item;
        }
        AllBuyNum = 1;
        BaseBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        slotItemPrice = 0;
        BaseBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item.itemCount == 0)
            {
                continue;
            }
            else
                slotItemPrice += slots[i].item.itemPrice;
        }
        BaseAllPrice = slotItemPrice;
        BaseBuyAllPrice.GetComponent<Text>().text = " / " + slotItemPrice.ToString() + "$";
    }

    public void MiddleBuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (Middleslots[i].item.itemCount == 0)
            {
                continue;
            }

            MiddleItemList[i] = Middleslots[i].item;
        }
        AllBuyNum = 1;
        MiddleBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        MiddleslotItemPrice = 0;
        MiddleBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < Middleslots.Count; i++)
        {
            if (Middleslots[i].item.itemCount == 0)
            {
                continue;
            }
            else
                MiddleslotItemPrice += Middleslots[i].item.itemPrice;
        }
        MiddleAllPrice = MiddleslotItemPrice;
        MiddleBuyAllPrice.GetComponent<Text>().text = " / " + MiddleslotItemPrice.ToString() + "$";
    }

    public void TopBuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (Topslots[i].item.itemCount == 0)
            {
                continue;
            }

            TopItemList[i] = Topslots[i].item;
        }
        AllBuyNum = 1;
        TopBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        TopslotItemPrice = 0;
        TopBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < Topslots.Count; i++)
        {
            if (Topslots[i].item.itemCount == 0)
            {
                continue;
            }
            else
                TopslotItemPrice += Topslots[i].item.itemPrice;
        }
        TopAllPrice = TopslotItemPrice;
        TopBuyAllPrice.GetComponent<Text>().text = " / " + TopslotItemPrice.ToString() + "$";
    }

    public void BaseBuyAllItem()
    {
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (BaseItemList[i] == null)
                continue;

            inven.GetComponent<Inventory>().BuyItem(BaseItemList[i]);

            BaseItemList[i].itemCount -= AllBuyNum;
            BaseItemList[i].InvenItemNum += AllBuyNum;
            //Debug.Log(BaseItemList[i].InvenItemNum);
        }
        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * AllBuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
    }
    public void MiddleBuyAllItem()
    {
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (MiddleItemList[i] == null)
                break;

            inven.GetComponent<Inventory>().BuyItem(MiddleItemList[i]);
            MiddleItemList[i].itemCount -= 1 * AllBuyNum;
            MiddleItemList[i].InvenItemNum += AllBuyNum;
        }

        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * AllBuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
    }

    public void TopBuyAllItem()
    {
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (TopItemList[i] == null)
                break;

            inven.GetComponent<Inventory>().BuyItem(TopItemList[i]);
            TopItemList[i].itemCount -= 1 * AllBuyNum;
            TopItemList[i].InvenItemNum += AllBuyNum;
        }

        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * AllBuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
    }
    public void Close()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        this.gameObject.SetActive(false);
        ItemDetail.gameObject.SetActive(false);
    }
    public void CloseDetail()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }
    public void CloseBuyAll()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BaseBuyAll.gameObject.SetActive(false);
        MiddleBuyAll.gameObject.SetActive(false);
        TopBuyAll.gameObject.SetActive(false);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        inven.gameObject.SetActive(false);
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

        if (BuyNum <= 1)
        {
            BaseMinusBtn.gameObject.GetComponent<Button>().interactable = false;
            MiddleMinusBtn.gameObject.GetComponent<Button>().interactable = false;
            TopMinusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            BaseMinusBtn.gameObject.GetComponent<Button>().interactable = true;
            MiddleMinusBtn.gameObject.GetComponent<Button>().interactable = true;
            TopMinusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        if ((BuyNum + 1) * slot.item.itemPrice > fd.Money)
        {
            Debug.Log("�ܵ� ����. ���̻� �߰� �Ұ�");
            BasePlusBtn.gameObject.GetComponent<Button>().interactable = false;
            MiddlePlusBtn.gameObject.GetComponent<Button>().interactable = false;
            TopPlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            BasePlusBtn.gameObject.GetComponent<Button>().interactable = true;
            MiddlePlusBtn.gameObject.GetComponent<Button>().interactable = true;
            TopPlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        if (fd.Money < slotItemPrice)
        {
            Debug.Log("�ܾ� ����");
            GameObject.Find("Store").transform.GetChild(0).GetChild(0).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Store").transform.GetChild(0).GetChild(1).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Store").transform.GetChild(0).GetChild(2).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;

            alertText.GetComponent<Text>().text = "�ܾ��� �����մϴ�.";
            StartCoroutine(FadeTextToZero());
        }
        else
        {
            GameObject.Find("Store").transform.GetChild(0).GetChild(0).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
            GameObject.Find("Store").transform.GetChild(0).GetChild(1).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
            GameObject.Find("Store").transform.GetChild(0).GetChild(2).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }

        if (BuyNum.ToString() == maxItemNum.ToString())
        {
            BasePlusBtn.gameObject.GetComponent<Button>().interactable = false;
            MiddlePlusBtn.gameObject.GetComponent<Button>().interactable = false;
            TopPlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            BasePlusBtn.gameObject.GetComponent<Button>().interactable = true;
            MiddlePlusBtn.gameObject.GetComponent<Button>().interactable = true;
            TopPlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }
    }


     IEnumerator Count(float target, float current)

    {
        float duration = 0.5f; // ī���ÿ� �ɸ��� �ð� ����. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            fd.GetComponent<Text>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        fd.GetComponent<Text>().text = ((int)current).ToString();

    }


}
