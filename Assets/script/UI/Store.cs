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

    public Slider BaseSlider;
    public Slider MiddleSlider;
    public Slider TopSlider;

    public Slider AllBuyslider;

    public Button MinusBtn;
    public Button PlusBtn;

    public Button BaseBuyAllBtn;
    public Button BaseAllBuyMinusBtn;
    public Button BaseAllBuyPlusBtn;

    public Button MiddleBuyAllBtn;
    public Button MiddleAllBuyMinusBtn;
    public Button MiddleAllBuyPlusBtn;

    public Button TopBuyAllBtn;
    public Button TopAllBuyMinusBtn;
    public Button TopAllBuyPlusBtn;

    public int BuyNum;
    public int AllBuyNum;
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

    public Text alertText;

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수
    //public System.Action<ItemProperty> onAllStoreSlotClick;//델리게이트 변수

    public ItemProperty[] BaseItemList = new ItemProperty[10];
    public ItemProperty[] MiddleItemList = new ItemProperty[10];
    public ItemProperty[] TopItemList = new ItemProperty[10];

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
        BaseSlider.value = 0;
        BuyNum = 0;
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        ItemDetail.gameObject.SetActive(true);
        image.sprite = clickedSlot.item.sprite;
        DetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        DetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        DetailItemExplanation.text = clickedSlot.item.itemExplanation;
        slot = clickedSlot;
        BaseSlider.maxValue = clickedSlot.item.itemCount;
      
    }

    public void OnClickMiddleSlot(Slot clickedSlot)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        MiddleSlider.value = 0;
        BuyNum = 0;
        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleItemDetail.gameObject.SetActive(true);
        Middleimage.sprite = clickedSlot.item.sprite;
        MiddleDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        MiddleDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        MiddleDetailItemExplanation.text = clickedSlot.item.itemExplanation;
        Middleslot = clickedSlot;
        MiddleSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void OnClickTopSlot(Slot clickedSlot)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        TopSlider.value = 0;
        BuyNum = 0;
        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopItemDetail.gameObject.SetActive(true);
        Topimage.sprite = clickedSlot.item.sprite;
        TopDetailItemName.GetComponent<Text>().text = clickedSlot.item.name;
        TopDetailPrice.GetComponent<Text>().text = " / " + clickedSlot.item.itemPrice.ToString() + "$";
        TopDetailItemExplanation.text = clickedSlot.item.itemExplanation;
        Topslot = clickedSlot;
        TopSlider.maxValue = clickedSlot.item.itemCount;

    }

    public void PlusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;
       
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        BaseSlider.value += 1;
    }
    public void MinusItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;
        
        DetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        BaseSlider.value -= 1;
    }

    public void PlusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleSlider.value += 1;
    }
    public void MinusMiddleItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        MiddleDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        MiddleSlider.value -= 1;
    }

    public void PlusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum += 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopSlider.value += 1;
    }
    public void MinusTopItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        BuyNum -= 1;

        TopDetailItemNum.GetComponent<Text>().text = BuyNum.ToString();
        TopSlider.value -= 1;
    }

    public void PlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        slotItemPrice *= AllBuyNum;
        /*string BaseAll = BaseBuyAllPrice.GetComponent<Text>().text;
        int BaseAllPrice = int.Parse(BaseAll);
        BaseAllPrice = 0;
        BaseAllPrice *= AllBuyNum;*/

        BaseBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value += 1;
    }

    public void MiddlePlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        MiddleBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value += 1;
    }

    public void TopPlusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum += 1;

        TopBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value += 1;
    }
    public void MinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;


        BaseBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value -= 1;
    }

    public void MiddleMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;


        MiddleBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value -= 1;
    }

    public void TopMinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;


        TopBuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value -= 1;
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
        alertText.GetComponent<Text>().text = slot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
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
        alertText.GetComponent<Text>().text = Middleslot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
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
        alertText.GetComponent<Text>().text = Topslot.item.name + " 향료 " + BuyNum + "개 구매 완료했습니다.";
        StartCoroutine(FadeTextToZero());
    }

    public void BuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (slots[i].item == null)
                break;

            BaseItemList[i] = slots[i].item;
        }
        AllBuyNum = 0;
        slotItemPrice = 0;
        BaseBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < slots.Count; i++)
        {
            slotItemPrice += slots[i].item.itemPrice;
        }
        BaseBuyAllPrice.GetComponent<Text>().text = " / " + slotItemPrice.ToString() + "$";
    }

    public void MiddleBuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < MiddleItemList.Length; i++)
        {
            if (Middleslots[i].item == null)
                break;

            MiddleItemList[i] = Middleslots[i].item;
        }
        AllBuyNum = 0;
        MiddleslotItemPrice = 0;
        MiddleBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < Middleslots.Count; i++)
        {
            MiddleslotItemPrice += Middleslots[i].item.itemPrice;
        }
        MiddleBuyAllPrice.GetComponent<Text>().text = " / " + MiddleslotItemPrice.ToString() + "$";
    }

    public void TopBuyAllItemUI()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < TopItemList.Length; i++)
        {
            if (Topslots[i].item == null)
                break;

            TopItemList[i] = Topslots[i].item;
        }
        AllBuyNum = 0;
        TopslotItemPrice = 0;
        TopBuyAll.gameObject.SetActive(true);
        inven.gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        inven.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < Topslots.Count; i++)
        {
            TopslotItemPrice += Topslots[i].item.itemPrice;
        }
        TopBuyAllPrice.GetComponent<Text>().text = " / " + TopslotItemPrice.ToString() + "$";
    }

    public void BaseBuyAllItem()
    {
        for (int i = 0; i < BaseItemList.Length; i++)
        {
            if (BaseItemList[i] == null)
                break;

            inven.GetComponent<Inventory>().BuyItem(BaseItemList[i]);
            BaseItemList[i].itemCount -= 1 * AllBuyNum;
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
            Debug.Log("잔돈 없음. 더이상 추가 불가");
            PlusBtn.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            PlusBtn.gameObject.GetComponent<Button>().interactable = true;
        }

        if (fd.Money < slotItemPrice * AllBuyNum)
        {
            Debug.Log("잔액 부족");
            BaseBuyAllBtn.gameObject.GetComponent<Button>().interactable = false;
            alertText.GetComponent<Text>().text = "잔액이 부족합니다.";
            StartCoroutine(FadeTextToZero());
        }
    }


     IEnumerator Count(float target, float current)

    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 

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
