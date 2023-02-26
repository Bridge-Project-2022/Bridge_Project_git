using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour, IDataPersistence
{
    public Transform BaseslotRoot;
    public Transform MiddleslotRoot;
    public Transform TopslotRoot;

    public Transform storeSlotRoot;
    public Store store;

    public List<Slot> Baseslots;
    public List<Slot> Middleslots;
    public List<Slot> Topslots;

    private List<Slot> storeSlots;

    //public bool isNew;//새로운 아이템이 들어온 경우 true
    public bool isSame;
    public bool isAllsame;

    ItemProperty allItem;
    // Start is called before the first frame update
    void Start()
    {
        isSame = false;
        isAllsame = false;

        Baseslots = new List<Slot>();
        Middleslots = new List<Slot>();
        Topslots = new List<Slot>();

        storeSlots = new List<Slot>();

        int BaseslotCount = BaseslotRoot.childCount;
        int MiddleslotCount = MiddleslotRoot.childCount;
        int TopslotCount = TopslotRoot.childCount;


        for (int i = 0; i < BaseslotCount; i++)
        {
            var slot = BaseslotRoot.GetChild(i).GetComponent<Slot>();

            Baseslots.Add(slot);
        }

        for (int i = 0; i < MiddleslotCount; i++)
        {
            var slot = MiddleslotRoot.GetChild(i).GetComponent<Slot>();

            Middleslots.Add(slot);
        }

        for (int i = 0; i < TopslotCount; i++)
        {
            var slot = TopslotRoot.GetChild(i).GetComponent<Slot>();

            Topslots.Add(slot);
        }

        for (int i = 0; i < storeSlotRoot.childCount; i++)
        {
            var Storeslot = storeSlotRoot.GetChild(i).GetComponent<Slot>();

            storeSlots.Add(Storeslot);
        }
        store.onStoreSlotClick += BuyItem;//구매하기 버튼 누르면 다음 함수 실행.
        //store.onAllStoreSlotClick += AllBuyItem;
    }

    public void BuyItem(ItemProperty item)
    {
        if (item.itemType == "Base")
        {
            var emptySlot = Baseslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];

            for (int i = 0; i < BaseslotRoot.childCount; i++)
            {
                if (Baseslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;

                    Baseslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Baseslots[i].item != item)//중복이 아닌 경우
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
                //Debug.Log("실행");
                emptySlot.SetInvenItem(item);
                item.InvenItemNum += store.BuyNum;
                //Debug.Log(emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);
                emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
            }
        }

        else if (item.itemType == "Middle")
        {
            var emptySlot = Middleslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Middleslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;
                    Middleslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Middleslots[i].item != item)//중복이 아닌 경우
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
                if (emptySlot != null)//슬롯 꽉차지 않은 경우
                {
                    emptySlot.SetInvenItem(item);
                    item.InvenItemNum += store.BuyNum;
                    emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
                }
                else
                {
                    Debug.Log("슬롯 꽉참");
                }
               
            }
        }

        else if (item.itemType == "Top")
        {
            var emptySlot = Topslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Topslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.BuyNum;
                    Topslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Topslots[i].item != item)//중복이 아닌 경우
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
                if (emptySlot != null)//슬롯 꽉차지 않은 경우
                {
                    emptySlot.SetInvenItem(item);
                    item.InvenItemNum += store.BuyNum;
                    emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
                }
                else
                {
                    Debug.Log("슬롯 꽉참");
                }
            }
        }

    }

    public void AllBuyItem(ItemProperty item)//일괄 구매
    {
        if (item.itemType == "Base")
        {
            var emptySlot = Baseslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];

            for (int i = 0; i < BaseslotRoot.childCount; i++)
            {
                if (Baseslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.AllBuyNum;

                    Baseslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Baseslots[i].item != item)//중복이 아닌 경우
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
                //Debug.Log("실행");
                emptySlot.SetInvenItem(item);
                item.InvenItemNum += store.AllBuyNum;
                //Debug.Log(emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);
                emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
            }
        }

        else if (item.itemType == "Middle")
        {
            var emptySlot = Middleslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Middleslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.MiddleAllBuyNum;
                    Middleslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Middleslots[i].item != item)//중복이 아닌 경우
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
                if (emptySlot != null)//슬롯 꽉차지 않은 경우
                {
                    emptySlot.SetInvenItem(item);
                    item.InvenItemNum += store.MiddleAllBuyNum;
                    emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
                }
                else
                {
                    Debug.Log("슬롯 꽉참");
                }

            }
        }

        else if (item.itemType == "Top")
        {
            var emptySlot = Topslots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty;
            });//모든 슬롯중에 아이템이 빈 슬롯을 emptyslot이라는 변수 할당.
               //var imsiSlot = imsiSlots[0];
            for (int i = 0; i < MiddleslotRoot.childCount; i++)
            {
                if (Topslots[i].item == item)//중복인 경우
                {
                    Debug.Log(i + "번째 슬롯 아이템이 겹침");
                    isSame = true;
                    item.InvenItemNum += store.TopAllBuyNum;
                    Topslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";

                    break;
                }

                if (Topslots[i].item != item)//중복이 아닌 경우
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
                if (emptySlot != null)//슬롯 꽉차지 않은 경우
                {
                    emptySlot.SetInvenItem(item);
                    item.InvenItemNum += store.TopAllBuyNum;
                    emptySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.InvenItemNum.ToString() + "개 남음";
                }
                else
                {
                    Debug.Log("슬롯 꽉참");
                }
            }
        }
    }
    public void Close()
    {
        this.transform.Translate(new Vector3(2000, 2000, 0));
        //this.gameObject.SetActive(false);
    }

    public void ResetInven()
    {
        for (int i = 0; i < Baseslots.Count; i++)
        {
            Baseslots[i].itemName.text = "";
            Baseslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            Baseslots[i].item = null;
            Baseslots[i].image.enabled = false;
            Baseslots[i].gameObject.name = "Empty";
        }
        for (int i = 0; i < Middleslots.Count; i++)
        {
            Middleslots[i].itemName.text = "";
            Middleslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            Middleslots[i].item = null;
            Middleslots[i].image.enabled = false;
            Middleslots[i].gameObject.name = "Empty";
        }
        for (int i = 0; i < Topslots.Count; i++)
        {
            Topslots[i].itemName.text = "";
            Topslots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            Topslots[i].item = null;
            Topslots[i].image.enabled = false;
            Topslots[i].gameObject.name = "Empty";
        }
    }

    public void LoadData(GameData data)
    {
        this.ResetInven();

        for (int i = 0; i < data.baseItemList.Count; i++)
        {
            data.baseItemList[i].InvenItemNum -= 1;
            this.BuyItem(data.baseItemList[i]);
        }
        for (int i = 0; i < data.middleItemList.Count; i++)
        {
            data.middleItemList[i].InvenItemNum -= 1;
            this.BuyItem(data.middleItemList[i]);
        }
        for (int i = 0; i < data.topItemList.Count; i++)
        {
            data.topItemList[i].InvenItemNum -= 1;
            this.BuyItem(data.topItemList[i]);
        }
    }

    public void SaveData(ref GameData data)
    {
        for (int i = 0; i < Baseslots.Count; i++)
        {
            data.baseItemList[i] = this.Baseslots[i].item;
        }
        for (int i = 0; i < Middleslots.Count; i++)
        {
            data.middleItemList[i] = this.Middleslots[i].item;
        }
        for (int i = 0; i < Topslots.Count; i++)
        {
            data.topItemList[i] = this.Topslots[i].item;
        }
    }
}
