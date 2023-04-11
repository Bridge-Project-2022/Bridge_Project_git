using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NextDay : Singleton<NextDay>
{
    //public int day = 1;
    public GameObject DailyResult;
    public GameObject RandomBuyer;
    public GameObject buyer;
    public GameObject Customer;
    public TextMeshProUGUI Today;
    public GameObject DayPanel;
    public GameObject DayPanelDay1;
    public GameObject DayPanelDay2;
    public GameObject Declaration;
    public Slider bgmSlider;
    public Slider sfxSlider;
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

        Invoke("MoveSceneLoad", 1f);
    }

    public void MoveSceneLoad()
    {
        SceneManager.LoadScene("MoveSystem");
    }

    public void DayCheckTest()
    {
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("DayFinish");
        DailyResult.GetComponent<Animator>().enabled = false;
        DailyResult.transform.localPosition = new Vector3(-2168, 1162, 0);

        if (GameDataManager.Instance.Day == 1)
        {
            //GameDataManager.Instance.Day++;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
            Invoke("NewsTimePanel", 2f);
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            //GameDataManager.Instance.Day++;
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().enabled = false;
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
        DayPanelDay1.GetComponent<TextMeshProUGUI>().text = (GameDataManager.Instance.Day).ToString();
        DayPanelDay2.GetComponent<TextMeshProUGUI>().text = (GameDataManager.Instance.Day).ToString();
        Invoke("DayStartPanel", 6f);

        DailyResult.GetComponent<DailyResult>().personNum = 0;
        DailyResult.GetComponent<DailyResult>().rejectNum = 0;
        DailyResult.GetComponent<DailyResult>().todayReputation = 0;
        DailyResult.GetComponent<DailyResult>().todayRevenue = 0;
        DailyResult.GetComponent<DailyResult>().originCost = 0;
        DailyResult.GetComponent<DailyResult>().allRevenue = 0;

        RandomBuyer.SetActive(false);
        buyer.SetActive(false);

        if (GameDataManager.Instance.Day == 2)
        {
            Invoke("SecondDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 3)
        {
            Invoke("ThirdDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 4)
        {
            Invoke("FourthDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 5)
        {
            Invoke("FifthDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("popup").transform.GetChild(1).gameObject.SetActive(true);
            Invoke("GoToTitle", 3f);
            //Invoke("SixthDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 7)
        {
            Invoke("SeventhDayStart", 3f);
        }
        if (GameDataManager.Instance.Day == 8)
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
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("main");
        Invoke("SellerStart", 2f);

    }
    public void NewsTimePanel()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayBGM("news");
        NewsPanel.gameObject.SetActive(true);
        if (GameDataManager.Instance.Day == 1)
        {
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[0];
        }
        if (GameDataManager.Instance.Day == 2)
        {
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[1];
        }
        if (GameDataManager.Instance.Day == 3)
        {
            NewsPanel.transform.GetChild(0).gameObject.SetActive(true);
            CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[2];
        }
        if (GameDataManager.Instance.Day == 4)
        {
            NewsPanel.transform.GetChild(0).gameObject.SetActive(true);
            CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[3];
        }
        if (GameDataManager.Instance.Day == 5)
        {
            NewsPanel.transform.GetChild(0).gameObject.SetActive(true);
            CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[4];
        }
        if (GameDataManager.Instance.Day == 6)
        {
            NewsPanel.transform.GetChild(0).gameObject.SetActive(true);
            CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[5];
        }
        if (GameDataManager.Instance.Day == 7)
        {
            NewsPanel.transform.GetChild(0).gameObject.SetActive(true);
            CriminalSystem.FindObjectOfType<CriminalSystem>().MontageShow();
            NewsPanel.GetComponent<Image>().sprite = NewsIMG[6];
        }
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

    IEnumerator NormalChat(string narration)// Ÿ���� ȿ�� -> ���⼭ ���� ���⿡ ���� ������ ���� ���� ����
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
        GameObject.Find("DialogueScript1").GetComponent<DialogueScript>().enabled = false;
        GameObject.Find("DialogueScript2").GetComponent<SecondDialogueScript>().enabled = true;
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
        GameObject.Find("DialogueScript2").GetComponent<SecondDialogueScript>().enabled = false;
        GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().enabled = true;
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
        GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().enabled = false;
        GameObject.Find("DialogueScript4").GetComponent<FourthDialogueScript>().enabled = true;
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
        GameObject.Find("DialogueScript4").GetComponent<FourthDialogueScript>().enabled = false;
        GameObject.Find("DialogueScript5").GetComponent<FifthDialogueScript>().enabled = true;
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
        GameObject.Find("DialogueScript5").GetComponent<FifthDialogueScript>().enabled = false;
        GameObject.Find("DialogueScript6").GetComponent<SixthDialogueScript>().enabled = true;
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
        GameObject.Find("DialogueScript6").GetComponent<SixthDialogueScript>().enabled = false;
        GameObject.Find("DialogueScript7").GetComponent<SeventhDialogueScript>().enabled = true;
        //TopBar.FindObjectOfType<TopBar>().DayBtnClose();
    }

    public void LoadData(GameData data)
    {
        GameDataManager.Instance.Day = data.day - 1;
        NextDayClick();
    }

    public void SaveData(ref GameData data)
    {
        data.day = GameDataManager.Instance.Day;
    }

    public void ClickSaveBtn()
    {
        GameDataManager.Instance.SFX = sfxSlider.value;
        GameDataManager.Instance.BGM = bgmSlider.value;
        GameDataManager.Instance.SaveData();
    }
}
