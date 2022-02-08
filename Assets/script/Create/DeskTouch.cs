using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskTouch : MonoBehaviour
{
    public bool isDeskUp = false;
    GameObject desk;
    GameObject inven;
    [SerializeField] 
    GameObject Manufacture;
    public void TouchDesk()
    {
        if (FindObjectOfType<DialogueRandom>().makeStart == true)
        {
            GameObject.Find("Arrow").gameObject.SetActive(false);
            GameObject.Find("buyer").gameObject.SetActive(false);
            GameObject.Find("Random_Buyer").gameObject.transform.position = new Vector3(-0.14f, 3.98f, -0.04f);

            //SceneManager.LoadScene("Manufacture");
            desk = GameObject.Find("Desk").gameObject;
            desk.transform.localScale = new Vector3(20, 11, 1);
            Manufacture.gameObject.SetActive(true);
            inven = GameObject.Find("InvenUI").gameObject;
            inven.transform.position = new Vector3(300, 400, 0);
            isDeskUp = true;
        }
    }
}
