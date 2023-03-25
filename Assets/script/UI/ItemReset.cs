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
        if (Inventory.GetComponent<Inventory>().isResetTrue == true)
        {
            GameObject.Find("InvenUI").GetComponent<Image>().sprite = Inventory.GetComponent<Inventory>().InvenOrigin;
            Inventory.GetComponent<Inventory>().isResetTrue = false;
            GameObject.Find("Cooler").GetComponent<Button>().interactable = false;
            GameObject.Find("Presser").GetComponent<Button>().interactable = false;
            GameObject.Find("Distiller").GetComponent<Button>().interactable = false;
            GameObject.Find("Etc").transform.GetChild(6).GetComponent<MouseFollow>().transform_icon.GetComponent<Image>().sprite = null;
            GameObject.Find("Etc").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
            Store.GetComponent<Store>().BuyNum = 1;
            Inventory.GetComponent<Inventory>().BuyItem(resetItem);
            this.transform.GetChild(0).GetComponent<Image>().sprite = null;
            Color color = this.transform.GetChild(0).GetComponent<Image>().color;
            color.a = 0;
            this.transform.GetChild(0).GetComponent<Image>().color = color;
            this.gameObject.SetActive(false);
        }
    }
}
