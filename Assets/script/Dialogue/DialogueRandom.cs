<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueRandom : MonoBehaviour
{
    //public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public GameObject DailyResult;

    GameObject BackGround;
    GameObject WindowBG;

    public TextMeshProUGUI BuyerDialogue;

    public bool isDialogueEnd = false;

    //public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//°ÅÀı È½¼ö -> ÆòÆÇ ¿µÇâ, ÀÏÂ÷ Áö³¯ ¶§ ¸¶´Ù ¸®¼ÂµÇ¾î¾ß ÇÔ.

    int C_1_random;
    int C_2_random;

    public string[] SellerSentences = new string[2];// À¯Àú ´ëÈ­ ¹è¿­

    DialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];
    public string[] BuyerFeel = new string[10];

    public Sprite[] BG_Sprite = new Sprite[5];

    public bool AStart = false;
    public bool D1Start = false;
    public bool D2Start = false;
    public bool EStart = false;

    int ACount = 0;
    int D1Count = 0;
    int D2Count = 0;
    int ECount = 0;
    public int FeelCnt = 0;

    public bool isDialogueStart = false;

    bool isSelectStart = false;
    bool isArrowStart = false;

    public void Update()
    {
        
        DS = GameObject.Find("DialogueScript1").GetComponent<DialogueScript>();

        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;

        for (int i = 0; i < BuyerOrder.Length; i++)
        {
            BuyerOrder[i] = DS.Customer_PerfumeOrder[i];
        }

        for (int i = 0; i < BuyerIntensity.Length; i++)
        {
            BuyerIntensity[i] = DS.Customer_IntensityOrder[i];
        }

        for (int i = 0; i < BuyerRejectReaction.Length; i++)
        {
            BuyerRejectReaction[i] = DS.Customer_RejectReaction[i];
        }

        for (int i = 0; i < BuyerPerfumeReaction.Length; i++)
        {
            BuyerPerfumeReaction[i] = DS.Customer_PerfumeReaction[i];
        }
        for (int i = 0; i < BuyerFeel.Length; i++)
        {
            BuyerFeel[i] = GameObject.Find("RC").GetComponent<CustomerFeel>().Customer_Feel[i];
        }

        Distiller.GetComponent<Distiller>().BaseItemName = DS.Customer_Flavoring[0];
        Presser.GetComponent<Presser>().MiddleItemName = DS.Customer_Flavoring[1];
        Cooler.GetComponent<Cooler>().TopItemName = DS.Customer_Flavoring[2];

        if (isDialogueEnd == true)
        {
            if (isSelectStart == true)
            {
                Select.gameObject.SetActive(true);
            }
            if (isArrowStart == true)
            {
                arrow.gameObject.SetActive(true);
            }
        }
        else
        {
            if (isSelectStart == false)
            {
                Select.gameObject.SetActive(false);
            }
            if (isArrowStart == false)
            {
                arrow.gameObject.SetActive(false);
            }
        }
    }
    public void NextDialogue()
    {
        StopAll();
        RandomImage.FindObjectOfType<RandomImage>().CurrentFeel = BuyerFeel[FeelCnt];
        FeelCnt++;

        if (AStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerOrder[ACount]));
            ACount++;

            if (BuyerOrder[ACount] == "")
            {
                //Debug.Log("A³¡³²");
                isSelectStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                ACount = 0;
                AStart = false;
            }
        }
        if (D1Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
            D1Count++;

            if (BuyerIntensity[D1Count] == "")
            {
                //Debug.Log("D1³¡³²");
                isArrowStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                D1Count = 0;
                D1Start = false;
            }
        }
        if (D2Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
            D2Count++;

            if (BuyerRejectReaction[D2Count] == "")
            {
                //Debug.Log("D2³¡³²");
                D2Count = 0;
                D2Start = false;
                Invoke("End", 2f);
            }
        }
        if (EStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerPerfumeReaction[ECount]));
            ECount++;

            if (BuyerPerfumeReaction[ECount] == "")
            {
                //Debug.Log("E³¡³²");
                ECount = 0;
                EStart = false;
                Invoke("End", 2f);
            }
        }
    }
   

    public void A_Start()//¼Õ´Ô : ÀÔÀå, Çâ¼ö ±¸¸Å ÀÌÀ¯ Á¦½Ã
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);

        AStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void C_1_Start()// À¯Àú : ½Â³« - Çâ ¼¼±â Áú¹®
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 0.3f);
    }

    public void C_2_Start()//À¯Àú : °ÅºÎ - °ÅºÎ ÀÌÀ¯ Á¦½Ã
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().rejectNum += 1;
        float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        rejectCnt += 1;
        if (rejectCnt == 1)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
            

        else if (rejectCnt == 2)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
        if (rejectCnt >= 3)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }

        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 0.3f);
    }

    public void D_1_Start()//¼Õ´Ô : ½Â³« - Çâ ¼¼±â °áÁ¤
    {
        Buyer.gameObject.SetActive(true);
        //Seller.gameObject.SetActive(false);
        //makeStart = true;
        D1Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void D_2_Start()// ¼Õ´Ô : °ÅºÎ - ºÒ¸¸ Ç¥Ãâ
    {
        //Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);

        D2Start = true;
        isDialogueStart = true;
        NextDialogue();
    }


    public void E_1_Start()//¼Õ´Ô : Çâ¼ö ¹Ş°í ¹İÀÀ
    {
        isArrowStart = false;
        EStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void End()
    {
        //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "basic";
        isDialogueStart = false;
        int temp;
        temp = DS.Customer_ID[0];

        for (int i = 0; i < DS.Customer_ID.Length - 1; i++)
        {
            DS.Customer_ID[i] = DS.Customer_ID[i + 1];
        }
        DS.Customer_ID[DS.Customer_ID.Length - 1] = temp;

        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum < 9)
        {
            if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 3)//¼Õ´Ô 3¸í °¡°í ³ª¼­ Á¡½ÉÀ¸·Î ¹Ù²ñ
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "afternoon";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[4];

            }
            else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 6)//¼Õ´Ô 6¸í °¡°í ³ª¼­ Àú³áÀ¸·Î ¹Ù²ñ
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "night";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[5];
            }

            Invoke("A_Start", 5f);//¼Õ´Ô °¡°í 5ÃÊ µÚ¿¡ ´ÙÀ½ ¼Õ´Ô µîÀå. ÀÎ°ÔÀÓ ½Ã°£ º¸°í Ãß°¡ Á¶°Ç¹® ´Ş¾Æ¾ß ÇÔ
        }
        

        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 9)//¼Õ´Ô 9¸í °¡°í ³ª¼­ ÃÖÁ¾ Ã¢ÀÌ ¶ä.
        {
            Invoke("DailyWindowOpen", 3f);
        }
    }

    public void DailyWindowOpen()
    {
        DailyResult.gameObject.SetActive(true);
    }
    IEnumerator NormalChat(string narration)// Å¸ÀÌÇÎ È¿°ú -> ¿©±â¼­ ÇâÀÇ ¼¼±â¿¡ µû¸¥ Áõ·ù±â ·ÎÁ÷ °áÁ¤ °¡´É
    {
        string writerText = "";
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
                isDialogueEnd = true;
            else
                isDialogueEnd = false;
            BuyerDialogue.text = writerText;
            //SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    IEnumerator Count(float target, float current)

    {
        float duration = 0.5f; // Ä«¿îÆÃ¿¡ °É¸®´Â ½Ã°£ ¼³Á¤. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            GameObject.Find("reputation_num").GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        GameObject.Find("reputation_num").GetComponent<TextMeshProUGUI>().text = ((int)current).ToString();

    }

    public void StopAll()
    {
        StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

}

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueRandom : MonoBehaviour
{
    //public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public GameObject DailyResult;

    GameObject BackGround;
    GameObject WindowBG;

    public TextMeshProUGUI BuyerDialogue;

    public bool isDialogueEnd = false;

    //public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//ê±°ì ˆ íšŸìˆ˜ -> í‰íŒ ì˜í–¥, ì¼ì°¨ ì§€ë‚  ë•Œ ë§ˆë‹¤ ë¦¬ì…‹ë˜ì–´ì•¼ í•¨.

    int C_1_random;
    int C_2_random;

    public string[] SellerSentences = new string[2];// ìœ ì € ëŒ€í™” ë°°ì—´

    DialogueScript DS;

    public string[] BuyerOrder = new string[10];
    public string[] BuyerIntensity = new string[5];
    public string[] BuyerRejectReaction = new string[5];
    public string[] BuyerPerfumeReaction = new string[5];
    public string[] BuyerFeel = new string[10];

    public Sprite[] BG_Sprite = new Sprite[5];

    public bool AStart = false;
    public bool D1Start = false;
    public bool D2Start = false;
    public bool EStart = false;

    int ACount = 0;
    int D1Count = 0;
    int D2Count = 0;
    int ECount = 0;
    public int FeelCnt = 0;

    public bool isDialogueStart = false;

    bool isSelectStart = false;
    bool isArrowStart = false;

    public void Update()
    {
        
        DS = GameObject.Find("DialogueScript1").GetComponent<DialogueScript>();

        BackGround = GameObject.Find("BGIMG").transform.GetChild(0).gameObject;
        WindowBG = GameObject.Find("BGIMG").transform.GetChild(1).gameObject;

        for (int i = 0; i < BuyerOrder.Length; i++)
        {
            BuyerOrder[i] = DS.Customer_PerfumeOrder[i];
        }

        for (int i = 0; i < BuyerIntensity.Length; i++)
        {
            BuyerIntensity[i] = DS.Customer_IntensityOrder[i];
        }

        for (int i = 0; i < BuyerRejectReaction.Length; i++)
        {
            BuyerRejectReaction[i] = DS.Customer_RejectReaction[i];
        }

        for (int i = 0; i < BuyerPerfumeReaction.Length; i++)
        {
            BuyerPerfumeReaction[i] = DS.Customer_PerfumeReaction[i];
        }
        for (int i = 0; i < BuyerFeel.Length; i++)
        {
            BuyerFeel[i] = GameObject.Find("RC").GetComponent<CustomerFeel>().Customer_Feel[i];
        }

        Distiller.GetComponent<Distiller>().BaseItemName = DS.Customer_Flavoring[0];
        Presser.GetComponent<Presser>().MiddleItemName = DS.Customer_Flavoring[1];
        Cooler.GetComponent<Cooler>().TopItemName = DS.Customer_Flavoring[2];

        if (isDialogueEnd == true)
        {
            if (isSelectStart == true)
            {
                Select.gameObject.SetActive(true);
            }
            if (isArrowStart == true)
            {
                arrow.gameObject.SetActive(true);
            }
        }
        else
        {
            if (isSelectStart == false)
            {
                Select.gameObject.SetActive(false);
            }
            if (isArrowStart == false)
            {
                arrow.gameObject.SetActive(false);
            }
        }
    }
    public void NextDialogue()
    {
        StopAll();
        RandomImage.FindObjectOfType<RandomImage>().CurrentFeel = BuyerFeel[FeelCnt];
        FeelCnt++;

        if (AStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerOrder[ACount]));
            ACount++;

            if (BuyerOrder[ACount] == "")
            {
                //Debug.Log("Aëë‚¨");
                isSelectStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                ACount = 0;
                AStart = false;
            }
        }
        if (D1Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerIntensity[D1Count]));
            D1Count++;

            if (BuyerIntensity[D1Count] == "")
            {
                //Debug.Log("D1ëë‚¨");
                isArrowStart = true;
                Buyer.gameObject.GetComponent<Button>().interactable = false;
                D1Count = 0;
                D1Start = false;
            }
        }
        if (D2Start == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerRejectReaction[D2Count]));
            D2Count++;

            if (BuyerRejectReaction[D2Count] == "")
            {
                //Debug.Log("D2ëë‚¨");
                D2Count = 0;
                D2Start = false;
                Invoke("End", 2f);
            }
        }
        if (EStart == true)
        {
            Buyer.gameObject.GetComponent<Button>().interactable = true;
            StartCoroutine(NormalChat(BuyerPerfumeReaction[ECount]));
            ECount++;

            if (BuyerPerfumeReaction[ECount] == "")
            {
                //Debug.Log("Eëë‚¨");
                ECount = 0;
                EStart = false;
                Invoke("End", 2f);
            }
        }
    }
   

    public void A_Start()//ì†ë‹˜ : ì…ì¥, í–¥ìˆ˜ êµ¬ë§¤ ì´ìœ  ì œì‹œ
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("visit");
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);

        AStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void C_1_Start()// ìœ ì € : ìŠ¹ë‚™ - í–¥ ì„¸ê¸° ì§ˆë¬¸
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 0.3f);
    }

    public void C_2_Start()//ìœ ì € : ê±°ë¶€ - ê±°ë¶€ ì´ìœ  ì œì‹œ
    {
        isSelectStart = false;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum += 1;
        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().rejectNum += 1;
        float imsiReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        rejectCnt += 1;
        if (rejectCnt == 1)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
            

        else if (rejectCnt == 2)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }
        if (rejectCnt >= 3)
        {
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
            StartCoroutine(Count(imsiReputation, FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation));
        }

        GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().todayReputation = FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation;
        Select.SetActive(false);
        isDialogueStart = false;
        //RandomDialogue();
        Buyer.gameObject.SetActive(false);
        //Seller.gameObject.SetActive(true);
        //StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 0.3f);
    }

    public void D_1_Start()//ì†ë‹˜ : ìŠ¹ë‚™ - í–¥ ì„¸ê¸° ê²°ì •
    {
        Buyer.gameObject.SetActive(true);
        //Seller.gameObject.SetActive(false);
        //makeStart = true;
        D1Start = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void D_2_Start()// ì†ë‹˜ : ê±°ë¶€ - ë¶ˆë§Œ í‘œì¶œ
    {
        //Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);

        D2Start = true;
        isDialogueStart = true;
        NextDialogue();
    }


    public void E_1_Start()//ì†ë‹˜ : í–¥ìˆ˜ ë°›ê³  ë°˜ì‘
    {
        isArrowStart = false;
        EStart = true;
        isDialogueStart = true;
        NextDialogue();
    }

    public void End()
    {
        //GameObject.Find("RC").GetComponent<RandomImage>().CurrentFeel = "basic";
        isDialogueStart = false;
        int temp;
        temp = DS.Customer_ID[0];

        for (int i = 0; i < DS.Customer_ID.Length - 1; i++)
        {
            DS.Customer_ID[i] = DS.Customer_ID[i + 1];
        }
        DS.Customer_ID[DS.Customer_ID.Length - 1] = temp;

        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);

        if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum < 9)
        {
            if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 3)//ì†ë‹˜ 3ëª… ê°€ê³  ë‚˜ì„œ ì ì‹¬ìœ¼ë¡œ ë°”ë€œ
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "afternoon";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[1];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[4];

            }
            else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 6)//ì†ë‹˜ 6ëª… ê°€ê³  ë‚˜ì„œ ì €ë…ìœ¼ë¡œ ë°”ë€œ
            {
                RandomImage.FindObjectOfType<RandomImage>().CurrentTime = "night";
                BackGround.GetComponent<SpriteRenderer>().sprite = BG_Sprite[2];
                WindowBG.GetComponent<SpriteRenderer>().sprite = BG_Sprite[5];
            }

            Invoke("A_Start", 5f);//ì†ë‹˜ ê°€ê³  5ì´ˆ ë’¤ì— ë‹¤ìŒ ì†ë‹˜ ë“±ì¥. ì¸ê²Œì„ ì‹œê°„ ë³´ê³  ì¶”ê°€ ì¡°ê±´ë¬¸ ë‹¬ì•„ì•¼ í•¨
        }
        

        else if (GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().personNum == 9)//ì†ë‹˜ 9ëª… ê°€ê³  ë‚˜ì„œ ìµœì¢… ì°½ì´ ëœ¸.
        {
            Invoke("DailyWindowOpen", 3f);
        }
    }

    public void DailyWindowOpen()
    {
        DailyResult.gameObject.SetActive(true);
    }
    IEnumerator NormalChat(string narration)// íƒ€ì´í•‘ íš¨ê³¼ -> ì—¬ê¸°ì„œ í–¥ì˜ ì„¸ê¸°ì— ë”°ë¥¸ ì¦ë¥˜ê¸° ë¡œì§ ê²°ì • ê°€ëŠ¥
    {
        string writerText = "";
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
                isDialogueEnd = true;
            else
                isDialogueEnd = false;
            BuyerDialogue.text = writerText;
            //SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    IEnumerator Count(float target, float current)

    {
        float duration = 0.5f; // ì¹´ìš´íŒ…ì— ê±¸ë¦¬ëŠ” ì‹œê°„ ì„¤ì •. 

        float offset = (target - current) / duration; // 

        while (current < target)
        {
            current += offset * Time.deltaTime;

            GameObject.Find("reputation_num").GetComponent<Text>().text = ((int)current).ToString();

            yield return null;
        }
        current = target;
        GameObject.Find("reputation_num").GetComponent<Text>().text = ((int)current).ToString();

    }

    public void StopAll()
    {
        StopAllCoroutines();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

}

>>>>>>> 951f4d97b6e6b55c8c4057ab753fbe526e43de3a
