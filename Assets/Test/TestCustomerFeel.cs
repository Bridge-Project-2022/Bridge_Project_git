using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCustomerFeel : MonoBehaviour
{
    public string CurrentName = "";

    public bool orderStart = false;
    public bool intensityStart = false;
    public bool rejectStart = false;
    public bool reactionStart = false;
    public bool declareStart = false;

    public string[] Customer_Feel = new string[10];

    void Update()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            CurrentName = GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>().Customer_Name.ToString();
        }
        FeelSelect();
    }

    public void FeelSelect()
    {
        if (CurrentName == "A")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "basic";
                Customer_Feel[1] = "sad";
                Customer_Feel[2] = "basic";
                Customer_Feel[3] = "sad";
                Customer_Feel[4] = "basic";

                for (int i = 5; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "good";
                for (int i = 1; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "sad";
                Customer_Feel[1] = "sad";
                Customer_Feel[2] = "sad";
                Customer_Feel[3] = "sad";

                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "bad";
                Customer_Feel[1] = "bad";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "good";
                        Customer_Feel[1] = "good";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "good";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "basic";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "sad";
                        Customer_Feel[1] = "sad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "bad";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }
        if (CurrentName == "B")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "basic";
                Customer_Feel[1] = "basic";
                Customer_Feel[2] = "good";
                Customer_Feel[3] = "basic";
                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "good";
                for (int i = 1; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "sad";
                Customer_Feel[1] = "sad";
                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "sad";
                Customer_Feel[1] = "sad";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "good";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "good";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        Customer_Feel[2] = "bad";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        Customer_Feel[2] = "bad";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }

        if (CurrentName == "D")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "good";
                Customer_Feel[1] = "good";
                Customer_Feel[2] = "good";
                Customer_Feel[3] = "good";
                Customer_Feel[4] = "good";

                for (int i = 5; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "basic";
                for (int i = 1; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "basic";
                Customer_Feel[1] = "basic";
                Customer_Feel[2] = "basic";

                for (int i = 3; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "bad";
                Customer_Feel[1] = "bad";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "good";
                        Customer_Feel[1] = "good";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "good";
                        Customer_Feel[1] = "good";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }

        if (CurrentName == "G")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "basic";
                Customer_Feel[1] = "basic";
                Customer_Feel[2] = "basic";
                Customer_Feel[3] = "sad";
                Customer_Feel[4] = "good";

                for (int i = 5; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "basic";

                for (int i = 1; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "bad";
                Customer_Feel[1] = "bad";
                Customer_Feel[2] = "bad";
                Customer_Feel[3] = "bad";


                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "bad";
                Customer_Feel[1] = "bad";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "good";

                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "basic";

                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "bad";

                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "bad";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "bad";
                        for (int i = 1; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }

        if (CurrentName == "H")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "sad";
                Customer_Feel[1] = "sad";
                Customer_Feel[2] = "sad";
                Customer_Feel[3] = "sad";
                Customer_Feel[4] = "sad";
                Customer_Feel[5] = "sad";
                Customer_Feel[6] = "sad";
                Customer_Feel[7] = "sad";

                for (int i = 8; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "sad";
                Customer_Feel[1] = "sad";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "bad";
                Customer_Feel[1] = "bad";
                Customer_Feel[2] = "bad";

                for (int i = 3; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "sad";
                        Customer_Feel[1] = "sad";
                        Customer_Feel[2] = "sad";

                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "good";
                        Customer_Feel[1] = "good";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        Customer_Feel[2] = "bad";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "bad";
                        Customer_Feel[1] = "bad";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }

        if (CurrentName == "Lorena1")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-a";
                Customer_Feel[2] = "1-a";
                Customer_Feel[3] = "1-a";
                Customer_Feel[4] = "1-a";
                Customer_Feel[5] = "1-a";

                for (int i = 6; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "1-b";

                for (int i = 1; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "1-c";
                Customer_Feel[1] = "1-c";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-c";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "1-b";
                        Customer_Feel[1] = "1-b";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "1-b";
                        Customer_Feel[1] = "1-b";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "1-a";
                        Customer_Feel[1] = "1-a";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "1-a";
                        Customer_Feel[1] = "1-a";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }
        if (CurrentName == "Lorena2")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-b";
                Customer_Feel[2] = "1-b";
                Customer_Feel[3] = "1-c";
                Customer_Feel[4] = "1-c";

                for (int i = 5; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "1-c";
                Customer_Feel[1] = "1-c";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "1-d";
                Customer_Feel[1] = "1-d";
                Customer_Feel[2] = "2-a";
                Customer_Feel[3] = "2-a";

                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "1-d";
                Customer_Feel[1] = "1-d";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "1-b";
                        Customer_Feel[1] = "1-b";

                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "1-a";
                        Customer_Feel[1] = "1-b";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-d";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-c";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-c";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }
        if (CurrentName == "Lorena2_1")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-a";
                Customer_Feel[2] = "1-a";
                Customer_Feel[3] = "1-a";
                Customer_Feel[4] = "1-a";
                Customer_Feel[5] = "1-a";

                for (int i = 6; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-b";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "1-c";
                Customer_Feel[1] = "1-c";
                Customer_Feel[2] = "1-c";

                for (int i = 3; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "1-d";
                Customer_Feel[1] = "1-d";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-c";
                        Customer_Feel[3] = "1-b";

                        for (int i = 4; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "1-b";
                        Customer_Feel[1] = "1-b";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-d";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-c";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-c";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }
        if (CurrentName == "Lorena2_2")
        {
            if (orderStart == true)
            {
                Customer_Feel[0] = "1-a";
                Customer_Feel[1] = "1-a";
                Customer_Feel[2] = "1-a";
                Customer_Feel[3] = "1-c";

                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (intensityStart == true)
            {
                Customer_Feel[0] = "1-c";
                Customer_Feel[1] = "1-c";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (rejectStart == true)
            {
                Customer_Feel[0] = "1-d";
                Customer_Feel[1] = "1-d";
                Customer_Feel[2] = "1-d";
                Customer_Feel[3] = "2-a";

                for (int i = 4; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }

            else if (declareStart == true)
            {
                Customer_Feel[0] = "1-d";
                Customer_Feel[1] = "1-d";

                for (int i = 2; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        Customer_Feel[0] = "1-b";
                        Customer_Feel[1] = "1-b";

                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        Customer_Feel[0] = "1-a";
                        Customer_Feel[1] = "1-b";
                        Customer_Feel[2] = "1-b";

                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        Customer_Feel[0] = "1-a";
                        Customer_Feel[1] = "1-c";
                        Customer_Feel[2] = "1-d";
                        for (int i = 3; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
                else//��Ḧ �ϳ��� �ٸ��� ����� ���
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                    {
                        Customer_Feel[0] = "2-a";
                        Customer_Feel[1] = "2-b";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }

                    else
                    {
                        Customer_Feel[0] = "1-c";
                        Customer_Feel[1] = "1-d";
                        for (int i = 2; i < Customer_Feel.Length; i++)
                        {
                            Customer_Feel[i] = "";
                        }
                    }
                }
            }
        }
    }
}