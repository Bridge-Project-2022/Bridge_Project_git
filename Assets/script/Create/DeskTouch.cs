using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskTouch : MonoBehaviour
{
    public bool isDeskUp = false;
    GameObject inven;
    public GameObject Buyer;
    [SerializeField] 
    GameObject Manufacture;
    public GameObject baseSlot;
    public GameObject middleSlot;
    public GameObject topSlot;
    public GameObject TopBar;
    public GameObject MoneyBar;
    public GameObject Receipt;

    GameObject BackGround;
    GameObject BGWindow;
    GameObject deskBG;

    public GameObject InvenUI;
    GameObject RandomBuyer;
    public GameObject Customer;

    public GameObject ClickItem;

    public Sprite Alpa;
    private void Update()
    {
        RandomBuyer = GameObject.Find("Else").transform.GetChild(0).gameObject;
        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        BGWindow = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;
        deskBG = GameObject.Find("BGIMG").transform.GetChild(2).gameObject;
    }
    public void TouchDesk()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        this.transform.GetChild(0).gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        TopBar.transform.Translate(new Vector3(200, 200, 0));
        MoneyBar.transform.Translate(new Vector3(200, 200, 0));

        Receipt.gameObject.SetActive(true);
        Customer.SetActive(false);
        BackGround.gameObject.SetActive(false);
        BGWindow.gameObject.SetActive(false);

        deskBG.gameObject.SetActive(true);
        GameObject.Find("Etc").transform.GetChild(2).gameObject.SetActive(false);

        Manufacture.gameObject.SetActive(true);
        inven = InvenUI.gameObject;
        inven.gameObject.SetActive(true);
        isDeskUp = true;

        for (int i = 0; i < baseSlot.transform.childCount; i++)
        {
            baseSlot.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < middleSlot.transform.childCount; i++)
        {
            middleSlot.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
        for (int i = 0; i < topSlot.transform.childCount; i++)
        {
            topSlot.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("create_asmr");

        Timer.FindObjectOfType<Timer>().isTimerStart = true;
    }

    public void TouchPerfume()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutResult == false)
        {
            TotalScore.FindObjectOfType<TotalScore>().isAllFinished = true;
            Customer.gameObject.SetActive(true);
            TopBar.transform.Translate(new Vector3(-200, -200, 0));
            MoneyBar.transform.Translate(new Vector3(-200, -200, 0));

            Receipt.gameObject.SetActive(false);

            BackGround.gameObject.SetActive(true);
            BGWindow.gameObject.SetActive(true);
            deskBG.gameObject.SetActive(false);

            inven.gameObject.SetActive(false);

            RandomBuyer.gameObject.SetActive(true);
            Buyer.gameObject.SetActive(true);

            ClickItem.SetActive(false);

            GameObject.Find("Perfume").GetComponent<PerfumeColor>().PerfumeReset();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("perfumeTouch");
            GameObject.Find("Etc").transform.GetChild(2).gameObject.SetActive(true);
            Manufacture.gameObject.SetActive(false);

            isDeskUp = false;
            Invoke("PerfumeDialogue", 0.3f);
        }
        else
        {
            TopBar.transform.Translate(new Vector3(-200, -200, 0));
            MoneyBar.transform.Translate(new Vector3(-200, -200, 0));

            Receipt.gameObject.SetActive(false);

            BackGround.gameObject.SetActive(true);
            BGWindow.gameObject.SetActive(true);
            deskBG.gameObject.SetActive(false);

            inven.gameObject.SetActive(false);

            ClickItem.SetActive(false);

            GameObject.Find("Perfume").GetComponent<PerfumeColor>().PerfumeReset();
            GameObject.Find("Etc").transform.GetChild(2).gameObject.SetActive(true);
            Manufacture.gameObject.SetActive(false);
            isDeskUp = false;
            Invoke("PerfumeDialogue", 0.3f);
        }
    }

    public void PerfumeDialogue()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutResult == false)
        {
            DayCheck.FindObjectOfType<DayCheck>().E1_Check();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("main");
        }
        else
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("main");
    }
}