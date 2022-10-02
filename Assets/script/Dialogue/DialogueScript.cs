<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    //public GameObject RC;
    //public GameObject DR;

    public int CriminalID = 0;

    //손님 대사 배열 - 전체는 랜덤이지만 내부는 순차적으로

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
    public string[] Customer_PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] Customer_IntensityOrder = new string[5];//향수 강도 대사
    public string[] Customer_Flavoring = new string[3];//원하는 향료 선택(베, 미, 탑)
    public string[] Customer_RejectReaction = new string[5];//손님 거절 반응
    public string[] Customer_PerfumeReaction = new string[5];//향수 받을 시 손님 반응

    public void Start()
    {
        //손님 아이디 배열에 1-9까지 중에 랜덤으로 넣되 중복되지 않도록 배치함. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001, 1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }

        CriminalID = Random.Range(1001, 1010);
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

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
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

        else if (Customer_ID[0] == 1002)//J : 마른 모습의 30-40대 아줌마, 소심함, 걱정
        {
            Customer_Name = "J";
            Customer_PerfumeOrder[0] = "저기요?";
            Customer_PerfumeOrder[1] = "우리 애가 아직도 어릴 때 가지고 놀던 인형을 못 잊어요.";
            Customer_PerfumeOrder[2] = "그렇게 기뻐하면서 가지고 놀던 거라 이해는 한다만..";
            Customer_PerfumeOrder[3] = "이미 버린 지가 오래인데 왜 아직도 못 잊었는지 참..";
            Customer_PerfumeOrder[4] = "혹시 향수 가능할까요?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "고마워요, 향은 적당히..? 해주세요.";
            Customer_IntensityOrder[1] = "애가 너무 향에 빠질까도 걱정이네요.";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "물건";
            Customer_Flavoring[1] = "인형";
            Customer_Flavoring[2] = "기쁨";

            Customer_RejectReaction[0] = "아니 돈을 준다는데도요?";
            Customer_RejectReaction[1] = "불쾌하네요.";
            Customer_RejectReaction[2] = "이걸 다른 사람들한테도 알려야겠어요.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "감사합니다. 이거면 우리 애 조금이라도 달랠 수 있겠죠?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "음.. 괜찮네요.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이건 향수가 아닌데요?";
                    Customer_PerfumeReaction[1] = "이렇게까지 못 만들 줄이야..";
                    Customer_PerfumeReaction[2] = "다른 사람들도 알아야 할 것 같네요.";
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
                    Customer_PerfumeReaction[0] = "완성도 안된 걸 이렇게 팔아도 되나요?";
                    Customer_PerfumeReaction[1] = "주변 사람들한테 다 말할거에요!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "음.. 이거 제가 말한 거랑 다른데요?";
                    Customer_PerfumeReaction[1] = "이게 맞나요?";
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

            Customer_IntensityOrder[0] = "향의 세기는 아무거나 상관없어요!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "아무거나";

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

        else if (Customer_ID[0] == 1005)//E : 10-20대 초반 여성
        {
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "안녕..?";
            Customer_PerfumeOrder[1] = "저기.. 부탁할 게 있는데..";
            Customer_PerfumeOrder[2] = "우리 집 고양이 나비를 한 번만이라도 다시 만나고 싶어...";
            Customer_PerfumeOrder[3] = "힘 없이 네 발로 비틀거리면서 일어서려고 노력하는 게 엊그제 같은데..";
            Customer_PerfumeOrder[4] = "축 처져서 아무 것도 안 하더니..";
            Customer_PerfumeOrder[5] = "이젠 더 이상 볼 수 없어..";
            Customer_PerfumeOrder[6] = "그 조그만 아이가 얼마나 아팠는지 생각하면..";
            Customer_PerfumeOrder[7] = "생각조차 힘들어서 눈물이 나..";
            Customer_PerfumeOrder[8] = "제발 나비를 한 번만이라도 만날 수 있게 해줘...";
            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 너무 진하지도... 너무 은은하지도 않게 해줘…";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "슬픔";

            Customer_RejectReaction[0] = "...나한테 대체 왜 그래요?";
            Customer_RejectReaction[1] = "단 한 번만 나비를 만나는 것도 안되는 거야?";
            Customer_RejectReaction[2] = "내가 이렇게까지 했는데..";
            Customer_RejectReaction[3] = "다른 사람들한테도 말할 거야.";
            Customer_RejectReaction[4] = "후회하지 마 당신이 한 선택이잖아.";

            for (int i = 5; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "나비야... 나비야...";
                    Customer_PerfumeReaction[1] = "차라리 내가 대신 아팠어야 하는데...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고마워요...";
                    Customer_PerfumeReaction[1] = "이렇게라도 나비를 볼 수 있어서..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "정말 최악이네요...";
                    Customer_PerfumeReaction[1] = "다른 사람들도 당신이 이렇게 못 만드는 거 알고 있나요..?";
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
                    Customer_PerfumeReaction[0] = "제대로 만든 거 맞나요..?";
                    Customer_PerfumeReaction[1] = "느껴지는 게 없는데..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이 향이 아닌데요..?";
                    Customer_PerfumeReaction[1] = "뭘 만든 거죠..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//I : 40대 건장한 체형의 남성
        {
            Customer_Name = "I";
            Customer_PerfumeOrder[0] = "자네 리프 섬에 가봤나?";
            Customer_PerfumeOrder[1] = "리프 섬을 모르는 모양이군..?";
            Customer_PerfumeOrder[2] = "젊은 사람이 말이야...";
            Customer_PerfumeOrder[3] = "내가 좀 얘기해 주지!";
            Customer_PerfumeOrder[4] = "리프 섬은 에메랄드 빛의 바다로 둘러싸인 아름다운 섬이라네!";
            Customer_PerfumeOrder[5] = "그늘에서 눈부시도록 반짝이는 바다를 바라보면 어찌나 황홀한지...";
            Customer_PerfumeOrder[6] = "꼭 다시 한번 가고 싶은 곳이야...!";
            Customer_PerfumeOrder[7] = "그때만 생각하면 너무나 행복하군!";
            Customer_PerfumeOrder[8] = "푸른 바닷가에 노을빛이 내려앉은 광경은 내 평생 잊지 못할 걸세!";


            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 아주 진하게 부탁하네!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "여행지";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "흠... 알겠네..";
            Customer_RejectReaction[1] = "실망이 크구만..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "상쾌한 바다 내음..";
                    Customer_PerfumeReaction[1] = "바로 이거지!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고맙구만 자네!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이게 뭔가..?";
                    Customer_PerfumeReaction[1] = "정신 차리게 젊은이..";

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
                    Customer_PerfumeReaction[0] = "아무 향이 안 나는데...";
                    Customer_PerfumeReaction[1] = "이런 걸 팔아도 되는 건가..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이건 리프 섬 냄새가 아니군 그래..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//C : 교복을 입은 청소년 남성
        {
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "안녕하세요, 아저씨";
            Customer_PerfumeOrder[1] = "오늘 아빠가 귀여운 새끼 강아지를 데리고 왔어요.";
            Customer_PerfumeOrder[2] = " 하얀 털이 복슬복슬한 동물이 우리 집에 같이 산다니..";
            Customer_PerfumeOrder[3] = "이제 우리 가족이 된 강아지와의 첫 만남을 평생 기억하고 싶어요.";
            Customer_PerfumeOrder[4] = "도와주세요..!";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 집에서 늘 은은하게 풍기면 좋겠어요.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "기쁨";

            Customer_RejectReaction[0] = "예?";
            Customer_RejectReaction[1] = "아.. 뭐.. 어쩔 수 없죠..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "와아!";
                    Customer_PerfumeReaction[1] = "감사합니다!";
                    Customer_PerfumeReaction[2] = "우리 집 강아지는 복슬 강아지~";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "감사합니다..";
                    Customer_PerfumeReaction[1] = "이 향수 잘 간직할게요.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "여기서 이상한 냄새가 나요..";
                    Customer_PerfumeReaction[1] = "일단 감사합니다.";

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
                    Customer_PerfumeReaction[0] = "뭐지..?";
                    Customer_PerfumeReaction[1] = "내 코가 막힌 건가..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이건 제가 말한 게 아니잖아요..";
                    Customer_PerfumeReaction[1] = "일단 감사합니다.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
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

        else if (Customer_ID[0] == 1009)//H : 30대 여성
        {
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "저기요..?";
            Customer_PerfumeOrder[1] = "헤어진 지 몇 년이나 지났는데, 아직도 생각나는 건 왜일까요..?";
            Customer_PerfumeOrder[2] = "사랑할 땐 슬프기만 해서 헤어지면 후련할 줄 알았는데..";
            Customer_PerfumeOrder[3] = "전 아직 제대로 잊지 못했나 봐요.";
            Customer_PerfumeOrder[4] = "이럴 줄 알았으면 시작하지 말았어야 했는데...";
            Customer_PerfumeOrder[5] = "참 바보 같죠?";
            Customer_PerfumeOrder[6] = "바보 같다는 건 알지만, 이제는 놓아주고 싶어요..";
            Customer_PerfumeOrder[7] = "저를 도와줄 수 있나요..?";

            for (int i = 8; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 약하게 해주세요..";
            Customer_IntensityOrder[1] = "향이 강하면 미련이 계속 남을 수도 있잖아요..? ";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "슬픔";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "......";
            Customer_RejectReaction[2] = "알겠어요..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "생각하면 할수록 그 사람 참 나빴는데..";
                    Customer_PerfumeReaction[1] = "이제는 잊을 수 있을 것 같아요..";
                    Customer_PerfumeReaction[2] = "고마워요.. 언젠간 좋은 사람이 오겠죠..?";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고마워요..";
                    Customer_PerfumeReaction[1] = "이제는 나아질 수 있겠죠..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "어떻게 이럴 수가 있죠..?";
                    Customer_PerfumeReaction[1] = "최악이에요..";

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
                    Customer_PerfumeReaction[0] = "음.. 전혀 느낄 수가 없는데요..?";
                    Customer_PerfumeReaction[1] = "제대로 한 게 맞나요...?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "이게.. 뭐죠..?";
                    Customer_PerfumeReaction[1] = "전혀 다른 냄새가 나는데요..?";
                    Customer_PerfumeReaction[2] = "이상한 걸 넣으면 어떡해요!!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    } 
  }
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    public GameObject RC;
    public GameObject DR;

    public int CriminalID = 0;

    //�넀�떂 ����궗 諛곗뿴 - �쟾泥대뒗 �옖�뜡�씠吏�留� �궡遺��뒗 �닚李⑥쟻�쑝濡�

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//�븳 �궇吏쒖뿉 �삤�뒗 �넀�떂�쓽 �븘�씠�뵒 (�넀�떂 �닔留뚰겮 �븷�떦)
    public string[] Customer_PerfumeOrder = new string[10];//�넀�떂 �뼢�닔 二쇰Ц ����궗
    public string[] Customer_IntensityOrder = new string[5];//�뼢�닔 媛뺣룄 ����궗
    public string[] Customer_Flavoring = new string[3];//�썝�븯�뒗 �뼢猷� �꽑�깮(踰�, 誘�, �깙)
    public string[] Customer_RejectReaction = new string[5];//�넀�떂 嫄곗젅 諛섏쓳
    public string[] Customer_PerfumeReaction = new string[5];//�뼢�닔 諛쏆쓣 �떆 �넀�떂 諛섏쓳

    public void Start()
    {
        //�넀�떂 �븘�씠�뵒 諛곗뿴�뿉 1-9源뚯�� 以묒뿉 �옖�뜡�쑝濡� �꽔�릺 以묐났�릺吏� �븡�룄濡� 諛곗튂�븿. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001, 1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }

        CriminalID = Random.Range(1001, 1010);
        //Customer = GameObject.Find("Etc").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        //踰붿즲�옄 �옖�뜡�쑝濡� �븳紐� 吏��젙�빐�꽌 �쁽�옱 �굹�삱 �넀�떂 �븘�씠�뵒�옉 �씪移섑븯硫� 踰붿즲�옄 吏��젙, 遺덇컪 true 蹂�寃�. 
        if (Customer_ID[0] == CriminalID)
        {
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = true;
        }
        else
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = false;


        if (Customer_ID[0] == 1001)//B : 珥덈벑�븰�깮 �뿬�옄�븘�씠, �떦�떦�븿
        {
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "�븞�뀞?";
            Customer_PerfumeOrder[1] = "�뼱由� �븣 �븘鍮� �넀�옟怨� 媛붾뜕 ����씠怨듭썝�뿉 �떎�떆 媛�怨� �떢�뼱!";
            Customer_PerfumeOrder[2] = "洹몃븣 吏꾩쭨 �뻾蹂듯뻽嫄곕뱺!!";
            Customer_PerfumeOrder[3] = "�뼢�닔濡� 留뚮뱾�뼱以� �닔 �엳�쓣源�?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "�뼢��� �젙留� 吏꾪븯寃� �빐以�!!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "媛뺥븿";

            Customer_Flavoring[0] = "�옣�냼";
            Customer_Flavoring[1] = "����씠怨듭썝";
            Customer_Flavoring[2] = "�뻾蹂�";

            Customer_RejectReaction[0] = "�븘吏� 紐� 留뚮뱶�뒗嫄곗빞?";
            Customer_RejectReaction[1] = "洹몃윭硫� �떎�쓬�뿉 �삱寃�!";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�젙留� 醫뗭븘!! 怨좊쭏�썙�슂!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�삤! �씠留뚰븯硫� 愿쒖갖��� 寃� 媛숈븘!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�썝�옒 �뼢�닔媛� �씠�젃�굹�슂..?";
                    Customer_PerfumeReaction[1] = "�셿�쟾 蹂꾨줎�뜲..?";
                    Customer_PerfumeReaction[2] = "�떎�젰�씠 �쁺..";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "萸� �븯�굹 鍮좊쑉由ъ떊 嫄� �븘�땲�뿉�슂?";
                    Customer_PerfumeReaction[1] = "�씠寃� �븘�땶 寃� 媛숈���뜲..";
                    Customer_PerfumeReaction[2] = "�셿�쟾 苑앹씠�빞!";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "�젣媛� 留먰븳 嫄곕옉 �떎瑜� 寃� 媛숈���뜲�슂?";
                    Customer_PerfumeReaction[1] = "�씠�윺 由ш�� �뾾�뒗�뜲..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1002)//J : 留덈Ⅸ 紐⑥뒿�쓽 30-40��� �븘以뚮쭏, �냼�떖�븿, 嫄깆젙
        {
            Customer_Name = "J";
            Customer_PerfumeOrder[0] = "���湲곗슂?";
            Customer_PerfumeOrder[1] = "�슦由� �븷媛� �븘吏곷룄 �뼱由� �븣 媛�吏�怨� ����뜕 �씤�삎�쓣 紐� �엸�뼱�슂.";
            Customer_PerfumeOrder[2] = "洹몃젃寃� 湲곕퍙�븯硫댁꽌 媛�吏�怨� ����뜕 嫄곕씪 �씠�빐�뒗 �븳�떎留�..";
            Customer_PerfumeOrder[3] = "�씠誘� 踰꾨┛ 吏�媛� �삤�옒�씤�뜲 �솢 �븘吏곷룄 紐� �엸�뿀�뒗吏� 李�..";
            Customer_PerfumeOrder[4] = "�샊�떆 �뼢�닔 媛��뒫�븷源뚯슂?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "怨좊쭏�썙�슂, �뼢��� �쟻�떦�엳..? �빐二쇱꽭�슂.";
            Customer_IntensityOrder[1] = "�븷媛� �꼫臾� �뼢�뿉 鍮좎쭏源뚮룄 嫄깆젙�씠�꽕�슂.";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "蹂댄넻";

            Customer_Flavoring[0] = "臾쇨굔";
            Customer_Flavoring[1] = "�씤�삎";
            Customer_Flavoring[2] = "湲곗겏";

            Customer_RejectReaction[0] = "�븘�땲 �룉�쓣 以��떎�뒗�뜲�룄�슂?";
            Customer_RejectReaction[1] = "遺덉풄�븯�꽕�슂.";
            Customer_RejectReaction[2] = "�씠嫄� �떎瑜� �궗�엺�뱾�븳�뀒�룄 �븣�젮�빞寃좎뼱�슂.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "媛먯궗�빀�땲�떎. �씠嫄곕㈃ �슦由� �븷 議곌툑�씠�씪�룄 �떖�옞 �닔 �엳寃좎짛?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�쓬.. 愿쒖갖�꽕�슂.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�씠嫄� �뼢�닔媛� �븘�땶�뜲�슂?";
                    Customer_PerfumeReaction[1] = "�씠�젃寃뚭퉴吏� 紐� 留뚮뱾 以꾩씠�빞..";
                    Customer_PerfumeReaction[2] = "�떎瑜� �궗�엺�뱾�룄 �븣�븘�빞 �븷 寃� 媛숇꽕�슂.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�셿�꽦�룄 �븞�맂 嫄� �씠�젃寃� �뙏�븘�룄 �릺�굹�슂?";
                    Customer_PerfumeReaction[1] = "二쇰�� �궗�엺�뱾�븳�뀒 �떎 留먰븷嫄곗뿉�슂!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�쓬.. �씠嫄� �젣媛� 留먰븳 嫄곕옉 �떎瑜몃뜲�슂?";
                    Customer_PerfumeReaction[1] = "�씠寃� 留욌굹�슂?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//G : 嫄댁옣�븳 30��� �궓�꽦
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "�븞�뀞�븯�꽭�슂!";
            Customer_PerfumeOrder[1] = "�궡�씪 ����쓽 �뿬�옄移쒓뎄�뿉寃� 泥��샎�쓣 �븯�젮怨� �빀�땲�떎.";
            Customer_PerfumeOrder[2] = "�븯�븯! �뫁�뒪�읇�꽕�슂.";
            Customer_PerfumeOrder[3] = "����쓽 �궗�옉�븯�뒗 留덉쓬�쓣 �뼢�닔濡� �븿猿� �꽑臾쇳븯怨� �떢����뜲..";
            Customer_PerfumeOrder[4] = "以�鍮� 媛��뒫�븷源뚯슂?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�븘! �뼢��� �븘二� 媛뺥븯寃� 遺��긽�뱶由쎈땲�떎.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "媛뺥븿";

            Customer_Flavoring[0] = "�씤媛�";
            Customer_Flavoring[1] = "�뿰�씤";
            Customer_Flavoring[2] = "�궗�옉";

            Customer_RejectReaction[0] = "�븞�맂�떎怨좎슂?";
            Customer_RejectReaction[1] = "�씠�젃寃� 臾댁옉�젙 嫄곗젅�빐�룄 �릺�뒗寃곷땲源�?";
            Customer_RejectReaction[2] = "�뿉�엲! �궡 湲곕텇 �떎 留앹낀�꽕.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���! �젣媛� �뵳 �썝�뻽�뜕 �뼢�닔�꽕�슂.";
                    Customer_PerfumeReaction[1] = "�씠嫄곕㈃ 泥��샎�룄 �꽦怨듯븷 �닔 �엳寃좎뼱�슂.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "媛먯궗�빀�땲�떎. �뜦 留덉쓬�뿉 �뱶�꽕�슂.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�씠 �뼢�닔�뒗..";
                    Customer_PerfumeReaction[1] = "諛쏅뒗 �젣 �뿬�옄移쒓뎄�룄 湲곕텇 �굹�걯寃좎뼱�슂.";
                    Customer_PerfumeReaction[2] = "�릱�뒿�땲�떎.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�굙�굙..";
                    Customer_PerfumeReaction[1] = "�뿬湲곗꽌 �븘臾� �뼢�룄 �굹吏� �븡�뒗 嫄몄슂?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씈.. �젣媛� 遺��긽�뱶由� �뼢�닔媛� �븘�땶 寃� 媛숆뎔�슂..";
                    Customer_PerfumeReaction[1] = "媛�蹂닿쿋�뒿�땲�떎.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//A : 珥덈벑�븰�깮 4-5�븰�뀈 �궓�옄 �븘�씠
        {
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "�븞�뀞�븯�꽭�슂?";
            Customer_PerfumeOrder[1] = "����룄 �삎 媛�吏�怨� �떢�뼱�슂!";
            Customer_PerfumeOrder[2] = "�삎�씠 �엳�쑝硫� 醫뗪쿋�떎!";
            Customer_PerfumeOrder[3] = "洹몃읆 留⑤궇 媛숈씠 ���怨� �뻾蹂듯븷�뀗�뜲!!";
            Customer_PerfumeOrder[4] = "�삎 �깂�깉�씪�룄 留≪쓣 �닔 �엳�쓣源뚯슂?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢�쓽 �꽭湲곕뒗 �븘臾닿굅�굹 �긽愿��뾾�뼱�슂!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "�븘臾닿굅�굹";

            Customer_Flavoring[0] = "�씤媛�";
            Customer_Flavoring[1] = "媛�議�";
            Customer_Flavoring[2] = "�뻾蹂�";

            Customer_RejectReaction[0] = "�븞�뤌�슂??";
            Customer_RejectReaction[1] = "�솢 �븞�뤌�슂??";
            Customer_RejectReaction[2] = "吏꾩쭨濡쒖슂??";
            Customer_RejectReaction[3] = "�븣寃좎뼱�슂..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���!! 怨좊쭥�뒿�땲�떎!!";
                    Customer_PerfumeReaction[1] = "�씠嫄곕㈃ �굹�룄 �삎�씠 �깮湲닿굔媛�??!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�삤�삤.. 怨좊쭥�뒿�땲�떎!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�씠嫄�.. 怨좊쭥�뒿�땲�떎..!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�깂�깉媛� �븞 �뒓猿댁���뒗�뜲..";
                    Customer_PerfumeReaction[1] = "�븘����뵪 �젣���濡� 留뚮뱺 嫄� 留욎븘�슂?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씠嫄� �삎 �깂�깉媛� �븘�땶�뜲�슂..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1005)//E : 10-20��� 珥덈컲 �뿬�꽦
        {
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "�븞�뀞..?";
            Customer_PerfumeOrder[1] = "���湲�.. 遺��긽�븷 寃� �엳�뒗�뜲..";
            Customer_PerfumeOrder[2] = "�슦由� 吏� 怨좎뼇�씠 �굹鍮꾨�� �븳 踰덈쭔�씠�씪�룄 �떎�떆 留뚮굹怨� �떢�뼱...";
            Customer_PerfumeOrder[3] = "�옒 �뾾�씠 �꽕 諛쒕줈 鍮꾪��嫄곕━硫댁꽌 �씪�뼱�꽌�젮怨� �끂�젰�븯�뒗 寃� �뿂洹몄젣 媛숈���뜲..";
            Customer_PerfumeOrder[4] = "異� 泥섏졇�꽌 �븘臾� 寃껊룄 �븞 �븯�뜑�땲..";
            Customer_PerfumeOrder[5] = "�씠�젨 �뜑 �씠�긽 蹂� �닔 �뾾�뼱..";
            Customer_PerfumeOrder[6] = "洹� 議곌렇留� �븘�씠媛� �뼹留덈굹 �븘�뙛�뒗吏� �깮媛곹븯硫�..";
            Customer_PerfumeOrder[7] = "�깮媛곸“李� �옒�뱾�뼱�꽌 �늿臾쇱씠 �굹..";
            Customer_PerfumeOrder[8] = "�젣諛� �굹鍮꾨�� �븳 踰덈쭔�씠�씪�룄 留뚮궇 �닔 �엳寃� �빐以�...";
            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢��� �꼫臾� 吏꾪븯吏��룄... �꼫臾� �������븯吏��룄 �븡寃� �빐以섃��";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "蹂댄넻";

            Customer_Flavoring[0] = "�룞臾�";
            Customer_Flavoring[1] = "諛섎젮�룞臾�";
            Customer_Flavoring[2] = "�뒳�뵒";

            Customer_RejectReaction[0] = "...�굹�븳�뀒 ���泥� �솢 洹몃옒�슂?";
            Customer_RejectReaction[1] = "�떒 �븳 踰덈쭔 �굹鍮꾨�� 留뚮굹�뒗 寃껊룄 �븞�릺�뒗 嫄곗빞?";
            Customer_RejectReaction[2] = "�궡媛� �씠�젃寃뚭퉴吏� �뻽�뒗�뜲..";
            Customer_RejectReaction[3] = "�떎瑜� �궗�엺�뱾�븳�뀒�룄 留먰븷 嫄곗빞.";
            Customer_RejectReaction[4] = "�썑�쉶�븯吏� 留� �떦�떊�씠 �븳 �꽑�깮�씠�옏�븘.";

            for (int i = 5; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�굹鍮꾩빞... �굹鍮꾩빞...";
                    Customer_PerfumeReaction[1] = "李⑤씪由� �궡媛� ����떊 �븘�뙛�뼱�빞 �븯�뒗�뜲...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "怨좊쭏�썙�슂...";
                    Customer_PerfumeReaction[1] = "�씠�젃寃뚮씪�룄 �굹鍮꾨�� 蹂� �닔 �엳�뼱�꽌..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�젙留� 理쒖븙�씠�꽕�슂...";
                    Customer_PerfumeReaction[0] = "�떎瑜� �궗�엺�뱾�룄 �떦�떊�씠 �씠�젃寃� 紐� 留뚮뱶�뒗 嫄� �븣怨� �엳�굹�슂..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�젣���濡� 留뚮뱺 嫄� 留욌굹�슂..?";
                    Customer_PerfumeReaction[1] = "�뒓猿댁���뒗 寃� �뾾�뒗�뜲..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씠 �뼢�씠 �븘�땶�뜲�슂..?";
                    Customer_PerfumeReaction[1] = "萸� 留뚮뱺 嫄곗짛..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//I : 40��� 嫄댁옣�븳 泥댄삎�쓽 �궓�꽦
        {
            Customer_Name = "I";
            Customer_PerfumeOrder[0] = "�옄�꽕 由ы봽 �꽟�뿉 媛�遊ㅻ굹?";
            Customer_PerfumeOrder[1] = "由ы봽 �꽟�쓣 紐⑤Ⅴ�뒗 紐⑥뼇�씠援�..?";
            Customer_PerfumeOrder[2] = "�젇��� �궗�엺�씠 留먯씠�빞...";
            Customer_PerfumeOrder[3] = "�궡媛� 醫� �뼐湲고빐 二쇱��!";
            Customer_PerfumeOrder[4] = "由ы봽 �꽟��� �뿉硫붾엫�뱶 鍮쏆쓽 諛붾떎濡� �몮�윭�떥�씤 �븘由꾨떎�슫 �꽟�씠�씪�꽕!";
            Customer_PerfumeOrder[5] = "洹몃뒛�뿉�꽌 �늿遺��떆�룄濡� 諛섏쭩�씠�뒗 諛붾떎瑜� 諛붾씪蹂대㈃ �뼱李뚮굹 �솴����븳吏�...";
            Customer_PerfumeOrder[6] = "瑗� �떎�떆 �븳踰� 媛�怨� �떢��� 怨녹씠�빞...!";
            Customer_PerfumeOrder[7] = "洹몃븣留� �깮媛곹븯硫� �꼫臾대굹 �뻾蹂듯븯援�!";
            Customer_PerfumeOrder[8] = "�뫖瑜� 諛붾떣媛��뿉 �끂�쓣鍮쏆씠 �궡�젮�븠��� 愿묎꼍��� �궡 �룊�깮 �엸吏� 紐삵븷 嫄몄꽭!";


            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢��� �븘二� 吏꾪븯寃� 遺��긽�븯�꽕!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "媛뺥븿";

            Customer_Flavoring[0] = "�옣�냼";
            Customer_Flavoring[1] = "�뿬�뻾吏�";
            Customer_Flavoring[2] = "�뻾蹂�";

            Customer_RejectReaction[0] = "�씈... �븣寃좊꽕..";
            Customer_RejectReaction[1] = "�떎留앹씠 �겕援щ쭔..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�긽苡뚰븳 諛붾떎 �궡�쓬..";
                    Customer_PerfumeReaction[1] = "諛붾줈 �씠嫄곗��!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "怨좊쭥援щ쭔 �옄�꽕!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�씠寃� 萸붽��..?";
                    Customer_PerfumeReaction[1] = "�젙�떊 李⑤━寃� �젇����씠..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�븘臾� �뼢�씠 �븞 �굹�뒗�뜲...";
                    Customer_PerfumeReaction[1] = "�씠�윴 嫄� �뙏�븘�룄 �릺�뒗 嫄닿��..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씠嫄� 由ы봽 �꽟 �깂�깉媛� �븘�땲援� 洹몃옒..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//C : 援먮났�쓣 �엯��� 泥��냼�뀈 �궓�꽦
        {
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "�븞�뀞�븯�꽭�슂, �븘����뵪";
            Customer_PerfumeOrder[1] = "�삤�뒛 �븘鍮좉�� 洹��뿬�슫 �깉�겮 媛뺤븘吏�瑜� �뜲由ш퀬 �솕�뼱�슂.";
            Customer_PerfumeOrder[2] = " �븯��� �꽭�씠 蹂듭뒳蹂듭뒳�븳 �룞臾쇱씠 �슦由� 吏묒뿉 媛숈씠 �궛�떎�땲..";
            Customer_PerfumeOrder[3] = "�씠�젣 �슦由� 媛�議깆씠 �맂 媛뺤븘吏�����쓽 泥� 留뚮궓�쓣 �룊�깮 湲곗뼲�븯怨� �떢�뼱�슂.";
            Customer_PerfumeOrder[4] = "�룄���二쇱꽭�슂..!";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢��� 吏묒뿉�꽌 �뒛 �������븯寃� �뭾湲곕㈃ 醫뗪쿋�뼱�슂.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "蹂댄넻";

            Customer_Flavoring[0] = "�룞臾�";
            Customer_Flavoring[1] = "諛섎젮�룞臾�";
            Customer_Flavoring[2] = "湲곗겏";

            Customer_RejectReaction[0] = "�삁?";
            Customer_RejectReaction[1] = "�븘.. 萸�.. �뼱姨� �닔 �뾾二�..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "����븘!";
                    Customer_PerfumeReaction[1] = "媛먯궗�빀�땲�떎!";
                    Customer_PerfumeReaction[2] = "�슦由� 吏� 媛뺤븘吏��뒗 蹂듭뒳 媛뺤븘吏�~";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "媛먯궗�빀�땲�떎..";
                    Customer_PerfumeReaction[1] = "�씠 �뼢�닔 �옒 媛꾩쭅�븷寃뚯슂.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�뿬湲곗꽌 �씠�긽�븳 �깂�깉媛� �굹�슂..";
                    Customer_PerfumeReaction[1] = "�씪�떒 媛먯궗�빀�땲�떎.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "萸먯��..?";
                    Customer_PerfumeReaction[1] = "�궡 肄붽�� 留됲엺 嫄닿��..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씠嫄� �젣媛� 留먰븳 寃� �븘�땲�옏�븘�슂..";
                    Customer_PerfumeReaction[1] = "�씪�떒 媛먯궗�빀�땲�떎.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//D : �떒諛� 癒몃━�쓽 泥��냼�뀈 �뿬�꽦
        {
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "�븞�뀞�븯�꽭�슂?";
            Customer_PerfumeOrder[1] = "�슦由� 吏묒뿉 洹��뿬�슫 媛뺤븘吏� 履쇨섕媛� �엳嫄곕뱺�슂?";
            Customer_PerfumeOrder[2] = "蹂� �븣留덈떎 �뼹留덈굹 �궗�옉�뒪�윭�슫 紐⑤Ⅴ寃좎뼱�슂!";
            Customer_PerfumeOrder[3] = "�씠嫄� �떎瑜� �븷�뱾�븳�뀒�룄 �븣�젮二쇨퀬 �떢����뜲..!";
            Customer_PerfumeOrder[4] = "�뼢�닔瑜� �꽑臾쇳븯硫� �릺吏� �븡�쓣源뚯슂?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢��� �셿�쟾 吏꾪븯寃�? �빐二쇱꽭�슂!!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "媛뺥븿";

            Customer_Flavoring[0] = "�룞臾�";
            Customer_Flavoring[1] = "諛섎젮�룞臾�";
            Customer_Flavoring[2] = "�궗�옉";

            Customer_RejectReaction[0] = "�쓳?";
            Customer_RejectReaction[1] = "�씈.. �솢�슂??";
            Customer_RejectReaction[2] = "�뼢�닔 �뙏硫� 醫뗭�� 嫄� �븘�땶媛�??";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�삤..吏꾩쭨 履쇨섕 �깂�깉�떎!";
                    Customer_PerfumeReaction[1] = "怨좊쭏�썙�슂!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�삤 履쇨섕 �깂�깉�궃�떎!";
                    Customer_PerfumeReaction[1] = "醫뗭븘�슂!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�쑝.. �씠�긽�븳 �깂�깉!!";
                    Customer_PerfumeReaction[1] = "履쇨섕�뒗 瑗ъ냼�븳 �깂�깉媛� �궃�떎援ъ슂!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�씠嫄� 臾댁뒯 �깂�깉吏�..?";
                    Customer_PerfumeReaction[1] = "�솢 �씠�젃寃� 留뚮뱺 嫄곗뿉�슂??";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�쓬.. 臾댁뒯 �깂�깉吏�..?";
                    Customer_PerfumeReaction[1] = "�셿�쟾�엳 �떎瑜� �깂�깉�씤�뜲�슂?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1009)//H : 30��� �뿬�꽦
        {
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "���湲곗슂..?";
            Customer_PerfumeOrder[1] = "�뿤�뼱吏� 吏� 紐� �뀈�씠�굹 吏��궗�뒗�뜲, �븘吏곷룄 �깮媛곷굹�뒗 嫄� �솢�씪源뚯슂..?";
            Customer_PerfumeOrder[2] = "�궗�옉�븷 �븧 �뒳�봽湲곕쭔 �빐�꽌 �뿤�뼱吏�硫� �썑�젴�븷 以� �븣�븯�뒗�뜲..";
            Customer_PerfumeOrder[3] = "�쟾 �븘吏� �젣���濡� �엸吏� 紐삵뻽�굹 遊먯슂.";
            Customer_PerfumeOrder[4] = "�씠�윺 以� �븣�븯�쑝硫� �떆�옉�븯吏� 留먯븯�뼱�빞 �뻽�뒗�뜲...";
            Customer_PerfumeOrder[5] = "李� 諛붾낫 媛숈짛?";
            Customer_PerfumeOrder[6] = "諛붾낫 媛숇떎�뒗 嫄� �븣吏�留�, �씠�젣�뒗 �넃�븘二쇨퀬 �떢�뼱�슂..";
            Customer_PerfumeOrder[7] = "���瑜� �룄���以� �닔 �엳�굹�슂..?";

            for (int i = 8; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�뼢��� �빟�븯寃� �빐二쇱꽭�슂..";
            Customer_IntensityOrder[1] = "�뼢�씠 媛뺥븯硫� 誘몃젴�씠 怨꾩냽 �궓�쓣 �닔�룄 �엳�옏�븘�슂..? ";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "�빟�븿";

            Customer_Flavoring[0] = "�씤媛�";
            Customer_Flavoring[1] = "�뿰�씤";
            Customer_Flavoring[2] = "�뒳�뵒";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "......";
            Customer_RejectReaction[2] = "�븣寃좎뼱�슂..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//踰좊�명깙 紐⑤몢 �삱諛붾Ⅸ �뼢猷� �궗�슜�븳 寃쎌슦 -> �룊�뙋 蹂닿퀬 �뙋�떒
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�깮媛곹븯硫� �븷�닔濡� 洹� �궗�엺 李� �굹鍮대뒗�뜲..";
                    Customer_PerfumeReaction[1] = "�씠�젣�뒗 �엸�쓣 �닔 �엳�쓣 寃� 媛숈븘�슂..";
                    Customer_PerfumeReaction[2] = "怨좊쭏�썙�슂.. �뼵�젨媛� 醫뗭�� �궗�엺�씠 �삤寃좎짛..?";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "怨좊쭏�썙�슂..";
                    Customer_PerfumeReaction[1] = "�씠�젣�뒗 �굹�븘吏� �닔 �엳寃좎짛..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�뼱�뼸寃� �씠�윺 �닔媛� �엳二�..?";
                    Customer_PerfumeReaction[1] = "理쒖븙�씠�뿉�슂..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//�뼢猷뚮�� �븯�굹�씪�룄 �떎瑜닿쾶 �궗�슜�븳 寃쎌슦
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//�뼢猷뚮�� �븯�굹�씪�룄 �꽔吏� �븡怨� 諛붾줈 �뼢�닔 �젣議고븳 寃쎌슦
                {
                    Customer_PerfumeReaction[0] = "�쓬.. �쟾��� �뒓�굜 �닔媛� �뾾�뒗�뜲�슂..?";
                    Customer_PerfumeReaction[1] = "�젣���濡� �븳 寃� 留욌굹�슂...?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�씠寃�.. 萸먯짛..?";
                    Customer_PerfumeReaction[1] = "�쟾��� �떎瑜� �깂�깉媛� �굹�뒗�뜲�슂..?";
                    Customer_PerfumeReaction[2] = "�씠�긽�븳 嫄� �꽔�쑝硫� �뼱�뼞�빐�슂!!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        TotalScore.FindObjectOfType<TotalScore>().baseItem.name = Customer_Flavoring[0];
        TotalScore.FindObjectOfType<TotalScore>().middleItem.name = Customer_Flavoring[1];
        TotalScore.FindObjectOfType<TotalScore>().topItem.name = Customer_Flavoring[2];
    } 
  }
>>>>>>> 951f4d97b6e6b55c8c4057ab753fbe526e43de3a
