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
        //Customer = GameObject.Find("Etc").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        //범죄자 랜덤으로 한명 지정해서 현재 나올 손님 아이디랑 일치하면 범죄자 지정, 불값 true 변경. 
        if (Customer_ID[0] == CriminalID)
        {
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = true;
        }
        else
            CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalStart = false;


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
                    Customer_PerfumeReaction[0] = "다른 사람들도 당신이 이렇게 못 만드는 거 알고 있나요..?";
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
