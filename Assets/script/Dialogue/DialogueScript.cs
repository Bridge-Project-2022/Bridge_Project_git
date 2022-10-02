<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    //public GameObject RC;
    //public GameObject DR;

    public int CriminalID = 0;

    //¼Õ´Ô ´ë»ç ¹è¿­ - ÀüÃ¼´Â ·£´ıÀÌÁö¸¸ ³»ºÎ´Â ¼øÂ÷ÀûÀ¸·Î

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//ÇÑ ³¯Â¥¿¡ ¿À´Â ¼Õ´ÔÀÇ ¾ÆÀÌµğ (¼Õ´Ô ¼ö¸¸Å­ ÇÒ´ç)
    public string[] Customer_PerfumeOrder = new string[10];//¼Õ´Ô Çâ¼ö ÁÖ¹® ´ë»ç
    public string[] Customer_IntensityOrder = new string[5];//Çâ¼ö °­µµ ´ë»ç
    public string[] Customer_Flavoring = new string[3];//¿øÇÏ´Â Çâ·á ¼±ÅÃ(º£, ¹Ì, Å¾)
    public string[] Customer_RejectReaction = new string[5];//¼Õ´Ô °ÅÀı ¹İÀÀ
    public string[] Customer_PerfumeReaction = new string[5];//Çâ¼ö ¹ŞÀ» ½Ã ¼Õ´Ô ¹İÀÀ

    public void Start()
    {
        //¼Õ´Ô ¾ÆÀÌµğ ¹è¿­¿¡ 1-9±îÁö Áß¿¡ ·£´ıÀ¸·Î ³ÖµÇ Áßº¹µÇÁö ¾Êµµ·Ï ¹èÄ¡ÇÔ. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001, 1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }

        CriminalID = Random.Range(1001, 1010);
    }
    public void Update()
    {
        if (Customer_ID[0] == 1001)//B : ÃÊµîÇĞ»ı ¿©ÀÚ¾ÆÀÌ, ´ç´çÇÔ
        {
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "¾È³ç?";
            Customer_PerfumeOrder[1] = "¾î¸± ¶§ ¾Æºü ¼ÕÀâ°í °¬´ø ³îÀÌ°ø¿ø¿¡ ´Ù½Ã °¡°í ½Í¾î!";
            Customer_PerfumeOrder[2] = "±×¶§ ÁøÂ¥ Çàº¹Çß°Åµç!!";
            Customer_PerfumeOrder[3] = "Çâ¼ö·Î ¸¸µé¾îÁÙ ¼ö ÀÖÀ»±î?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "ÇâÀº Á¤¸» ÁøÇÏ°Ô ÇØÁà!!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "°­ÇÔ";

            Customer_Flavoring[0] = "Àå¼Ò";
            Customer_Flavoring[1] = "³îÀÌ°ø¿ø";
            Customer_Flavoring[2] = "Çàº¹";

            Customer_RejectReaction[0] = "¾ÆÁ÷ ¸ø ¸¸µå´Â°Å¾ß?";
            Customer_RejectReaction[1] = "±×·¯¸é ´ÙÀ½¿¡ ¿Ã°Ô!";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "Á¤¸» ÁÁ¾Æ!! °í¸¶¿ö¿ä!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "¿À! ÀÌ¸¸ÇÏ¸é ±¦ÂúÀº °Í °°¾Æ!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "¿ø·¡ Çâ¼ö°¡ ÀÌ·¸³ª¿ä..?";
                    Customer_PerfumeReaction[1] = "¿ÏÀü º°·Ğµ¥..?";
                    Customer_PerfumeReaction[2] = "½Ç·ÂÀÌ ¿µ..";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "¹¹ ÇÏ³ª ºü¶ß¸®½Å °Å ¾Æ´Ï¿¡¿ä?";
                    Customer_PerfumeReaction[1] = "ÀÌ°Ô ¾Æ´Ñ °Í °°Àºµ¥..";
                    Customer_PerfumeReaction[2] = "¿ÏÀü ²ÎÀÌ¾ß!";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "Á¦°¡ ¸»ÇÑ °Å¶û ´Ù¸¥ °Í °°Àºµ¥¿ä?";
                    Customer_PerfumeReaction[1] = "ÀÌ·² ¸®°¡ ¾ø´Âµ¥..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1002)//J : ¸¶¸¥ ¸ğ½ÀÀÇ 30-40´ë ¾ÆÁÜ¸¶, ¼Ò½ÉÇÔ, °ÆÁ¤
        {
            Customer_Name = "J";
            Customer_PerfumeOrder[0] = "Àú±â¿ä?";
            Customer_PerfumeOrder[1] = "¿ì¸® ¾Ö°¡ ¾ÆÁ÷µµ ¾î¸± ¶§ °¡Áö°í ³î´ø ÀÎÇüÀ» ¸ø ÀØ¾î¿ä.";
            Customer_PerfumeOrder[2] = "±×·¸°Ô ±â»µÇÏ¸é¼­ °¡Áö°í ³î´ø °Å¶ó ÀÌÇØ´Â ÇÑ´Ù¸¸..";
            Customer_PerfumeOrder[3] = "ÀÌ¹Ì ¹ö¸° Áö°¡ ¿À·¡ÀÎµ¥ ¿Ö ¾ÆÁ÷µµ ¸ø ÀØ¾ú´ÂÁö Âü..";
            Customer_PerfumeOrder[4] = "È¤½Ã Çâ¼ö °¡´ÉÇÒ±î¿ä?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "°í¸¶¿ö¿ä, ÇâÀº Àû´çÈ÷..? ÇØÁÖ¼¼¿ä.";
            Customer_IntensityOrder[1] = "¾Ö°¡ ³Ê¹« Çâ¿¡ ºüÁú±îµµ °ÆÁ¤ÀÌ³×¿ä.";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "º¸Åë";

            Customer_Flavoring[0] = "¹°°Ç";
            Customer_Flavoring[1] = "ÀÎÇü";
            Customer_Flavoring[2] = "±â»İ";

            Customer_RejectReaction[0] = "¾Æ´Ï µ·À» ÁØ´Ù´Âµ¥µµ¿ä?";
            Customer_RejectReaction[1] = "ºÒÄèÇÏ³×¿ä.";
            Customer_RejectReaction[2] = "ÀÌ°É ´Ù¸¥ »ç¶÷µéÇÑÅ×µµ ¾Ë·Á¾ß°Ú¾î¿ä.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "°¨»çÇÕ´Ï´Ù. ÀÌ°Å¸é ¿ì¸® ¾Ö Á¶±İÀÌ¶óµµ ´Ş·¤ ¼ö ÀÖ°ÚÁÒ?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "À½.. ±¦Âú³×¿ä.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç Çâ¼ö°¡ ¾Æ´Ñµ¥¿ä?";
                    Customer_PerfumeReaction[1] = "ÀÌ·¸°Ô±îÁö ¸ø ¸¸µé ÁÙÀÌ¾ß..";
                    Customer_PerfumeReaction[2] = "´Ù¸¥ »ç¶÷µéµµ ¾Ë¾Æ¾ß ÇÒ °Í °°³×¿ä.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "¿Ï¼ºµµ ¾ÈµÈ °É ÀÌ·¸°Ô ÆÈ¾Æµµ µÇ³ª¿ä?";
                    Customer_PerfumeReaction[1] = "ÁÖº¯ »ç¶÷µéÇÑÅ× ´Ù ¸»ÇÒ°Å¿¡¿ä!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "À½.. ÀÌ°Å Á¦°¡ ¸»ÇÑ °Å¶û ´Ù¸¥µ¥¿ä?";
                    Customer_PerfumeReaction[1] = "ÀÌ°Ô ¸Â³ª¿ä?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//G : °ÇÀåÇÑ 30´ë ³²¼º
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "¾È³çÇÏ¼¼¿ä!";
            Customer_PerfumeOrder[1] = "³»ÀÏ ÀúÀÇ ¿©ÀÚÄ£±¸¿¡°Ô Ã»È¥À» ÇÏ·Á°í ÇÕ´Ï´Ù.";
            Customer_PerfumeOrder[2] = "ÇÏÇÏ! ¾¦½º·´³×¿ä.";
            Customer_PerfumeOrder[3] = "ÀúÀÇ »ç¶ûÇÏ´Â ¸¶À½À» Çâ¼ö·Î ÇÔ²² ¼±¹°ÇÏ°í ½ÍÀºµ¥..";
            Customer_PerfumeOrder[4] = "ÁØºñ °¡´ÉÇÒ±î¿ä?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "¾Æ! ÇâÀº ¾ÆÁÖ °­ÇÏ°Ô ºÎÅ¹µå¸³´Ï´Ù.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "°­ÇÔ";

            Customer_Flavoring[0] = "ÀÎ°£";
            Customer_Flavoring[1] = "¿¬ÀÎ";
            Customer_Flavoring[2] = "»ç¶û";

            Customer_RejectReaction[0] = "¾ÈµÈ´Ù°í¿ä?";
            Customer_RejectReaction[1] = "ÀÌ·¸°Ô ¹«ÀÛÁ¤ °ÅÀıÇØµµ µÇ´Â°Ì´Ï±î?";
            Customer_RejectReaction[2] = "¿¡ÀÕ! ³» ±âºĞ ´Ù ¸ÁÃÆ³×.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "¿Í! Á¦°¡ µü ¿øÇß´ø Çâ¼ö³×¿ä.";
                    Customer_PerfumeReaction[1] = "ÀÌ°Å¸é Ã»È¥µµ ¼º°øÇÒ ¼ö ÀÖ°Ú¾î¿ä.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "°¨»çÇÕ´Ï´Ù. ½â ¸¶À½¿¡ µå³×¿ä.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ÀÌ Çâ¼ö´Â..";
                    Customer_PerfumeReaction[1] = "¹Ş´Â Á¦ ¿©ÀÚÄ£±¸µµ ±âºĞ ³ª»Ú°Ú¾î¿ä.";
                    Customer_PerfumeReaction[2] = "µÆ½À´Ï´Ù.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "Å¯Å¯..";
                    Customer_PerfumeReaction[1] = "¿©±â¼­ ¾Æ¹« Çâµµ ³ªÁú ¾Ê´Â °É¿ä?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "Èì.. Á¦°¡ ºÎÅ¹µå¸° Çâ¼ö°¡ ¾Æ´Ñ °Í °°±º¿ä..";
                    Customer_PerfumeReaction[1] = "°¡º¸°Ú½À´Ï´Ù.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//A : ÃÊµîÇĞ»ı 4-5ÇĞ³â ³²ÀÚ ¾ÆÀÌ
        {
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "¾È³çÇÏ¼¼¿ä?";
            Customer_PerfumeOrder[1] = "Àúµµ Çü °¡Áö°í ½Í¾î¿ä!";
            Customer_PerfumeOrder[2] = "ÇüÀÌ ÀÖÀ¸¸é ÁÁ°Ú´Ù!";
            Customer_PerfumeOrder[3] = "±×·³ ¸Ç³¯ °°ÀÌ ³î°í Çàº¹ÇÒÅÙµ¥!!";
            Customer_PerfumeOrder[4] = "Çü ³¿»õ¶óµµ ¸ÃÀ» ¼ö ÀÖÀ»±î¿ä?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀÇ ¼¼±â´Â ¾Æ¹«°Å³ª »ó°ü¾ø¾î¿ä!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "¾Æ¹«°Å³ª";

            Customer_Flavoring[0] = "ÀÎ°£";
            Customer_Flavoring[1] = "°¡Á·";
            Customer_Flavoring[2] = "Çàº¹";

            Customer_RejectReaction[0] = "¾ÈµÅ¿ä??";
            Customer_RejectReaction[1] = "¿Ö ¾ÈµÅ¿ä??";
            Customer_RejectReaction[2] = "ÁøÂ¥·Î¿ä??";
            Customer_RejectReaction[3] = "¾Ë°Ú¾î¿ä..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "¿Í!! °í¸¿½À´Ï´Ù!!";
                    Customer_PerfumeReaction[1] = "ÀÌ°Å¸é ³ªµµ ÇüÀÌ »ı±ä°Ç°¡??!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "¿À¿À.. °í¸¿½À´Ï´Ù!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç.. °í¸¿½À´Ï´Ù..!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "³¿»õ°¡ ¾È ´À²¸Áö´Âµ¥..";
                    Customer_PerfumeReaction[1] = "¾ÆÀú¾¾ Á¦´ë·Î ¸¸µç °Å ¸Â¾Æ¿ä?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç Çü ³¿»õ°¡ ¾Æ´Ñµ¥¿ä..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1005)//E : 10-20´ë ÃÊ¹İ ¿©¼º
        {
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "¾È³ç..?";
            Customer_PerfumeOrder[1] = "Àú±â.. ºÎÅ¹ÇÒ °Ô ÀÖ´Âµ¥..";
            Customer_PerfumeOrder[2] = "¿ì¸® Áı °í¾çÀÌ ³ªºñ¸¦ ÇÑ ¹ø¸¸ÀÌ¶óµµ ´Ù½Ã ¸¸³ª°í ½Í¾î...";
            Customer_PerfumeOrder[3] = "Èû ¾øÀÌ ³× ¹ß·Î ºñÆ²°Å¸®¸é¼­ ÀÏ¾î¼­·Á°í ³ë·ÂÇÏ´Â °Ô ¾ü±×Á¦ °°Àºµ¥..";
            Customer_PerfumeOrder[4] = "Ãà Ã³Á®¼­ ¾Æ¹« °Íµµ ¾È ÇÏ´õ´Ï..";
            Customer_PerfumeOrder[5] = "ÀÌÁ¨ ´õ ÀÌ»ó º¼ ¼ö ¾ø¾î..";
            Customer_PerfumeOrder[6] = "±× Á¶±×¸¸ ¾ÆÀÌ°¡ ¾ó¸¶³ª ¾ÆÆÍ´ÂÁö »ı°¢ÇÏ¸é..";
            Customer_PerfumeOrder[7] = "»ı°¢Á¶Â÷ Èûµé¾î¼­ ´«¹°ÀÌ ³ª..";
            Customer_PerfumeOrder[8] = "Á¦¹ß ³ªºñ¸¦ ÇÑ ¹ø¸¸ÀÌ¶óµµ ¸¸³¯ ¼ö ÀÖ°Ô ÇØÁà...";
            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀº ³Ê¹« ÁøÇÏÁöµµ... ³Ê¹« ÀºÀºÇÏÁöµµ ¾Ê°Ô ÇØÁà¡¦";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "º¸Åë";

            Customer_Flavoring[0] = "µ¿¹°";
            Customer_Flavoring[1] = "¹İ·Áµ¿¹°";
            Customer_Flavoring[2] = "½½ÇÄ";

            Customer_RejectReaction[0] = "...³ªÇÑÅ× ´ëÃ¼ ¿Ö ±×·¡¿ä?";
            Customer_RejectReaction[1] = "´Ü ÇÑ ¹ø¸¸ ³ªºñ¸¦ ¸¸³ª´Â °Íµµ ¾ÈµÇ´Â °Å¾ß?";
            Customer_RejectReaction[2] = "³»°¡ ÀÌ·¸°Ô±îÁö Çß´Âµ¥..";
            Customer_RejectReaction[3] = "´Ù¸¥ »ç¶÷µéÇÑÅ×µµ ¸»ÇÒ °Å¾ß.";
            Customer_RejectReaction[4] = "ÈÄÈ¸ÇÏÁö ¸¶ ´ç½ÅÀÌ ÇÑ ¼±ÅÃÀÌÀİ¾Æ.";

            for (int i = 5; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "³ªºñ¾ß... ³ªºñ¾ß...";
                    Customer_PerfumeReaction[1] = "Â÷¶ó¸® ³»°¡ ´ë½Å ¾ÆÆÍ¾î¾ß ÇÏ´Âµ¥...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "°í¸¶¿ö¿ä...";
                    Customer_PerfumeReaction[1] = "ÀÌ·¸°Ô¶óµµ ³ªºñ¸¦ º¼ ¼ö ÀÖ¾î¼­..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "Á¤¸» ÃÖ¾ÇÀÌ³×¿ä...";
                    Customer_PerfumeReaction[1] = "´Ù¸¥ »ç¶÷µéµµ ´ç½ÅÀÌ ÀÌ·¸°Ô ¸ø ¸¸µå´Â °Å ¾Ë°í ÀÖ³ª¿ä..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "Á¦´ë·Î ¸¸µç °Å ¸Â³ª¿ä..?";
                    Customer_PerfumeReaction[1] = "´À²¸Áö´Â °Ô ¾ø´Âµ¥..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ÀÌ ÇâÀÌ ¾Æ´Ñµ¥¿ä..?";
                    Customer_PerfumeReaction[1] = "¹» ¸¸µç °ÅÁÒ..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//I : 40´ë °ÇÀåÇÑ Ã¼ÇüÀÇ ³²¼º
        {
            Customer_Name = "I";
            Customer_PerfumeOrder[0] = "ÀÚ³× ¸®ÇÁ ¼¶¿¡ °¡ºÃ³ª?";
            Customer_PerfumeOrder[1] = "¸®ÇÁ ¼¶À» ¸ğ¸£´Â ¸ğ¾çÀÌ±º..?";
            Customer_PerfumeOrder[2] = "ÀşÀº »ç¶÷ÀÌ ¸»ÀÌ¾ß...";
            Customer_PerfumeOrder[3] = "³»°¡ Á» ¾ê±âÇØ ÁÖÁö!";
            Customer_PerfumeOrder[4] = "¸®ÇÁ ¼¶Àº ¿¡¸Ş¶öµå ºûÀÇ ¹Ù´Ù·Î µÑ·¯½ÎÀÎ ¾Æ¸§´Ù¿î ¼¶ÀÌ¶ó³×!";
            Customer_PerfumeOrder[5] = "±×´Ã¿¡¼­ ´«ºÎ½Ãµµ·Ï ¹İÂ¦ÀÌ´Â ¹Ù´Ù¸¦ ¹Ù¶óº¸¸é ¾îÂî³ª È²È¦ÇÑÁö...";
            Customer_PerfumeOrder[6] = "²À ´Ù½Ã ÇÑ¹ø °¡°í ½ÍÀº °÷ÀÌ¾ß...!";
            Customer_PerfumeOrder[7] = "±×¶§¸¸ »ı°¢ÇÏ¸é ³Ê¹«³ª Çàº¹ÇÏ±º!";
            Customer_PerfumeOrder[8] = "Çª¸¥ ¹Ù´å°¡¿¡ ³ëÀ»ºûÀÌ ³»·Á¾ÉÀº ±¤°æÀº ³» Æò»ı ÀØÁö ¸øÇÒ °É¼¼!";


            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀº ¾ÆÁÖ ÁøÇÏ°Ô ºÎÅ¹ÇÏ³×!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "°­ÇÔ";

            Customer_Flavoring[0] = "Àå¼Ò";
            Customer_Flavoring[1] = "¿©ÇàÁö";
            Customer_Flavoring[2] = "Çàº¹";

            Customer_RejectReaction[0] = "Èì... ¾Ë°Ú³×..";
            Customer_RejectReaction[1] = "½Ç¸ÁÀÌ Å©±¸¸¸..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "»óÄèÇÑ ¹Ù´Ù ³»À½..";
                    Customer_PerfumeReaction[1] = "¹Ù·Î ÀÌ°ÅÁö!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "°í¸¿±¸¸¸ ÀÚ³×!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ÀÌ°Ô ¹º°¡..?";
                    Customer_PerfumeReaction[1] = "Á¤½Å Â÷¸®°Ô ÀşÀºÀÌ..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "¾Æ¹« ÇâÀÌ ¾È ³ª´Âµ¥...";
                    Customer_PerfumeReaction[1] = "ÀÌ·± °É ÆÈ¾Æµµ µÇ´Â °Ç°¡..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç ¸®ÇÁ ¼¶ ³¿»õ°¡ ¾Æ´Ï±º ±×·¡..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//C : ±³º¹À» ÀÔÀº Ã»¼Ò³â ³²¼º
        {
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "¾È³çÇÏ¼¼¿ä, ¾ÆÀú¾¾";
            Customer_PerfumeOrder[1] = "¿À´Ã ¾Æºü°¡ ±Í¿©¿î »õ³¢ °­¾ÆÁö¸¦ µ¥¸®°í ¿Ô¾î¿ä.";
            Customer_PerfumeOrder[2] = " ÇÏ¾á ÅĞÀÌ º¹½½º¹½½ÇÑ µ¿¹°ÀÌ ¿ì¸® Áı¿¡ °°ÀÌ »ê´Ù´Ï..";
            Customer_PerfumeOrder[3] = "ÀÌÁ¦ ¿ì¸® °¡Á·ÀÌ µÈ °­¾ÆÁö¿ÍÀÇ Ã¹ ¸¸³²À» Æò»ı ±â¾ïÇÏ°í ½Í¾î¿ä.";
            Customer_PerfumeOrder[4] = "µµ¿ÍÁÖ¼¼¿ä..!";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀº Áı¿¡¼­ ´Ã ÀºÀºÇÏ°Ô Ç³±â¸é ÁÁ°Ú¾î¿ä.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "º¸Åë";

            Customer_Flavoring[0] = "µ¿¹°";
            Customer_Flavoring[1] = "¹İ·Áµ¿¹°";
            Customer_Flavoring[2] = "±â»İ";

            Customer_RejectReaction[0] = "¿¹?";
            Customer_RejectReaction[1] = "¾Æ.. ¹¹.. ¾îÂ¿ ¼ö ¾øÁÒ..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "¿Í¾Æ!";
                    Customer_PerfumeReaction[1] = "°¨»çÇÕ´Ï´Ù!";
                    Customer_PerfumeReaction[2] = "¿ì¸® Áı °­¾ÆÁö´Â º¹½½ °­¾ÆÁö~";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "°¨»çÇÕ´Ï´Ù..";
                    Customer_PerfumeReaction[1] = "ÀÌ Çâ¼ö Àß °£Á÷ÇÒ°Ô¿ä.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "¿©±â¼­ ÀÌ»óÇÑ ³¿»õ°¡ ³ª¿ä..";
                    Customer_PerfumeReaction[1] = "ÀÏ´Ü °¨»çÇÕ´Ï´Ù.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "¹¹Áö..?";
                    Customer_PerfumeReaction[1] = "³» ÄÚ°¡ ¸·Èù °Ç°¡..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç Á¦°¡ ¸»ÇÑ °Ô ¾Æ´ÏÀİ¾Æ¿ä..";
                    Customer_PerfumeReaction[1] = "ÀÏ´Ü °¨»çÇÕ´Ï´Ù.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//D : ´Ü¹ß ¸Ó¸®ÀÇ Ã»¼Ò³â ¿©¼º
        {
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "¾È³çÇÏ¼¼¿ä?";
            Customer_PerfumeOrder[1] = "¿ì¸® Áı¿¡ ±Í¿©¿î °­¾ÆÁö ÂÉ²¿°¡ ÀÖ°Åµç¿ä?";
            Customer_PerfumeOrder[2] = "º¼ ¶§¸¶´Ù ¾ó¸¶³ª »ç¶û½º·¯¿î ¸ğ¸£°Ú¾î¿ä!";
            Customer_PerfumeOrder[3] = "ÀÌ°É ´Ù¸¥ ¾ÖµéÇÑÅ×µµ ¾Ë·ÁÁÖ°í ½ÍÀºµ¥..!";
            Customer_PerfumeOrder[4] = "Çâ¼ö¸¦ ¼±¹°ÇÏ¸é µÇÁö ¾ÊÀ»±î¿ä?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀº ¿ÏÀü ÁøÇÏ°Ô? ÇØÁÖ¼¼¿ä!!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "°­ÇÔ";

            Customer_Flavoring[0] = "µ¿¹°";
            Customer_Flavoring[1] = "¹İ·Áµ¿¹°";
            Customer_Flavoring[2] = "»ç¶û";

            Customer_RejectReaction[0] = "ÀÀ?";
            Customer_RejectReaction[1] = "Èì.. ¿Ö¿ä??";
            Customer_RejectReaction[2] = "Çâ¼ö ÆÈ¸é ÁÁÀº °Å ¾Æ´Ñ°¡??";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "¿À..ÁøÂ¥ ÂÉ²¿ ³¿»õ´Ù!";
                    Customer_PerfumeReaction[1] = "°í¸¶¿ö¿ä!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "¿À ÂÉ²¿ ³¿»õ³­´Ù!";
                    Customer_PerfumeReaction[1] = "ÁÁ¾Æ¿ä!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "À¸.. ÀÌ»óÇÑ ³¿»õ!!";
                    Customer_PerfumeReaction[1] = "ÂÉ²¿´Â ²¿¼ÒÇÑ ³¿»õ°¡ ³­´Ù±¸¿ä!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "ÀÌ°Ç ¹«½¼ ³¿»õÁö..?";
                    Customer_PerfumeReaction[1] = "¿Ö ÀÌ·¸°Ô ¸¸µç °Å¿¡¿ä??";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "À½.. ¹«½¼ ³¿»õÁö..?";
                    Customer_PerfumeReaction[1] = "¿ÏÀüÈ÷ ´Ù¸¥ ³¿»õÀÎµ¥¿ä?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1009)//H : 30´ë ¿©¼º
        {
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "Àú±â¿ä..?";
            Customer_PerfumeOrder[1] = "Çì¾îÁø Áö ¸î ³âÀÌ³ª Áö³µ´Âµ¥, ¾ÆÁ÷µµ »ı°¢³ª´Â °Ç ¿ÖÀÏ±î¿ä..?";
            Customer_PerfumeOrder[2] = "»ç¶ûÇÒ ¶© ½½ÇÁ±â¸¸ ÇØ¼­ Çì¾îÁö¸é ÈÄ·ÃÇÒ ÁÙ ¾Ë¾Ò´Âµ¥..";
            Customer_PerfumeOrder[3] = "Àü ¾ÆÁ÷ Á¦´ë·Î ÀØÁö ¸øÇß³ª ºÁ¿ä.";
            Customer_PerfumeOrder[4] = "ÀÌ·² ÁÙ ¾Ë¾ÒÀ¸¸é ½ÃÀÛÇÏÁö ¸»¾Ò¾î¾ß Çß´Âµ¥...";
            Customer_PerfumeOrder[5] = "Âü ¹Ùº¸ °°ÁÒ?";
            Customer_PerfumeOrder[6] = "¹Ùº¸ °°´Ù´Â °Ç ¾ËÁö¸¸, ÀÌÁ¦´Â ³õ¾ÆÁÖ°í ½Í¾î¿ä..";
            Customer_PerfumeOrder[7] = "Àú¸¦ µµ¿ÍÁÙ ¼ö ÀÖ³ª¿ä..?";

            for (int i = 8; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ÇâÀº ¾àÇÏ°Ô ÇØÁÖ¼¼¿ä..";
            Customer_IntensityOrder[1] = "ÇâÀÌ °­ÇÏ¸é ¹Ì·ÃÀÌ °è¼Ó ³²À» ¼öµµ ÀÖÀİ¾Æ¿ä..? ";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "¾àÇÔ";

            Customer_Flavoring[0] = "ÀÎ°£";
            Customer_Flavoring[1] = "¿¬ÀÎ";
            Customer_Flavoring[2] = "½½ÇÄ";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "......";
            Customer_RejectReaction[2] = "¾Ë°Ú¾î¿ä..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//º£¹ÌÅ¾ ¸ğµÎ ¿Ã¹Ù¸¥ Çâ·á »ç¿ëÇÑ °æ¿ì -> ÆòÆÇ º¸°í ÆÇ´Ü
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "»ı°¢ÇÏ¸é ÇÒ¼ö·Ï ±× »ç¶÷ Âü ³ª»¦´Âµ¥..";
                    Customer_PerfumeReaction[1] = "ÀÌÁ¦´Â ÀØÀ» ¼ö ÀÖÀ» °Í °°¾Æ¿ä..";
                    Customer_PerfumeReaction[2] = "°í¸¶¿ö¿ä.. ¾ğÁ¨°£ ÁÁÀº »ç¶÷ÀÌ ¿À°ÚÁÒ..?";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "°í¸¶¿ö¿ä..";
                    Customer_PerfumeReaction[1] = "ÀÌÁ¦´Â ³ª¾ÆÁú ¼ö ÀÖ°ÚÁÒ..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "¾î¶»°Ô ÀÌ·² ¼ö°¡ ÀÖÁÒ..?";
                    Customer_PerfumeReaction[1] = "ÃÖ¾ÇÀÌ¿¡¿ä..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//Çâ·á¸¦ ÇÏ³ª¶óµµ ´Ù¸£°Ô »ç¿ëÇÑ °æ¿ì
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//Çâ·á¸¦ ÇÏ³ª¶óµµ ³ÖÁö ¾Ê°í ¹Ù·Î Çâ¼ö Á¦Á¶ÇÑ °æ¿ì
                {
                    Customer_PerfumeReaction[0] = "À½.. ÀüÇô ´À³¥ ¼ö°¡ ¾ø´Âµ¥¿ä..?";
                    Customer_PerfumeReaction[1] = "Á¦´ë·Î ÇÑ °Ô ¸Â³ª¿ä...?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ÀÌ°Ô.. ¹¹ÁÒ..?";
                    Customer_PerfumeReaction[1] = "ÀüÇô ´Ù¸¥ ³¿»õ°¡ ³ª´Âµ¥¿ä..?";
                    Customer_PerfumeReaction[2] = "ÀÌ»óÇÑ °É ³ÖÀ¸¸é ¾î¶±ÇØ¿ä!!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    } 
  }
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    public GameObject RC;
    public GameObject DR;

    public int CriminalID = 0;

    //ì†ë‹˜ ëŒ€ì‚¬ ë°°ì—´ - ì „ì²´ëŠ” ëœë¤ì´ì§€ë§Œ ë‚´ë¶€ëŠ” ìˆœì°¨ì ìœ¼ë¡œ

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//í•œ ë‚ ì§œì— ì˜¤ëŠ” ì†ë‹˜ì˜ ì•„ì´ë”” (ì†ë‹˜ ìˆ˜ë§Œí¼ í• ë‹¹)
    public string[] Customer_PerfumeOrder = new string[10];//ì†ë‹˜ í–¥ìˆ˜ ì£¼ë¬¸ ëŒ€ì‚¬
    public string[] Customer_IntensityOrder = new string[5];//í–¥ìˆ˜ ê°•ë„ ëŒ€ì‚¬
    public string[] Customer_Flavoring = new string[3];//ì›í•˜ëŠ” í–¥ë£Œ ì„ íƒ(ë² , ë¯¸, íƒ‘)
    public string[] Customer_RejectReaction = new string[5];//ì†ë‹˜ ê±°ì ˆ ë°˜ì‘
    public string[] Customer_PerfumeReaction = new string[5];//í–¥ìˆ˜ ë°›ì„ ì‹œ ì†ë‹˜ ë°˜ì‘

    public void Start()
    {
        //ì†ë‹˜ ì•„ì´ë”” ë°°ì—´ì— 1-9ê¹Œì§€ ì¤‘ì— ëœë¤ìœ¼ë¡œ ë„£ë˜ ì¤‘ë³µë˜ì§€ ì•Šë„ë¡ ë°°ì¹˜í•¨. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001, 1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }

        CriminalID = Random.Range(1001, 1010);
        //Customer = GameObject.Find("Etc").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        //ë²”ì£„ì ëœë¤ìœ¼ë¡œ í•œëª… ì§€ì •í•´ì„œ í˜„ì¬ ë‚˜ì˜¬ ì†ë‹˜ ì•„ì´ë””ë‘ ì¼ì¹˜í•˜ë©´ ë²”ì£„ì ì§€ì •, ë¶ˆê°’ true ë³€ê²½. 
        if (Customer_ID[0] == CriminalID)
        {
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = true;
        }
        else
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = false;


        if (Customer_ID[0] == 1001)//B : ì´ˆë“±í•™ìƒ ì—¬ìì•„ì´, ë‹¹ë‹¹í•¨
        {
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "ì•ˆë…•?";
            Customer_PerfumeOrder[1] = "ì–´ë¦´ ë•Œ ì•„ë¹  ì†ì¡ê³  ê°”ë˜ ë†€ì´ê³µì›ì— ë‹¤ì‹œ ê°€ê³  ì‹¶ì–´!";
            Customer_PerfumeOrder[2] = "ê·¸ë•Œ ì§„ì§œ í–‰ë³µí–ˆê±°ë“ !!";
            Customer_PerfumeOrder[3] = "í–¥ìˆ˜ë¡œ ë§Œë“¤ì–´ì¤„ ìˆ˜ ìˆì„ê¹Œ?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "í–¥ì€ ì •ë§ ì§„í•˜ê²Œ í•´ì¤˜!!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "ê°•í•¨";

            Customer_Flavoring[0] = "ì¥ì†Œ";
            Customer_Flavoring[1] = "ë†€ì´ê³µì›";
            Customer_Flavoring[2] = "í–‰ë³µ";

            Customer_RejectReaction[0] = "ì•„ì§ ëª» ë§Œë“œëŠ”ê±°ì•¼?";
            Customer_RejectReaction[1] = "ê·¸ëŸ¬ë©´ ë‹¤ìŒì— ì˜¬ê²Œ!";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ì •ë§ ì¢‹ì•„!! ê³ ë§ˆì›Œìš”!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ì˜¤! ì´ë§Œí•˜ë©´ ê´œì°®ì€ ê²ƒ ê°™ì•„!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì›ë˜ í–¥ìˆ˜ê°€ ì´ë ‡ë‚˜ìš”..?";
                    Customer_PerfumeReaction[1] = "ì™„ì „ ë³„ë¡ ë°..?";
                    Customer_PerfumeReaction[2] = "ì‹¤ë ¥ì´ ì˜..";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ë­ í•˜ë‚˜ ë¹ ëœ¨ë¦¬ì‹  ê±° ì•„ë‹ˆì—ìš”?";
                    Customer_PerfumeReaction[1] = "ì´ê²Œ ì•„ë‹Œ ê²ƒ ê°™ì€ë°..";
                    Customer_PerfumeReaction[2] = "ì™„ì „ ê½ì´ì•¼!";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "ì œê°€ ë§í•œ ê±°ë‘ ë‹¤ë¥¸ ê²ƒ ê°™ì€ë°ìš”?";
                    Customer_PerfumeReaction[1] = "ì´ëŸ´ ë¦¬ê°€ ì—†ëŠ”ë°..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1002)//J : ë§ˆë¥¸ ëª¨ìŠµì˜ 30-40ëŒ€ ì•„ì¤Œë§ˆ, ì†Œì‹¬í•¨, ê±±ì •
        {
            Customer_Name = "J";
            Customer_PerfumeOrder[0] = "ì €ê¸°ìš”?";
            Customer_PerfumeOrder[1] = "ìš°ë¦¬ ì• ê°€ ì•„ì§ë„ ì–´ë¦´ ë•Œ ê°€ì§€ê³  ë†€ë˜ ì¸í˜•ì„ ëª» ìŠì–´ìš”.";
            Customer_PerfumeOrder[2] = "ê·¸ë ‡ê²Œ ê¸°ë»í•˜ë©´ì„œ ê°€ì§€ê³  ë†€ë˜ ê±°ë¼ ì´í•´ëŠ” í•œë‹¤ë§Œ..";
            Customer_PerfumeOrder[3] = "ì´ë¯¸ ë²„ë¦° ì§€ê°€ ì˜¤ë˜ì¸ë° ì™œ ì•„ì§ë„ ëª» ìŠì—ˆëŠ”ì§€ ì°¸..";
            Customer_PerfumeOrder[4] = "í˜¹ì‹œ í–¥ìˆ˜ ê°€ëŠ¥í• ê¹Œìš”?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ê³ ë§ˆì›Œìš”, í–¥ì€ ì ë‹¹íˆ..? í•´ì£¼ì„¸ìš”.";
            Customer_IntensityOrder[1] = "ì• ê°€ ë„ˆë¬´ í–¥ì— ë¹ ì§ˆê¹Œë„ ê±±ì •ì´ë„¤ìš”.";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "ë³´í†µ";

            Customer_Flavoring[0] = "ë¬¼ê±´";
            Customer_Flavoring[1] = "ì¸í˜•";
            Customer_Flavoring[2] = "ê¸°ì¨";

            Customer_RejectReaction[0] = "ì•„ë‹ˆ ëˆì„ ì¤€ë‹¤ëŠ”ë°ë„ìš”?";
            Customer_RejectReaction[1] = "ë¶ˆì¾Œí•˜ë„¤ìš”.";
            Customer_RejectReaction[2] = "ì´ê±¸ ë‹¤ë¥¸ ì‚¬ëŒë“¤í•œí…Œë„ ì•Œë ¤ì•¼ê² ì–´ìš”.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ê°ì‚¬í•©ë‹ˆë‹¤. ì´ê±°ë©´ ìš°ë¦¬ ì•  ì¡°ê¸ˆì´ë¼ë„ ë‹¬ë  ìˆ˜ ìˆê² ì£ ?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ìŒ.. ê´œì°®ë„¤ìš”.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì´ê±´ í–¥ìˆ˜ê°€ ì•„ë‹Œë°ìš”?";
                    Customer_PerfumeReaction[1] = "ì´ë ‡ê²Œê¹Œì§€ ëª» ë§Œë“¤ ì¤„ì´ì•¼..";
                    Customer_PerfumeReaction[2] = "ë‹¤ë¥¸ ì‚¬ëŒë“¤ë„ ì•Œì•„ì•¼ í•  ê²ƒ ê°™ë„¤ìš”.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ì™„ì„±ë„ ì•ˆëœ ê±¸ ì´ë ‡ê²Œ íŒ”ì•„ë„ ë˜ë‚˜ìš”?";
                    Customer_PerfumeReaction[1] = "ì£¼ë³€ ì‚¬ëŒë“¤í•œí…Œ ë‹¤ ë§í• ê±°ì—ìš”!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ìŒ.. ì´ê±° ì œê°€ ë§í•œ ê±°ë‘ ë‹¤ë¥¸ë°ìš”?";
                    Customer_PerfumeReaction[1] = "ì´ê²Œ ë§ë‚˜ìš”?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//G : ê±´ì¥í•œ 30ëŒ€ ë‚¨ì„±
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "ì•ˆë…•í•˜ì„¸ìš”!";
            Customer_PerfumeOrder[1] = "ë‚´ì¼ ì €ì˜ ì—¬ìì¹œêµ¬ì—ê²Œ ì²­í˜¼ì„ í•˜ë ¤ê³  í•©ë‹ˆë‹¤.";
            Customer_PerfumeOrder[2] = "í•˜í•˜! ì‘¥ìŠ¤ëŸ½ë„¤ìš”.";
            Customer_PerfumeOrder[3] = "ì €ì˜ ì‚¬ë‘í•˜ëŠ” ë§ˆìŒì„ í–¥ìˆ˜ë¡œ í•¨ê»˜ ì„ ë¬¼í•˜ê³  ì‹¶ì€ë°..";
            Customer_PerfumeOrder[4] = "ì¤€ë¹„ ê°€ëŠ¥í• ê¹Œìš”?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "ì•„! í–¥ì€ ì•„ì£¼ ê°•í•˜ê²Œ ë¶€íƒë“œë¦½ë‹ˆë‹¤.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "ê°•í•¨";

            Customer_Flavoring[0] = "ì¸ê°„";
            Customer_Flavoring[1] = "ì—°ì¸";
            Customer_Flavoring[2] = "ì‚¬ë‘";

            Customer_RejectReaction[0] = "ì•ˆëœë‹¤ê³ ìš”?";
            Customer_RejectReaction[1] = "ì´ë ‡ê²Œ ë¬´ì‘ì • ê±°ì ˆí•´ë„ ë˜ëŠ”ê²ë‹ˆê¹Œ?";
            Customer_RejectReaction[2] = "ì—ì‡! ë‚´ ê¸°ë¶„ ë‹¤ ë§ì³¤ë„¤.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ì™€! ì œê°€ ë”± ì›í–ˆë˜ í–¥ìˆ˜ë„¤ìš”.";
                    Customer_PerfumeReaction[1] = "ì´ê±°ë©´ ì²­í˜¼ë„ ì„±ê³µí•  ìˆ˜ ìˆê² ì–´ìš”.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ê°ì‚¬í•©ë‹ˆë‹¤. ì© ë§ˆìŒì— ë“œë„¤ìš”.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì´ í–¥ìˆ˜ëŠ”..";
                    Customer_PerfumeReaction[1] = "ë°›ëŠ” ì œ ì—¬ìì¹œêµ¬ë„ ê¸°ë¶„ ë‚˜ì˜ê² ì–´ìš”.";
                    Customer_PerfumeReaction[2] = "ëìŠµë‹ˆë‹¤.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "í‚í‚..";
                    Customer_PerfumeReaction[1] = "ì—¬ê¸°ì„œ ì•„ë¬´ í–¥ë„ ë‚˜ì§ˆ ì•ŠëŠ” ê±¸ìš”?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "í .. ì œê°€ ë¶€íƒë“œë¦° í–¥ìˆ˜ê°€ ì•„ë‹Œ ê²ƒ ê°™êµ°ìš”..";
                    Customer_PerfumeReaction[1] = "ê°€ë³´ê² ìŠµë‹ˆë‹¤.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//A : ì´ˆë“±í•™ìƒ 4-5í•™ë…„ ë‚¨ì ì•„ì´
        {
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "ì•ˆë…•í•˜ì„¸ìš”?";
            Customer_PerfumeOrder[1] = "ì €ë„ í˜• ê°€ì§€ê³  ì‹¶ì–´ìš”!";
            Customer_PerfumeOrder[2] = "í˜•ì´ ìˆìœ¼ë©´ ì¢‹ê² ë‹¤!";
            Customer_PerfumeOrder[3] = "ê·¸ëŸ¼ ë§¨ë‚  ê°™ì´ ë†€ê³  í–‰ë³µí• í…ë°!!";
            Customer_PerfumeOrder[4] = "í˜• ëƒ„ìƒˆë¼ë„ ë§¡ì„ ìˆ˜ ìˆì„ê¹Œìš”?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì˜ ì„¸ê¸°ëŠ” ì•„ë¬´ê±°ë‚˜ ìƒê´€ì—†ì–´ìš”!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "ì•„ë¬´ê±°ë‚˜";

            Customer_Flavoring[0] = "ì¸ê°„";
            Customer_Flavoring[1] = "ê°€ì¡±";
            Customer_Flavoring[2] = "í–‰ë³µ";

            Customer_RejectReaction[0] = "ì•ˆë¼ìš”??";
            Customer_RejectReaction[1] = "ì™œ ì•ˆë¼ìš”??";
            Customer_RejectReaction[2] = "ì§„ì§œë¡œìš”??";
            Customer_RejectReaction[3] = "ì•Œê² ì–´ìš”..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ì™€!! ê³ ë§™ìŠµë‹ˆë‹¤!!";
                    Customer_PerfumeReaction[1] = "ì´ê±°ë©´ ë‚˜ë„ í˜•ì´ ìƒê¸´ê±´ê°€??!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ì˜¤ì˜¤.. ê³ ë§™ìŠµë‹ˆë‹¤!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì´ê±´.. ê³ ë§™ìŠµë‹ˆë‹¤..!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ëƒ„ìƒˆê°€ ì•ˆ ëŠê»´ì§€ëŠ”ë°..";
                    Customer_PerfumeReaction[1] = "ì•„ì €ì”¨ ì œëŒ€ë¡œ ë§Œë“  ê±° ë§ì•„ìš”?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ì´ê±´ í˜• ëƒ„ìƒˆê°€ ì•„ë‹Œë°ìš”..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1005)//E : 10-20ëŒ€ ì´ˆë°˜ ì—¬ì„±
        {
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "ì•ˆë…•..?";
            Customer_PerfumeOrder[1] = "ì €ê¸°.. ë¶€íƒí•  ê²Œ ìˆëŠ”ë°..";
            Customer_PerfumeOrder[2] = "ìš°ë¦¬ ì§‘ ê³ ì–‘ì´ ë‚˜ë¹„ë¥¼ í•œ ë²ˆë§Œì´ë¼ë„ ë‹¤ì‹œ ë§Œë‚˜ê³  ì‹¶ì–´...";
            Customer_PerfumeOrder[3] = "í˜ ì—†ì´ ë„¤ ë°œë¡œ ë¹„í‹€ê±°ë¦¬ë©´ì„œ ì¼ì–´ì„œë ¤ê³  ë…¸ë ¥í•˜ëŠ” ê²Œ ì—Šê·¸ì œ ê°™ì€ë°..";
            Customer_PerfumeOrder[4] = "ì¶• ì²˜ì ¸ì„œ ì•„ë¬´ ê²ƒë„ ì•ˆ í•˜ë”ë‹ˆ..";
            Customer_PerfumeOrder[5] = "ì´ì   ë” ì´ìƒ ë³¼ ìˆ˜ ì—†ì–´..";
            Customer_PerfumeOrder[6] = "ê·¸ ì¡°ê·¸ë§Œ ì•„ì´ê°€ ì–¼ë§ˆë‚˜ ì•„íŒ ëŠ”ì§€ ìƒê°í•˜ë©´..";
            Customer_PerfumeOrder[7] = "ìƒê°ì¡°ì°¨ í˜ë“¤ì–´ì„œ ëˆˆë¬¼ì´ ë‚˜..";
            Customer_PerfumeOrder[8] = "ì œë°œ ë‚˜ë¹„ë¥¼ í•œ ë²ˆë§Œì´ë¼ë„ ë§Œë‚  ìˆ˜ ìˆê²Œ í•´ì¤˜...";
            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì€ ë„ˆë¬´ ì§„í•˜ì§€ë„... ë„ˆë¬´ ì€ì€í•˜ì§€ë„ ì•Šê²Œ í•´ì¤˜â€¦";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "ë³´í†µ";

            Customer_Flavoring[0] = "ë™ë¬¼";
            Customer_Flavoring[1] = "ë°˜ë ¤ë™ë¬¼";
            Customer_Flavoring[2] = "ìŠ¬í””";

            Customer_RejectReaction[0] = "...ë‚˜í•œí…Œ ëŒ€ì²´ ì™œ ê·¸ë˜ìš”?";
            Customer_RejectReaction[1] = "ë‹¨ í•œ ë²ˆë§Œ ë‚˜ë¹„ë¥¼ ë§Œë‚˜ëŠ” ê²ƒë„ ì•ˆë˜ëŠ” ê±°ì•¼?";
            Customer_RejectReaction[2] = "ë‚´ê°€ ì´ë ‡ê²Œê¹Œì§€ í–ˆëŠ”ë°..";
            Customer_RejectReaction[3] = "ë‹¤ë¥¸ ì‚¬ëŒë“¤í•œí…Œë„ ë§í•  ê±°ì•¼.";
            Customer_RejectReaction[4] = "í›„íšŒí•˜ì§€ ë§ˆ ë‹¹ì‹ ì´ í•œ ì„ íƒì´ì–ì•„.";

            for (int i = 5; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ë‚˜ë¹„ì•¼... ë‚˜ë¹„ì•¼...";
                    Customer_PerfumeReaction[1] = "ì°¨ë¼ë¦¬ ë‚´ê°€ ëŒ€ì‹  ì•„íŒ ì–´ì•¼ í•˜ëŠ”ë°...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ê³ ë§ˆì›Œìš”...";
                    Customer_PerfumeReaction[1] = "ì´ë ‡ê²Œë¼ë„ ë‚˜ë¹„ë¥¼ ë³¼ ìˆ˜ ìˆì–´ì„œ..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì •ë§ ìµœì•…ì´ë„¤ìš”...";
                    Customer_PerfumeReaction[0] = "ë‹¤ë¥¸ ì‚¬ëŒë“¤ë„ ë‹¹ì‹ ì´ ì´ë ‡ê²Œ ëª» ë§Œë“œëŠ” ê±° ì•Œê³  ìˆë‚˜ìš”..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ì œëŒ€ë¡œ ë§Œë“  ê±° ë§ë‚˜ìš”..?";
                    Customer_PerfumeReaction[1] = "ëŠê»´ì§€ëŠ” ê²Œ ì—†ëŠ”ë°..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ì´ í–¥ì´ ì•„ë‹Œë°ìš”..?";
                    Customer_PerfumeReaction[1] = "ë­˜ ë§Œë“  ê±°ì£ ..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//I : 40ëŒ€ ê±´ì¥í•œ ì²´í˜•ì˜ ë‚¨ì„±
        {
            Customer_Name = "I";
            Customer_PerfumeOrder[0] = "ìë„¤ ë¦¬í”„ ì„¬ì— ê°€ë´¤ë‚˜?";
            Customer_PerfumeOrder[1] = "ë¦¬í”„ ì„¬ì„ ëª¨ë¥´ëŠ” ëª¨ì–‘ì´êµ°..?";
            Customer_PerfumeOrder[2] = "ì Šì€ ì‚¬ëŒì´ ë§ì´ì•¼...";
            Customer_PerfumeOrder[3] = "ë‚´ê°€ ì¢€ ì–˜ê¸°í•´ ì£¼ì§€!";
            Customer_PerfumeOrder[4] = "ë¦¬í”„ ì„¬ì€ ì—ë©”ë„ë“œ ë¹›ì˜ ë°”ë‹¤ë¡œ ë‘˜ëŸ¬ì‹¸ì¸ ì•„ë¦„ë‹¤ìš´ ì„¬ì´ë¼ë„¤!";
            Customer_PerfumeOrder[5] = "ê·¸ëŠ˜ì—ì„œ ëˆˆë¶€ì‹œë„ë¡ ë°˜ì§ì´ëŠ” ë°”ë‹¤ë¥¼ ë°”ë¼ë³´ë©´ ì–´ì°Œë‚˜ í™©í™€í•œì§€...";
            Customer_PerfumeOrder[6] = "ê¼­ ë‹¤ì‹œ í•œë²ˆ ê°€ê³  ì‹¶ì€ ê³³ì´ì•¼...!";
            Customer_PerfumeOrder[7] = "ê·¸ë•Œë§Œ ìƒê°í•˜ë©´ ë„ˆë¬´ë‚˜ í–‰ë³µí•˜êµ°!";
            Customer_PerfumeOrder[8] = "í‘¸ë¥¸ ë°”ë‹·ê°€ì— ë…¸ì„ë¹›ì´ ë‚´ë ¤ì•‰ì€ ê´‘ê²½ì€ ë‚´ í‰ìƒ ìŠì§€ ëª»í•  ê±¸ì„¸!";


            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì€ ì•„ì£¼ ì§„í•˜ê²Œ ë¶€íƒí•˜ë„¤!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "ê°•í•¨";

            Customer_Flavoring[0] = "ì¥ì†Œ";
            Customer_Flavoring[1] = "ì—¬í–‰ì§€";
            Customer_Flavoring[2] = "í–‰ë³µ";

            Customer_RejectReaction[0] = "í ... ì•Œê² ë„¤..";
            Customer_RejectReaction[1] = "ì‹¤ë§ì´ í¬êµ¬ë§Œ..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ìƒì¾Œí•œ ë°”ë‹¤ ë‚´ìŒ..";
                    Customer_PerfumeReaction[1] = "ë°”ë¡œ ì´ê±°ì§€!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ê³ ë§™êµ¬ë§Œ ìë„¤!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì´ê²Œ ë­”ê°€..?";
                    Customer_PerfumeReaction[1] = "ì •ì‹  ì°¨ë¦¬ê²Œ ì Šì€ì´..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ì•„ë¬´ í–¥ì´ ì•ˆ ë‚˜ëŠ”ë°...";
                    Customer_PerfumeReaction[1] = "ì´ëŸ° ê±¸ íŒ”ì•„ë„ ë˜ëŠ” ê±´ê°€..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ì´ê±´ ë¦¬í”„ ì„¬ ëƒ„ìƒˆê°€ ì•„ë‹ˆêµ° ê·¸ë˜..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//C : êµë³µì„ ì…ì€ ì²­ì†Œë…„ ë‚¨ì„±
        {
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "ì•ˆë…•í•˜ì„¸ìš”, ì•„ì €ì”¨";
            Customer_PerfumeOrder[1] = "ì˜¤ëŠ˜ ì•„ë¹ ê°€ ê·€ì—¬ìš´ ìƒˆë¼ ê°•ì•„ì§€ë¥¼ ë°ë¦¬ê³  ì™”ì–´ìš”.";
            Customer_PerfumeOrder[2] = " í•˜ì–€ í„¸ì´ ë³µìŠ¬ë³µìŠ¬í•œ ë™ë¬¼ì´ ìš°ë¦¬ ì§‘ì— ê°™ì´ ì‚°ë‹¤ë‹ˆ..";
            Customer_PerfumeOrder[3] = "ì´ì œ ìš°ë¦¬ ê°€ì¡±ì´ ëœ ê°•ì•„ì§€ì™€ì˜ ì²« ë§Œë‚¨ì„ í‰ìƒ ê¸°ì–µí•˜ê³  ì‹¶ì–´ìš”.";
            Customer_PerfumeOrder[4] = "ë„ì™€ì£¼ì„¸ìš”..!";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì€ ì§‘ì—ì„œ ëŠ˜ ì€ì€í•˜ê²Œ í’ê¸°ë©´ ì¢‹ê² ì–´ìš”.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "ë³´í†µ";

            Customer_Flavoring[0] = "ë™ë¬¼";
            Customer_Flavoring[1] = "ë°˜ë ¤ë™ë¬¼";
            Customer_Flavoring[2] = "ê¸°ì¨";

            Customer_RejectReaction[0] = "ì˜ˆ?";
            Customer_RejectReaction[1] = "ì•„.. ë­.. ì–´ì©” ìˆ˜ ì—†ì£ ..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ì™€ì•„!";
                    Customer_PerfumeReaction[1] = "ê°ì‚¬í•©ë‹ˆë‹¤!";
                    Customer_PerfumeReaction[2] = "ìš°ë¦¬ ì§‘ ê°•ì•„ì§€ëŠ” ë³µìŠ¬ ê°•ì•„ì§€~";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ê°ì‚¬í•©ë‹ˆë‹¤..";
                    Customer_PerfumeReaction[1] = "ì´ í–¥ìˆ˜ ì˜ ê°„ì§í• ê²Œìš”.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì—¬ê¸°ì„œ ì´ìƒí•œ ëƒ„ìƒˆê°€ ë‚˜ìš”..";
                    Customer_PerfumeReaction[1] = "ì¼ë‹¨ ê°ì‚¬í•©ë‹ˆë‹¤.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ë­ì§€..?";
                    Customer_PerfumeReaction[1] = "ë‚´ ì½”ê°€ ë§‰íŒ ê±´ê°€..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ì´ê±´ ì œê°€ ë§í•œ ê²Œ ì•„ë‹ˆì–ì•„ìš”..";
                    Customer_PerfumeReaction[1] = "ì¼ë‹¨ ê°ì‚¬í•©ë‹ˆë‹¤.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//D : ë‹¨ë°œ ë¨¸ë¦¬ì˜ ì²­ì†Œë…„ ì—¬ì„±
        {
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "ì•ˆë…•í•˜ì„¸ìš”?";
            Customer_PerfumeOrder[1] = "ìš°ë¦¬ ì§‘ì— ê·€ì—¬ìš´ ê°•ì•„ì§€ ìª¼ê¼¬ê°€ ìˆê±°ë“ ìš”?";
            Customer_PerfumeOrder[2] = "ë³¼ ë•Œë§ˆë‹¤ ì–¼ë§ˆë‚˜ ì‚¬ë‘ìŠ¤ëŸ¬ìš´ ëª¨ë¥´ê² ì–´ìš”!";
            Customer_PerfumeOrder[3] = "ì´ê±¸ ë‹¤ë¥¸ ì• ë“¤í•œí…Œë„ ì•Œë ¤ì£¼ê³  ì‹¶ì€ë°..!";
            Customer_PerfumeOrder[4] = "í–¥ìˆ˜ë¥¼ ì„ ë¬¼í•˜ë©´ ë˜ì§€ ì•Šì„ê¹Œìš”?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì€ ì™„ì „ ì§„í•˜ê²Œ? í•´ì£¼ì„¸ìš”!!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "ê°•í•¨";

            Customer_Flavoring[0] = "ë™ë¬¼";
            Customer_Flavoring[1] = "ë°˜ë ¤ë™ë¬¼";
            Customer_Flavoring[2] = "ì‚¬ë‘";

            Customer_RejectReaction[0] = "ì‘?";
            Customer_RejectReaction[1] = "í .. ì™œìš”??";
            Customer_RejectReaction[2] = "í–¥ìˆ˜ íŒ”ë©´ ì¢‹ì€ ê±° ì•„ë‹Œê°€??";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ì˜¤..ì§„ì§œ ìª¼ê¼¬ ëƒ„ìƒˆë‹¤!";
                    Customer_PerfumeReaction[1] = "ê³ ë§ˆì›Œìš”!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ì˜¤ ìª¼ê¼¬ ëƒ„ìƒˆë‚œë‹¤!";
                    Customer_PerfumeReaction[1] = "ì¢‹ì•„ìš”!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ìœ¼.. ì´ìƒí•œ ëƒ„ìƒˆ!!";
                    Customer_PerfumeReaction[1] = "ìª¼ê¼¬ëŠ” ê¼¬ì†Œí•œ ëƒ„ìƒˆê°€ ë‚œë‹¤êµ¬ìš”!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ì´ê±´ ë¬´ìŠ¨ ëƒ„ìƒˆì§€..?";
                    Customer_PerfumeReaction[1] = "ì™œ ì´ë ‡ê²Œ ë§Œë“  ê±°ì—ìš”??";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ìŒ.. ë¬´ìŠ¨ ëƒ„ìƒˆì§€..?";
                    Customer_PerfumeReaction[1] = "ì™„ì „íˆ ë‹¤ë¥¸ ëƒ„ìƒˆì¸ë°ìš”?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1009)//H : 30ëŒ€ ì—¬ì„±
        {
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "ì €ê¸°ìš”..?";
            Customer_PerfumeOrder[1] = "í—¤ì–´ì§„ ì§€ ëª‡ ë…„ì´ë‚˜ ì§€ë‚¬ëŠ”ë°, ì•„ì§ë„ ìƒê°ë‚˜ëŠ” ê±´ ì™œì¼ê¹Œìš”..?";
            Customer_PerfumeOrder[2] = "ì‚¬ë‘í•  ë• ìŠ¬í”„ê¸°ë§Œ í•´ì„œ í—¤ì–´ì§€ë©´ í›„ë ¨í•  ì¤„ ì•Œì•˜ëŠ”ë°..";
            Customer_PerfumeOrder[3] = "ì „ ì•„ì§ ì œëŒ€ë¡œ ìŠì§€ ëª»í–ˆë‚˜ ë´ìš”.";
            Customer_PerfumeOrder[4] = "ì´ëŸ´ ì¤„ ì•Œì•˜ìœ¼ë©´ ì‹œì‘í•˜ì§€ ë§ì•˜ì–´ì•¼ í–ˆëŠ”ë°...";
            Customer_PerfumeOrder[5] = "ì°¸ ë°”ë³´ ê°™ì£ ?";
            Customer_PerfumeOrder[6] = "ë°”ë³´ ê°™ë‹¤ëŠ” ê±´ ì•Œì§€ë§Œ, ì´ì œëŠ” ë†“ì•„ì£¼ê³  ì‹¶ì–´ìš”..";
            Customer_PerfumeOrder[7] = "ì €ë¥¼ ë„ì™€ì¤„ ìˆ˜ ìˆë‚˜ìš”..?";

            for (int i = 8; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "í–¥ì€ ì•½í•˜ê²Œ í•´ì£¼ì„¸ìš”..";
            Customer_IntensityOrder[1] = "í–¥ì´ ê°•í•˜ë©´ ë¯¸ë ¨ì´ ê³„ì† ë‚¨ì„ ìˆ˜ë„ ìˆì–ì•„ìš”..? ";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "ì•½í•¨";

            Customer_Flavoring[0] = "ì¸ê°„";
            Customer_Flavoring[1] = "ì—°ì¸";
            Customer_Flavoring[2] = "ìŠ¬í””";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "......";
            Customer_RejectReaction[2] = "ì•Œê² ì–´ìš”..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//ë² ë¯¸íƒ‘ ëª¨ë‘ ì˜¬ë°”ë¥¸ í–¥ë£Œ ì‚¬ìš©í•œ ê²½ìš° -> í‰íŒ ë³´ê³  íŒë‹¨
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "ìƒê°í•˜ë©´ í• ìˆ˜ë¡ ê·¸ ì‚¬ëŒ ì°¸ ë‚˜ë¹´ëŠ”ë°..";
                    Customer_PerfumeReaction[1] = "ì´ì œëŠ” ìŠì„ ìˆ˜ ìˆì„ ê²ƒ ê°™ì•„ìš”..";
                    Customer_PerfumeReaction[2] = "ê³ ë§ˆì›Œìš”.. ì–¸ì  ê°„ ì¢‹ì€ ì‚¬ëŒì´ ì˜¤ê² ì£ ..?";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "ê³ ë§ˆì›Œìš”..";
                    Customer_PerfumeReaction[1] = "ì´ì œëŠ” ë‚˜ì•„ì§ˆ ìˆ˜ ìˆê² ì£ ..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "ì–´ë–»ê²Œ ì´ëŸ´ ìˆ˜ê°€ ìˆì£ ..?";
                    Customer_PerfumeReaction[1] = "ìµœì•…ì´ì—ìš”..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë‹¤ë¥´ê²Œ ì‚¬ìš©í•œ ê²½ìš°
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//í–¥ë£Œë¥¼ í•˜ë‚˜ë¼ë„ ë„£ì§€ ì•Šê³  ë°”ë¡œ í–¥ìˆ˜ ì œì¡°í•œ ê²½ìš°
                {
                    Customer_PerfumeReaction[0] = "ìŒ.. ì „í˜€ ëŠë‚„ ìˆ˜ê°€ ì—†ëŠ”ë°ìš”..?";
                    Customer_PerfumeReaction[1] = "ì œëŒ€ë¡œ í•œ ê²Œ ë§ë‚˜ìš”...?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "ì´ê²Œ.. ë­ì£ ..?";
                    Customer_PerfumeReaction[1] = "ì „í˜€ ë‹¤ë¥¸ ëƒ„ìƒˆê°€ ë‚˜ëŠ”ë°ìš”..?";
                    Customer_PerfumeReaction[2] = "ì´ìƒí•œ ê±¸ ë„£ìœ¼ë©´ ì–´ë–¡í•´ìš”!!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    } 
  }
>>>>>>> 951f4d97b6e6b55c8c4057ab753fbe526e43de3a
