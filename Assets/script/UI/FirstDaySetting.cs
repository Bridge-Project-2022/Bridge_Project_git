using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstDaySetting : MonoBehaviour
{
    public int Time = 8;
    public int Money = 50000;
    public int Reputation = 60;

    public TextMeshProUGUI GameMoney;
    public GameObject GameReputation;
    public GameObject Customer;

    string[] CustomerTxt = new string[2];

    public void Start()
    {
        CustomerTxt[0] = "오늘 가져온 향료 좀 볼텐가?";
        CustomerTxt[1] = "더 필요한 물건이 있나?";

        if (GameObject.Find("NextDay").GetComponent<NextDay>().day == 1)
        {
            GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(false);
            Invoke("FirstDayStart", 6f);
        }
    }
    private void Update()
    {
        GameMoney.text = Money.ToString();
        GameReputation.gameObject.GetComponent<Text>().text = Reputation.ToString();

        if (Reputation < 0)
        { 
            //배드 엔딩 ㄱ
        }
    }

    public void FirstDayStart()
    {
        GameObject.Find("FirstDayPanel").gameObject.SetActive(false);
        GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(true);
        Invoke("SellerStart", 1f);
    }

    public void SellerStart()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Invoke("SellerSpeak", 1f);
    }

    public void SellerSpeak()
    {
        Customer.gameObject.SetActive(true);
        StartCoroutine(NormalChat(CustomerTxt[0]));
    }
    public void SellerEnd()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
        Customer.gameObject.SetActive(true);
        StartCoroutine(NormalChat(CustomerTxt[1]));
    }

    IEnumerator NormalChat(string narration)// 타이핑 효과 -> 여기서 향의 세기에 따른 증류기 로직 결정 가능
    {
        string writerText = "";
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");

        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");

            Customer.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

}
