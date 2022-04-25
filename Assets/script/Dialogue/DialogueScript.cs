using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    public string[] Dialogue_A = new string[3];
    public string[] Dialogue_B = new string[3];
    public string[] Dialogue_C_1 = new string[3];
    public string[] Dialogue_C_2 = new string[3];
    public string[] Dialogue_D_1 = new string[3];
    public string[] Dialogue_D_2 = new string[3];

    public string[] Dialogue_E_1 = new string[4];
    public string[] Dialogue_E_2 = new string[3];
    public string[] Dialogue_E_3 = new string[3];

    public Sprite[] customerSprites = new Sprite[3];//손님 이미지 배열
    public void Start()
    {
        //손님 : 입장 멘트
        Dialogue_A[0] = "안녕하세요.";
        Dialogue_A[1] = "저기요..?";
        Dialogue_A[2] = "향수좀 만들 수 있을까요?";

        //손님 : 향수 구매 이유
        Dialogue_B[0] = "제가 사랑했던 그의 향이 맡고 싶어요...";
        Dialogue_B[1] = "어렸을 때 자주 갔던 놀이공원에 대한 기억을 찾아주세요..";
        Dialogue_B[2] = "무지개 다리를 건넌 강아지를 생각하면 너무 슬퍼요..";
       // Dialogue_B[3] = "저에게는 가족만큼 소중했거든요..";

        //유저 : '예' 선택한 경우
        Dialogue_C_1[0] = "향의 세기는 어느 정도로 해드릴까요?";
        Dialogue_C_1[1] = "향은 어느 정도로 해드릴까요?";
        Dialogue_C_1[2] = "생각하신 향의 세기가 있을까요?";

        //유저 : '아니오' 선택한 경우
        Dialogue_C_2[0] = "죄송합니다. 손님에게 판매할 수 없어요.";
        Dialogue_C_2[1] = "죄송합니다. 손님에게 향수를 만들어줄 수 없어요.";
        Dialogue_C_2[2] = "죄송합니다. 손님의 향수는 만들 수 없어요.";

        //손님 : C_1 이후 대답. 향의 세기 선정
        Dialogue_D_1[0] = "아주 강렬하게 해주세요..";
        Dialogue_D_1[1] = "적당히 해주세요. \n너무 강하면 미쳐버릴지도..";
        Dialogue_D_1[2] = "아주 약하게 해주세요..";

        //손님 : C_2 이후 대답. D_2 이후 다시 A로 돌아감.
        Dialogue_D_2[0] = "대체 왜죠? 그럴 거면 가게를 하지 말든가..";
        Dialogue_D_2[1] = "정말 별로네요.";
        Dialogue_D_2[2] = "아무런 이유도 없이 거부하는 건 정말 너무하네요.";

        //향수 판매했을 때 평판이 Very Good or Good 인 경우
        Dialogue_E_1[0] = "당장이라도 내 눈에 보이는 것만 같아요..";
        Dialogue_E_1[1] = "고맙습니다… 정말 고맙습니다..";
        Dialogue_E_1[2] = "정말 좋은 향이네요..";
        Dialogue_E_1[3] = "조금만 더 빨리 올걸… \n감사합니다..";

        //향수 판매했을 때 평판이 Normal 인 경우
        Dialogue_E_2[0] = "그럭저럭 괜찮네요.";
        Dialogue_E_2[1] = "이만하면 괜찮은 거 같아요.\n고마워요";
        Dialogue_E_2[2] = "조금 아쉽지만, 어쩔 수 없겠죠.";

        //향수 판매했을 때 평판이 Bad or Very Bad 인 경우
        Dialogue_E_3[0] = "이걸 향수라고 부를 수 있나요..?";
        Dialogue_E_3[1] = "여기 오기까지 얼마나 힘들었는데 이런 향수를 사다니..\n돈이 아깝네요";
        Dialogue_E_3[2] = "이건 내가 찾던 향이 아닌데… ";


    }
}
