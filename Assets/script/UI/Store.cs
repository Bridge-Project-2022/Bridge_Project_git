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

    public System.Action<ItemProperty> onStoreSlotClick;//델리게이트 변수
    //public System.Action<ItemProperty> onAllStoreSlotClick;//델리게이트 변수

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
            else // 아이템이 없는 경우 클릭 불가하게 만듦.
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
            else // 아이템이 없는 경우 클릭 불가하게 만듦.
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

        BuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
        AllBuyslider.value += 1;
    }
    public void MinusAllItem()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        AllBuyNum -= 1;

        BuyAllNum.GetComponent<Text>().text = AllBuyNum.ToString();
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
        BuyAll.gameObject.SetActive(false);
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
            BuyAllBtn.gameObject.GetComponent<Button>().interactable = false;
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
