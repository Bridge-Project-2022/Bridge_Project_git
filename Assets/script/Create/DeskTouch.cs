using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskTouch : MonoBehaviour
{
    public bool isDeskUp = false;
    GameObject desk;
    GameObject inven;
    public GameObject Buyer;
    [SerializeField] 
    GameObject Manufacture;
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

        DialogueRandom.FindObjectOfType<DialogueRandom>().E_1_Start();
        /*if(평판 == GOOD)
        {
            DialogueRandom.FindObjectOfType<DialogueRandom>().E_1_Start();
        }

        else if(평판 == NORMAL)
        {
              DialogueRandom.FindObjectOfType<DialogueRandom>().E_2_Start();
        }

        else if(평판 == BAD)
        {
              DialogueRandom.FindObjectOfType<DialogueRandom>().E_3_Start();
        }

        */
    }
}
