using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthDialogueScript : MonoBehaviour
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
    public bool isUnique = false;

    public int CriminalID = 1000;
    public int UniqueID = 1000;

    public GameObject RC;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(17, 24);
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
        Customer B = CustomerManager.Instance.days.day[3].customer[0];
        Customer D = CustomerManager.Instance.days.day[3].customer[1];
        Customer E = CustomerManager.Instance.days.day[3].customer[2];
        Customer L = CustomerManager.Instance.days.day[3].customer[3];
        Customer G = CustomerManager.Instance.days.day[3].customer[4];
        Customer LorenaA = CustomerManager.Instance.days.day[3].customer[5];
        Customer LorenaBC = CustomerManager.Instance.days.day[3].customer[6];


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
                RC.GetComponent<CriminalImage>().isCriminal = true;
                RC.GetComponent<CriminalImage>().CriminaID = B.id;
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
                RC.GetComponent<CriminalImage>().isCriminal = true;
                RC.GetComponent<CriminalImage>().CriminaID = E.id;
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
                RC.GetComponent<CriminalImage>().isCriminal = true;
                RC.GetComponent<CriminalImage>().CriminaID = D.id;
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

        if (Customer_ID[0] == L.id)
        {
            Customer_Name = L.name;

            if (L.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = L.id;
            }

            if (L.criminalGuest == true)
            {
                RC.GetComponent<CriminalImage>().isCriminal = true;
                RC.GetComponent<CriminalImage>().CriminaID = L.id;
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
                RC.GetComponent<CriminalImage>().isCriminal = true;
                RC.GetComponent<CriminalImage>().CriminaID = G.id;
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

        if (Customer_ID[0] == LorenaA.id)
        {
            Customer_Name = LorenaA.name;

            if (LorenaA.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = LorenaA.id;
            }

            if (LorenaA.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = LorenaA.id;
            }

            foreach (string str in LorenaA.dialogue.visitComment)
            {
                Customer_PerfumeOrder = LorenaA.dialogue.visitComment;
            }

            foreach (string str in LorenaA.dialogue.requestComment)
            {
                Customer_IntensityOrder = LorenaA.dialogue.requestComment;
            }

            foreach (string str in LorenaA.dialogue.refusalComment)
            {
                Customer_RejectReaction = LorenaA.dialogue.refusalComment;
            }

            foreach (string str in LorenaA.dialogue.visitFace)
            {
                OrderFace = LorenaA.dialogue.visitFace;
            }

            foreach (string str in LorenaA.dialogue.requestFace)
            {
                IntensityFace = LorenaA.dialogue.requestFace;
            }

            foreach (string str in LorenaA.dialogue.refusalFace)
            {
                RejectFace = LorenaA.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = LorenaA.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = LorenaA.currentPerfume.bassNotes;
            Customer_Flavoring[1] = LorenaA.currentPerfume.middleNotes;
            Customer_Flavoring[2] = LorenaA.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in LorenaA.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaA.dialogue.resultGoodComment;
                    }

                    foreach (string str in LorenaA.dialogue.resultGoodFace)
                    {
                        ReactFace = LorenaA.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in LorenaA.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = LorenaA.dialogue.resultNormalComment;
                    }

                    foreach (string str in LorenaA.dialogue.resultNormalFace)
                    {
                        ReactFace = LorenaA.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in LorenaA.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = LorenaA.dialogue.resultBadComment;
                    }

                    foreach (string str in LorenaA.dialogue.resultBadFace)
                    {
                        ReactFace = LorenaA.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in LorenaA.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaA.dialogue.noFlavorComment;
                    }

                    foreach (string str in LorenaA.dialogue.noFlavorFace)
                    {
                        ReactFace = LorenaA.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in LorenaA.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaA.dialogue.noExistComment;
                    }

                    foreach (string str in LorenaA.dialogue.noExistFace)
                    {
                        ReactFace = LorenaA.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == LorenaBC.id)
        {
            Customer_Name = LorenaBC.name;

            if (LorenaBC.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = LorenaBC.id;
            }

            if (LorenaBC.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = LorenaBC.id;
            }

            foreach (string str in LorenaBC.dialogue.visitComment)
            {
                Customer_PerfumeOrder = LorenaBC.dialogue.visitComment;
            }

            foreach (string str in LorenaBC.dialogue.requestComment)
            {
                Customer_IntensityOrder = LorenaBC.dialogue.requestComment;
            }

            foreach (string str in LorenaBC.dialogue.refusalComment)
            {
                Customer_RejectReaction = LorenaBC.dialogue.refusalComment;
            }

            foreach (string str in LorenaBC.dialogue.visitFace)
            {
                OrderFace = LorenaBC.dialogue.visitFace;
            }

            foreach (string str in LorenaBC.dialogue.requestFace)
            {
                IntensityFace = LorenaBC.dialogue.requestFace;
            }

            foreach (string str in LorenaBC.dialogue.refusalFace)
            {
                RejectFace = LorenaBC.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = LorenaBC.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = LorenaBC.currentPerfume.bassNotes;
            Customer_Flavoring[1] = LorenaBC.currentPerfume.middleNotes;
            Customer_Flavoring[2] = LorenaBC.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in LorenaBC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaBC.dialogue.resultGoodComment;
                    }

                    foreach (string str in LorenaBC.dialogue.resultGoodFace)
                    {
                        ReactFace = LorenaBC.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in LorenaBC.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = LorenaBC.dialogue.resultNormalComment;
                    }

                    foreach (string str in LorenaBC.dialogue.resultNormalFace)
                    {
                        ReactFace = LorenaBC.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in LorenaBC.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = LorenaBC.dialogue.resultBadComment;
                    }

                    foreach (string str in LorenaBC.dialogue.resultBadFace)
                    {
                        ReactFace = LorenaBC.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in LorenaBC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaBC.dialogue.noFlavorComment;
                    }

                    foreach (string str in LorenaBC.dialogue.noFlavorFace)
                    {
                        ReactFace = LorenaBC.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in LorenaBC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaBC.dialogue.noExistComment;
                    }

                    foreach (string str in LorenaBC.dialogue.noExistFace)
                    {
                        ReactFace = LorenaBC.dialogue.noExistFace;
                    }
                }
            }

        }

        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    }
}
