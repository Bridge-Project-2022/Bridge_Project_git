using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public ItemProperty item;
    public UnityEngine.UI.Image image;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemCount;
    public TextMeshProUGUI itemName;

    public ItemProperty ClickedItem;

    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = item.name;
            image.sprite = item.sprite;
            itemPrice.text = item.itemPrice.ToString();
            //itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "개 보유";
        }
    }

    public void SetInvenItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = item.name;
            image.sprite = item.sprite;
            //Debug.Log("ss");
            itemCount.text = item.itemCount.ToString() + "개 보유";
            itemName.text = item.name + "향료";
        }
    }

    public void ItemClick(Slot ClickedSlot)//슬롯 아이템 클릭 경우
    {
        GameObject.Find("Inventory").transform.position = new Vector3(1038, 3000, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        //클릭한 아이템이 화면에 보여짐
        
        Color color = GameObject.Find("ClickedItem").GetComponent<Image>().color;
        color.a = 255;
        GameObject.Find("ClickedItem").GetComponent<Image>().color = color;//클릭한 아이템 투명도 0이었다가 보여져야 하니까 255로 변경
        GameObject.Find("ClickedItem").GetComponent<Image>().sprite = this.image.sprite;

        if (ClickedSlot.item.itemType == "Base" && GameObject.Find("TotalScoreBuffer").GetComponent<TotalScore>().DistillCnt == 0)//증류기 실행
        {
            ClickedItem = ClickedSlot.item;
            ItemReset.FindObjectOfType<ItemReset>().resetItem = ClickedItem;

            GameObject.Find("Distiller").GetComponent<Button>().interactable = true;
            GameObject.Find("ClickedItem").GetComponent<Button>().interactable = true;
            GameObject.Find("Etc").transform.GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(6).GetComponent<MouseFollow>().transform_icon.GetComponent<Image>().sprite = GameObject.Find("ClickedItem").GetComponent<Image>().sprite;
            GameObject.Find("Manufacture").transform.GetChild(6).GetComponent<Distiller>().DistillerOn(ClickedItem);
            Debug.Log("증류기 시작");
        }

        else if (item.itemType == "Middle" && GameObject.Find("TotalScoreBuffer").GetComponent<TotalScore>().PressCnt == 0)//압착기 실행
        {
            ClickedItem = ClickedSlot.item;
            ItemReset.FindObjectOfType<ItemReset>().resetItem = ClickedItem;

            GameObject.Find("Presser").GetComponent<Button>().interactable = true;
            GameObject.Find("ClickedItem").GetComponent<Button>().interactable = true;
            GameObject.Find("Etc").transform.GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(6).GetComponent<MouseFollow>().transform_icon.GetComponent<Image>().sprite = GameObject.Find("ClickedItem").GetComponent<Image>().sprite;
            Debug.Log("압착기 시작");
            GameObject.Find("Presser").GetComponent<Presser>().PresserOn(ClickedItem);
        }
        else if (item.itemType == "Top" && GameObject.Find("TotalScoreBuffer").GetComponent<TotalScore>().CoolCnt == 0)//냉침기 실행
        {
            ClickedItem = ClickedSlot.item;
            ItemReset.FindObjectOfType<ItemReset>().resetItem = ClickedItem;

            GameObject.Find("Cooler").GetComponent<Button>().interactable = true;
            GameObject.Find("ClickedItem").GetComponent<Button>().interactable = true;
            GameObject.Find("Etc").transform.GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(true);
            GameObject.Find("Etc").transform.GetChild(6).GetComponent<MouseFollow>().transform_icon.GetComponent<Image>().sprite = GameObject.Find("ClickedItem").GetComponent<Image>().sprite;
            GameObject.Find("Cooler").GetComponent<Cooler>().CoolerOn(ClickedItem);
            Debug.Log("냉침기 시작");
        }
        else
            Debug.Log("오류");

        //클릭 아이템 숫자 하나 줄어듦. -> 0일 경우에 슬롯 삭제되도록 설정.
        if (ClickedSlot.item.InvenItemNum >= 1)
        {
            ClickedSlot.item.InvenItemNum -= 1;
            ClickedSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = ClickedSlot.item.InvenItemNum.ToString() + "개 남음";
            if (ClickedSlot.item.InvenItemNum == 0)
            {
                ClickedSlot.itemName.text = "";
                ClickedSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
                ClickedSlot.item = null;
                ClickedSlot.image.enabled = false;
                ClickedSlot.gameObject.name = "Empty";
            }
        }
    }
    public void Update()
    {
        if (this.item != null && this.tag != "InvenSlot")
        {
            //Debug.Log("s");
            itemCount.text = item.itemCount.ToString() + "개 보유";
            if (item.itemCount <= 0)
            {
                this.itemPrice.text = "0";
                this.GetComponent<UnityEngine.UI.Button>().interactable = false;
                itemCount.text = "판매 완료";
            }
        }
    }
}
