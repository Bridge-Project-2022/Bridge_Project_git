using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDialogueScript : MonoBehaviour
{
    public GameObject Distiller;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[9];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
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
    public bool isUnique = false;

    public int CriminalID = 10;
    public int UniqueID = 10;

    public GameObject RC;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(18, 27);
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
        Customer C = CustomerManager.Instance.days.day[2].customer[0];
        Customer G = CustomerManager.Instance.days.day[2].customer[1];
        Customer I = CustomerManager.Instance.days.day[2].customer[2];
        Customer E = CustomerManager.Instance.days.day[2].customer[3];
        Customer F = CustomerManager.Instance.days.day[2].customer[4];
        Customer B = CustomerManager.Instance.days.day[2].customer[5];
        Customer L = CustomerManager.Instance.days.day[2].customer[6];
        Customer D = CustomerManager.Instance.days.day[2].customer[7];
        Customer Lorena = CustomerManager.Instance.days.day[2].customer[8];


        if (Customer_ID[0] == B.id)
        {
            Customer_Name = B.name;

            if (B.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = B.id;
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

        if (Customer_ID[0] == F.id)
        {
            Customer_Name = F.name;

            if (F.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = F.id;
            }

            if (F.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = F.id;
            }

            foreach (string str in F.dialogue.visitComment)
            {
                Customer_PerfumeOrder = F.dialogue.visitComment;
            }

            foreach (string str in F.dialogue.requestComment)
            {
                Customer_IntensityOrder = F.dialogue.requestComment;
            }

            foreach (string str in F.dialogue.refusalComment)
            {
                Customer_RejectReaction = F.dialogue.refusalComment;
            }

            foreach (string str in F.dialogue.visitFace)
            {
                OrderFace = F.dialogue.visitFace;
            }

            foreach (string str in F.dialogue.requestFace)
            {
                IntensityFace = F.dialogue.requestFace;
            }

            foreach (string str in F.dialogue.refusalFace)
            {
                RejectFace = F.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = F.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = F.currentPerfume.bassNotes;
            Customer_Flavoring[1] = F.currentPerfume.middleNotes;
            Customer_Flavoring[2] = F.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in F.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = F.dialogue.resultGoodComment;
                    }

                    foreach (string str in F.dialogue.resultGoodFace)
                    {
                        ReactFace = F.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in F.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = F.dialogue.resultNormalComment;
                    }

                    foreach (string str in F.dialogue.resultNormalFace)
                    {
                        ReactFace = F.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in F.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = F.dialogue.resultBadComment;
                    }

                    foreach (string str in F.dialogue.resultBadFace)
                    {
                        ReactFace = F.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in F.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = F.dialogue.noFlavorComment;
                    }

                    foreach (string str in F.dialogue.noFlavorFace)
                    {
                        ReactFace = F.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in F.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = F.dialogue.noExistComment;
                    }

                    foreach (string str in F.dialogue.noExistFace)
                    {
                        ReactFace = F.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == E.id)
        {
            Customer_Name = E.name;

            if (E.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = E.id;
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

        if (Customer_ID[0] == C.id)
        {
            Customer_Name = C.name;

            if (C.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = C.id;
            }

            if (C.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = C.id;
            }

            foreach (string str in C.dialogue.visitComment)
            {
                Customer_PerfumeOrder = C.dialogue.visitComment;
            }

            foreach (string str in C.dialogue.requestComment)
            {
                Customer_IntensityOrder = C.dialogue.requestComment;
            }

            foreach (string str in C.dialogue.refusalComment)
            {
                Customer_RejectReaction = C.dialogue.refusalComment;
            }

            foreach (string str in C.dialogue.visitFace)
            {
                OrderFace = C.dialogue.visitFace;
            }

            foreach (string str in C.dialogue.requestFace)
            {
                IntensityFace = C.dialogue.requestFace;
            }

            foreach (string str in C.dialogue.refusalFace)
            {
                RejectFace = C.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = C.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = C.currentPerfume.bassNotes;
            Customer_Flavoring[1] = C.currentPerfume.middleNotes;
            Customer_Flavoring[2] = C.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in C.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = C.dialogue.resultGoodComment;
                    }

                    foreach (string str in C.dialogue.resultGoodFace)
                    {
                        ReactFace = C.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in C.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = C.dialogue.resultNormalComment;
                    }

                    foreach (string str in C.dialogue.resultNormalFace)
                    {
                        ReactFace = C.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in C.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = C.dialogue.resultBadComment;
                    }

                    foreach (string str in C.dialogue.resultBadFace)
                    {
                        ReactFace = C.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in C.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = C.dialogue.noFlavorComment;
                    }

                    foreach (string str in C.dialogue.noFlavorFace)
                    {
                        ReactFace = C.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in C.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = C.dialogue.noExistComment;
                    }

                    foreach (string str in C.dialogue.noExistFace)
                    {
                        ReactFace = C.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == D.id)
        {
            Customer_Name = D.name;

            if (D.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = D.id;
            }

            if (D.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = D.id;
            }

            foreach (string str in D.dialogue.visitComment)
            {
                Customer_PerfumeOrder = D.dialogue.visitComment;
            }

            foreach (string str in D.dialogue.requestComment)
            {
                Customer_IntensityOrder = D.dialogue.requestComment;
            }

            foreach (string str in D.dialogue.refusalComment)
            {
                Customer_RejectReaction = D.dialogue.refusalComment;
            }

            foreach (string str in D.dialogue.visitFace)
            {
                OrderFace = D.dialogue.visitFace;
            }

            foreach (string str in D.dialogue.requestFace)
            {
                IntensityFace = D.dialogue.requestFace;
            }

            foreach (string str in D.dialogue.refusalFace)
            {
                RejectFace = D.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = D.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = D.currentPerfume.bassNotes;
            Customer_Flavoring[1] = D.currentPerfume.middleNotes;
            Customer_Flavoring[2] = D.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in D.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = D.dialogue.resultGoodComment;
                    }

                    foreach (string str in D.dialogue.resultGoodFace)
                    {
                        ReactFace = D.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in D.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = D.dialogue.resultNormalComment;
                    }

                    foreach (string str in D.dialogue.resultNormalFace)
                    {
                        ReactFace = D.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in D.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = D.dialogue.resultBadComment;
                    }

                    foreach (string str in D.dialogue.resultBadFace)
                    {
                        ReactFace = D.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in D.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = D.dialogue.noFlavorComment;
                    }

                    foreach (string str in D.dialogue.noFlavorFace)
                    {
                        ReactFace = D.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in D.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = D.dialogue.noExistComment;
                    }

                    foreach (string str in D.dialogue.noExistFace)
                    {
                        ReactFace = D.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == G.id)
        {
            Customer_Name = G.name;

            if (G.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = G.id;
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

        if (Customer_ID[0] == L.id)
        {
            Customer_Name = L.name;

            if (L.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = L.id;
            }

            if (E.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = L.id;
            }

            foreach (string str in L.dialogue.visitComment)
            {
                Customer_PerfumeOrder = L.dialogue.visitComment;
            }

            foreach (string str in L.dialogue.requestComment)
            {
                Customer_IntensityOrder = L.dialogue.requestComment;
            }

            foreach (string str in L.dialogue.refusalComment)
            {
                Customer_RejectReaction = L.dialogue.refusalComment;
            }

            foreach (string str in L.dialogue.visitFace)
            {
                OrderFace = L.dialogue.visitFace;
            }

            foreach (string str in L.dialogue.requestFace)
            {
                IntensityFace = L.dialogue.requestFace;
            }

            foreach (string str in L.dialogue.refusalFace)
            {
                RejectFace = L.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = L.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = L.currentPerfume.bassNotes;
            Customer_Flavoring[1] = L.currentPerfume.middleNotes;
            Customer_Flavoring[2] = L.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in L.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = L.dialogue.resultGoodComment;
                    }

                    foreach (string str in L.dialogue.resultGoodFace)
                    {
                        ReactFace = L.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in L.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = L.dialogue.resultNormalComment;
                    }

                    foreach (string str in L.dialogue.resultNormalFace)
                    {
                        ReactFace = L.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in L.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = L.dialogue.resultBadComment;
                    }

                    foreach (string str in L.dialogue.resultBadFace)
                    {
                        ReactFace = L.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in L.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = L.dialogue.noFlavorComment;
                    }

                    foreach (string str in L.dialogue.noFlavorFace)
                    {
                        ReactFace = L.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in L.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = L.dialogue.noExistComment;
                    }

                    foreach (string str in L.dialogue.noExistFace)
                    {
                        ReactFace = L.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == I.id)
        {
            Customer_Name = I.name;

            if (I.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = I.id;
            }

            if (I.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = I.id;
            }

            foreach (string str in I.dialogue.visitComment)
            {
                Customer_PerfumeOrder = I.dialogue.visitComment;
            }

            foreach (string str in I.dialogue.requestComment)
            {
                Customer_IntensityOrder = I.dialogue.requestComment;
            }

            foreach (string str in I.dialogue.refusalComment)
            {
                Customer_RejectReaction = I.dialogue.refusalComment;
            }

            foreach (string str in I.dialogue.visitFace)
            {
                OrderFace = I.dialogue.visitFace;
            }

            foreach (string str in I.dialogue.requestFace)
            {
                IntensityFace = I.dialogue.requestFace;
            }

            foreach (string str in I.dialogue.refusalFace)
            {
                RejectFace = I.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = I.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = I.currentPerfume.bassNotes;
            Customer_Flavoring[1] = I.currentPerfume.middleNotes;
            Customer_Flavoring[2] = I.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in I.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = I.dialogue.resultGoodComment;
                    }

                    foreach (string str in I.dialogue.resultGoodFace)
                    {
                        ReactFace = I.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in I.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = I.dialogue.resultNormalComment;
                    }

                    foreach (string str in I.dialogue.resultNormalFace)
                    {
                        ReactFace = I.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in I.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = I.dialogue.resultBadComment;
                    }

                    foreach (string str in I.dialogue.resultBadFace)
                    {
                        ReactFace = I.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in I.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = I.dialogue.noFlavorComment;
                    }

                    foreach (string str in I.dialogue.noFlavorFace)
                    {
                        ReactFace = I.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in I.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = I.dialogue.noExistComment;
                    }

                    foreach (string str in I.dialogue.noExistFace)
                    {
                        ReactFace = I.dialogue.noExistFace;
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
