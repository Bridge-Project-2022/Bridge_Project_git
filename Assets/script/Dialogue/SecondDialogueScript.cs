using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SecondDialogueScript : MonoBehaviour
{
   //public GameObject Customer;
   public GameObject Distiller;

    GameObject RC;
    //손님 대사 배열 - 전체는 랜덤이지만 내부는 순차적으로

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
    //public Sprite[] Customer_Image = new Sprite[10];//손님 이미지 -> 아이디랑 연관
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
            Customer_ID[i] = Random.Range(2001, 2010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }

        //Customer = GameObject.Find("Etc").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (Customer_ID[0] == 2001)
        {
            Customer_Name = "J";
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[0];

            Customer_PerfumeOrder[0] = "저기요?";
            Customer_PerfumeOrder[1] = "오늘은.. 저의 옛 결혼기념일이랍니다..";
            Customer_PerfumeOrder[2] = "그가 처음으로 저에게 반지를 건넸을 때는 정말 깜짝 놀라서 믿지를 못했어요.. ";
            Customer_PerfumeOrder[3] = "그때의 감정이 새록새록 떠오르네요..";
            Customer_PerfumeOrder[4] = "물론 더이상 그를 볼 일이 없겠지만 말이죠.";
            Customer_PerfumeOrder[5] = "이런 저의 옛 추억도 담아줄 수 있나요?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "더 이상 과거에 집착하고 싶지 않아요..";
            Customer_IntensityOrder[1] = "향은 그냥 은은하게 해주세요!";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "놀라움";

            Customer_RejectReaction[0] = "그다지 어려운 부탁을 하진 않았던 거 같은데.. ";
            Customer_RejectReaction[1] = "다시는 이런 일이 없으면 좋겠네요.";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "고마워요, 덕분에 좋은 기억만을 가져가네요..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "음.. 만족스럽네요.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이걸 나보고 어떻게 쓰라는 거예요?";
                    Customer_PerfumeReaction[1] = "이건 악취잖아요 악취";
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
                    Customer_PerfumeReaction[0] = "이게 다 만든 건가요..? ";
                    Customer_PerfumeReaction[1] = "받을 가치도 없네요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "대체 무슨 향수를 만든 거죠?";
                    Customer_PerfumeReaction[1] = "정말 형편없네요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 2002)//K: 베레모를 쓴 푸근한 인상의 할아버지
        {
            Customer_Name = "K";
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[1];

            Customer_PerfumeOrder[0] = "반갑네, 주인 양반!";
            Customer_PerfumeOrder[1] = "내가 이 가게는 처음이지만 마음이 벌써 따뜻해지는군..";
            Customer_PerfumeOrder[2] = "우리 할멈도 이런 곳에 오면 좋을 텐데..";
            Customer_PerfumeOrder[3] = "할멈과 단둘이 데이트하던 그때 모습도 볼 수 있는 건가?";
            Customer_PerfumeOrder[4] = "허허! 그렇다면 우리 할멈의 꽃다운 시절, 행복했던 미소를 다시 보고 싶구만..";
            Customer_PerfumeOrder[5] = "어디 만들어 줄 수 있는가?";
            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "그때 우리 할멈이 그렇게 예뻤어..";
            Customer_IntensityOrder[1] = "향을 아주 진~하게 해주게나!";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "흠.. 알겠네…";
            Customer_RejectReaction[1] = "괜히 찾아왔구만... ";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "고맙구만, 우리 할멈의 미소를 보니 나도 행복해지는 것만 같네!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오호, 아주 좋은 향수구만.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이걸 향수라고 만든 건가…?";
                    Customer_PerfumeReaction[1] = "할멈이 보고 싶구만…";
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
                    Customer_PerfumeReaction[0] = "향수라고 하기엔.. 아무 냄새가 나질 않는구만!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "내가 찾던 향수는 이게 아닌 것 같은데..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2003)//A: 덥수룩한 머리의 꼬마 남자아이
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[2];
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "안녕하세요 ?";
            Customer_PerfumeOrder[1] = "저도 동생을 가지고 싶어요!!";
            Customer_PerfumeOrder[2] = "친구들이 동생이랑만 아주 신나게 소꿉놀이를 하더라구요!";
            Customer_PerfumeOrder[3] = "나도 진짜 잘 놀아줄 자신 있는데..";
            Customer_PerfumeOrder[4] = "저도 동생 냄새라도 맡아보고 싶어요..!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "혹시 동생이 다칠 수 있으니까 향은 너무 세지않게 해주세요!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "가족";
            Customer_Flavoring[2] = "기쁨";

            Customer_RejectReaction[0] = "안돼요??";
            Customer_RejectReaction[1] = "왜 안돼요??";
            Customer_RejectReaction[2] = "진짜로요..?";
            Customer_RejectReaction[3] = "알겠어요..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "우와! 나도 이런 동생을 낳아달라고 할래요!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "감사합니다!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "으…. 별로야… ";
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
                    Customer_PerfumeReaction[0] = "냄새가 안 느껴지는데… 제대로 만든 거 맞아요..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "저는.. 이런 향수를… 사러 온 게 아니에요..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2004)//F:반짝이는 눈의 20대 여자
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[3];
            Customer_Name = "F";
            Customer_PerfumeOrder[0] = "저기 너 말이야!";
            Customer_PerfumeOrder[1] = "루트 대륙 끝에 작은 산맥이 있는 거 알아?";
            Customer_PerfumeOrder[2] = "그 작은 산맥을 가로지르는 길이 하나 있는데";
            Customer_PerfumeOrder[3] = "거기서 주위를 둘러보면 그렇게 좋을 수가 없다...?";
            Customer_PerfumeOrder[4] = "그 풍경에 놀라서 아직도 입이 다 물어지지 않아!";
            Customer_PerfumeOrder[5] = "그때 생각나게 해줄 거지?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "좋아! 내가 언제나 다시 여행할 수 있도록 향은 은은하게 해줘!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "여행지";
            Customer_Flavoring[2] = "놀라움";

            Customer_RejectReaction[0] = "뭐..?";
            Customer_RejectReaction[1] = "손님을 그렇게 대해도 되는거야?";
            Customer_RejectReaction[2] = "실망이야..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
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
                    Customer_PerfumeReaction[0] = "오.. 만족스러운걸?";
                    Customer_PerfumeReaction[1] = "정말 고마워!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "으으.. 최악이야..";
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
                    Customer_PerfumeReaction[0] = "이거 맞아?";
                    Customer_PerfumeReaction[1] = "정말로 다 한 거 맞아..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이게 대체 무슨 냄새야?";
                    Customer_PerfumeReaction[1] = "내가 원하는 게 아니잖아!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2005)//B: 양갈래 머리의 꼬마 여자 아이
        {
            // Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[4];
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "저기...";
            Customer_PerfumeOrder[1] = "내 애착 인형이 너무 그리워..";
            Customer_PerfumeOrder[2] = "그 인형을 껴안으면 진짜 행복했는데..";
            Customer_PerfumeOrder[3] = "엄마가 내 인형이 터졌다고 버려버린 거 있지..?";
            Customer_PerfumeOrder[4] = "내가 수술해 주기로 꼬옥 약속했는데…";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 엄청 많이! 진하게! 해줘요!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "물건";
            Customer_Flavoring[1] = "인형";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "지금 안 만들어 주실 거예요?";
            Customer_RejectReaction[1] = "미워..";
            Customer_RejectReaction[2] = "진짜 미워!!";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "와! 인형이다!!";
                    Customer_PerfumeReaction[1] = "그래그래, 너를 다시 만나니까 너무 좋아!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "와아.. 정말 감사합니다!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이 냄새 아니야!!";
                    Customer_PerfumeReaction[1] = "내 인형 냄새가 아니야!!";

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
                    Customer_PerfumeReaction[0] = "뭐 하나 빠트리신 거 아니에요?";
                    Customer_PerfumeReaction[1] = "이게 아닌 거 같은데..";
                    Customer_PerfumeReaction[2] = "완전 꽝이야!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "그러니까.. .이게.. 내 인형이야.?";
                    Customer_PerfumeReaction[1] = "이럴 리가 없는데..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2006)//D
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[5];
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "저기..";
            Customer_PerfumeOrder[1] = "엄마가 어릴 때 사준 자동차가 왜 아직도 생각나는 걸까?";
            Customer_PerfumeOrder[2] = "그때 가지고 놀기만 해도 행복해서 그랬나?";
            Customer_PerfumeOrder[3] = "나도 잘 모르겠는데 장난감 자동차가 자꾸 생각나";
            Customer_PerfumeOrder[4] = "나 좀 도와주지 않을래?";
 
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "음.. 향은 은은하게 부탁할게!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "물건";
            Customer_Flavoring[1] = "장난감";
            Customer_Flavoring[2] = "행복";

            Customer_RejectReaction[0] = "뭐??";
            Customer_RejectReaction[1] = "칫 기분 나빠졌어.";
            Customer_RejectReaction[1] = "여긴 다시 안 올 거야!";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "오 진짜같아!!";
                    Customer_PerfumeReaction[1] = "자동차 타고 날아다닐 수 있을 거 같아!!!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "음 좀 비슷하네요?";
                    Customer_PerfumeReaction[1] = "내가 찾던 자동차랑 닮은 거 같아!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "어…. 너무 별론데?";
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
                    Customer_PerfumeReaction[0] = "이건 대체 무슨 냄새야?";
                    Customer_PerfumeReaction[1] = "아무 냄새 안나잖아";
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

        else if (Customer_ID[0] == 2007)//E: 수척하고 다크서클 있는 20대 남성
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[6];
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "....여...";
            Customer_PerfumeOrder[1] = "....여자..친..구...";
            Customer_PerfumeOrder[2] = "...보..고...싶어...";
            Customer_PerfumeOrder[3] = "...괜찮...을...까...?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은.. ..진...하게...";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = ".....";
            Customer_RejectReaction[1] = ".........";
            Customer_RejectReaction[2] = ".............";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "….익숙한 향..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "....고마워...";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "...별로야..";
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
                    Customer_PerfumeReaction[0] = ".....";
                    Customer_PerfumeReaction[1] = "..........";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이게..아닌..데.....?"; ;
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2008)//H : 단발머리 안경을 쓴 청소년 여성
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[7];
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "안녕하세요~";
            Customer_PerfumeOrder[1] = "축하해줘야 하는 일이 하나 있어요.";
            Customer_PerfumeOrder[2] = "바로바로..";
            Customer_PerfumeOrder[3] = "제가 그토록 원하던 로스쿨에 드디어 합격했다고요!";
            Customer_PerfumeOrder[4] = "이 기분 좋은 날을 평생 기억하고 싶어요~";
            Customer_PerfumeOrder[5] = "향수 하나만 부탁드릴게요!";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 적당히만 해도 충분할 거 같아요!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "학교";
            Customer_Flavoring[2] = "기쁨";

            Customer_RejectReaction[0] = "네..?";
            Customer_RejectReaction[1] = "참.. 어이가 없네요..";
            Customer_RejectReaction[2] = "여기는 괜히 왔던 것 같아요.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "이 추억을 소중하게 잘 간직해서 멋진 변호사가 될게요.";
                    Customer_PerfumeReaction[1] = "정말 감사합니다!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "오.. 좋아요!";
                    Customer_PerfumeReaction[1] = "만족합니다!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "악.. 이게 뭔가요..?";
                    Customer_PerfumeReaction[1] = "이건 문제가 있다고 생각하는 걸요..";
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
                    Customer_PerfumeReaction[0] = "무슨 향이 난다는 건지..";
                    Customer_PerfumeReaction[1] = "그게 완성품인가요?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "제가..찾는 향은 아니겠죠?";
                    Customer_PerfumeReaction[1] = "실수는 용납할 수 없어요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2009)//C
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[8];
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "저기요..?";
            Customer_PerfumeOrder[1] = "아니.. 그게..";
            Customer_PerfumeOrder[2] = "혹시 짝사랑을 해본 적이 있나요..?";
            Customer_PerfumeOrder[3] = "요즘 같은 반 짝꿍과 눈만 마주치면 제 심장이 두근거려요.";
            Customer_PerfumeOrder[4] = "예쁜 그 갈색 눈동자..";
            Customer_PerfumeOrder[5] = "이런 제 마음이 어디 새어나가지 않도록 보관할 방법이 없을까요?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 저만 느껴질 정도로 은은하게 부탁해요.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "친구";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "에휴.. 이러다 진짜 들키는 거 아니야..?";
            Customer_RejectReaction[1] = "돌겠다..";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "나비야... 나비야...";
                    Customer_PerfumeReaction[1] = "차라리 내가 대신 아팠어야 했는데...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "와!";
                    Customer_PerfumeReaction[1] = "제 마음에 쏙 들어요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "제 마음을 들킬 일은 없겠네요.";
                    Customer_PerfumeReaction[1] = "뭐.. 감사합니다.";
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
                    Customer_PerfumeReaction[1] = "내 코가 이상한건가..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이건..음...";
                    Customer_PerfumeReaction[1] = "제가 찾던 향수가 아니에요.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
}
