using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthDialogueScript : MonoBehaviour
{
    public GameObject Distiller;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[8];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
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
            Customer_ID[i] = Random.Range(32, 40);
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
        Customer I = CustomerManager.Instance.days.day[5].customer[0];
        Customer A = CustomerManager.Instance.days.day[5].customer[1];
        Customer B = CustomerManager.Instance.days.day[5].customer[2];
        Customer C = CustomerManager.Instance.days.day[5].customer[3];
        Customer F = CustomerManager.Instance.days.day[5].customer[4];
        Customer E = CustomerManager.Instance.days.day[5].customer[5];
        Customer Lorena1 = CustomerManager.Instance.days.day[5].customer[6];
        Customer Lorena2 = CustomerManager.Instance.days.day[5].customer[7];


        if (Customer_ID[0] == B.id)
        {
            Customer_Name = B.name;

            if (B.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (B.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

            if (E.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (E.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == I.id)
        {
            Customer_Name = I.name;

            if (I.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (I.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == C.id)
        {
            Customer_Name = C.name;

            if (C.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (C.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == F.id)
        {
            Customer_Name = F.name;

            if (F.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (F.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

            if (A.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (A.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == Lorena1.id)
        {
            Customer_Name = Lorena1.name;

            if (Lorena1.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = Lorena1.id;
            }

            if (Lorena1.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
            }

            foreach (string str in Lorena1.dialogue.visitComment)
            {
                Customer_PerfumeOrder = Lorena1.dialogue.visitComment;
            }

            foreach (string str in Lorena1.dialogue.requestComment)
            {
                Customer_IntensityOrder = Lorena1.dialogue.requestComment;
            }

            foreach (string str in Lorena1.dialogue.refusalComment)
            {
                Customer_RejectReaction = Lorena1.dialogue.refusalComment;
            }

            foreach (string str in Lorena1.dialogue.visitFace)
            {
                OrderFace = Lorena1.dialogue.visitFace;
            }

            foreach (string str in Lorena1.dialogue.requestFace)
            {
                IntensityFace = Lorena1.dialogue.requestFace;
            }

            foreach (string str in Lorena1.dialogue.refusalFace)
            {
                RejectFace = Lorena1.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = Lorena1.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = Lorena1.currentPerfume.bassNotes;
            Customer_Flavoring[1] = Lorena1.currentPerfume.middleNotes;
            Customer_Flavoring[2] = Lorena1.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in Lorena1.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena1.dialogue.resultGoodComment;
                    }

                    foreach (string str in Lorena1.dialogue.resultGoodFace)
                    {
                        ReactFace = Lorena1.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in Lorena1.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = Lorena1.dialogue.resultNormalComment;
                    }

                    foreach (string str in Lorena1.dialogue.resultNormalFace)
                    {
                        ReactFace = Lorena1.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in Lorena1.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = Lorena1.dialogue.resultBadComment;
                    }

                    foreach (string str in Lorena1.dialogue.resultBadFace)
                    {
                        ReactFace = Lorena1.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in Lorena1.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena1.dialogue.noFlavorComment;
                    }

                    foreach (string str in Lorena1.dialogue.noFlavorFace)
                    {
                        ReactFace = Lorena1.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in Lorena1.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena1.dialogue.noExistComment;
                    }

                    foreach (string str in Lorena1.dialogue.noExistFace)
                    {
                        ReactFace = Lorena1.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == Lorena2.id)
        {
            Customer_Name = Lorena2.name;

            if (Lorena2.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = Lorena2.id;
            }

            if (Lorena2.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
            }

            foreach (string str in Lorena2.dialogue.visitComment)
            {
                Customer_PerfumeOrder = Lorena2.dialogue.visitComment;
            }

            foreach (string str in Lorena2.dialogue.requestComment)
            {
                Customer_IntensityOrder = Lorena2.dialogue.requestComment;
            }

            foreach (string str in Lorena2.dialogue.refusalComment)
            {
                Customer_RejectReaction = Lorena2.dialogue.refusalComment;
            }

            foreach (string str in Lorena2.dialogue.visitFace)
            {
                OrderFace = Lorena2.dialogue.visitFace;
            }

            foreach (string str in Lorena2.dialogue.requestFace)
            {
                IntensityFace = Lorena2.dialogue.requestFace;
            }

            foreach (string str in Lorena2.dialogue.refusalFace)
            {
                RejectFace = Lorena2.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = Lorena2.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = Lorena2.currentPerfume.bassNotes;
            Customer_Flavoring[1] = Lorena2.currentPerfume.middleNotes;
            Customer_Flavoring[2] = Lorena2.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in Lorena2.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena2.dialogue.resultGoodComment;
                    }

                    foreach (string str in Lorena2.dialogue.resultGoodFace)
                    {
                        ReactFace = Lorena2.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in Lorena2.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = Lorena2.dialogue.resultNormalComment;
                    }

                    foreach (string str in Lorena2.dialogue.resultNormalFace)
                    {
                        ReactFace = Lorena2.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in Lorena2.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = Lorena2.dialogue.resultBadComment;
                    }

                    foreach (string str in Lorena2.dialogue.resultBadFace)
                    {
                        ReactFace = Lorena2.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in Lorena2.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena2.dialogue.noFlavorComment;
                    }

                    foreach (string str in Lorena2.dialogue.noFlavorFace)
                    {
                        ReactFace = Lorena2.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in Lorena2.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = Lorena2.dialogue.noExistComment;
                    }

                    foreach (string str in Lorena2.dialogue.noExistFace)
                    {
                        ReactFace = Lorena2.dialogue.noExistFace;
                    }
                }
            }

        }

        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    }
}
