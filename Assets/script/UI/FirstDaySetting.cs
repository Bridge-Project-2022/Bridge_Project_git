using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstDaySetting : MonoBehaviour
{
    public int Day = 1;
    public int Time = 8;
    public int Money = 50000;
    public int Reputation = 60;

    public GameObject GameMoney;
    public GameObject GameReputation;


    private void Update()
    {
       GameMoney.gameObject.GetComponent<Text>().text = Money.ToString();
       GameReputation.gameObject.GetComponent<Text>().text = Reputation.ToString();

        if (Reputation < 0)
        { 
            //배드 엔딩 ㄱ
        }
    }
}
