using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestDialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    public GameObject RC;
    public GameObject DR;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[6];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
    public string[] Customer_PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] Customer_IntensityOrder = new string[5];//향수 강도 대사
    public string[] Customer_Flavoring = new string[3];//원하는 향료 선택(베, 미, 탑)
    public string[] Customer_RejectReaction = new string[5];//손님 거절 반응
    public string[] Customer_PerfumeReaction = new string[5];//향수 받을 시 손님 반응
    public string[] Customer_CriminalDeclareReaction = new string[5];//신고했을 시 반응

    public void Start()
    {
        Customer_ID[0] = 1004;//랜덤
        Customer_ID[1] = 1010;//로레나 1
        Customer_ID[2] = 1003;//범죄자
        Customer_ID[3] = 1008;//랜덤
        Customer_ID[4] = 1011;//로레나2
        Customer_ID[5] = 1001;//랜덤

        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (Customer_ID[0] == 1001)//B : 초등학생 여자아이, 당당함
        {
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "안녕?";
            Customer_PerfumeOrder[1] = "어릴 때 아빠 손잡고 갔던 놀이공원에 다시 가고 싶어!";
            Customer_PerfumeOrder[2] = "그때 진짜 행복했거든!!";
            Customer_PerfumeOrder[3] = "향수로 만들어줄 수 있을까?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "향은 정말 진하게 해줘!!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Customer_CriminalDeclareReaction[0] = "감히 나를 신고해?";

            for (int i = 1; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "놀이공원";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "아직 못 만드는거야?";
            Customer_RejectReaction[1] = "그러면 다음에 올게!";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "정말 좋아!! 고마워요!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오! 이만하면 괜찮은 것 같아!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "원래 향수가 이렇나요..?";
                    Customer_PerfumeReaction[1] = "완전 별론데..?";
                    Customer_PerfumeReaction[2] = "실력이 영..";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "뭐 하나 빠뜨리신 거 아니에요?";
                    Customer_PerfumeReaction[1] = "이게 아닌 것 같은데..";
                    Customer_PerfumeReaction[2] = "완전 꽝이야!";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "제가 말한 거랑 다른 것 같은데요?";
                    Customer_PerfumeReaction[1] = "이럴 리가 없는데..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1010)// 로레나 1
        {
            Customer_Name = "Lorena1";
            Customer_PerfumeOrder[0] = "...";
            Customer_PerfumeOrder[1] = "……";
            Customer_PerfumeOrder[2] = "………";
            Customer_PerfumeOrder[3] = "……향수..좀..줘…";
            Customer_PerfumeOrder[4] = "......";
            Customer_PerfumeOrder[5] = "남자친구...";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
        }

        else if (Customer_ID[0] == 1011)// 로레나 1
        {
            Customer_Name = "Lorena2";
            Customer_PerfumeOrder[0] = "저...";
            Customer_PerfumeOrder[1] = "같이 캠퍼스 거닐 때..., 행복했는데….";
            Customer_PerfumeOrder[2] = "..";
            Customer_PerfumeOrder[3] = "....그때가 너무 그리워...";
            Customer_PerfumeOrder[4] = "내가 더 잘할 걸...";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
        }
        else if (Customer_ID[0] == 1003)//G : 건장한 30대 남성
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "안녕하세요!";
            Customer_PerfumeOrder[1] = "내일 저의 여자친구에게 청혼을 하려고 합니다.";
            Customer_PerfumeOrder[2] = "하하! 쑥스럽네요.";
            Customer_PerfumeOrder[3] = "저의 사랑하는 마음을 향수로 함께 선물하고 싶은데..";
            Customer_PerfumeOrder[4] = "준비 가능할까요?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "아! 향은 아주 강하게 부탁드립니다.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_CriminalDeclareReaction[0] = "아니.. 들켰잖아?";

            for (int i = 1; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "안된다고요?";
            Customer_RejectReaction[1] = "이렇게 무작정 거절해도 되는겁니까?";
            Customer_RejectReaction[2] = "에잇! 내 기분 다 망쳤네.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "와! 제가 딱 원했던 향수네요.";
                    Customer_PerfumeReaction[1] = "이거면 청혼도 성공할 수 있겠어요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "감사합니다. 썩 마음에 드네요.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이 향수는..";
                    Customer_PerfumeReaction[1] = "받는 제 여자친구도 기분 나쁘겠어요.";
                    Customer_PerfumeReaction[2] = "됐습니다.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "킁킁..";
                    Customer_PerfumeReaction[1] = "여기서 아무 향도 나질 않는 걸요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "흠.. 제가 부탁드린 향수가 아닌 것 같군요..";
                    Customer_PerfumeReaction[1] = "가보겠습니다.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//A : 초등학생 4-5학년 남자 아이
        {
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "안녕하세요?";
            Customer_PerfumeOrder[1] = "저도 형 가지고 싶어요!";
            Customer_PerfumeOrder[2] = "형이 있으면 좋겠다!";
            Customer_PerfumeOrder[3] = "그럼 맨날 같이 놀고 행복할텐데!!";
            Customer_PerfumeOrder[4] = "형 냄새라도 맡을 수 있을까요?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_CriminalDeclareReaction[0] = "감히 나를 신고해?";

            for (int i = 1; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_IntensityOrder[0] = "향의 세기는 적당히 해주세요!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "가족";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "안돼요??";
            Customer_RejectReaction[1] = "왜 안돼요??";
            Customer_RejectReaction[2] = "진짜로요??";
            Customer_RejectReaction[3] = "알겠어요..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "와!! 고맙습니다!!";
                    Customer_PerfumeReaction[1] = "이거면 나도 형이 생긴건가??!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오오.. 고맙습니다!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이건.. 고맙습니다..!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "냄새가 안 느껴지는데..";
                    Customer_PerfumeReaction[1] = "아저씨 제대로 만든 거 맞아요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이건 형 냄새가 아닌데요..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//D : 단발 머리의 청소년 여성
        {
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "안녕하세요?";
            Customer_PerfumeOrder[1] = "우리 집에 귀여운 강아지 쪼꼬가 있거든요?";
            Customer_PerfumeOrder[2] = "볼 때마다 얼마나 사랑스러운 모르겠어요!";
            Customer_PerfumeOrder[3] = "이걸 다른 애들한테도 알려주고 싶은데..!";
            Customer_PerfumeOrder[4] = "향수를 선물하면 되지 않을까요?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_CriminalDeclareReaction[0] = "감히 나를 신고해?";

            for (int i = 1; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 완전 진하게? 해주세요!!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "응?";
            Customer_RejectReaction[1] = "흠.. 왜요??";
            Customer_RejectReaction[2] = "향수 팔면 좋은 거 아닌가??";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "오..진짜 쪼꼬 냄새다!";
                    Customer_PerfumeReaction[1] = "고마워요!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오 쪼꼬 냄새난다!";
                    Customer_PerfumeReaction[1] = "좋아요!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "으.. 이상한 냄새!!";
                    Customer_PerfumeReaction[1] = "쪼꼬는 꼬소한 냄새가 난다구요!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "이건 무슨 냄새지..?";
                    Customer_PerfumeReaction[1] = "왜 이렇게 만든 거에요??";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "음.. 무슨 냄새지..?";
                    Customer_PerfumeReaction[1] = "완전히 다른 냄새인데요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
}
