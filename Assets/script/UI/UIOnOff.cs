using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{

    public GameObject Store;
    public GameObject Inven;
    public void InvenOpen()
    {
        Debug.Log("�κ��丮 ����");
        Inven.gameObject.SetActive(true);

    }
    public void StoreOpen()
    {
        Debug.Log("������ ����");
        Store.gameObject.SetActive(true);

    }

}
