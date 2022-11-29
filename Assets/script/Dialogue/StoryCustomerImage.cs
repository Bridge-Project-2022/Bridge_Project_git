using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryCustomerImage : MonoBehaviour
{
    public Sprite[] L01_Image = new Sprite[12];
    public Sprite[] L02_Image = new Sprite[6];
    public Sprite[] L03_Image = new Sprite[12];
    public Sprite[] L04_Image = new Sprite[9];
    public Sprite[] L05_Image = new Sprite[6];

    public string CurrentName = "";
    public string CurrentFeel = "";
    public string CurrentTime = "morning";

    public bool isUnique = false;
    public int UniqueID = 1000;

    public GameObject Customer;

    void Update()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            CurrentName = GameObject.Find("DialogueScript1").GetComponent<DialogueScript>().Customer_Name.ToString();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            CurrentName = GameObject.Find("DialogueScript2").GetComponent<SecondDialogueScript>().Customer_Name.ToString();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            CurrentName = GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().Customer_Name.ToString();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            CurrentName = GameObject.Find("DialogueScript4").GetComponent<FourthDialogueScript>().Customer_Name.ToString();
        }
        RCFeeling();
    }

    public void RCFeeling()
    {
        if (CurrentName == "·Î·¹³ª")
        {
            if (isUnique == true)
            {
                if (CurrentFeel == "L01_vacant")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L01_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L01_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L01_Image[2];
                }
                if (CurrentFeel == "L01_faint1")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L01_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L01_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L01_Image[5];
                }
                if (CurrentFeel == "L01_faint2")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L01_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L01_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L01_Image[8];
                }
                if (CurrentFeel == "L01_cry")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L01_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L01_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L01_Image[11];
                }
                if (CurrentFeel == "L02_paintful1")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L02_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L02_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L02_Image[2];
                }
                if (CurrentFeel == "L02_paintful2")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L02_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L02_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L02_Image[5];
                }
                if (CurrentFeel == "L03_ecstatic1")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L03_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L03_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L03_Image[2];
                }
                if (CurrentFeel == "L03_ecstatic2")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L03_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L03_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L03_Image[5];
                }
                if (CurrentFeel == "L03_ecstatic3")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L03_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L03_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L03_Image[8];
                }
                if (CurrentFeel == "L03_ecstatic4")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L03_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L03_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L03_Image[11];
                }
                if (CurrentFeel == "L04_angry1")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L04_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L04_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L04_Image[2];
                }
                if (CurrentFeel == "L04_angry2")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L04_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L04_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L04_Image[5];
                }
                if (CurrentFeel == "L04_angry3")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L04_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L04_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L04_Image[8];
                }
                if (CurrentFeel == "L05_wobble1")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L05_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L05_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L05_Image[2];
                }
                if (CurrentFeel == "L05_wobble2")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = L05_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = L05_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = L05_Image[5];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }
    }
}
