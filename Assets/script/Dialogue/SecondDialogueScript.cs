using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SecondDialogueScript : MonoBehaviour
{
   public GameObject Customer;
   public GameObject Distiller;

    GameObject RC;
    //손님 대사 배열 - 전체는 랜덤이지만 내부는 순차적으로

    public static int FirstDayCustomerNum = 9;

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

        Customer = GameObject.Find("Dialogue").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (Customer_ID[0] == 2001)
        {
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

            Customer_Flavoring[0] = "사람";
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

        else if (Customer_ID[0] == 2002)//베레모를 쓴 푸근한 인상의 할아버지
        {
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

            Customer_Flavoring[0] = "사람";
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

        else if (Customer_ID[0] == 2003)//덥수룩한 머리의 꼬마 남자아이
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[2];

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

            Customer_Flavoring[0] = "사람";
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

        else if (Customer_ID[0] == 2004)//반짝이는 눈의 20대 여자
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[3];

            Customer_PerfumeOrder[0] = "안녕하세요!";
            Customer_PerfumeOrder[1] = "어른이 되고 나니까 괜히 어릴 때로 돌아가고 싶은 거 있죠?";
            Customer_PerfumeOrder[2] = "친구들과 학교 다닐 때가 정말 좋았는데..";
            Customer_PerfumeOrder[3] = "매일 아침 지각해서 복도에서 손들고 있었다니까요~?";
            Customer_PerfumeOrder[4] = "하하! 그때는 볼이 빨개져서 쥐구멍에 숨고 싶었는데..";
            Customer_PerfumeOrder[5] = "지나보니 그런 게 다 저에겐 추억이더라고요.";
            Customer_PerfumeOrder[6] = "혹시 이것도 향수로 받을 수 있을까요?";

            for (int i = 7; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 너무 진하지 않도록 적당하게 부탁해요!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "장소";
            Customer_Flavoring[1] = "학교";
            Customer_Flavoring[2] = "부끄러움";

            Customer_RejectReaction[0] = "네? 지금 거절하신 건가요?";
            Customer_RejectReaction[1] = "그래요, 제 기분을 제대로 망치셨네요.";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "저의 학창 시절의 모습이 그대로 담겨있네요.";
                    Customer_PerfumeReaction[1] = "순수했던 모습을 찾아줘서 고마워요!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "바로 이거야..!";
                    Customer_PerfumeReaction[0] = "정말 고마워요!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이걸 내 돈 주고 샀다는 게 정말 부끄럽네요..";
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
                    Customer_PerfumeReaction[0] = "이거 맞나요?";
                    Customer_PerfumeReaction[1] = "정말로... 다 한 거 맞는 거죠..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이게 대체 무슨 냄새지?";
                    Customer_PerfumeReaction[1] = "조..금.. 실망인걸요..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2005)//양갈래 머리의 꼬마 여자 아이
        {
           // Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[4];

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

        else if (Customer_ID[0] == 2006)//눈에 상처가 있는 40대 남성
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[5];

            Customer_PerfumeOrder[0] = "자네 리프 섬에 가봤나?";
            Customer_PerfumeOrder[1] = "리프 섬을 모르는 모양이군..?";
            Customer_PerfumeOrder[2] = "젊은 사람이 말이야…";
            Customer_PerfumeOrder[3] = "내가 좀 얘기해 주지!";
            Customer_PerfumeOrder[4] = "리프 섬은 에메랄드 빛의 바다로 둘러싸인 아름다운 섬이라네!";
            Customer_PerfumeOrder[5] = "그늘에서 눈부시도록 반짝이는 바다를 바라보면 어찌나 황홀한지…";
            Customer_PerfumeOrder[6] = "꼭 다시 한번 가고 싶은 곳이야…!";
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

            Customer_RejectReaction[0] = "흠..알겠네..";
            Customer_RejectReaction[1] = "실망이 크구만..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "상쾌한 바다 내음...";
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
                    Customer_PerfumeReaction[1] = "이런 걸 팔아도 되는 건가?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "이건 리프 섬 냄새가 아니군 그래..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2007)//수척하고 다크서클 있는 20대 남성
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[6];

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

            Customer_Flavoring[0] = "사람";
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

            Customer_PerfumeOrder[0] = "저기..";
            Customer_PerfumeOrder[1] = "나 도와주고 싶은 친구가 있어..";
            Customer_PerfumeOrder[2] = "친구가 괴롭힘 당하지만 아무 것도 못 하고 있어..";
            Customer_PerfumeOrder[3] = "내가 조금만 더 용기를 내면 괜찮을까..?";
            Customer_PerfumeOrder[4] = "조금이라도 달라질까..?";
            Customer_PerfumeOrder[5] = "그 친구만 생각하면 너무 미안하구..";
            Customer_PerfumeOrder[6] = "내가 그 친구를 도와줄 수 있을까..?";

            for (int i = 7; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "내가 힘낼 수 있도록 향은 적당히 조절해줘..";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "사람";
            Customer_Flavoring[1] = "친구";
            Customer_Flavoring[2] = "죄책감";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "그래 내가 알아서 할게..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "고마워!";
                    Customer_PerfumeReaction[1] = "이제야 친구를 도울 수 있을 것 같아..!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "이 정도면 괜찮은 것 같아..!";
      
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "왜 이렇게 만든 거야..?";
                    Customer_PerfumeReaction[1] = "정말 싫어..";
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
                    Customer_PerfumeReaction[0] = "일부로 이런 거야..?";
                    Customer_PerfumeReaction[1] = "이러지 않아도 됐잖아...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "대체 뭘 만든 거야..?";
                    Customer_PerfumeReaction[1] = "이건 완전 다른 거잖아!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2009)//수척하고 다크서클이 낀 20대 남성
        {
           //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[8];

            Customer_PerfumeOrder[0] = "안녕..?";
            Customer_PerfumeOrder[1] = "저기.. 부탁할 게 있는데..";
            Customer_PerfumeOrder[2] = "우리 집 고양이 나비를 한 번만이라도 다시 만나고 싶어...";
            Customer_PerfumeOrder[3] = "힘 없이 네 발로 비틀거리면서 일어서려고 노력하는 게 엊그제 같은데..";
            Customer_PerfumeOrder[4] = "축 처져서 아무것도 안 하더니...";
            Customer_PerfumeOrder[5] = "이젠 더 이상 볼 수 없어..";
            Customer_PerfumeOrder[6] = "그 조그만 아이가 얼마나 아팠는지 생각하면...";
            Customer_PerfumeOrder[7] = "생각조차 힘들어서 눈물이 나...";
            Customer_PerfumeOrder[8] = "제발 나비를 한 번만이라도 만날 수 있게 해줘...";

            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "향은 너무 진하지도... 너무 은은하지도 않게 해줘...";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "동물";
            Customer_Flavoring[1] = "반려동물";
            Customer_Flavoring[2] = "슬픔";

            Customer_RejectReaction[0] = "...나한테 대체 왜 그래요?";
            Customer_RejectReaction[1] = "단 한 번만 나비를 만나는 것도 안 되는 거야?";
            Customer_RejectReaction[2] = "내가 이렇게까지 했는데...";
            Customer_RejectReaction[3] = "다른 사람들한테도 말할 거야";
            Customer_RejectReaction[4] = "후회하지 마. 당신이 한 선택이잖아.";


            for (int i = 5; i < Customer_RejectReaction.Length; i++)
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
                    Customer_PerfumeReaction[0] = "고마워요...";
                    Customer_PerfumeReaction[1] = "이렇게라도 나비를 볼 수 있어서...";
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

                else
                {
                    Customer_PerfumeReaction[0] = "이 향이 아닌데요..?";
                    Customer_PerfumeReaction[1] = "뭘 만든 거죠..? ";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
}
