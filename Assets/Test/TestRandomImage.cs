using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRandomImage : MonoBehaviour
{
    public Sprite[] A_Image = new Sprite[12];
    public Sprite[] B_Image = new Sprite[12];
    //public Sprite[] C_Image = new Sprite[12];
    public Sprite[] D_Image = new Sprite[12];
    //public Sprite[] E_Image = new Sprite[12];
    //public Sprite[] F_Image = new Sprite[12];
    public Sprite[] G_Image = new Sprite[12];
    public Sprite[] H_Image = new Sprite[12];
    //public Sprite[] I_Image = new Sprite[12];
    //public Sprite[] J_Image = new Sprite[12];
    //public Sprite[] K_Image = new Sprite[12];

    public Sprite[] Lorena1_Image = new Sprite[12];
    public Sprite[] Lorena2_Image = new Sprite[12];

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
            CurrentName = GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>().Customer_Name.ToString();
        }
        RCFeeling();
    }

    public void RCFeeling()
    {
        if (CurrentName == "A")
        {
            if (CurrentFeel == "basic")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[2];
            }
            if (CurrentFeel == "good")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[5];
            }
            if (CurrentFeel == "sad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[8];
            }
            if (CurrentFeel == "bad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().A_Image[11];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }
        else if (CurrentName == "B")
        {
            if (CurrentFeel == "basic")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[2];
            }
            if (CurrentFeel == "good")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[5];
            }
            if (CurrentFeel == "sad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[8];
            }
            if (CurrentFeel == "bad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().B_Image[11];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "D")
        {
            if (CurrentFeel == "basic")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[2];
            }
            if (CurrentFeel == "good")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[5];
            }
            if (CurrentFeel == "sad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[8];
            }
            if (CurrentFeel == "bad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().D_Image[11];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "G")
        {
            if (CurrentFeel == "basic")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[2];
            }
            if (CurrentFeel == "good")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[5];
            }
            if (CurrentFeel == "sad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[8];
            }
            if (CurrentFeel == "bad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().G_Image[11];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "H")
        {
            if (CurrentFeel == "basic")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[2];
            }
            if (CurrentFeel == "good")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[5];
            }
            if (CurrentFeel == "sad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[8];
            }
            if (CurrentFeel == "bad")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().H_Image[11];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "Lorena1")
        {
            if (CurrentFeel == "1-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[2];
            }
            if (CurrentFeel == "1-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[5];
            }
            if (CurrentFeel == "1-c")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[8];
            }
            if (CurrentFeel == "1-d")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[11];
            }
            else
            {
                Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "Lorena2")
        {
            if (CurrentFeel == "1-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[2];
            }
            if (CurrentFeel == "1-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[5];
            }
            if (CurrentFeel == "1-c")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[8];
            }
            if (CurrentFeel == "1-d")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[11];
            }
            if (CurrentFeel == "2-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[2];
            }
            if (CurrentFeel == "2-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[5];
            }
            else
            {
                Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "Lorena2_1")
        {
            if (CurrentFeel == "1-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[2];
            }
            if (CurrentFeel == "1-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[5];
            }
            if (CurrentFeel == "1-c")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[8];
            }
            if (CurrentFeel == "1-d")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[11];
            }
            else
            {
                Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }

        else if (CurrentName == "Lorena2_2")
        {
            if (CurrentFeel == "1-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[2];
            }
            if (CurrentFeel == "1-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[5];
            }
            if (CurrentFeel == "1-c")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[6];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[7];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[8];
            }
            if (CurrentFeel == "1-d")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[9];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[10];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[11];
            }
            if (CurrentFeel == "2-a")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[0];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[1];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[2];
            }
            if (CurrentFeel == "2-b")
            {
                if (CurrentTime == "morning")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[3];
                else if (CurrentTime == "afternoon")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[4];
                else if (CurrentTime == "night")
                    Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena2_Image[5];
            }
            else
            {
                Customer.GetComponent<Image>().sprite = this.GetComponent<TestRandomImage>().Lorena1_Image[0];
            }
            Customer.GetComponent<Image>().SetNativeSize();
        }


    }
}
