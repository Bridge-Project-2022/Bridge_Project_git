using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NextDay : MonoBehaviour, IDataPersistence
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

    public GameObject Store;

    public GameObject NewsPanel;

    public Sprite[] NewsIMG = new Sprite[7];

    public AudioClip NewsBGM;
    public GameObject BGMSlider;
    public GameObject SFXSlider;

    private GameData gameData;

    public RectTransform BaseSlots;
    public RectTransform MiddleSlots;
    public RectTransform TopSlots;

    public void Start()
    {
        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;
    }

    public void DayCheck()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("DayFinish");
        DailyResult.GetComponent<Animator>().enabled = false;
        DailyResult.transform.localPosition = new Vector3(-2168, 1162, 0);

        //Debug.Log(day);
        if (day == 1)
        {
            NextDayClick();
        }
        else if (day == 2)
        {
            NextDayClick();
        }
        else if (day == 3)
        {
            NewsTimePanel();
        }
        else if (day == 4)
        {
            NewsTimePanel();
        }
        else if (day == 5)
        {
            NewsTimePanel();
        }
        else if (day == 6)
        {
            NewsTimePanel();
        }
        else if (day == 7)
        {
            GameObject.Find("popup").transform.GetChild(1).gameObject.SetActive(true);
            Invoke("GoToTitle", 3f);
        }
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
            Invoke("ThirdDayStart", 3f);
        }
        if (day == 4)
        {
            Invoke("FourthDayStart", 3f);
        }
        if (day == 5)
        {
            Invoke("FifthDayStart", 3f);
        }
        if (day == 6)
        {
            Invoke("SixthDayStart", 3f);
        }
        if (day == 7)
        {
            Invoke("SeventhDayStart", 3f);
        }
        if (day == 8)
        {
            GameObject.Find("popup").transform.GetChild(1).gameObject.SetActive(true);
            Invoke("GoToTitle", 3f);
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
    public void SaveData()
    {

    }
    public void NewsTimePanel()
    {
        NewsPanel.gameObject.SetActive(true);
        CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("news");
        NewsPanel.gameObject.GetComponent<Image>().sprite = NewsIMG[2];
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

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<DialogueRandom>().enabled = false;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();

        MiddleSlots.anchoredPosition = new Vector3(0, -28, 0); //-28, +306
        MiddleSlots.sizeDelta = new Vector2(1302, 780);
    }

    public void ThirdDayStart()
    {
        Today.text = "03";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<SecondDialogueRandom>().enabled = false;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();

        TopSlots.anchoredPosition = new Vector3(0, -28, 0);
        TopSlots.sizeDelta = new Vector2(1302, 780);
    }

    public void FourthDayStart()
    {
        Today.text = "04";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<ThirdDialogueRandom>().enabled = false;
        Trigger.GetComponent<FourthDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void FifthDayStart()
    {
        Today.text = "05";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<FourthDialogueRandom>().enabled = false;
        Trigger.GetComponent<FifthDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();

        MiddleSlots.anchoredPosition = new Vector3(0, -56, 0);
        MiddleSlots.sizeDelta = new Vector2(1302, 1086);
        TopSlots.anchoredPosition = new Vector3(0, -56, 0);
        TopSlots.sizeDelta = new Vector2(1302, 1086);
    }

    public void SixthDayStart()
    {
        Today.text = "06";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<FifthDialogueRandom>().enabled = false;
        Trigger.GetComponent<SixthDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void SeventhDayStart()
    {
        Today.text = "07";
        RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "morning";
        BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite;
        WindowBG.GetComponent<SpriteRenderer>().sprite = WD_Sprite;

        Store.GetComponent<Store>().openCnt = 0;
        GameObject Trigger = GameObject.Find("Trigger").gameObject;
        Trigger.GetComponent<SixthDialogueRandom>().enabled = false;
        Trigger.GetComponent<SeventhDialogueRandom>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void LoadData(GameData data)
    {
        this.day = data.day - 1;
        NextDayClick();
    }

    public void SaveData(ref GameData data)
    {
        data.day = this.day;
    }
}
