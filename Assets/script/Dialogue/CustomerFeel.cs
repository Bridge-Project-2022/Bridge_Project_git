using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFeel : MonoBehaviour
{
    public string CurrentName = "";

    public bool orderStart = false;
    public bool intensityStart = false;
    public bool rejectStart = false;
    public bool reactionStart = false;

    public string[] Customer_Feel = new string[10];

    void Update()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 1)
        {
            //CurrentName = GameObject.Find("DialogueScript1").GetComponent<DialogueScript>().Customer_Name.ToString();
            CurrentName = GameObject.Find("DialogueScript1").GetComponent<TestDialogueScript>().Customer_Name.ToString();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 2)
        {
            CurrentName = GameObject.Find("DialogueScript2").GetComponent<SecondDialogueScript>().Customer_Name.ToString();
        }
        else if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            CurrentName = GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().Customer_Name.ToString();
 
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
                Customer_Feel[1] = "basic";
                Customer_Feel[2] = "basic";
                Customer_Feel[3] = "basic";
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
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
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
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
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
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
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
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
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
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
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
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
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
                Customer_Feel[2] = "good";
                Customer_Feel[3] = "basic";
                Customer_Feel[4] = "basic";

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

                for (int i = 3; i < Customer_Feel.Length; i++)
                {
                    Customer_Feel[i] = "";
                }
            }
            else if (reactionStart == true)
            {
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
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
                        Customer_Feel[0] = "basic";

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
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        Customer_Feel[0] = "basic";
                        Customer_Feel[1] = "sad";
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
                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
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
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (TotalScore.FindObjectOfType<TotalScore>().UseItem < 3)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
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
    }
}
