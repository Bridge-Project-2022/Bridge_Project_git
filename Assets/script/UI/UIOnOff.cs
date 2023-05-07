using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class UIOnOff : MonoBehaviour
{
    public GameObject Store;
    public GameObject Inven;
    public GameObject InvenStoreBtn;
    public Sprite InvenImg;
    public Sprite StoreImg;
    public bool isInvenClick = false;
    public void InvenOpen()
    {
        //Debug.Log("인벤토리 오픈");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("inven");
        Inven.SetActive(true);
        Inven.transform.position = new Vector3(960, 540, 0);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Inventory").transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

    }
    public void StoreOpen()
    {
        if (GameObject.Find("Etc").transform.GetChild(9).gameObject.GetComponent<Image>().sprite.name == "향료 아저씨")
        {
            Inven.transform.position = new Vector3(960, 540, 0);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        GameObject.Find("Etc").transform.GetChild(9).gameObject.SetActive(true);
        //Debug.Log("보따리 오픈");
        FirstDaySetting.FindObjectOfType<FirstDaySetting>().StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        Store.SetActive(true);
    }

    public void StoreClose()
    {
        //Debug.Log("보따리 닫음");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Customer").gameObject.SetActive(false);

    }

    public void StoreToInven()
    {
        if (isInvenClick == false)
        {
            InvenStoreBtn.GetComponent<Image>().sprite = StoreImg;
            InvenStoreBtn.GetComponent<Image>().SetNativeSize();
            InvenStoreBtn.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
            GameObject.Find("Store").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Store").transform.GetChild(2).gameObject.SetActive(false);
            Inven.transform.position = new Vector3(960, 540, 0);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Inventory").transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            isInvenClick = true;
        }
        else
        {
            InvenStoreBtn.GetComponent<Image>().sprite = InvenImg;
            InvenStoreBtn.GetComponent<Image>().SetNativeSize();
            InvenStoreBtn.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
            GameObject.Find("Store").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Store").transform.GetChild(2).gameObject.SetActive(true);
            Inven.transform.position = new Vector3(1038, 3000, 0);
            isInvenClick = false;
        }
    }

    public void YesBold()
    {
        GameObject.Find("Customer").transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 40;
    }
    public void YesRegular()
    {
        GameObject.Find("Customer").transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 30;
    }
    public void NoBold()
    {
        GameObject.Find("Customer").transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 35;
    }
    public void NoRegular()
    {
        GameObject.Find("Customer").transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 30;
    }


}
