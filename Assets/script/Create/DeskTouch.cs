using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskTouch : MonoBehaviour
{
    public bool isDeskUp = false;
    GameObject desk;
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
        GameObject.Find("Arrow").gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        TopBar.transform.Translate(new Vector3(200, 200, 0));
        MoneyBar.transform.Translate(new Vector3(200, 200, 0));

        //GameObject.Find("Declaration").gameObject.SetActive(false);
        Receipt.gameObject.SetActive(true);
        GameObject.Find("Random_Buyer").gameObject.SetActive(false);
        BackGround.gameObject.SetActive(false);
        BGWindow.gameObject.SetActive(false);

        deskBG.gameObject.SetActive(true);
        desk = GameObject.Find("Desk").gameObject;
        desk.gameObject.SetActive(false);

        Manufacture.gameObject.SetActive(true);
        inven = InvenUI.gameObject;
        inven.gameObject.SetActive(true);
        inven.transform.position = new Vector3(300, 400, 0);
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


        Timer.FindObjectOfType<Timer>().isTimerStart = true;
    }

    public void TouchPerfume()
    {
        //Invoke("feelStart", 0.4f);
        
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

        GameObject.Find("LiquidColor").GetComponent<PerfumeColor>().PerfumeReset();

        desk.gameObject.SetActive(true);
        Manufacture.gameObject.SetActive(false);

        isDeskUp = false;
        Invoke("PerfumeDialogue", 0.3f);
    }

    public void PerfumeDialogue()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        DayCheck.FindObjectOfType<DayCheck>().E1_Check();
    }
    public void feelStart()
    {
        //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = GameObject.Find("RC").GetComponent<CustomerFeel>().Customer_Feel[0];
    }
}