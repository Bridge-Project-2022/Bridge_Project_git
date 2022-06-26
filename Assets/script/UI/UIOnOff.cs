using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{

    public GameObject Store;
    public GameObject Inven;
    public void InvenOpen()
    {
        //Debug.Log("�κ��丮 ����");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("inven");
        Inven.gameObject.SetActive(true);

    }
    public void StoreOpen()
    {
        //Debug.Log("������ ����");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        Store.gameObject.SetActive(true);

    }

    public void StoreClose()
    {
        //Debug.Log("������ ����");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Customer").gameObject.SetActive(false);

    }

}
