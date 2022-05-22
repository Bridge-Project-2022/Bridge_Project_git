using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    public GameObject Customer;
    public GameObject Distiller;


    //손님 대사 배열 - 전체는 랜덤이지만 내부는 순차적으로

    public static int FirstDayCustomerNum = 9;

    public int[] Customer_ID = new int[FirstDayCustomerNum];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
    public Sprite[] Customer_Image = new Sprite[10];//손님 이미지 -> 아이디랑 연관
    public string[] Customer_PerfumeOrder = new string[10];//손님 향수 주문 대사
    public string[] Customer_IntensityOrder = new string[5];//향수 강도 대사
    public string[] Customer_Flavoring = new string[3];//원하는 향료 선택(베, 미, 탑)
    public string[] Customer_RejectReaction = new string[5];//손님 거절 반응
    public string[] Customer_PerfumeReaction = new string[5];//향수 받을 시 손님 반응

    //유저 대사 배열 - 기존 랜덤 적용
    public string[] Dialogue_C_1 = new string[3];//유저 - 향 세기 물어봄
    public string[] Dialogue_C_2 = new string[3];//유저 - 거절 대사

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

        //유저 : '예' 선택한 경우
        Dialogue_C_1[0] = "향의 세기는 어느 정도로 해드릴까요?";
        Dialogue_C_1[1] = "향은 어느 정도로 해드릴까요?";
        Dialogue_C_1[2] = "생각하신 향의 세기가 있을까요?";

        //유저 : '아니오' 선택한 경우
        Dialogue_C_2[0] = "죄송합니다. 손님에게 판매할 수 없어요.";
        Dialogue_C_2[1] = "죄송합니다. 손님에게 향수를 만들어줄 수 없어요.";
        Dialogue_C_2[2] = "죄송합니다. 손님의 향수는 만들 수 없어요.";
    }
    public void Update()
    {
        if (Customer_ID[0] == 1001)//A : 초등학생 여자아이, 당당함
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[0];

            Customer_PerfumeOrder[0] = "안녕?";
            Customer_PerfumeOrder[1] = "어릴 때 아빠 손잡고 갔던 놀이공원에 다시 가고 싶어!";
            Customer_PerfumeOrder[2] = "그때 진짜 행복했거든!!";
            Customer_PerfumeOrder[3] = "향수로 만들어줄 수 있을까?";
            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "정말 진하게 해줘";
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
                    Customer_PerfumeReaction[0] = "오! 이만하면 괜찮은 것 같아요!";
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
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "뭐 하나 빠뜨리신 거 아니에요?";
                    Customer_PerfumeReaction[1] = "이게 아닌 것 같은데..";
                    Customer_PerfumeReaction[2] = "완전 꽝이야!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
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

        else if (Customer_ID[0] == 1002)//B : 마른 모습의 30-40대 아줌마, 소심함, 걱정
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[1];

            Customer_PerfumeOrder[0] = "저기요?";
            Customer_PerfumeOrder[1] = "우리 애가 아직도 어릴 때 가지고 놀던 인형을 못 잊어요.";
            Customer_PerfumeOrder[2] = "그렇게 기뻐하면서 가지고 놀던 거라 이해는 한다만..";
            Customer_PerfumeOrder[3] = "이미 버린 지가 오래인데 왜 아직도 못 잊었는지 참..";
            Customer_PerfumeOrder[4] = "혹시 향수 가능할까요?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "적당히..? 해주세요.";
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
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "완성도 안된 걸 이렇게 팔아도 되나요?";
                    Customer_PerfumeReaction[1] = "주변 사람들한테 다 말할거에요!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "음.. 이거 제가 말한 거랑 다른데요?";
                    Customer_PerfumeReaction[1] = "이게 맞나요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//C : 글썽이는 20-30대 남자, 수척함
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[2];

            Customer_PerfumeOrder[0] = "..저기..요?";
            Customer_PerfumeOrder[1] = "...제발 내 사랑을 다시 한번만이라도 보고 싶어..";
            Customer_PerfumeOrder[2] = "내가 이렇게 좋아하는데.. 대체 어떻게 지내고 있는거야..?";
            Customer_PerfumeOrder[3] = "내가 사랑하는 그녀가 미치도록 보고 싶어..";
            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향이 빠지지 않도록 강하게 해주세요..";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "...나한테 대체 왜 그래요?";
            Customer_RejectReaction[1] = "당신만큼은 그러면 안 되잖아..";
            Customer_RejectReaction[2] = "다른 사람들한테도 말할거야.";
            Customer_RejectReaction[3] = "후회하지 마, 당신이 한 선택이잖아?";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "이것이 바로 그녀의 향..";
                    Customer_PerfumeReaction[1] = "정말 감사합니다.. 정말로...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고마워요..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "너무 못 만든거 아닌가요..?";
                    Customer_PerfumeReaction[1] = "다른 사람들도 당신이 이렇게 못 만드는 거 알고 있나요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "제대로 만든 거 맞나요..?";
                    Customer_PerfumeReaction[1] = "아무 것도 느껴지지 않아요..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이건 내가 맡고 싶은 향이 아니에요..";
                    Customer_PerfumeReaction[1] = "완전 최악이네요..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//D : 초등학생 4-5학년 남자 아이
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[3];

            Customer_PerfumeOrder[0] = "안녕하세요?";
            Customer_PerfumeOrder[1] = "저도 형 가지고 싶어요!";
            Customer_PerfumeOrder[2] = "형이 있으면 좋겠다!";
            Customer_PerfumeOrder[3] = "그럼 맨날 같이 놀고 행복할텐데!!";
            Customer_PerfumeOrder[4] = "형 냄새라도 맡을 수 있을까요?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "아무거나 해주세요!!";
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
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "냄새가 안 느껴지는데..";
                    Customer_PerfumeReaction[1] = "아저씨 제대로 만든 거 맞아요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
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
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[4];

            Customer_PerfumeOrder[0] = "아저씨..?";
            Customer_PerfumeOrder[1] = "엄마가 어릴 때 사준 자동차가 왜 아직도 생각나는 걸까?";
            Customer_PerfumeOrder[2] = "그 때 가지고 놀기만 해도 행복해서 그랬나?";
            Customer_PerfumeOrder[3] = "나도 잘 모르겠는데 장난감 자동차가 자꾸 생각나..";
            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "음.. 은은하게 해줘!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "물건";
            Customer_Flavoring[1] = "장난감";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "뭐??";
            Customer_RejectReaction[1] = "칫 기분 나빠졌어!";
            Customer_RejectReaction[2] = "여긴 다시 안 올거야!";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "오.. 진짜같아!!";
                    Customer_PerfumeReaction[1] = "자동차 타고 날아다닐 수 있을 것 같아!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "음.. 좀 비슷하네!";
                    Customer_PerfumeReaction[1] = "내가 찾던 자동차랑 닮은 것 같아!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "어.. 너무 별론데?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "이건 대체 무슨 냄새야?";
                    Customer_PerfumeReaction[1] = "아무 냄새 안 나잖아!";
                    Customer_PerfumeReaction[2] = "뭘 만든거야 대체?";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "내가 찾던 자동차가 아니잖아??";
                    Customer_PerfumeReaction[1] = "이런 쓰레기를 왜 만들었어?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//F : 30대 남성
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[5];

            Customer_PerfumeOrder[0] = "저희 강아지가... 무지개 다리를 건넜어요..";
            Customer_PerfumeOrder[1] = "매일 아침 눈을 뜨면, 둥이가 없어서 미칠 것 같아요..";
            Customer_PerfumeOrder[2] = "그게 뭐가 힘들다고.. 산책도 못 가줬는데..";
            Customer_PerfumeOrder[3] = "더 잘 해주지 못해서 너무 미안한데..";
            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "둥이랑 같이 덮고 자던 이불에 뿌릴 거에요..";
            Customer_IntensityOrder[1] = "그 이불에서 만큼은 둥이를 느낄 수 있게..";
            Customer_IntensityOrder[2] = "이럴 거면 진해야겠죠..?";
            for (int i = 3; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "죄책감";

            Customer_RejectReaction[0] = "...?";
            Customer_RejectReaction[1] = "그쪽은 반려견을 키워본 경험이 없나보죠?";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "둥이야.. 이 냄새가 너무 너무 그리웠어..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "이 냄새가 그리웠어..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이렇게 못 만드는 것도 재주다 재주.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "향이 없는데 뭘 맡으란 거야?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이게 무슨 냄새인가요??";
                    Customer_PerfumeReaction[1] = "둥이 냄새가 아닌데?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//G : 40-50대 중년의 남성
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[6];

            Customer_PerfumeOrder[0] = "안녕하신가..";
            Customer_PerfumeOrder[1] = "내 죽은 친구 놈이 보고 싶구만..";
            Customer_PerfumeOrder[2] = "그 때 가지 말라고 말렸어야 했는데 말이야..";
            Customer_PerfumeOrder[3] = "빌어먹을.. 그놈이 사고에 휘말렸어..";
            Customer_PerfumeOrder[4] = "제기랄.. 내 탓이지 뭐..";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "그 친구 향이 영원히 지속됐으면 좋겠군..";
            Customer_IntensityOrder[1] = "내가 감히 이래도 되는 걸까..?";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "친구";
            Customer_Flavoring[2] = "죄책감";

            Customer_RejectReaction[0] = "젠장.. 내가 당신에게 뭘 잘못했지..?";
            Customer_RejectReaction[1] = "오늘도 개 같은 하루구만..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "내가.. 정말...";
                    Customer_PerfumeReaction[1] = "정말...";
                    Customer_PerfumeReaction[2] = ".....";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고맙군.. 자네..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이건 대체 뭘..";
                    Customer_PerfumeReaction[1] = "형편없구만.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "지금 장난하는건가?";
                    Customer_PerfumeReaction[1] = "향이 안 느껴지는데 뭐 어떡하라는 거야?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "내가 우습나?"; ;
                    Customer_PerfumeReaction[1] = "이럴 거면 때려치우게.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//H : 20대 초반의 여성
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[7];

            Customer_PerfumeOrder[0] = "저기 너 말이야!";
            Customer_PerfumeOrder[1] = "루트 대륙 끝에 작은 산맥이 있는거 알아?";
            Customer_PerfumeOrder[2] = "그 작은 산맥을 가로지르는 길이 하나 있는데";
            Customer_PerfumeOrder[3] = "거기서 주위를 둘러보면 그렇게 좋을 수가 없다...?";
            Customer_PerfumeOrder[4] = "그 풍경에 놀라서 아직도 입이 다 물어지지 않아!";
            Customer_PerfumeOrder[5] = "그때 생각나게 해줄 거지?";
            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "언제나 다시 여행할 수 있도록 은은하게 해줘!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "여행지";
            Customer_Flavoring[2] = "놀라움";

            Customer_RejectReaction[0] = "뭐..? 손님을 그렇게 대해도 되는거야? 실망이야";
            for (int i = 1; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "너무 짜릿해! 너 덕분에 그 풍경을 다시 즐길 수 있었어.";
                    Customer_PerfumeReaction[1] = "정말 고마워!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오.. 만족스러운걸?!";
                    Customer_PerfumeReaction[1] = "정말 고마워!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "으으....";
                    Customer_PerfumeReaction[1] = "최악이야..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "이거 맞아?";
                    Customer_PerfumeReaction[1] = "정말로 다 한 거 맞아?!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이게 대체 무슨 냄새야?!";
                    Customer_PerfumeReaction[1] = "내가 원하는 게 아니잖아!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1009)//I : 10대의 남성
        {
            Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[8];

            Customer_PerfumeOrder[0] = "저기.. 안녕하세요?";
            Customer_PerfumeOrder[1] = "사실 요즘 제 물건이 사라지는 것 같아서요..";
            Customer_PerfumeOrder[2] = "의심하고 싶진 않은데 친구랑 놀고 있으면 물건이 자꾸 사라져요!";
            Customer_PerfumeOrder[3] = "그냥 제 착각인 것 같기도 하고..";
            Customer_PerfumeOrder[4] = "아무리 기억을 되새겨봐도 확신이 생기지 않아서요..";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "정확하게 기억할 수 있도록 강하게 해주세요!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "친구";
            Customer_Flavoring[2] = "의심";

            Customer_RejectReaction[0] = "아… 아무리 생각해봐도 걔가 맞는 거 같은데..";
            Customer_RejectReaction[1] = "..미치겠네";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "휴.. 주머니가 터진 바지를 입어서 그랬네";
                    Customer_PerfumeReaction[1] = "착각해서 친구를 의심할 뻔 했어요!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "뭐야 내 잘못이잖아!?";
                    Customer_PerfumeReaction[1] = "고마워요!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이건… 좀….";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//향료를 하나라도 다르게 사용한 경우
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//향료를 하나라도 넣지 않고 바로 향수 제조한 경우
                {
                    Customer_PerfumeReaction[0] = "아무 향이 없는데요?";
                    Customer_PerfumeReaction[1] = "이건… 좀….";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "내가 원하던 게 아닌데요..?";
                    Customer_PerfumeReaction[1] = "이건… 좀….";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            //유저 : '예' 선택한 경우
            Dialogue_C_1[0] = "향의 세기는 어느 정도로 해드릴까요?";
            Dialogue_C_1[1] = "향은 어느 정도로 해드릴까요?";
            Dialogue_C_1[2] = "생각하신 향의 세기가 있을까요?";

            //유저 : '아니오' 선택한 경우
            Dialogue_C_2[0] = "죄송합니다. 손님에게 판매할 수 없어요.";
            Dialogue_C_2[1] = "죄송합니다. 손님에게 향수를 만들어줄 수 없어요.";
            Dialogue_C_2[2] = "죄송합니다. 손님의 향수는 만들 수 없어요.";
        }
    }
}
