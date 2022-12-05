using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NextDay : MonoBehaviour
{
    public int day = 1;
    public GameObject DailyResult;
    public GameObject RandomBuyer;
    public GameObject buyer;
    public GameObject Customer;
    public TextMeshProUGUI Today;
    public GameObject DayPanel;
    public GameObject DayPanelDay1;
    public GameObject DayPanelDay2;
    public GameObject Declaration;

    public Sprite BG_Sprite;
    public Sprite WD_Sprite;

    GameObject BackGround;
    GameObject WindowBG;

    string[] CustomerTxt = new string[2];

    public void Start()
    {
        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;
    }
    public void NextDayClick()
    {
        Declaration.gameObject.SetActive(false);
        Customer.gameObject.SetActive(false);
        CustomerTxt[0] = "오늘 가져온 향료 좀 볼텐가?";
        CustomerTxt[1] = "더 필요한 물건이 있나?";

        DayPanel.gameObject.SetActive(true);
        GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(false);
        DayPanelDay1.GetComponent<TextMeshProUGUI>().text = (day + 1).ToString();
        DayPanelDay2.GetComponent<TextMeshProUGUI>().text = (day + 1).ToString();
        Invoke("DayStartPanel", 6f);

        DailyResult.GetComponent<DailyResult>().personNum = 0;
        DailyResult.GetComponent<DailyResult>().rejectNum = 0;
        DailyResult.GetComponent<DailyResult>().todayReputation = 0;
        DailyResult.GetComponent<DailyResult>().todayRevenue = 0;
        DailyResult.GetComponent<DailyResult>().originCost = 0;
        DailyResult.GetComponent<DailyResult>().allRevenue = 0;

        RandomBuyer.SetActive(false);
        buyer.SetActive(false);

        day++;
        if (day == 2)
        {
            Invoke("SecondDayStart", 3f);
        }
        if (day == 3)
        {
            GameObject.Find("popup").transform.GetChild(1).gameObject.SetActive(true);
            Invoke("GoToTitle", 3f);
            //Invoke("ThirdDayStart", 3f);
        }
        if (day == 4)
        {
            Invoke("FourthDayStart", 3f);
        }
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void DayStartPanel()
    {
        DayPanel.gameObject.SetActive(false);
        GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>().gameObject.SetActive(true);
        Invoke("SellerStart", 2f);

    }

    public void SellerStart()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Customer.gameObject.SetActive(true);
        StartCoroutine(NormalChat(CustomerTxt[0]));
    }
    public void SellerEnd()
    {
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

    public void SecondDayStart()
    {
        Today.text = "02";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<DialogueRandom>().enabled = false;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void ThirdDayStart()
    {
        Today.text = "03";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = false;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void FourthDayStart()
    {
        Today.text = "04";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = false;
        Trigger.GetComponent<FourthDialogueRandom>().enabled = true;
        TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }
}
