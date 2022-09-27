using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDialogueScript : MonoBehaviour
{
    public GameObject Distiller;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[9];//한 날짜에 오는 손님의 아이디 (손님 수만큼 할당)
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
            Customer_ID[i] = Random.Range(3001, 3010);
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
        if (Customer_ID[0] == 3001)
        {
            Customer_Name = "C";

            Customer_PerfumeOrder[0] = "저기..";
            Customer_PerfumeOrder[1] = "나 도와주고 싶은 친구가 있어..";
            Customer_PerfumeOrder[2] = "친구가 괴롭힘당하지만 아무 것도 못 하고 있어..";
            Customer_PerfumeOrder[3] = "내가 조금만 더 용기를 내면 괜찮을까..?";
            Customer_PerfumeOrder[4] = "조금이라도 달라질까..?";
            Customer_PerfumeOrder[5] = "그 친구만 생각하면 너무 미안하구..";
            Customer_PerfumeOrder[6] = "내가 그 친구를 도와줄 수 있을까..?";

            for (int i = 7; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "내가 힘낼 수 있도록 향은 적당히 조절해줘…  ";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "보통";

            Customer_Flavoring[0] = "인간";
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
                    Customer_PerfumeReaction[0] = "이 정도면 괜찮은 거 같아..! ";

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
                    Customer_PerfumeReaction[0] = "일부로 이런 거야…?";
                    Customer_PerfumeReaction[1] = "이러지 않아도 됐잖아...";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
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

        if (Customer_ID[0] == 3002)
        {
            Customer_Name = "G";

            Customer_PerfumeOrder[0] = "저희 강아지가...무지개다리를 건넜어요...";
            Customer_PerfumeOrder[1] = "매일 아침 눈을 뜨면, 둥이가 없어서 미칠 것 같아요..";
            Customer_PerfumeOrder[2] = "그게 뭐가 힘들다고... 산책도 못 가줬는데..";
            Customer_PerfumeOrder[3] = "더 잘해주지 못해서 너무 미안한데… ";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "둥이랑 같이 덮고 자던 이불에 뿌릴 거예요...";
            Customer_IntensityOrder[1] = "그 이불에서만큼은 둥이를 느낄 수 있게..";
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
            Customer_RejectReaction[1] = "그쪽은 반려견을 키워 본 경험이 없나보죠?";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "둥이야… 이 냄새가 너무 너무 그리웠어.. ";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "이 냄새가 그리웠어.. ";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "이렇게 못 만드는 것도 재주다. 재주";

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
                    Customer_PerfumeReaction[0] = "향이 없는데 뭘 맡으란 거야? ";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
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

        if (Customer_ID[0] == 3003)
        {
            Customer_Name = "I";

            Customer_PerfumeOrder[0] = "안녕하신가..";
            Customer_PerfumeOrder[1] = "내 죽은 친구 놈이 보고 싶구만..";
            Customer_PerfumeOrder[2] = "그때 가지 말라고 말렸어야 했는데 말이야..";
            Customer_PerfumeOrder[3] = "빌어먹을.. 그놈이 사고에 휘말렸어..";
            Customer_PerfumeOrder[4] = "제기랄.. 내 탓이지 뭐..";
            Customer_PerfumeOrder[5] = "혹시 향수 하나만 만들어줄 수 있는가?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "그 친구 향이 영원히 지속됐으면 좋겠군…";
            Customer_IntensityOrder[1] = "내가 감히 이래도 되는 걸까..?";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "친구";
            Customer_Flavoring[2] = "죄책감";

            Customer_RejectReaction[0] = "젠장.. 내가 당신한테 뭘 잘못했지..?";
            Customer_RejectReaction[1] = "오늘도 개 같은 하루구만..";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "내가...정말...";
                    Customer_PerfumeReaction[1] = "정말...";
                    Customer_PerfumeReaction[2] = "......";

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
                    Customer_PerfumeReaction[1] = "형편없구만 ";

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
                    Customer_PerfumeReaction[0] = "지금 장난하는건가?";
                    Customer_PerfumeReaction[1] = "향이 안 느껴지는데 뭐 어떡하라는 거야?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "내가 우습나?";
                    Customer_PerfumeReaction[1] = "이럴 거면 때려치우게 ";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3004)
        {
            Customer_Name = "E";

            Customer_PerfumeOrder[0] = "...저기.. 요?";
            Customer_PerfumeOrder[1] = "....제발 내 사랑을 다시 한번만이라도 보고 싶어... ";
            Customer_PerfumeOrder[2] = "내가 이렇게 좋아하는데.. 대체 어떻게 지내고 있는거야..?";
            Customer_PerfumeOrder[3] = "내가 사랑하는 그녀가 미치도록 보고 싶어..";
            Customer_PerfumeOrder[4] = "이런 나를 좀 도와주지 않을래..?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "향은 절대 빠지지 않도록 강하게 해주세요...";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "강함";

            Customer_Flavoring[0] = "인간";
            Customer_Flavoring[1] = "연인";
            Customer_Flavoring[2] = "사랑";

            Customer_RejectReaction[0] = "...나한테 대체 왜 그래요?";
            Customer_RejectReaction[1] = "당신만큼은 그러면 안 되잖아";
            Customer_RejectReaction[2] = "다른 사람들한테도 말할 거야";
            Customer_RejectReaction[3] = "후회하지 마 당신이 한 선택이잖아?";

            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "이것이 바로 그녀의 향..";
                    Customer_PerfumeReaction[1] = "정말 감사합니다.. 정말로…  ";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "고마워요… ";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "너무 못 만든거 아닌가요..?";
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
                    Customer_PerfumeReaction[1] = "아무 것도 느껴지지 않아요..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "이건 내가 맡고 싶은 향이 아니에요..";
                    Customer_PerfumeReaction[1] = "정말 최악이네요..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3005)
        {
            Customer_Name = "";

            Customer_PerfumeOrder[0] = "";
            Customer_PerfumeOrder[1] = "";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "";
            Customer_PerfumeOrder[4] = "";
            Customer_PerfumeOrder[5] = "";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "";
            Customer_IntensityOrder[1] = "";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "";
            Customer_Flavoring[1] = "";
            Customer_Flavoring[2] = "";

            Customer_RejectReaction[0] = "";
            Customer_RejectReaction[1] = "";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

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
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3006)
        {
            Customer_Name = "";

            Customer_PerfumeOrder[0] = "";
            Customer_PerfumeOrder[1] = "";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "";
            Customer_PerfumeOrder[4] = "";
            Customer_PerfumeOrder[5] = "";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "";
            Customer_IntensityOrder[1] = "";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "";
            Customer_Flavoring[1] = "";
            Customer_Flavoring[2] = "";

            Customer_RejectReaction[0] = "";
            Customer_RejectReaction[1] = "";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

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
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3007)
        {
            Customer_Name = "";

            Customer_PerfumeOrder[0] = "";
            Customer_PerfumeOrder[1] = "";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "";
            Customer_PerfumeOrder[4] = "";
            Customer_PerfumeOrder[5] = "";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "";
            Customer_IntensityOrder[1] = "";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "";
            Customer_Flavoring[1] = "";
            Customer_Flavoring[2] = "";

            Customer_RejectReaction[0] = "";
            Customer_RejectReaction[1] = "";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

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
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3008)
        {
            Customer_Name = "";

            Customer_PerfumeOrder[0] = "";
            Customer_PerfumeOrder[1] = "";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "";
            Customer_PerfumeOrder[4] = "";
            Customer_PerfumeOrder[5] = "";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "";
            Customer_IntensityOrder[1] = "";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "";
            Customer_Flavoring[1] = "";
            Customer_Flavoring[2] = "";

            Customer_RejectReaction[0] = "";
            Customer_RejectReaction[1] = "";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

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
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        if (Customer_ID[0] == 3009)
        {
            Customer_Name = "";

            Customer_PerfumeOrder[0] = "";
            Customer_PerfumeOrder[1] = "";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "";
            Customer_PerfumeOrder[4] = "";
            Customer_PerfumeOrder[5] = "";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "";
            Customer_IntensityOrder[1] = "";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "약함";

            Customer_Flavoring[0] = "";
            Customer_Flavoring[1] = "";
            Customer_Flavoring[2] = "";

            Customer_RejectReaction[0] = "";
            Customer_RejectReaction[1] = "";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//베미탑 모두 올바른 향료 사용한 경우 -> 평판 보고 판단
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "";

                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

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
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if(TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    Customer_PerfumeReaction[0] = "";
                    Customer_PerfumeReaction[1] = "";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
}
