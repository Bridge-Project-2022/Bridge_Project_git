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

    public GameObject IB;
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
    public TextMeshProUGUI DetailPrice;
    public TextMeshProUGUI DetailItemName;
    public TextMeshProUGUI DetailItemNum;
    public TextMeshProUGUI DetailItemExplanation;

    public UnityEngine.UI.Image Middleimage;
    public TextMeshProUGUI MiddleDetailPrice;
    public TextMeshProUGUI MiddleDetailItemName;
    public TextMeshProUGUI MiddleDetailItemNum;
    public TextMeshProUGUI MiddleDetailItemExplanation;

    public UnityEngine.UI.Image Topimage;
    public TextMeshProUGUI TopDetailPrice;
    public TextMeshProUGUI TopDetailItemName;
    public TextMeshProUGUI TopDetailItemNum;
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
    //public int AllBuyNum = 1;
    int slotItemPrice = 0;
    int MiddleslotItemPrice = 0;
    int TopslotItemPrice = 0;

    public Slot slot;
    public Slot Middleslot;
    public Slot Topslot;


    public GameObject BaseBuyAll;
    public TextMeshProUGUI BaseBuyAllPrice;
    public TextMeshProUGUI BaseBuyAllNum;

    public GameObject MiddleBuyAll;
    public TextMeshProUGUI MiddleBuyAllPrice;
    public TextMeshProUGUI MiddleBuyAllNum;

    public GameObject TopBuyAll;
    public TextMeshProUGUI TopBuyAllPrice;
    public TextMeshProUGUI TopBuyAllNum;

    public GameObject BaseBuyBtn;
    public GameObject MiddleBuyBtn;
    public GameObject TopBuyBtn;

    public Text alertText;

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수
    //public System.Action<ItemProperty> onAllStoreSlotClick;//델리게이트 변수

    public ItemProperty[] BaseItemList = new ItemProperty[4];
    public ItemProperty[] MiddleItemList = new ItemProperty[5];
    public ItemProperty[] TopItemList = new ItemProperty[4];

    int BaseAllPrice = 0;
    int MiddleAllPrice = 0;
    int TopAllPrice = 0;

    int ItemCurPrice = 0;

    public int maxItemNum = 0;


    public void StoreOpen()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            itemBuffer = IB.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<ItemBuffer>();
            MiddleitemBuffer = IB.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<ItemBuffer>();
            TopitemBuffer = IB.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<ItemBuffer>();
        }

        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            itemBuffer = IB.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<ItemBuffer>();
            MiddleitemBuffer = IB.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<ItemBuffer>();
            TopitemBuffer = IB.transform.GetChild(1).transform.GetChild(2).gameObject.GetComponent<ItemBuffer>();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            itemBuffer = IB.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<ItemBuffer>();
            MiddleitemBuffer = IB.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<ItemBuffer>();
            TopitemBuffer = IB.transform.GetChild(2).transform.GetChild(2).gameObject.GetComponent<ItemBuffer>();
        }

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
            else // 아이템이 없는 경우 클릭 불가하게 만듦.
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
            else // 아이템이 없는 경우 클릭 불가하게 만듦.
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
            else // 아이템이 없는 경우 클릭 불가하게 만듦.
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
        DetailItemNum.text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.text = clickedSlot.item.name;
        DetailPrice.text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
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
        MiddleDetailItemNum.text = BuyNum.ToString();
        MiddleItemDetail.gameObject.SetActive(true);
        Middleimage.sprite = clickedSlot.item.sprite;
        MiddleDetailItemName.text = clickedSlot.item.name;
        MiddleDetailPrice.text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
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
        TopDetailItemNum.text = BuyNum.ToString();
        TopItemDetail.gameObject.SetActive(true);
        Topimage.sprite = clickedSlot.item.sprite;
        TopDetailItemName.text = clickedSlot.item.name;
        TopDetailPrice.text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
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
       
        DetailItemNum.text = BuyNum.ToString();
        DetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //BaseSlider.value += 1;

    }
    public void MinusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;
        
        DetailItemNum.text = BuyNum.ToString();
        DetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //BaseSlider.value -= 1;
    }

    public void PlusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        MiddleDetailItemNum.text = BuyNum.ToString();
        MiddleDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //MiddleSlider.value += 1;
    }
    public void MinusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        MiddleDetailItemNum.text = BuyNum.ToString();
        MiddleDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";

        //MiddleSlider.value -= 1;
    }

    public void PlusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        TopDetailItemNum.text = BuyNum.ToString();
        TopDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //TopSlider.value += 1;
    }
    public void MinusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        TopDetailItemNum.text = BuyNum.ToString();
        TopDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
        //TopSlider.value -= 1;
    }

    public void PlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;
        slotItemPrice = BaseAllPrice * BuyNum;

        BaseBuyAllNum.text = BuyNum.ToString();
        BaseBuyAllPrice.text = " / " +  slotItemPrice.ToString() + "$";

        //AllBuyslider.value += 1;
    }

    public void MiddlePlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        MiddleslotItemPrice = MiddleAllPrice * BuyNum;

        MiddleBuyAllNum.text = BuyNum.ToString();
        MiddleBuyAllPrice.text = " / " + MiddleslotItemPrice.ToString() + "$";
        //AllBuyslider.value += 1;
    }

    public void TopPlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        TopslotItemPrice = TopAllPrice * BuyNum;

        TopBuyAllNum.text = BuyNum.ToString();
        TopBuyAllPrice.text = " / " + TopslotItemPrice.ToString() + "$";
        //AllBuyslider.value += 1;
    }
    public void MinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        slotItemPrice = BaseAllPrice * BuyNum;


        BaseBuyAllNum.text = BuyNum.ToString();
        BaseBuyAllPrice.text = " / " + slotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void MiddleMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        MiddleslotItemPrice = MiddleAllPrice * BuyNum;

        MiddleBuyAllNum.text = BuyNum.ToString();
        MiddleBuyAllPrice.text = " / " + MiddleslotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void TopMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        TopslotItemPrice = TopAllPrice * BuyNum;

        TopBuyAllNum.text = BuyNum.ToString();
        TopBuyAllPrice.text = " / " + TopslotItemPrice.ToString() + "$";
        //AllBuyslider.value -= 1;
    }

    public void BuyItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(slot.item);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        slot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= slot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        //alertText.GetComponent<Text>().text = slot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
        StartCoroutine(FadeTextToZero());
        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }

    public void BuyMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Middleslot.item);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        Middleslot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= Middleslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        //alertText.GetComponent<Text>().text = Middleslot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
        StartCoroutine(FadeTextToZero());
        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }

    public void BuyTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (onStoreSlotClick != null)
        {
            onStoreSlotClick(Topslot.item);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        Topslot.item.itemCount -= 1 * BuyNum;
        float imsiMoney = fd.Money;
        fd.Money -= Topslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        //alertText.GetComponent<Text>().text = Topslot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
        StartCoroutine(FadeTextToZero());
        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }

    public void BuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            //Debug.Log(slots[i].item.itemCount);
            if (slots[i].item.itemCount == 0)
            {
                continue;
            }

            BaseItemList[i] = slots[i].item;
        }
        BuyNum = 1;
        BaseBuyAllNum.text = BuyNum.ToString();
        slotItemPrice = 0;
        BaseBuyAll.gameObject.SetActive(true);
        //inven.gameObject.SetActive(true);
        //inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        //inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
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
        BaseBuyAllPrice.text = " / " + slotItemPrice.ToString() + "$";
    }

    public void MiddleBuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            //Debug.Log(Middleslots[i].itemCount);
            if (Middleslots[i].item.itemCount == 0)
            {
                continue;
            }

            MiddleItemList[i] = Middleslots[i].item;
        }
        BuyNum = 1;
        MiddleBuyAllNum.text = BuyNum.ToString();
        MiddleslotItemPrice = 0;
        MiddleBuyAll.gameObject.SetActive(true);

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
        MiddleBuyAllPrice.text = " / " + MiddleslotItemPrice.ToString() + "$";
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
        BuyNum = 1;
        TopBuyAllNum.text = BuyNum.ToString();
        TopslotItemPrice = 0;
        TopBuyAll.gameObject.SetActive(true);
        //inven.gameObject.SetActive(true);
        //inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        //inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
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
        TopBuyAllPrice.text = " / " + TopslotItemPrice.ToString() + "$";
    }

    public void BaseBuyAllItem()
    {
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (BaseItemList[i] == null)
                continue;

            inven.GetComponent<Inventory>().BuyItem(BaseItemList[i]);

            BaseItemList[i].itemCount -= BuyNum;
            //BaseItemList[i].InvenItemNum += BuyNum;
            //Debug.Log(BaseItemList[i].InvenItemNum);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        BaseBuyAll.SetActive(false);
        MiddleBuyAll.SetActive(false);
        TopBuyAll.SetActive(false);
    }
    public void MiddleBuyAllItem()
    {
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (MiddleItemList[i] == null)
                break;

            inven.GetComponent<Inventory>().BuyItem(MiddleItemList[i]);
            MiddleItemList[i].itemCount -= 1 * BuyNum;
            //MiddleItemList[i].InvenItemNum += BuyNum;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        BaseBuyAll.SetActive(false);
        MiddleBuyAll.SetActive(false);
        TopBuyAll.SetActive(false);
    }

    public void TopBuyAllItem()
    {
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (TopItemList[i] == null)
                break;

            inven.GetComponent<Inventory>().BuyItem(TopItemList[i]);
            TopItemList[i].itemCount -= 1 * BuyNum;
            //TopItemList[i].InvenItemNum += BuyNum;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));
        BaseBuyAll.SetActive(false);
        MiddleBuyAll.SetActive(false);
        TopBuyAll.SetActive(false);
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
        //inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        //inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        //inven.gameObject.SetActive(false);
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
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
            Debug.Log("잔돈 없음. 더이상 추가 불가");
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
            Debug.Log("잔액 부족");
            GameObject.Find("Store").transform.GetChild(1).GetChild(0).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Store").transform.GetChild(1).GetChild(1).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Store").transform.GetChild(1).GetChild(2).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = false;

            alertText.GetComponent<Text>().text = "잔액이 부족합니다.";
            StartCoroutine(FadeTextToZero());
        }
        else
        {
            GameObject.Find("Store").transform.GetChild(1).GetChild(0).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
            GameObject.Find("Store").transform.GetChild(1).GetChild(1).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
            GameObject.Find("Store").transform.GetChild(1).GetChild(2).GetChild(6).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
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
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            fd.GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        fd.GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

    }


}
