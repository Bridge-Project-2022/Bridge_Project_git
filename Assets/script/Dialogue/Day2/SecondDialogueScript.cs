using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecondDialogueScript : MonoBehaviour
{
    public GameObject Distiller;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[6];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
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

    public int CriminalID = 1000;

    public GameObject RC;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(5, 11);
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
        Customer I = CustomerManager.Instance.days.day[1].customer[0];
        Customer K = CustomerManager.Instance.days.day[1].customer[1];
        Customer D = CustomerManager.Instance.days.day[1].customer[2];
        Customer E = CustomerManager.Instance.days.day[1].customer[3];
        Customer C = CustomerManager.Instance.days.day[1].customer[4];
        Customer Lorena = CustomerManager.Instance.days.day[1].customer[5];

        if (Customer_ID[0] == I.id)
        {
            Customer_Name = I.name;

            if (I.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
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

        if (Customer_ID[0] == K.id)
        {
            Customer_Name = K.name;

            if (K.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
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
            if (C.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
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

            if (D.uniqueGuest == false)
            {
                RC.GetComponent<StoryCustomerImage>().isUnique = false;
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
