using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distiller : MonoBehaviour
{
    public float distillerTime = 6.0f;

    public GameObject distillerWindow;
    public GameObject distiller;
    public GameObject clickedItem;
    public ItemProperty ClickedItem;
    public GameObject itemImage;
    public GameObject InvenUI;

    bool isWickDown = false;
    public string DistillerStatus = "";

    public GameObject temperatureSlider;
    int temperature = 0;
    int maxTemperature = 135;

    public float HighTemperDuration = 0.0f;//��� ���� �ð�
    public float TemperDuration = 0.0f;//��� ���� �ð�
    public float LowTemperDuration = 0.0f;//��� ���� �ð�
    
    float maxTemperDuration = 0.0f;
    float minTemperDuration = 0.0f;

    public bool DistillGood;
    public bool DistillNormal;
    public bool DistillBad;

    public string BaseItemName = ""; //�մ��� �䱸�ϴ� ���̽� ��� �̸�

    public Animator Anim;

    //public GameObject baseInvenSlots;

    public void OnEnable()
    {
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("boiling");
        Invoke("EndDistiller", distillerTime);
    }

public void DistillerOn(ItemProperty item)
    {
        //this.gameObject.GetComponent<Button>().interactable = true;//������ ��ư Ŭ�� ��������.
        ClickedItem = item;
        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        if (ClickedItem.name == BaseItemName)
        {
            Debug.Log("���̽� ��� ����");
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
        distillerWindow.SetActive(true);

        if (clickedItem == null)
            return;

        itemImage.GetComponent<Image>().sprite = clickedItem.GetComponent<Image>().sprite;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("fireon");
    }

    void Update()
    {
        float curTemper = temperatureSlider.GetComponent<Slider>().value;
        if (isWickDown)//�����⴩�� ���
        {
            temperatureSlider.GetComponent<Slider>().value += 0.1f;//���� �� ���� �����̴� 1�� ����

            if (curTemper >= 91 && curTemper <= 134)
            {
                HighTemperDuration += 0.01f;
                TemperDuration = 0;
                LowTemperDuration = 0;
                //Debug.Log("���ҷ� �ٲ�");
                Anim.SetBool("isHigh", true);
                Anim.SetBool("isNormal", false);
                Anim.SetBool("isLow", false);
                if (DistillerStatus == "����")
                {
                    if (HighTemperDuration >= 4f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (HighTemperDuration >= 2f && HighTemperDuration < 4f)
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
            if (curTemper >= 135)//���� �µ��� 135���� ũ��
            {
                maxTemperDuration *= Time.deltaTime;// �ִ� ���� �ð� �ʴ� �þ

                if (maxTemperDuration > 1.5f)// �ִ� ���� �ð� 1.5���� ũ��
                {
                    Debug.Log("Ÿ����");
                    //itemImage.GetComponent<Image>().color = new Color(1, 0, 0); 
                    //clickedItem.GetComponent<Image>().color = new Color(1, 0, 0);
                    EndDistiller();
                    maxTemperDuration = 0.0f;
                }
            }
            else if (curTemper >= 46 && curTemper <= 90)
            {
                maxTemperDuration = 0.0f;
                HighTemperDuration = 0;
                LowTemperDuration = 0;
                TemperDuration += 0.01f;
                //Debug.Log("�ߺҷ� �ٲ�");
                Anim.SetBool("isHigh", false);
                Anim.SetBool("isNormal", true);
                Anim.SetBool("isLow", false);

                if (DistillerStatus == "����")
                {
                    if (TemperDuration >= 4f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (TemperDuration >= 2f && TemperDuration < 4f)
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
            temperatureSlider.GetComponent<Slider>().value -= 0.1f;
            if (curTemper >= 1 && curTemper <= 45)
            {
                TemperDuration = 0;
                HighTemperDuration = 0;
                LowTemperDuration += 0.01f;
                //Debug.Log("��ҷ� �ٲ�");
                Anim.SetBool("isHigh", false);
                Anim.SetBool("isNormal", false);
                Anim.SetBool("isLow", true);

                if (DistillerStatus == "�ƹ��ų�")
                {
                    if (LowTemperDuration >= 4f)
                    {
                        DistillGood = true;
                        DistillNormal = false;
                        DistillBad = false;
                    }
                    if (LowTemperDuration >= 2f && LowTemperDuration < 4f)
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
        DistillerResult();
        temperatureSlider.GetComponent<Slider>().value = 1;
        HighTemperDuration = 0;
        TemperDuration = 0;
        LowTemperDuration = 0;
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().SFXStop();
        InvenUI.GetComponent<Button>().interactable = true;
        Invoke("CloseWindow", 0.5f);
    }

    public void CloseWindow()
    {
        TotalScore.FindObjectOfType<TotalScore>().isDistillFin = true;
        temperature = 0;
        distiller.gameObject.GetComponent<Button>().interactable = false;
        distillerWindow.SetActive(false);
        
    }

    public void DistillerResult()
    {
        if (DistillerStatus == "����")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("���� �ߵ�");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("���� ����");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("���� �ȵ�");
            }
        }

        else if (DistillerStatus == "����")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("���� �ߵ�");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("���� ����");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("���� �ȵ�");
            }
        }

        else if (DistillerStatus == "�ƹ��ų�")
        {
            if (DistillGood == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillGood = true;
                Debug.Log("���� �ߵ�");
            }
            else if (DistillNormal == true)
            {
                DistillBad = false;
                TotalScore.FindObjectOfType<TotalScore>().isDistillNormal = true;
                Debug.Log("���� ����");
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isDistillBad = true;
                Debug.Log("���� �ȵ�");
            }
        }

        /*else if (DistillerStatus == "�ƹ��ų�")
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
