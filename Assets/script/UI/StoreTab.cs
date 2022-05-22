using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTab : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> contentsPanels;

    public void ClickTab(int id)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject BaseDetail = GameObject.Find("Store").transform.GetChild(0).GetChild(0).GetChild(5).gameObject;
        GameObject MiddleDetail = GameObject.Find("Store").transform.GetChild(0).GetChild(1).GetChild(5).gameObject;
        GameObject TopDetail = GameObject.Find("Store").transform.GetChild(0).GetChild(2).GetChild(5).gameObject;
        //탭 버튼 누를 때에 만약 슬롯 디테일 켜져있으면 다 끄기
        if (BaseDetail.activeSelf == true || MiddleDetail.activeSelf == true || TopDetail.activeSelf == true)
        {
            BaseDetail.SetActive(false);
            MiddleDetail.SetActive(false);
            TopDetail.SetActive(false);
        }
        for (int i = 0; i < contentsPanels.Count; i++)
        {
            if (i == id)
            {
                contentsPanels[i].SetActive(true);
            }
            else 
            {
                contentsPanels[i].SetActive(false);
            }
        }
    }

    public void ClickInvenTab(int id)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        for (int i = 0; i < contentsPanels.Count; i++)
        {
            if (i == id)
            {
                contentsPanels[i].SetActive(true);
            }
            else
            {
                contentsPanels[i].SetActive(false);
            }
        }
    }
}