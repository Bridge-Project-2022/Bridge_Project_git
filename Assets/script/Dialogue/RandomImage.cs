using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{
    public Sprite[] A_Image = new Sprite[12];
    public Sprite[] B_Image = new Sprite[12];
    public Sprite[] C_Image = new Sprite[12];
    public Sprite[] D_Image = new Sprite[12];
    public Sprite[] E_Image = new Sprite[12];
    public Sprite[] F_Image = new Sprite[12];
    public Sprite[] G_Image = new Sprite[12];
    public Sprite[] H_Image = new Sprite[12];
    public Sprite[] I_Image = new Sprite[12];
    public Sprite[] J_Image = new Sprite[12];
    public Sprite[] K_Image = new Sprite[12];
    public Sprite[] L_Image = new Sprite[12];
    public Sprite[] Lorena_Image = new Sprite[12];

    public string CurrentName = "";
    public string CurrentFeel = "Common";
    public string CurrentTime = "morning";

    public GameObject Customer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (CurrentName == "A")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                    {
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[0];
                    }
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }
        else if (CurrentName == "B")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().B_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "C")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().C_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "D")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().D_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "E")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().E_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "F")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().F_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "G")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().G_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "H")
        {
            if(this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().H_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "I")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().I_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "J")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().J_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "K")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().K_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }

        else if (CurrentName == "L")
        {
            if (this.GetComponent<CriminalImage>().isCriminal == false)
            {
                if (CurrentFeel == "Common")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[0];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[1];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[2];
                }
                if (CurrentFeel == "Happy")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[3];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[4];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[5];
                }
                if (CurrentFeel == "Sad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[6];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[7];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[8];
                }
                if (CurrentFeel == "Bad")
                {
                    if (CurrentTime == "morning")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[9];
                    else if (CurrentTime == "afternoon")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[10];
                    else if (CurrentTime == "night")
                        Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().L_Image[11];
                }
                Customer.GetComponent<Image>().SetNativeSize();
            }
        }
    }
}