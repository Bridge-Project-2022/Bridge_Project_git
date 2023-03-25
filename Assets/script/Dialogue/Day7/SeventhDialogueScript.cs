using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhDialogueScript : MonoBehaviour
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

    public int CriminalID = 10;
    public int UniqueID = 1000;

    public GameObject RC;

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(32, 38);
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
        Customer I = CustomerManager.Instance.days.day[6].customer[0];
        Customer B = CustomerManager.Instance.days.day[6].customer[1];
        Customer J = CustomerManager.Instance.days.day[6].customer[2];
        Customer H = CustomerManager.Instance.days.day[6].customer[3];
        Customer D = CustomerManager.Instance.days.day[6].customer[4];
        Customer G = CustomerManager.Instance.days.day[6].customer[5];


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

        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    }
}
