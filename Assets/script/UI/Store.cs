using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Store : MonoBehaviour
{
    public Transform slotRoot;
    public Transform MiddleslotRoot;
    public Transform TopslotRoot;

    public ItemBuffer BaseitemBuffer;
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
    public int MiddleAllBuyNum = 1;
    public int TopAllBuyNum = 1;


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

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수

    public ItemProperty[] BaseItemList = new ItemProperty[4];
    public ItemProperty[] MiddleItemList = new ItemProperty[10];
    public ItemProperty[] TopItemList = new ItemProperty[10];


    int BaseAllPrice = 0;
    int MiddleAllPrice = 0;
    int TopAllPrice = 0;

    int ItemCurPrice = 0;

    public int maxItemNum = 0;
    public int openCnt = 0; //날 바뀌고 처음 상점 열었을 때 파악 용도

    bool isBaseAllOpen = false;
    bool isMiddleAllOpen = false;
    bool isTopAllOpen = false;

    public int Basecnt = 0;
    public void StoreOpen()
    {
        this.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);

        openCnt++;
        slots = new List<Slot>();
        Middleslots = new List<Slot>();
        Topslots = new List<Slot>();

        int slotCount = slotRoot.childCount;
        int MiddleslotCount = MiddleslotRoot.childCount;
        int TopslotCount = TopslotRoot.childCount;


        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            for (int i = 0; i <= 3; i++)
            {
                slot = slotRoot.GetChild(i).GetComponent<Slot>();

                if (i < BaseitemBuffer.items.Count)
                {
                    slot.SetItem(BaseitemBuffer.items[i]);
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    if (BaseitemBuffer.items[i].isNew == true)
                    {
                        slotRoot.GetChild(i).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                slots.Add(slot);
            }

            for (int j = 0; j <= 5; j++)
            {
                Middleslot = MiddleslotRoot.GetChild(j).GetComponent<Slot>();
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (j < MiddleitemBuffer.items.Count)
                {
                    Middleslot.SetItem(MiddleitemBuffer.items[j]);

                    if (MiddleitemBuffer.items[j].isNew == true)
                    {
                        MiddleslotRoot.GetChild(j).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                Middleslots.Add(Middleslot);
            }

            for (int k = 0; k <= 3; k++)
            {
                Topslot = TopslotRoot.GetChild(k).GetComponent<Slot>();
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (k < TopitemBuffer.items.Count)
                {
                    Topslot.SetItem(TopitemBuffer.items[k]);

                    if (TopitemBuffer.items[k].isNew == true)
                    {
                        TopslotRoot.GetChild(k).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                Topslots.Add(Topslot);
            }
        }
       
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            BaseBuyAllBtn.GetComponent<Button>().interactable = true;
            MiddleBuyAllBtn.GetComponent<Button>().interactable = true;
            TopBuyAllBtn.GetComponent<Button>().interactable = true;
            for (int i = 0; i <= 3; i++)
            {
                slot = slotRoot.GetChild(i).GetComponent<Slot>();

                if (i < BaseitemBuffer.items.Count)
                {
                    slot.SetItem(BaseitemBuffer.items[i]);
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    if (BaseitemBuffer.items[i].isNew == true)
                    {
                        slotRoot.GetChild(i).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                slots.Add(slot);
            }

            for (int j = 0; j <= 8; j++)
            {
                Middleslot = MiddleslotRoot.GetChild(j).GetComponent<Slot>();
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (j < MiddleitemBuffer.items.Count)
                {
                    Middleslot.SetItem(MiddleitemBuffer.items[j]);

                    if (MiddleitemBuffer.items[j].isNew == true)
                    {
                        MiddleslotRoot.GetChild(j).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                Middleslots.Add(Middleslot);
            }

            for (int k = 0; k <= 4; k++)
            {
                Topslot = TopslotRoot.GetChild(k).GetComponent<Slot>();
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (k < TopitemBuffer.items.Count)
                {
                    Topslot.SetItem(TopitemBuffer.items[k]);

                    if (TopitemBuffer.items[k].isNew == true)
                    {
                        TopslotRoot.GetChild(k).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                Topslots.Add(Topslot);
            }

            for (int i = 6; i <= 8; i++)
            {
                MiddleslotRoot.transform.GetChild(i).gameObject.SetActive(true);
            }
            TopslotRoot.transform.GetChild(4).gameObject.SetActive(true);

            if (openCnt == 1)//처음 열었을 때
            {
                for (int i = 0; i <= 3; i++)
                {
                    BaseitemBuffer.items[i].itemCount = 5;
                }
                for (int i = 0; i <= 5; i++)
                {
                    MiddleitemBuffer.items[i].itemCount = 3;
                }
                for (int i = 0; i <= 3; i++)
                {
                    TopitemBuffer.items[i].itemCount = 3;
                }
            }

        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            BaseBuyAllBtn.GetComponent<Button>().interactable = true;
            MiddleBuyAllBtn.GetComponent<Button>().interactable = true;
            TopBuyAllBtn.GetComponent<Button>().interactable = true;
            for (int i = 0; i <= 3; i++)
            {
                slot = slotRoot.GetChild(i).GetComponent<Slot>();

                if (i < BaseitemBuffer.items.Count)
                {
                    slot.SetItem(BaseitemBuffer.items[i]);
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    if (BaseitemBuffer.items[i].isNew == true)
                    {
                        slotRoot.GetChild(i).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                slots.Add(slot);
            }

            for (int j = 0; j <= 8; j++)
            {
                Middleslot = MiddleslotRoot.GetChild(j).GetComponent<Slot>();
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (j < MiddleitemBuffer.items.Count)
                {
                    Middleslot.SetItem(MiddleitemBuffer.items[j]);

                    if (MiddleitemBuffer.items[j].isNew == true)
                    {
                        MiddleslotRoot.GetChild(j).GetChild(5).gameObject.SetActive(false);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                Middleslots.Add(Middleslot);
            }

            for (int k = 0; k <= 6; k++)
            {
                Topslot = TopslotRoot.GetChild(k).GetComponent<Slot>();
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (k < TopitemBuffer.items.Count)
                {
                    Topslot.SetItem(TopitemBuffer.items[k]);

                    if (TopitemBuffer.items[k].isNew == true)
                    {
                        TopslotRoot.GetChild(k).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                Topslots.Add(Topslot);
            }

            for (int i = 6; i <= 8; i++)
            {
                MiddleslotRoot.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 4; i <= 6; i++)
            {
                TopslotRoot.transform.GetChild(i).gameObject.SetActive(true);
            }

            if (TopitemBuffer.items[4].isNew == true)
            {
                TopslotRoot.GetChild(4).GetChild(5).gameObject.SetActive(false);
            }
            if (openCnt == 1)//처음 열었을 때
            {
                for (int i = 0; i <= 3; i++)
                {
                    BaseitemBuffer.items[i].itemCount = 5;
                }
                for (int i = 0; i <= 8; i++)
                {
                    MiddleitemBuffer.items[i].itemCount = 3;
                }
                for (int i = 0; i <= 4; i++)
                {
                    TopitemBuffer.items[i].itemCount = 3;
                }
            }
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            BaseBuyAllBtn.GetComponent<Button>().interactable = true;
            MiddleBuyAllBtn.GetComponent<Button>().interactable = true;
            TopBuyAllBtn.GetComponent<Button>().interactable = true;
            for (int i = 0; i <= 3; i++)
            {
                slot = slotRoot.GetChild(i).GetComponent<Slot>();

                if (i < BaseitemBuffer.items.Count)
                {
                    slot.SetItem(BaseitemBuffer.items[i]);
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    if (BaseitemBuffer.items[i].isNew == true)
                    {
                        slotRoot.GetChild(i).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                slots.Add(slot);
            }

            for (int j = 0; j <= 8; j++)
            {
                Middleslot = MiddleslotRoot.GetChild(j).GetComponent<Slot>();
                Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (j < MiddleitemBuffer.items.Count)
                {
                    Middleslot.SetItem(MiddleitemBuffer.items[j]);

                    if (MiddleitemBuffer.items[j].isNew == true)
                    {
                        MiddleslotRoot.GetChild(j).GetChild(5).gameObject.SetActive(false);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Middleslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }

                Middleslots.Add(Middleslot);
            }

            for (int k = 0; k <= 8; k++)
            {
                Topslot = TopslotRoot.GetChild(k).GetComponent<Slot>();
                Topslot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (k < TopitemBuffer.items.Count)
                {
                    Topslot.SetItem(TopitemBuffer.items[k]);

                    if (TopitemBuffer.items[k].isNew == true)
                    {
                        TopslotRoot.GetChild(k).GetChild(5).gameObject.SetActive(true);
                    }
                }
                else // 아이템이 없는 경우 클릭 불가하게 만듦.
                {
                    Topslot.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                Topslots.Add(Topslot);
            }

            for (int i = 6; i <= 8; i++)
            {
                MiddleslotRoot.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 4; i <= 8; i++)
            {
                TopslotRoot.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i <= 6; i++)
            {
                if (TopitemBuffer.items[i].isNew == true)
                {
                    TopslotRoot.GetChild(i).GetChild(5).gameObject.SetActive(false);
                }
            }

            if (openCnt == 1)//처음 열었을 때
            {
                for (int i = 0; i <= 3; i++)
                {
                    BaseitemBuffer.items[i].itemCount = 5;
                }
                for (int i = 0; i <= 8; i++)
                {
                    MiddleitemBuffer.items[i].itemCount = 3;
                }
                for (int i = 0; i <= 6; i++)
                {
                    TopitemBuffer.items[i].itemCount = 3;
                }
            }
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

    }

    public void PlusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;
       
        DetailItemNum.text = BuyNum.ToString();
        DetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";

    }
    public void MinusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;
        
        DetailItemNum.text = BuyNum.ToString();
        DetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
    }

    public void PlusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        MiddleDetailItemNum.text = BuyNum.ToString();
        MiddleDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
    }
    public void MinusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        MiddleDetailItemNum.text = BuyNum.ToString();
        MiddleDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
    }

    public void PlusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        TopDetailItemNum.text = BuyNum.ToString();
        TopDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
    }
    public void MinusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        TopDetailItemNum.text = BuyNum.ToString();
        TopDetailPrice.text = " / " + (BuyNum * ItemCurPrice).ToString() + "$";
    }

    public void PlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;
        slotItemPrice = BaseAllPrice * AllBuyNum;

        BaseBuyAllNum.text = AllBuyNum.ToString();
        BaseBuyAllPrice.text = " / " +  slotItemPrice.ToString() + "$";
    }

    public void MiddlePlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        MiddleAllBuyNum += 1;

        MiddleslotItemPrice = MiddleAllPrice * MiddleAllBuyNum;

        MiddleBuyAllNum.text = MiddleAllBuyNum.ToString();
        MiddleBuyAllPrice.text = " / " + MiddleslotItemPrice.ToString() + "$";
    }

    public void TopPlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        TopAllBuyNum += 1;

        TopslotItemPrice = TopAllPrice * TopAllBuyNum;

        TopBuyAllNum.text = TopAllBuyNum.ToString();
        TopBuyAllPrice.text = " / " + TopslotItemPrice.ToString() + "$";
    }
    public void MinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;

        slotItemPrice = BaseAllPrice * AllBuyNum;


        BaseBuyAllNum.text = AllBuyNum.ToString();
        BaseBuyAllPrice.text = " / " + slotItemPrice.ToString() + "$";
    }

    public void MiddleMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        MiddleAllBuyNum -= 1;

        MiddleslotItemPrice = MiddleAllPrice * MiddleAllBuyNum;

        MiddleBuyAllNum.text = MiddleAllBuyNum.ToString();
        MiddleBuyAllPrice.text = " / " + MiddleslotItemPrice.ToString() + "$";
    }

    public void TopMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        TopAllBuyNum -= 1;

        TopslotItemPrice = TopAllPrice * TopAllBuyNum;

        TopBuyAllNum.text = TopAllBuyNum.ToString();
        TopBuyAllPrice.text = " / " + TopslotItemPrice.ToString() + "$";
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

        if (slot.item.itemCount < 0)
            slot.item.itemCount = 0;
        float imsiMoney = fd.Money;
        fd.Money -= slot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (BaseItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == BaseItemList.Length)
            {
                BaseBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;

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

        if (Middleslot.item.itemCount < 0)
            Middleslot.item.itemCount = 0;

        float imsiMoney = fd.Money;
        fd.Money -= Middleslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (MiddleItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == MiddleItemList.Length)
            {
                MiddleBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;

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

        if (Topslot.item.itemCount < 0)
            Topslot.item.itemCount = 0;

        float imsiMoney = fd.Money;
        fd.Money -= Topslot.item.itemPrice * BuyNum;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (TopItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == TopItemList.Length)
            {
                TopBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;

        ItemDetail.gameObject.SetActive(false);
        MiddleItemDetail.gameObject.SetActive(false);
        TopItemDetail.gameObject.SetActive(false);
    }

    public void BuyAllItemUI()
    {
        isBaseAllOpen = true;
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
        BaseBuyAllNum.text = AllBuyNum.ToString();
        slotItemPrice = 0;
        BaseBuyAll.gameObject.SetActive(true);
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
        isMiddleAllOpen = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            Array.Resize(ref MiddleItemList, 9);
        }
        if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            Array.Resize(ref MiddleItemList, 9);
        }
        if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            Array.Resize(ref MiddleItemList, 9);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (Middleslots[i].item.itemCount == 0)
            {
                continue;
            }

            MiddleItemList[i] = Middleslots[i].item;
        }
        MiddleAllBuyNum = 1;
        MiddleBuyAllNum.text = MiddleAllBuyNum.ToString();
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
        isTopAllOpen = true;
        if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            Array.Resize(ref TopItemList, 5);
        }
        if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            Array.Resize(ref TopItemList, 7);
        }
        if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            Array.Resize(ref TopItemList, 9);
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (Topslots[i].item.itemCount == 0)
            {
                continue;
            }

            TopItemList[i] = Topslots[i].item;
        }
        TopAllBuyNum = 1;
        TopBuyAllNum.text = TopAllBuyNum.ToString();
        TopslotItemPrice = 0;
        TopBuyAll.gameObject.SetActive(true);
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
            BaseItemList[i].itemCount -= AllBuyNum;
            if (BaseItemList[i].itemCount < 0)
                BaseItemList[i].itemCount = 0;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= slotItemPrice;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (BaseItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == BaseItemList.Length)
            {
                BaseBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;


        BaseBuyAll.SetActive(false);
        MiddleBuyAll.SetActive(false);
        TopBuyAll.SetActive(false);
    }
    public void MiddleBuyAllItem()
    {
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (MiddleItemList[i] == null)
            {
                continue;
            }

            inven.GetComponent<Inventory>().BuyItem(MiddleItemList[i]);
            MiddleItemList[i].itemCount -= MiddleAllBuyNum;

            if (MiddleItemList[i].itemCount < 0)
                MiddleItemList[i].itemCount = 0;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= MiddleslotItemPrice;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (MiddleItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == MiddleItemList.Length)
            {
                MiddleBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;

        BaseBuyAll.SetActive(false);
        MiddleBuyAll.SetActive(false);
        TopBuyAll.SetActive(false);
    }

    public void TopBuyAllItem()
    {
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (TopItemList[i] == null)
                continue;

            inven.GetComponent<Inventory>().BuyItem(TopItemList[i]);
            TopItemList[i].itemCount -= TopAllBuyNum;

            if (TopItemList[i].itemCount < 0)
                TopItemList[i].itemCount = 0;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        float imsiMoney = fd.Money;
        fd.Money -= TopslotItemPrice;
        StartCoroutine(Count(imsiMoney, fd.Money));

        int cnt = 0;
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (TopItemList[i].itemCount == 0)
            {
                cnt++;
            }

            if (cnt == TopItemList.Length)
            {
                TopBuyAllBtn.GetComponent<Button>().interactable = false;
            }
        }
        cnt = 0;

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
        isBaseAllOpen = false;
        isMiddleAllOpen = false;
        isTopAllOpen = false;

        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BaseBuyAll.gameObject.SetActive(false);
        MiddleBuyAll.gameObject.SetActive(false);
        TopBuyAll.gameObject.SetActive(false);
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

        if (AllBuyNum <= 1 || MiddleAllBuyNum <= 1 || TopAllBuyNum <= 1)
        {
            BaseAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = false;
            MiddleAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = false;
            TopAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            BaseAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = true;
            MiddleAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = true;
            TopAllBuyMinusBtn.gameObject.GetComponent<Button>().interactable = true;
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

        if (fd.Money <= slotItemPrice)
        {
            //Debug.Log("잔액 부족");
            BaseAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;
            MiddleAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;
            TopAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;

        }
        else
        {
            BaseAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
            MiddleAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
            TopAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
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

        if (isBaseAllOpen == true)
        {
            int Bmin = BaseItemList[0].itemCount;
            int Bmax = BaseItemList[0].itemCount;

            for (int i = 0; i < BaseItemList.Length; i++)
            {
                if (Bmin > BaseItemList[i].itemCount)
                    Bmin = BaseItemList[i].itemCount;

                else if (Bmax < BaseItemList[i].itemCount)
                    Bmax = BaseItemList[i].itemCount;
            }

            if (this.transform.GetChild(1).GetChild(0).gameObject.activeSelf == true)
            {
                if (AllBuyNum == Bmin)
                {
                    BaseAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;
                }
                else
                    BaseAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
            }

        }

        if (isMiddleAllOpen == true)
        {
            int Mmin = MiddleItemList[0].itemCount;
            int Mmax = MiddleItemList[0].itemCount;

            for (int i = 0; i < MiddleItemList.Length; i++)
            {
                if (Mmin > MiddleItemList[i].itemCount)
                    Mmin = MiddleItemList[i].itemCount;

                else if (Mmax < MiddleItemList[i].itemCount)
                    Mmax = MiddleItemList[i].itemCount;
            }

            if (this.transform.GetChild(1).GetChild(1).gameObject.activeSelf == true)
            {
                if (MiddleAllBuyNum == Mmin)
                {
                    MiddleAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;
                }
                else
                    MiddleAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
            }
        }

        if (isTopAllOpen == true)
        {
            int Tmin = TopItemList[0].itemCount;
            int Tmax = TopItemList[0].itemCount;

            for (int i = 0; i < TopItemList.Length; i++)
            {
                if (Tmin > TopItemList[i].itemCount)
                    Tmin = TopItemList[i].itemCount;

                else if (Tmax < TopItemList[i].itemCount)
                    Tmax = TopItemList[i].itemCount;
            }

            if (this.transform.GetChild(1).GetChild(2).gameObject.activeSelf == true)
            {
                if (TopAllBuyNum == Tmin)
                {
                    TopAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = false;
                }
                else
                    TopAllBuyPlusBtn.gameObject.GetComponent<Button>().interactable = true;
            }
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
