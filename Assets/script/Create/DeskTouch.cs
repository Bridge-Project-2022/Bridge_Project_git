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

    public GameObject BackGround;
    public GameObject BGWindow;
    public GameObject deskBG;

    public GameObject InvenUI;
    public GameObject RandomBuyer;

    public void TouchDesk()
    {
        if (FindObjectOfType<DialogueRandom>().makeStart == true)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
            GameObject.Find("Arrow").gameObject.SetActive(false);
            Buyer.gameObject.SetActive(false);
            //GameObject.Find("Random_Buyer").gameObject.transform.position = new Vector3(-0.14f, 3.98f, -0.04f);
            GameObject.Find("Random_Buyer").gameObject.SetActive(false);
            //BackGround.transform.position = new Vector3(0, 1.98f, 0);
            BackGround.gameObject.SetActive(false);
            BGWindow.gameObject.SetActive(false);

            deskBG.gameObject.SetActive(true);
            desk = GameObject.Find("Desk").gameObject;
            desk.gameObject.SetActive(false);
            //desk.transform.localScale = new Vector3(20, 11, 1);
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
    }

    public void TouchPerfume()
    {
        BackGround.gameObject.SetActive(true);
        BGWindow.gameObject.SetActive(true);
        deskBG.gameObject.SetActive(false);

        inven.gameObject.SetActive(false);
        //GameObject.Find("Random_Buyer").gameObject.transform.position = new Vector3(-0.1f, 0.4f, 0.0f);
        RandomBuyer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);

        //desk.transform.localScale = new Vector3(20, 4, 1);
        desk.gameObject.SetActive(true);
        Manufacture.gameObject.SetActive(false);
        //inven = GameObject.Find("InvenUI").gameObject;
        //inven.transform.position = new Vector3(1651, 503, 0);
        isDeskUp = false;
        Invoke("PerfumeDialogue", 0.3f);
      
    }

    public void PerfumeDialogue()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        DialogueRandom.FindObjectOfType<DialogueRandom>().E_1_Start();
    }
}
