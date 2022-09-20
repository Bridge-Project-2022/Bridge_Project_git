using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{

    public GameObject Store;
    public GameObject Inven;
    public void InvenOpen()
    {
        //Debug.Log("인벤토리 오픈");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("inven");
        Inven.gameObject.SetActive(true);
        Inven.transform.position = new Vector3(998, 540, 0);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

    }
    public void StoreOpen()
    {
        //Debug.Log("보따리 오픈");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        Store.gameObject.SetActive(true);

    }

    public void StoreClose()
    {
        //Debug.Log("보따리 닫음");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Customer").gameObject.SetActive(false);

    }

}
