using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstDaySetting : MonoBehaviour, IDataPersistence
{
    public int Time = 8;
    //public int Money = 10000;
    //public int Reputation = 60;

    public TextMeshProUGUI GameMoney;
    public GameObject GameReputation;
    public GameObject Customer;
    public GameObject TutorialPanel;

    string[] CustomerTxt = new string[2];

    public void FirstStart()
    {
        CustomerTxt[0] = "오늘 가져온 향료 좀 볼텐가?";
        CustomerTxt[1] = "더 필요한 물건이 있나?";

        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(false);
            Invoke("FirstDayStart", 8f);
        }
        
    }
    private void Update()
    {
        
        GameMoney.text = GameDataManager.Instance.Money.ToString();
        GameReputation.gameObject.GetComponent<Text>().text = GameDataManager.Instance.Reputation.ToString();

        if (GameDataManager.Instance.Reputation < 0)
        { 
            //배드 엔딩 ㄱ
        }
    }

    public void FirstDayStart()
    {
        GameObject.Find("FirstDayPanel").gameObject.SetActive(false);
        GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(true);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("main");
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
        TutorialPanel.SetActive(true);
        TutorialPanel.GetComponent<Tutorial>().StartDialogue();
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
        if(GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutBuy == false)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            Customer.gameObject.SetActive(true);
            StartCoroutine(NormalChat(CustomerTxt[1]));
        }
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

    public void LoadData(GameData data)
    {
        GameDataManager.Instance.Money = data.money;
        GameDataManager.Instance.Reputation = data.reputation;
        GameObject.Find("ReputationSlider").GetComponent<Slider>().value = data.reputationValue;
        if (GameDataManager.Instance.Reputation <= 30)
        {
            GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationBad;
        }
        else if (GameDataManager.Instance.Reputation <= 60 && GameDataManager.Instance.Reputation > 30)
        {
            GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationNormal;
        }
        else if (GameDataManager.Instance.Reputation > 60)
        {
            GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationGood;
        }
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("a");
        data.money = GameDataManager.Instance.Money;
        data.reputation = GameDataManager.Instance.Reputation;
        data.reputationValue = GameObject.Find("ReputationSlider").GetComponent<Slider>().value;
    }
}
