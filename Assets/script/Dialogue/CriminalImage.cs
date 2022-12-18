using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriminalImage : MonoBehaviour
{
    public Sprite[] G1_Criminal_Image = new Sprite[12];
    public Sprite[] G2_Criminal_Image = new Sprite[12];
    public Sprite[] G3_Criminal_Image = new Sprite[12];
    public Sprite[] G4_Criminal_Image = new Sprite[12];

    public Sprite[] H1_Criminal_Image = new Sprite[12];
    public Sprite[] H2_Criminal_Image = new Sprite[12];
    public Sprite[] H3_Criminal_Image = new Sprite[12];
    public Sprite[] H4_Criminal_Image = new Sprite[12];


    public string CurrentName = "";
    public string CurrentFeel = "Common";
    public string CurrentTime = "morning";

    public bool isCriminal = false;
    public int CriminaID = 1000;

    public GameObject Customer;
    public GameObject CriminalSystem;

    void Update()
    {
        CurrentTime = this.GetComponent<RandomImage>().CurrentTime;

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
       
       if (CurrentName == "G")
        {
            if (isCriminal == true)
            {
                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 1)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G1_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 2)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G2_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 3)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G3_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 4)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().G4_Criminal_Image[11];
                    }
                }
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "H")
        {
            if (isCriminal == true)
            {
                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 1)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H1_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 2)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H2_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 3)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H3_Criminal_Image[11];
                    }
                }

                if (CriminalSystem.GetComponent<CriminalSystem>().CriminalNum[0] == 4)
                {
                    if (CurrentFeel == "Common")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[0];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[1];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[2];
                    }
                    if (CurrentFeel == "Happy")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[3];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[4];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[5];
                    }
                    if (CurrentFeel == "Sad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[6];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[7];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[8];
                    }
                    if (CurrentFeel == "Bad")
                    {
                        if (CurrentTime == "morning")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[9];
                        else if (CurrentTime == "afternoon")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[10];
                        else if (CurrentTime == "night")
                            Customer.GetComponent<Image>().sprite = this.GetComponent<CriminalImage>().H4_Criminal_Image[11];
                    }
                }
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }
    }
}
