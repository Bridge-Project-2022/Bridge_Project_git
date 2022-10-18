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

    public bool isRorenaBad = false;
    public void Start()
    {
        Customer_ID[0] = 1004;//랜덤 A
        Customer_ID[1] = 1010;//로레나 1
        Customer_ID[2] = 1003;//범죄자 G
        Customer_ID[3] = 1008;//랜덤 D
        Customer_ID[4] = 1011;//로레나2
        Customer_ID[5] = 1001;//랜덤 B

        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (TestDialogueRandom.FindObjectOfType<TestDialogueRandom>().isLorenaReject == true)
        {
            if (Customer_ID[0] == 1011)
            {
                Customer_ID[0] = 1012;
            }
        }
        if (isRorenaBad == true)
        {
            if (Customer_ID[0] == 1011)
            {
                Customer_ID[0] = 1013;
            }
        }
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

            Customer_CriminalDeclareReaction[0] = "흐..흐흑...";
            Customer_CriminalDeclareReaction[1] = "왜..그랬..어요..??";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
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

        else if (Customer_ID[0] == 1010)// 로레나 1번쨰 방문
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

            Customer_IntensityOrder[0] = "향은.. 약해도.. 돼...";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = "........";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "...";
            Customer_RejectReaction[1] = "그래요..";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "와아..";
                    Customer_PerfumeReaction[1] = "감사합니다...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "..음..";
                    Customer_PerfumeReaction[1] = "괜찮네요...";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    isRorenaBad = true;
                    Customer_PerfumeReaction[0] = "하...";
                    Customer_PerfumeReaction[1] = "이게 아니라...";
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
                    isRorenaBad = true;
                    Customer_PerfumeReaction[0] = "이건..";
                    Customer_PerfumeReaction[1] = "무슨..향..이죠...?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    isRorenaBad = true;
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "...";
                    Customer_PerfumeReaction[1] = "이건 대체...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1011)// 로레나2번째 방문
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

            Customer_IntensityOrder[0] = "그 때의 기억이 희미해져가....";
            Customer_IntensityOrder[1] = "더 강한 향이 필요해...";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = "...뭐하는거야 지금?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "아...";
            Customer_RejectReaction[1] = "내가 이렇게 필요하다는데...";
            Customer_RejectReaction[2] = "대체 나한테 왜 그러는 거야?";
            Customer_RejectReaction[3] = "어째서..";

            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "난 남자친구를 정말 사랑했어...";
                    Customer_PerfumeReaction[1] = "정말 고마워...정말...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "이 기억이 맞아..";
                    Customer_PerfumeReaction[1] = "..고마워";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이게 대체 뭐야...";
                    Customer_PerfumeReaction[1] = "내 추억을 망치지 마!!";
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
                    Customer_PerfumeReaction[0] = "나한테 왜 그러는 거야..?";
                    Customer_PerfumeReaction[1] = "당신을 믿은 내가 한심해..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이게 아니야..";
                    Customer_PerfumeReaction[1] = "다신 오지 않겠어..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        else if (Customer_ID[0] == 1012)// 로레나1 거절 시 로레나 2 다르게 나옴.
        {
            Customer_Name = "Lorena2_1";
            Customer_PerfumeOrder[0] = "...";
            Customer_PerfumeOrder[1] = "저기..";
            Customer_PerfumeOrder[2] = "오늘은...향수를..";
            Customer_PerfumeOrder[3] = "오늘도..";
            Customer_PerfumeOrder[4] = "...";
            Customer_PerfumeOrder[5] = "남자친구..";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
            Customer_IntensityOrder[0] = "강한 향으로...";
            Customer_IntensityOrder[1] = "최대한 빠르게..";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = ".....뭐하는거야 지금..?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "하...";
            Customer_RejectReaction[1] = "왜 항상...";
            Customer_RejectReaction[2] = "나에게만 그러는 거야..?";


            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "아..";
                    Customer_PerfumeReaction[1] = "그 사람과의 추억이 떠올라...";
                    Customer_PerfumeReaction[2] = "";
                    Customer_PerfumeReaction[3] = "정말..고마워...";
                    for (int i = 4; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "맞아..";
                    Customer_PerfumeReaction[1] = "난 이 향을 찾고 있었어.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이게 아니야..";
                    Customer_PerfumeReaction[1] = "내 추억을 망쳐버리다니..";
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
                    Customer_PerfumeReaction[0] = "음..";
                    Customer_PerfumeReaction[1] = "이 향수는 조금...";
                    Customer_PerfumeReaction[2] = "부족한 느낌이 드는걸..?";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "저기...";
                    Customer_PerfumeReaction[1] = "내가 말한 향은..";
                    Customer_PerfumeReaction[2] = "이런 게 아니야...";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1013)// 로레나1 거절 시 로레나 2 다르게 나옴.
        {
            Customer_Name = "Lorena2_2";
            Customer_PerfumeOrder[0] = "남자친구..가...";
            Customer_PerfumeOrder[1] = "너무..그리워..";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "그 때의 향이 필요해...";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
            Customer_IntensityOrder[0] = "우리의.. 추억이.. 잘 담긴 향이 필요해..";
            Customer_IntensityOrder[1] = "강한 향으로..";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = ".....뭐하는거야 지금..?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "학교";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "그래..";
            Customer_RejectReaction[1] = "내가 기댈 곳은 없어..";
            Customer_RejectReaction[2] = "내가 이렇지 뭐...";
            Customer_RejectReaction[3] = "정말 내가 너무 싫어..";


            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "그 캠퍼스에서 정말 행복했는데...";
                    Customer_PerfumeReaction[1] = "정말..고마워...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "으음..";
                    Customer_PerfumeReaction[1] = "그 때가 어렴풋이 떠올라..";
                    Customer_PerfumeReaction[2] = "고마워..";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "...";
                    Customer_PerfumeReaction[1] = "내 추억을 망쳤어..";
                    Customer_PerfumeReaction[2] = "앞으로 오지 않을게..";
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
                    Customer_PerfumeReaction[0] = "이딴..걸 나한테 판 거야..?";
                    Customer_PerfumeReaction[1] = "믿은 내 잘못이지..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "내가 찾던 향수가 아니야..";
                    Customer_PerfumeReaction[1] = "대체 뭘 만든거야..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//G : 건장한 30대 남성
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "저기요 아저씨";
            Customer_PerfumeOrder[1] = "향수 좀 줘요";
            Customer_PerfumeOrder[2] = "우리 집에 작고 귀여운 애 한 마리 있는데";
            Customer_PerfumeOrder[3] = "제가 좀 멀리 갈 일이 있어서 냄새라도 계속 맡고 싶어요.";
            Customer_PerfumeOrder[4] = "우리 개만 보면 기쁘단 말이에요";
            Customer_PerfumeOrder[5] = "그래줄 거죠?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "음.. 강하게.. 강하게 합시다.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_CriminalDeclareReaction[0] = "이거 왜 이래?";
            Customer_CriminalDeclareReaction[1] = "난 아직 한게 아무것도 없다고!";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "기쁨";

            Customer_RejectReaction[0] = "왜요";
            Customer_RejectReaction[1] = "내가 뭔 짓이라도 할까 봐?";
            Customer_RejectReaction[2] = "참.. 어이가 없어";
            Customer_RejectReaction[3] = "다음에.. 다시 올게";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "고마워요 잘 쓸게요~";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "음 좋네요";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이거 쓸 수 있는거 맞죠...?";
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
                    Customer_PerfumeReaction[0] = "이거 쓸 수 있는거 맞죠...?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이거 쓸 수 있는거 맞죠...?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
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

            Customer_CriminalDeclareReaction[0] = "뭐아??!!";
            Customer_CriminalDeclareReaction[1] = "짜증나!!";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 적당히 해주세요!!";
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

            Customer_CriminalDeclareReaction[0] = "내가 왜요??";
            Customer_CriminalDeclareReaction[1] = "이상한 사람이야 정말";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
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
