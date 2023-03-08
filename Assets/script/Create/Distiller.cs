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

    public bool isBurn = false;

    public AudioClip LowSFX;
    public AudioClip MiddleSFX;
    public AudioClip HighSFX;

    public GameObject DistillWindow;
    public GameObject DistillPanel;

    public bool isBaseRight = false;

    public void OnEnable()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
            Invoke("EndDistiller", distillerTime);
    }


    public void DistillWindowOpen()
    {
        Receipt.gameObject.SetActive(false);
        GameObject.Find("Manufacture").transform.GetChild(7).gameObject.SetActive(false);
        DistillPanel.SetActive(false);
        GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
        DistillWindow.gameObject.SetActive(true);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }
public void DistillerOn(ItemProperty item)
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == true)
        {
            ClickedItem = item;
            itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
            if (ClickedItem.name == "동물")
            {
                isBaseRight = true;
                Debug.Log("튜토리얼 베이스 향료 맞음");
                DistillerStatus = "강함";
                Tutorial.FindObjectOfType<Tutorial>().NextTutDialogue();
            }
            else
            {
                isBaseRight = false;
            }
        }
        else
        {
            ClickedItem = item;
            itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
            if (ClickedItem.name == BaseItemName)
            {
                isBaseRight = true;
                Debug.Log("베이스 향료 맞음");
            }
            else
            {
                isBaseRight = false;
            }
        }
    }

    public void OnDistillerBtnClick()
    {
        if (isBaseRight == true)
        {
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
        }
        else if (isBaseRight == false)
        {
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
        }
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;
        distillerDetail.SetActive(true);

        if (clickedItem == null)
            return;

        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }

    void Update()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false || GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutDistill == true)
        {
            if (isLow == true)
            {
                LowTemperDuration += Time.deltaTime;
                HighTemperDuration = 0;
                TemperDuration = 0;

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
            if (isMiddle == true)
            {
                TemperDuration += Time.deltaTime;
                HighTemperDuration = 0;
                LowTemperDuration = 0;

                if (DistillerStatus == "중간")
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
            if (isHigh == true)
            {
                HighTemperDuration += Time.deltaTime;
                TemperDuration = 0;
                LowTemperDuration = 0;

                if (DistillerStatus == "강함")
                {
                    if (HighTemperDuration >= 3f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    else if (HighTemperDuration >= 2f && HighTemperDuration < 3f)
                    {
                        DistillGood = false;
                        DistillNormal = true;
                        DistillBad = false;
                    }
                    else if (HighTemperDuration < 2f)
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

            /*if (isBurn == true)
            {
                HighTemperDuration += Time.deltaTime;
                TemperDuration = 0;
                LowTemperDuration = 0;

                maxTemperDuration *= Time.deltaTime;// 최대 지속 시간 초당 늘어남
                if (maxTemperDuration > 1.5f)// 최대 지속 시간 1.5보다 크면
                {
                    DistillGood = false;
                    DistillNormal = false;
                    DistillBad = true;

                    EndDistiller();
                    maxTemperDuration = 0.0f;
                }
            }*/

            float curTemper = temperatureSlider.GetComponent<Slider>().value;

            if (isWickDown == true)//증류기누를 경우
            {
                temperatureSlider.GetComponent<Slider>().value += 0.3f;//누를 때 마다 슬라이더 1씩 증가

                if (curTemper >= 91 && curTemper <= 134)
                {
                    isHigh = true;
                    isMiddle = false;
                    isLow = false;
                    isBurn = false;

                    //Debug.Log("강불로 바뀜");
                    Anim.SetBool("isHigh", true);
                    Anim.SetBool("isNormal", false);
                    Anim.SetBool("isLow", false);

                    //this.GetComponent<AudioSource>().clip = HighSFX;
                    //this.GetComponent<AudioSource>().Play();
                }
                /*else if (curTemper >= 135)//현재 온도가 135보다 크면
                {
                    isHigh = false;
                    isMiddle = false;
                    isLow = false;
                    isBurn = true;

                    Debug.Log("타버림");
                    Anim.SetBool("isHigh", true);
                    Anim.SetBool("isNormal", false);
                    Anim.SetBool("isLow", false);

                    this.GetComponent<AudioSource>().clip = HighSFX;
                    this.GetComponent<AudioSource>().Play();
                }*/
                else if (curTemper >= 46 && curTemper <= 90)
                {
                    isHigh = false;
                    isMiddle = true;
                    isLow = false;
                    isBurn = false;

                    //Debug.Log("중불로 바뀜");
                    Anim.SetBool("isHigh", false);
                    Anim.SetBool("isNormal", true);
                    Anim.SetBool("isLow", false);

                    //this.GetComponent<AudioSource>().clip = MiddleSFX;
                    //this.GetComponent<AudioSource>().Play();
                }
            }
            if (isWickDown == false)
            {
                temperatureSlider.GetComponent<Slider>().value -= 0.3f;
                if (curTemper >= 1 && curTemper <= 45)
                {
                    isHigh = false;
                    isMiddle = false;
                    isLow = true;
                    isBurn = false;

                    Anim.SetBool("isHigh", false);
                    Anim.SetBool("isNormal", false);
                    Anim.SetBool("isLow", true);

                    //this.GetComponent<AudioSource>().clip = LowSFX;
                    //this.GetComponent<AudioSource>().Play();
                }

                else if (curTemper >= 46 && curTemper <= 90)
                {
                    isHigh = false;
                    isMiddle = true;
                    isLow = false;

                    //Debug.Log("중불로 바뀜");
                    Anim.SetBool("isHigh", false);
                    Anim.SetBool("isNormal", true);
                    Anim.SetBool("isLow", false);

                    //this.GetComponent<AudioSource>().clip = MiddleSFX;
                    //this.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
    public void DistillSound()
    {
        if (isHigh == true)
        {
            this.GetComponent<AudioSource>().clip = HighSFX;
            this.GetComponent<AudioSource>().Play();
        }
        else if (isMiddle == true)
        {
            this.GetComponent<AudioSource>().clip = MiddleSFX;
            this.GetComponent<AudioSource>().Play();
        }
        else if (isLow == true)
        {
            this.GetComponent<AudioSource>().clip = LowSFX;
            this.GetComponent<AudioSource>().Play();
        }
    }
    public void EndDistiller()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            DistillPanel.SetActive(true);
            GameObject.Find("SFX").GetComponent<AudioSource>().loop = false;
            DistillerResult();
            temperatureSlider.GetComponent<Slider>().value = 1;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
            InvenUI.GetComponent<Button>().interactable = true;
            Invoke("CloseWindow", 1.5f);
        }
        else
        {
            if (DistillGood == true)
            {
                DistillPanel.SetActive(true);
                GameObject.Find("SFX").GetComponent<AudioSource>().loop = false;
                DistillerResult();
                temperatureSlider.GetComponent<Slider>().value = 1;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
                InvenUI.GetComponent<Button>().interactable = true;
                Invoke("CloseWindow", 1.5f);
            }
            else
            {
                GameObject.Find("SFX").GetComponent<AudioSource>().loop = false;
                DistillerResult();
                temperatureSlider.GetComponent<Slider>().value = 1;
                HighTemperDuration = 0.0f;
                TemperDuration = 0.0f;
                LowTemperDuration = 0.0f;
                temperature = 0;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
            }
        }
    }

    public void CloseWindow()
    {
        GameObject.Find("Perfume").GetComponent<PerfumeColor>().FinishCnt++;
        GameObject.Find("Perfume").GetComponent<PerfumeColor>().PerfumeChoice(ClickedItem.name);
        DistillPanel.SetActive(false);
        isBaseRight = false;
        TotalScore.FindObjectOfType<TotalScore>().DistillCnt++;
        for (int i = 0; i < GameObject.Find("BaseInvenSlots").transform.childCount; i++)
        {
            GameObject.Find("BaseInvenSlots").transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        HighTemperDuration = 0.0f;
        TemperDuration = 0.0f;
        LowTemperDuration = 0.0f;
        TotalScore.FindObjectOfType<TotalScore>().isDistillFin = true;
        temperature = 0;
        distiller.gameObject.GetComponent<Button>().interactable = false;
        distillerDetail.SetActive(false);
        Receipt.gameObject.SetActive(true);

    }

    public void DistillerResult()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
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
                else if (DistillBad == true)
                {
                    TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                    Debug.Log("증류 안됨");
                }
            }

            else if (DistillerStatus == "중간")
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
                else if (DistillBad == true)
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
                else if (DistillBad == true)
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
        else
        {
            if (DistillGood == true)
            {
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().NextTutDialogue();
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
            }
            else
            {
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().TutDistillBad();
                HighTemperDuration = 0;
                TemperDuration = 0;
                LowTemperDuration = 0;
                Anim.SetBool("isHigh", false);
                Anim.SetBool("isNormal", false);
                Anim.SetBool("isLow", true);
                isLow = true;
                isMiddle = false;
                isHigh = false;
            }
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
