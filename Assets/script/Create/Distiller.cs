using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distiller : MonoBehaviour
{
    public float distillerTime = 6.0f;

    public GameObject distillerDetail;
    public GameObject distiller;
    public GameObject clickedItem;
    public ItemProperty ClickedItem;
    public GameObject itemImage;
    public GameObject InvenUI;

    public GameObject Receipt;
    bool isWickDown = false;
    public string DistillerStatus = "";

    public GameObject temperatureSlider;
    int temperature = 0;
    int maxTemperature = 135;

    public float HighTemperDuration = 0.0f;//향수 지속 시간
    public float TemperDuration = 0.0f;//향수 지속 시간
    public float LowTemperDuration = 0.0f;//향수 지속 시간
    
    float maxTemperDuration = 0.0f;
    float minTemperDuration = 0.0f;

    public bool DistillGood;
    public bool DistillNormal;
    public bool DistillBad;

    public string BaseItemName = ""; //손님이 요구하는 베이스 향료 이름

    public Animator Anim;

    public bool isLow = false;
    public bool isMiddle = false;
    public bool isHigh = false;

    public AudioClip LowSFX;
    public AudioClip MiddleSFX;
    public AudioClip HighSFX;

    public GameObject DistillWindow;

    public void OnEnable()
    {
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("boiling");
        Invoke("EndDistiller", distillerTime);
    }


    public void DistillWindowOpen()
    {
        GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
        DistillWindow.gameObject.SetActive(true);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }
public void DistillerOn(ItemProperty item)
    {
        TotalScore.FindObjectOfType<TotalScore>().DistillCnt++;
        for (int i = 0; i < GameObject.Find("BaseInvenSlots").transform.childCount; i++)
        {
            GameObject.Find("BaseInvenSlots").transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        Receipt.gameObject.SetActive(false);
        ClickedItem = item;
        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        if (ClickedItem.name == BaseItemName)
        {
            Debug.Log("베이스 향료 맞음");
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;

        }
        else
        {
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
        }
    }

    public void OnDistillerBtnClick()
    {
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        distillerDetail.SetActive(true);

        if (clickedItem == null)
            return;

        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }

    void Update()
    {
        if (isLow == true)
        {
            LowTemperDuration += Time.deltaTime;
            HighTemperDuration = 0;
            TemperDuration = 0;
        }
        if (isMiddle == true)
        {
            TemperDuration += Time.deltaTime;
            HighTemperDuration = 0;
            LowTemperDuration = 0;
        }
        if (isHigh == true)
        {
            HighTemperDuration += Time.deltaTime;
            TemperDuration = 0;
            LowTemperDuration = 0;
        }

        float curTemper = temperatureSlider.GetComponent<Slider>().value;
        if (isWickDown)//증류기누를 경우
        {
            temperatureSlider.GetComponent<Slider>().value += 0.3f;//누를 때 마다 슬라이더 1씩 증가

            if (curTemper >= 91 && curTemper <= 134)
            {
                //HighTemperDuration += 0.01f;
                isHigh = true;
                isMiddle = false;
                isLow = false;
                TemperDuration = 0;
                LowTemperDuration = 0;
                //Debug.Log("강불로 바뀜");
                Anim.SetBool("isHigh", true);
                Anim.SetBool("isNormal", false);
                Anim.SetBool("isLow", false);

                this.GetComponent<AudioSource>().clip = HighSFX;
                this.GetComponent<AudioSource>().Play();

                if (DistillerStatus == "강함")
                {
                    if (HighTemperDuration >= 3f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (HighTemperDuration >= 2f && HighTemperDuration < 3f)
                    {
                        DistillGood = false;
                        DistillNormal = true;
                        DistillBad = false;
                    }
                    if (HighTemperDuration < 2f)
                    {
                        DistillGood = false;
                        DistillNormal = false;
                        DistillBad = true;
                    }
                }
                else
                {
                    DistillGood = false;
                    DistillNormal = false;
                    DistillBad = true;
                }
            }
            if (curTemper >= 135)//현재 온도가 135보다 크면
            {
                maxTemperDuration *= Time.deltaTime;// 최대 지속 시간 초당 늘어남

                if (maxTemperDuration > 1.5f)// 최대 지속 시간 1.5보다 크면
                {
                    Debug.Log("타버림");
                    EndDistiller();
                    maxTemperDuration = 0.0f;
                }
            }
            else if (curTemper >= 46 && curTemper <= 90)
            {
                maxTemperDuration = 0.0f;
                HighTemperDuration = 0;
                LowTemperDuration = 0;
                isHigh = false;
                isMiddle = true;
                isLow = false;
                //TemperDuration += 0.01f;
                //Debug.Log("중불로 바뀜");
                Anim.SetBool("isHigh", false);
                Anim.SetBool("isNormal", true);
                Anim.SetBool("isLow", false);

                this.GetComponent<AudioSource>().clip = MiddleSFX;
                this.GetComponent<AudioSource>().Play();

                if (DistillerStatus == "보통")
                {
                    if (TemperDuration >= 3f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (TemperDuration >= 2f && TemperDuration < 3f)
                    {
                        DistillGood = false;
                        DistillNormal = true;
                        DistillBad = false;
                    }
                    if (TemperDuration < 2f)
                    {
                        DistillGood = false;
                        DistillNormal = false;
                        DistillBad = true;
                    }
                }
                else
                {
                    DistillGood = false;
                    DistillNormal = false;
                    DistillBad = true;
                }
            }
        }
        else
        {
            temperatureSlider.GetComponent<Slider>().value -= 0.3f;
            if (curTemper >= 1 && curTemper <= 45)
            {
                TemperDuration = 0;
                HighTemperDuration = 0;
                LowTemperDuration += 0.01f;
                //Debug.Log("약불로 바뀜");
                isHigh = false;
                isMiddle = false;
                isLow = true;
                Anim.SetBool("isHigh", false);
                Anim.SetBool("isNormal", false);
                Anim.SetBool("isLow", true);

                this.GetComponent<AudioSource>().clip = LowSFX;
                this.GetComponent<AudioSource>().Play();

                if (DistillerStatus == "약함")
                {
                    if (LowTemperDuration >= 3f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (LowTemperDuration >= 2f && LowTemperDuration < 3f)
                    {
                        DistillGood = false;
                        DistillNormal = true;
                        DistillBad = false;
                    }
                    if (LowTemperDuration < 2f)
                    {
                        DistillGood = false;
                        DistillNormal = false;
                        DistillBad = true;
                    }
                }
                else
                {
                    DistillGood = false;
                    DistillNormal = false;
                    DistillBad = true;
                }
            }
        }
    }

    public void EndDistiller()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().loop = false;
        DistillerResult();
        temperatureSlider.GetComponent<Slider>().value = 1;
        HighTemperDuration = 0.0f;
        TemperDuration = 0.0f;
        LowTemperDuration = 0.0f;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
        InvenUI.GetComponent<Button>().interactable = true;
        Invoke("CloseWindow", 0.5f);
    }

    public void CloseWindow()
    {
        TotalScore.FindObjectOfType<TotalScore>().isDistillFin = true;
        temperature = 0;
        distiller.gameObject.GetComponent<Button>().interactable = false;
        distillerDetail.SetActive(false);
        Receipt.gameObject.SetActive(true);

    }

    public void DistillerResult()
    {
        if (DistillerStatus == "강함")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("증류 잘됨");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("증류 보통");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("증류 안됨");
            }
        }

        else if (DistillerStatus == "보통")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("증류 잘됨");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("증류 보통");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("증류 안됨");
            }
        }

        else if (DistillerStatus == "약함")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("증류 잘됨");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("증류 보통");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("증류 안됨");
            }
        }

        /*else if (DistillerStatus == "아무거나")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
            }
        }*/

        else
        {
            TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
        }
    }
    public void WickDown()
    {
        isWickDown = true;
    }

    public void WickUp()
    {
        isWickDown = false;
    }
}
