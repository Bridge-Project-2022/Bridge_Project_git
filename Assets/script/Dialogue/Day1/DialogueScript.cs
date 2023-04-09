using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    public GameObject Distiller;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[5];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
    public string[] Customer_PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] Customer_IntensityOrder = new string[5];//향수 강도 대사
    public string[] Customer_Flavoring = new string[3];//원하는 향료 선택(베, 미, 탑)
    public string[] Customer_RejectReaction = new string[5];//손님 거절 반응
    public string[] Customer_PerfumeReaction = new string[5];//향수 받을 시 손님 반응

    public string[] OrderFace = new string[5];
    public string[] IntensityFace = new string[5];
    public string[] RejectFace = new string[5];
    public string[] ReactFace = new string[5];

    public bool isCriminal = false;

    public int CriminalID = 10;

    public GameObject RC;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(0,5);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }
    }
    public void Update()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            Customer B = CustomerManager.Instance.days.day[0].customer[0];
            Customer J = CustomerManager.Instance.days.day[0].customer[1];
            Customer G = CustomerManager.Instance.days.day[0].customer[2];
            Customer E = CustomerManager.Instance.days.day[0].customer[3];
            Customer Lorena = CustomerManager.Instance.days.day[0].customer[4];

            if (Customer_ID[0] == B.id)
            {
                Customer_Name = B.name;

                if (B.uniqueGuest == false)
                {
                    RC.GetComponent<StoryCustomerImage>().isUnique = false;
                }

                if (B.criminalGuest == true)
                {
                    isCriminal = true;
                    CriminalID = B.id;
                }

                foreach (string str in B.dialogue.visitComment)
                {
                    Customer_PerfumeOrder = B.dialogue.visitComment;
                }

                foreach (string str in B.dialogue.requestComment)
                {
                    Customer_IntensityOrder = B.dialogue.requestComment;
                }

                foreach (string str in B.dialogue.refusalComment)
                {
                    Customer_RejectReaction = B.dialogue.refusalComment;
                }

                foreach (string str in B.dialogue.visitFace)
                {
                    OrderFace = B.dialogue.visitFace;
                }

                foreach (string str in B.dialogue.requestFace)
                {
                    IntensityFace = B.dialogue.requestFace;
                }

                foreach (string str in B.dialogue.refusalFace)
                {
                    RejectFace = B.dialogue.refusalFace;
                }

                Distiller.GetComponent<Distiller>().DistillerStatus = B.currentPerfume.perfumeForce[0];

                Customer_Flavoring[0] = B.currentPerfume.bassNotes;
                Customer_Flavoring[1] = B.currentPerfume.middleNotes;
                Customer_Flavoring[2] = B.currentPerfume.topNotes[0];


                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        foreach (string str in B.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = B.dialogue.resultGoodComment;
                        }

                        foreach (string str in B.dialogue.resultGoodFace)
                        {
                            ReactFace = B.dialogue.resultGoodFace;
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        foreach (string str in B.dialogue.resultNormalComment)
                        {
                            Customer_PerfumeReaction = B.dialogue.resultNormalComment;
                        }

                        foreach (string str in B.dialogue.resultNormalFace)
                        {
                            ReactFace = B.dialogue.resultNormalFace;
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        foreach (string str in B.dialogue.resultBadComment)
                        {
                            Customer_PerfumeReaction = B.dialogue.resultBadComment;
                        }

                        foreach (string str in B.dialogue.resultBadFace)
                        {
                            ReactFace = B.dialogue.resultBadFace;
                        }
                    }
                }
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        foreach (string str in B.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = B.dialogue.noFlavorComment;
                        }

                        foreach (string str in B.dialogue.noFlavorFace)
                        {
                            ReactFace = B.dialogue.noFlavorFace;
                        }
                    }

                    else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                    {
                        foreach (string str in B.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = B.dialogue.noExistComment;
                        }

                        foreach (string str in B.dialogue.noExistFace)
                        {
                            ReactFace = B.dialogue.noExistFace;
                        }
                    }
                }

            }

            if (Customer_ID[0] == J.id)
            {
                Customer_Name = J.name;

                if (J.uniqueGuest == false)
                {
                    RC.GetComponent<StoryCustomerImage>().isUnique = false;
                }

                if (J.criminalGuest == true)
                {
                    isCriminal = true;
                    CriminalID = J.id;
                }

                foreach (string str in J.dialogue.visitComment)
                {
                    Customer_PerfumeOrder = J.dialogue.visitComment;
                }

                foreach (string str in J.dialogue.requestComment)
                {
                    Customer_IntensityOrder = J.dialogue.requestComment;
                }

                foreach (string str in J.dialogue.refusalComment)
                {
                    Customer_RejectReaction = J.dialogue.refusalComment;
                }

                foreach (string str in J.dialogue.visitFace)
                {
                    OrderFace = J.dialogue.visitFace;
                }

                foreach (string str in J.dialogue.requestFace)
                {
                    IntensityFace = J.dialogue.requestFace;
                }

                foreach (string str in J.dialogue.refusalFace)
                {
                    RejectFace = J.dialogue.refusalFace;
                }

                Distiller.GetComponent<Distiller>().DistillerStatus = J.currentPerfume.perfumeForce[0];

                Customer_Flavoring[0] = J.currentPerfume.bassNotes;
                Customer_Flavoring[1] = J.currentPerfume.middleNotes;
                Customer_Flavoring[2] = J.currentPerfume.topNotes[0];


                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        foreach (string str in J.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = J.dialogue.resultGoodComment;
                        }

                        foreach (string str in J.dialogue.resultGoodFace)
                        {
                            ReactFace = J.dialogue.resultGoodFace;
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        foreach (string str in J.dialogue.resultNormalComment)
                        {
                            Customer_PerfumeReaction = J.dialogue.resultNormalComment;
                        }

                        foreach (string str in J.dialogue.resultNormalFace)
                        {
                            ReactFace = J.dialogue.resultNormalFace;
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        foreach (string str in J.dialogue.resultBadComment)
                        {
                            Customer_PerfumeReaction = J.dialogue.resultBadComment;
                        }

                        foreach (string str in J.dialogue.resultBadFace)
                        {
                            ReactFace = J.dialogue.resultBadFace;
                        }
                    }
                }
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        foreach (string str in J.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = J.dialogue.noFlavorComment;
                        }

                        foreach (string str in J.dialogue.noFlavorFace)
                        {
                            ReactFace = J.dialogue.noFlavorFace;
                        }
                    }

                    else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                    {
                        foreach (string str in J.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = J.dialogue.noExistComment;
                        }

                        foreach (string str in J.dialogue.noExistFace)
                        {
                            ReactFace = J.dialogue.noExistFace;
                        }
                    }
                }

            }

            if (Customer_ID[0] == G.id)
            {
                Customer_Name = G.name;

                if (G.uniqueGuest == false)
                {
                    RC.GetComponent<StoryCustomerImage>().isUnique = false;
                }

                if (G.criminalGuest == true)
                {
                    isCriminal = true;
                    CriminalID = G.id;
                }

                foreach (string str in G.dialogue.visitComment)
                {
                    Customer_PerfumeOrder = G.dialogue.visitComment;
                }

                foreach (string str in G.dialogue.requestComment)
                {
                    Customer_IntensityOrder = G.dialogue.requestComment;
                }

                foreach (string str in G.dialogue.refusalComment)
                {
                    Customer_RejectReaction = G.dialogue.refusalComment;
                }

                foreach (string str in G.dialogue.visitFace)
                {
                    OrderFace = G.dialogue.visitFace;
                }

                foreach (string str in G.dialogue.requestFace)
                {
                    IntensityFace = G.dialogue.requestFace;
                }

                foreach (string str in G.dialogue.refusalFace)
                {
                    RejectFace = G.dialogue.refusalFace;
                }

                Distiller.GetComponent<Distiller>().DistillerStatus = G.currentPerfume.perfumeForce[0];

                Customer_Flavoring[0] = G.currentPerfume.bassNotes;
                Customer_Flavoring[1] = G.currentPerfume.middleNotes;
                Customer_Flavoring[2] = G.currentPerfume.topNotes[0];


                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        foreach (string str in G.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = G.dialogue.resultGoodComment;
                        }

                        foreach (string str in G.dialogue.resultGoodFace)
                        {
                            ReactFace = G.dialogue.resultGoodFace;
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        foreach (string str in G.dialogue.resultNormalComment)
                        {
                            Customer_PerfumeReaction = G.dialogue.resultNormalComment;
                        }

                        foreach (string str in G.dialogue.resultNormalFace)
                        {
                            ReactFace = G.dialogue.resultNormalFace;
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        foreach (string str in G.dialogue.resultBadComment)
                        {
                            Customer_PerfumeReaction = G.dialogue.resultBadComment;
                        }

                        foreach (string str in G.dialogue.resultBadFace)
                        {
                            ReactFace = G.dialogue.resultBadFace;
                        }
                    }
                }
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        foreach (string str in G.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = G.dialogue.noFlavorComment;
                        }

                        foreach (string str in G.dialogue.noFlavorFace)
                        {
                            ReactFace = G.dialogue.noFlavorFace;
                        }
                    }

                    else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                    {
                        foreach (string str in G.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = G.dialogue.noExistComment;
                        }

                        foreach (string str in G.dialogue.noExistFace)
                        {
                            ReactFace = G.dialogue.noExistFace;
                        }
                    }
                }

            }

            if (Customer_ID[0] == E.id)
            {
                Customer_Name = E.name;

                if (E.uniqueGuest == false)
                {
                    RC.GetComponent<StoryCustomerImage>().isUnique = false;
                }

                if (E.criminalGuest == true)
                {
                    isCriminal = true;
                    CriminalID = E.id;
                }

                foreach (string str in E.dialogue.visitComment)
                {
                    Customer_PerfumeOrder = E.dialogue.visitComment;
                }

                foreach (string str in E.dialogue.requestComment)
                {
                    Customer_IntensityOrder = E.dialogue.requestComment;
                }

                foreach (string str in E.dialogue.refusalComment)
                {
                    Customer_RejectReaction = E.dialogue.refusalComment;
                }

                foreach (string str in E.dialogue.visitFace)
                {
                    OrderFace = E.dialogue.visitFace;
                }

                foreach (string str in E.dialogue.requestFace)
                {
                    IntensityFace = E.dialogue.requestFace;
                }

                foreach (string str in E.dialogue.refusalFace)
                {
                    RejectFace = E.dialogue.refusalFace;
                }

                Distiller.GetComponent<Distiller>().DistillerStatus = E.currentPerfume.perfumeForce[0];

                Customer_Flavoring[0] = E.currentPerfume.bassNotes;
                Customer_Flavoring[1] = E.currentPerfume.middleNotes;
                Customer_Flavoring[2] = E.currentPerfume.topNotes[0];


                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        foreach (string str in E.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = E.dialogue.resultGoodComment;
                        }

                        foreach (string str in E.dialogue.resultGoodFace)
                        {
                            ReactFace = E.dialogue.resultGoodFace;
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        foreach (string str in E.dialogue.resultNormalComment)
                        {
                            Customer_PerfumeReaction = E.dialogue.resultNormalComment;
                        }

                        foreach (string str in E.dialogue.resultNormalFace)
                        {
                            ReactFace = E.dialogue.resultNormalFace;
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        foreach (string str in E.dialogue.resultBadComment)
                        {
                            Customer_PerfumeReaction = E.dialogue.resultBadComment;
                        }

                        foreach (string str in E.dialogue.resultBadFace)
                        {
                            ReactFace = E.dialogue.resultBadFace;
                        }
                    }
                }
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        foreach (string str in E.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = E.dialogue.noFlavorComment;
                        }

                        foreach (string str in E.dialogue.noFlavorFace)
                        {
                            ReactFace = E.dialogue.noFlavorFace;
                        }
                    }

                    else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                    {
                        foreach (string str in E.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = E.dialogue.noExistComment;
                        }

                        foreach (string str in E.dialogue.noExistFace)
                        {
                            ReactFace = E.dialogue.noExistFace;
                        }
                    }
                }

            }

            if (Customer_ID[0] == Lorena.id)
            {
                Customer_Name = Lorena.name;

                if (Lorena.uniqueGuest == true)
                {
                    RC.GetComponent<StoryCustomerImage>().isUnique = true;
                    RC.GetComponent<StoryCustomerImage>().UniqueID = Lorena.id;
                }

                if (Lorena.criminalGuest == true)
                {
                    isCriminal = true;
                    CriminalID = Lorena.id;
                }

                foreach (string str in Lorena.dialogue.visitComment)
                {
                    Customer_PerfumeOrder = Lorena.dialogue.visitComment;
                }

                foreach (string str in Lorena.dialogue.requestComment)
                {
                    Customer_IntensityOrder = Lorena.dialogue.requestComment;
                }

                foreach (string str in Lorena.dialogue.refusalComment)
                {
                    Customer_RejectReaction = Lorena.dialogue.refusalComment;
                }

                foreach (string str in Lorena.dialogue.visitFace)
                {
                    OrderFace = Lorena.dialogue.visitFace;
                }

                foreach (string str in Lorena.dialogue.requestFace)
                {
                    IntensityFace = Lorena.dialogue.requestFace;
                }

                foreach (string str in Lorena.dialogue.refusalFace)
                {
                    RejectFace = Lorena.dialogue.refusalFace;
                }

                Distiller.GetComponent<Distiller>().DistillerStatus = Lorena.currentPerfume.perfumeForce[0];

                Customer_Flavoring[0] = Lorena.currentPerfume.bassNotes;
                Customer_Flavoring[1] = Lorena.currentPerfume.middleNotes;
                Customer_Flavoring[2] = Lorena.currentPerfume.topNotes[0];


                if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
                {
                    if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                    {
                        foreach (string str in Lorena.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = Lorena.dialogue.resultGoodComment;
                        }

                        foreach (string str in Lorena.dialogue.resultGoodFace)
                        {
                            ReactFace = Lorena.dialogue.resultGoodFace;
                        }
                    }

                    else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                    {
                        foreach (string str in Lorena.dialogue.resultNormalComment)
                        {
                            Customer_PerfumeReaction = Lorena.dialogue.resultNormalComment;
                        }

                        foreach (string str in Lorena.dialogue.resultNormalFace)
                        {
                            ReactFace = Lorena.dialogue.resultNormalFace;
                        }
                    }

                    else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                    {
                        foreach (string str in Lorena.dialogue.resultBadComment)
                        {
                            Customer_PerfumeReaction = Lorena.dialogue.resultBadComment;
                        }

                        foreach (string str in Lorena.dialogue.resultBadFace)
                        {
                            ReactFace = Lorena.dialogue.resultBadFace;
                        }
                    }
                }
                else//향료를 하나라도 다르게 사용한 경우
                {
                    if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                    {
                        foreach (string str in Lorena.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = Lorena.dialogue.noFlavorComment;
                        }

                        foreach (string str in Lorena.dialogue.noFlavorFace)
                        {
                            ReactFace = Lorena.dialogue.noFlavorFace;
                        }
                    }

                    else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                    {
                        foreach (string str in Lorena.dialogue.resultGoodComment)
                        {
                            Customer_PerfumeReaction = Lorena.dialogue.noExistComment;
                        }

                        foreach (string str in Lorena.dialogue.noExistFace)
                        {
                            ReactFace = Lorena.dialogue.noExistFace;
                        }
                    }
                }

            }

            TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
            TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
            TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
        }
    } 
  }
