using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecondDialogueScript : MonoBehaviour
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

    public int CriminalID = 1000;
    public int UniqueID = 1000;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(9, 18);
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
        Customer J = CustomerManager.Instance.days.day[1].customer[0];
        Customer K = CustomerManager.Instance.days.day[1].customer[1];
        Customer A = CustomerManager.Instance.days.day[1].customer[2];
        Customer F = CustomerManager.Instance.days.day[1].customer[3];
        Customer B = CustomerManager.Instance.days.day[1].customer[4];
        Customer D = CustomerManager.Instance.days.day[1].customer[5];
        Customer E = CustomerManager.Instance.days.day[1].customer[6];
        Customer H = CustomerManager.Instance.days.day[1].customer[7];
        Customer C = CustomerManager.Instance.days.day[1].customer[8];


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

        if (Customer_ID[0] == J.id)
        {
            Customer_Name = J.name;

            if (J.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = J.id;
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

        if (Customer_ID[0] == A.id)
        {
            Customer_Name = A.name;

            if (A.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = A.id;
            }

            if (A.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = A.id;
            }

            foreach (string str in A.dialogue.visitComment)
            {
                Customer_PerfumeOrder = A.dialogue.visitComment;
            }

            foreach (string str in A.dialogue.requestComment)
            {
                Customer_IntensityOrder = A.dialogue.requestComment;
            }

            foreach (string str in A.dialogue.refusalComment)
            {
                Customer_RejectReaction = A.dialogue.refusalComment;
            }

            foreach (string str in A.dialogue.visitFace)
            {
                OrderFace = A.dialogue.visitFace;
            }

            foreach (string str in A.dialogue.requestFace)
            {
                IntensityFace = A.dialogue.requestFace;
            }

            foreach (string str in A.dialogue.refusalFace)
            {
                RejectFace = A.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = A.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = A.currentPerfume.bassNotes;
            Customer_Flavoring[1] = A.currentPerfume.middleNotes;
            Customer_Flavoring[2] = A.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in A.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = A.dialogue.resultGoodComment;
                    }

                    foreach (string str in A.dialogue.resultGoodFace)
                    {
                        ReactFace = A.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in A.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = A.dialogue.resultNormalComment;
                    }

                    foreach (string str in A.dialogue.resultNormalFace)
                    {
                        ReactFace = A.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in A.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = A.dialogue.resultBadComment;
                    }

                    foreach (string str in A.dialogue.resultBadFace)
                    {
                        ReactFace = A.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in A.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = A.dialogue.noFlavorComment;
                    }

                    foreach (string str in A.dialogue.noFlavorFace)
                    {
                        ReactFace = A.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in A.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = A.dialogue.noExistComment;
                    }

                    foreach (string str in A.dialogue.noExistFace)
                    {
                        ReactFace = A.dialogue.noExistFace;
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

        if (Customer_ID[0] == K.id)
        {
            Customer_Name = K.name;

            if (K.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = K.id;
            }

            if (K.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = K.id;
            }

            foreach (string str in K.dialogue.visitComment)
            {
                Customer_PerfumeOrder = K.dialogue.visitComment;
            }

            foreach (string str in K.dialogue.requestComment)
            {
                Customer_IntensityOrder = K.dialogue.requestComment;
            }

            foreach (string str in K.dialogue.refusalComment)
            {
                Customer_RejectReaction = K.dialogue.refusalComment;
            }

            foreach (string str in K.dialogue.visitFace)
            {
                OrderFace = K.dialogue.visitFace;
            }

            foreach (string str in K.dialogue.requestFace)
            {
                IntensityFace = K.dialogue.requestFace;
            }

            foreach (string str in K.dialogue.refusalFace)
            {
                RejectFace = K.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = K.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = K.currentPerfume.bassNotes;
            Customer_Flavoring[1] = K.currentPerfume.middleNotes;
            Customer_Flavoring[2] = K.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in K.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = K.dialogue.resultGoodComment;
                    }

                    foreach (string str in K.dialogue.resultGoodFace)
                    {
                        ReactFace = K.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in K.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = K.dialogue.resultNormalComment;
                    }

                    foreach (string str in K.dialogue.resultNormalFace)
                    {
                        ReactFace = K.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in K.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = K.dialogue.resultBadComment;
                    }

                    foreach (string str in K.dialogue.resultBadFace)
                    {
                        ReactFace = K.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in K.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = K.dialogue.noFlavorComment;
                    }

                    foreach (string str in K.dialogue.noFlavorFace)
                    {
                        ReactFace = K.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in K.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = K.dialogue.noExistComment;
                    }

                    foreach (string str in K.dialogue.noExistFace)
                    {
                        ReactFace = K.dialogue.noExistFace;
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

        if (Customer_ID[0] == H.id)
        {
            Customer_Name = H.name;

            if (H.uniqueGuest == true)
            {
                isUnique = true;
                UniqueID = H.id;
            }

            if (H.criminalGuest == true)
            {
                isCriminal = true;
                CriminalID = H.id;
            }

            foreach (string str in H.dialogue.visitComment)
            {
                Customer_PerfumeOrder = H.dialogue.visitComment;
            }

            foreach (string str in H.dialogue.requestComment)
            {
                Customer_IntensityOrder = H.dialogue.requestComment;
            }

            foreach (string str in H.dialogue.refusalComment)
            {
                Customer_RejectReaction = H.dialogue.refusalComment;
            }

            foreach (string str in H.dialogue.visitFace)
            {
                OrderFace = H.dialogue.visitFace;
            }

            foreach (string str in H.dialogue.requestFace)
            {
                IntensityFace = H.dialogue.requestFace;
            }

            foreach (string str in H.dialogue.refusalFace)
            {
                RejectFace = H.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = H.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = H.currentPerfume.bassNotes;
            Customer_Flavoring[1] = H.currentPerfume.middleNotes;
            Customer_Flavoring[2] = H.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in H.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = H.dialogue.resultGoodComment;
                    }

                    foreach (string str in H.dialogue.resultGoodFace)
                    {
                        ReactFace = H.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in H.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = H.dialogue.resultNormalComment;
                    }

                    foreach (string str in H.dialogue.resultNormalFace)
                    {
                        ReactFace = H.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in H.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = H.dialogue.resultBadComment;
                    }

                    foreach (string str in H.dialogue.resultBadFace)
                    {
                        ReactFace = H.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in H.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = H.dialogue.noFlavorComment;
                    }

                    foreach (string str in H.dialogue.noFlavorFace)
                    {
                        ReactFace = H.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in H.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = H.dialogue.noExistComment;
                    }

                    foreach (string str in H.dialogue.noExistFace)
                    {
                        ReactFace = H.dialogue.noExistFace;
                    }
                }
            }

        }

        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    }
}
