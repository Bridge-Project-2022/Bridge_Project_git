using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemProperty item;
    public UnityEngine.UI.Image image;
    public GameObject itemPrice;
    public GameObject itemCount;

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
            itemPrice.gameObject.GetComponent<Text>().text = item.itemPrice.ToString();
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
            itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "개 보유";
        }
    }

    public void Update()
    {
        itemCount.gameObject.GetComponent<Text>().text = item.itemCount.ToString() + "개 보유";
        if (item.itemCount == 0)
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = false;
            itemCount.gameObject.GetComponent<Text>().text = "판매 완료";
        }
    }
}
