using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReset : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Store;
    public ItemProperty resetItem;

    public void itemReset()
    {
        Store.GetComponent<Store>().BuyNum = 1;
        Inventory.GetComponent<Inventory>().BuyItem(resetItem);
        this.GetComponent<Image>().sprite = null;
        Color color = this.GetComponent<Image>().color;
        color.a = 0;
        this.GetComponent<Image>().color = color;

    }
}
