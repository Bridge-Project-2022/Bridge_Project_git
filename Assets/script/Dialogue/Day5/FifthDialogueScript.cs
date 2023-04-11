using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthDialogueScript : MonoBehaviour
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
            Customer_ID[i] = Random.Range(24, 32);
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
        Customer H = CustomerManager.Instance.days.day[4].customer[0];
        Customer I = CustomerManager.Instance.days.day[4].customer[1];
        Customer C = CustomerManager.Instance.days.day[4].customer[2];
        Customer D = CustomerManager.Instance.days.day[4].customer[3];
        Customer F = CustomerManager.Instance.days.day[4].customer[4];
        Customer LorenaA = CustomerManager.Instance.days.day[4].customer[5];
        Customer LorenaB = CustomerManager.Instance.days.day[4].customer[6];
        Customer LorenaC = CustomerManager.Instance.days.day[4].customer[7];

        if (GameDataManager.Instance.FourthLorenaResult == "A")
        {
            if (Customer_ID[0] == 30 || Customer_ID[0] == 31)
            {
                Customer_ID[0] = 29;
            }
        }

        if (GameDataManager.Instance.FourthLorenaResult == "B")
        {
            if (Customer_ID[0] == 29 || Customer_ID[0] == 31)
            {
                Customer_ID[0] = 30;
            }
        }

        if (GameDataManager.Instance.FourthLorenaResult == "C")
        {
            if (Customer_ID[0] == 29 || Customer_ID[0] == 30)
            {
                Customer_ID[0] = 31;
            }
        }


        if (Customer_ID[0] == H.id)
        {
            Customer_Name = H.name;

            if (H.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (H.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == D.id)
        {
            Customer_Name = D.name;

            if (D.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (D.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == C.id)
        {
            Customer_Name = C.name;

            if (C.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
            }

            if (C.criminalGuest == true)
            {
                RC.GetComponent<CriminalImage>().isCriminal = true;
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

        if (Customer_ID[0] == LorenaA.id)
        {
            Customer_Name = LorenaA.name;

            if (LorenaA.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = LorenaA.id;
            }

            if (LorenaA.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
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

        if (Customer_ID[0] == LorenaB.id)
        {
            Customer_Name = LorenaB.name;

            if (LorenaB.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = LorenaB.id;
            }

            if (LorenaB.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
            }

            foreach (string str in LorenaB.dialogue.visitComment)
            {
                Customer_PerfumeOrder = LorenaB.dialogue.visitComment;
            }

            foreach (string str in LorenaB.dialogue.requestComment)
            {
                Customer_IntensityOrder = LorenaB.dialogue.requestComment;
            }

            foreach (string str in LorenaB.dialogue.refusalComment)
            {
                Customer_RejectReaction = LorenaB.dialogue.refusalComment;
            }

            foreach (string str in LorenaB.dialogue.visitFace)
            {
                OrderFace = LorenaB.dialogue.visitFace;
            }

            foreach (string str in LorenaB.dialogue.requestFace)
            {
                IntensityFace = LorenaB.dialogue.requestFace;
            }

            foreach (string str in LorenaB.dialogue.refusalFace)
            {
                RejectFace = LorenaA.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = LorenaB.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = LorenaB.currentPerfume.bassNotes;
            Customer_Flavoring[1] = LorenaB.currentPerfume.middleNotes;
            Customer_Flavoring[2] = LorenaB.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in LorenaB.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaB.dialogue.resultGoodComment;
                    }

                    foreach (string str in LorenaB.dialogue.resultGoodFace)
                    {
                        ReactFace = LorenaB.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in LorenaB.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = LorenaB.dialogue.resultNormalComment;
                    }

                    foreach (string str in LorenaB.dialogue.resultNormalFace)
                    {
                        ReactFace = LorenaB.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in LorenaB.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = LorenaB.dialogue.resultBadComment;
                    }

                    foreach (string str in LorenaB.dialogue.resultBadFace)
                    {
                        ReactFace = LorenaB.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in LorenaB.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaB.dialogue.noFlavorComment;
                    }

                    foreach (string str in LorenaB.dialogue.noFlavorFace)
                    {
                        ReactFace = LorenaB.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in LorenaB.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaB.dialogue.noExistComment;
                    }

                    foreach (string str in LorenaB.dialogue.noExistFace)
                    {
                        ReactFace = LorenaB.dialogue.noExistFace;
                    }
                }
            }

        }

        if (Customer_ID[0] == LorenaC.id)
        {
            Customer_Name = LorenaC.name;

            if (LorenaC.uniqueGuest == true)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = true;
                RC.GetComponent<StoryCustomerImage>().UniqueID = LorenaC.id;
            }

            if (LorenaC.criminalGuest == false)
            {
                RC.GetComponent<CriminalImage>().isCriminal = false;
            }

            foreach (string str in LorenaC.dialogue.visitComment)
            {
                Customer_PerfumeOrder = LorenaC.dialogue.visitComment;
            }

            foreach (string str in LorenaC.dialogue.requestComment)
            {
                Customer_IntensityOrder = LorenaC.dialogue.requestComment;
            }

            foreach (string str in LorenaC.dialogue.refusalComment)
            {
                Customer_RejectReaction = LorenaC.dialogue.refusalComment;
            }

            foreach (string str in LorenaC.dialogue.visitFace)
            {
                OrderFace = LorenaC.dialogue.visitFace;
            }

            foreach (string str in LorenaC.dialogue.requestFace)
            {
                IntensityFace = LorenaC.dialogue.requestFace;
            }

            foreach (string str in LorenaC.dialogue.refusalFace)
            {
                RejectFace = LorenaC.dialogue.refusalFace;
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = LorenaC.currentPerfume.perfumeForce[0];

            Customer_Flavoring[0] = LorenaC.currentPerfume.bassNotes;
            Customer_Flavoring[1] = LorenaC.currentPerfume.middleNotes;
            Customer_Flavoring[2] = LorenaC.currentPerfume.topNotes[0];


            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    foreach (string str in LorenaC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaC.dialogue.resultGoodComment;
                    }

                    foreach (string str in LorenaC.dialogue.resultGoodFace)
                    {
                        ReactFace = LorenaC.dialogue.resultGoodFace;
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    foreach (string str in LorenaC.dialogue.resultNormalComment)
                    {
                        Customer_PerfumeReaction = LorenaC.dialogue.resultNormalComment;
                    }

                    foreach (string str in LorenaC.dialogue.resultNormalFace)
                    {
                        ReactFace = LorenaC.dialogue.resultNormalFace;
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    foreach (string str in LorenaC.dialogue.resultBadComment)
                    {
                        Customer_PerfumeReaction = LorenaC.dialogue.resultBadComment;
                    }

                    foreach (string str in LorenaC.dialogue.resultBadFace)
                    {
                        ReactFace = LorenaC.dialogue.resultBadFace;
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    foreach (string str in LorenaC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaC.dialogue.noFlavorComment;
                    }

                    foreach (string str in LorenaC.dialogue.noFlavorFace)
                    {
                        ReactFace = LorenaC.dialogue.noFlavorFace;
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    foreach (string str in LorenaC.dialogue.resultGoodComment)
                    {
                        Customer_PerfumeReaction = LorenaC.dialogue.noExistComment;
                    }

                    foreach (string str in LorenaC.dialogue.noExistFace)
                    {
                        ReactFace = LorenaC.dialogue.noExistFace;
                    }
                }
            }

        }


        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    }
}
