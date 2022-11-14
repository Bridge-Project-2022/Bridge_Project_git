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
    //public Sprite[] E_Image = new Sprite[12];
    //public Sprite[] F_Image = new Sprite[12];
    public Sprite[] G_Image = new Sprite[12];
    public Sprite[] H_Image = new Sprite[12];
    //public Sprite[] I_Image = new Sprite[12];
    public Sprite[] J_Image = new Sprite[12];
    public Sprite[] K_Image = new Sprite[12];
    public Sprite[] L_Image = new Sprite[12];

    public string CurrentName = "";
    public string CurrentFeel = "basic";
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
        RCFeeling();
    }

    public void RCFeeling()
    {
        if (CurrentName == "A")
        {
            if (CurrentFeel == "Common")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<RandomImage>().A_Image[0];
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
        else if (CurrentName == "B")
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

        else if (CurrentName == "C")
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

        else if (CurrentName == "D")
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

        else if (CurrentName == "G")
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

        else if (CurrentName == "H")
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

        else if (CurrentName == "J")
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

        else if (CurrentName == "K")
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

        else if (CurrentName == "L")
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