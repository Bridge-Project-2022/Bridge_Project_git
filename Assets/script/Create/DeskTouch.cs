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
    public void TouchDesk()
    {
        if (FindObjectOfType<DialogueRandom>().makeStart == true)
        {
            GameObject.Find("Arrow").gameObject.SetActive(false);
            Buyer.gameObject.SetActive(false);
            GameObject.Find("Random_Buyer").gameObject.transform.position = new Vector3(-0.14f, 3.98f, -0.04f);

            desk = GameObject.Find("Desk").gameObject;
            desk.transform.localScale = new Vector3(20, 11, 1);
            Manufacture.gameObject.SetActive(true);
            inven = GameObject.Find("InvenUI").gameObject;
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
        GameObject.Find("Random_Buyer").gameObject.transform.position = new Vector3(-0.1f, 0.4f, 0.0f);
        Buyer.gameObject.SetActive(true);

        desk = GameObject.Find("Desk").gameObject;
        desk.transform.localScale = new Vector3(20, 4, 1);
        Manufacture.gameObject.SetActive(false);
        inven = GameObject.Find("InvenUI").gameObject;
        inven.transform.position = new Vector3(1651, 503, 0);
        isDeskUp = false;

        if(TotalScore.FindObjectOfType<TotalScore>().reputation == "verygood" || TotalScore.FindObjectOfType<TotalScore>().reputation == "good")
        {
            DialogueRandom.FindObjectOfType<DialogueRandom>().E_1_Start();

        }

        else if(TotalScore.FindObjectOfType<TotalScore>().reputation == "normal")
        {
             DialogueRandom.FindObjectOfType<DialogueRandom>().E_2_Start();
        }

        else if(TotalScore.FindObjectOfType<TotalScore>().reputation == "verybad" || TotalScore.FindObjectOfType<TotalScore>().reputation == "bad")
        {
             DialogueRandom.FindObjectOfType<DialogueRandom>().E_3_Start();
        }
    }
}
