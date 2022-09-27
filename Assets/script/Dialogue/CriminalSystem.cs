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
                Debug.Log(newsTime.GetComponent<NewsTime>().randomResult1 + "바뀌고"
                + newsTime.GetComponent<NewsTime>().randomResult2 + "바뀜!");
            }
            else
            {
                Debug.Log(newsTime.GetComponent<NewsTime>().randomResult1 + "바뀌고"
                    + newsTime.GetComponent<NewsTime>().randomResult2 + "바뀌고"
                    + newsTime.GetComponent<NewsTime>().randomResult3 + "바뀜!");
            }
        }
    }
}
