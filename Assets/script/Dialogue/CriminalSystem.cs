using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalSystem : MonoBehaviour
{
    public bool isCriminalStart = false;
    public GameObject newsTime;
    
    public void Update()
    {
        if (isCriminalStart == true)
        {
            if (newsTime.GetComponent<NewsTime>().randomNum == 2)
            {
                Debug.Log(newsTime.GetComponent<NewsTime>().randomResult1 + "�ٲ��"
                + newsTime.GetComponent<NewsTime>().randomResult2 + "�ٲ�!");
            }
            else
            {
                Debug.Log(newsTime.GetComponent<NewsTime>().randomResult1 + "�ٲ��"
                    + newsTime.GetComponent<NewsTime>().randomResult2 + "�ٲ��"
                    + newsTime.GetComponent<NewsTime>().randomResult3 + "�ٲ�!");
            }
        }
    }
}
