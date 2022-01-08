using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{

    public GameObject Store;
    public GameObject Inven;
    public void InvenOpen()
    {
        Debug.Log("인벤토리 오픈");
        Inven.gameObject.SetActive(true);

    }
    public void StoreOpen()
    {
        Debug.Log("보따리 오픈");
        Store.gameObject.SetActive(true);

    }

}
