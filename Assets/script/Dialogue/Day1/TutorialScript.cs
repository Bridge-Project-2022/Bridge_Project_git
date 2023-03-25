using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public string[] tutStart = new string[16];
    public string[] tutStore = new string[19];
    public string[] tutBuy = new string[19];
    public string[] tutCreate = new string[47];
    public string[] tutResult = new string[11];

    public void Update()
    {
        tutStart[0] = "호오, 자네가 이 향수 가게를 물려받은 새 주인장인가?"; tutStart[1] = "반갑네. 앞으로 자주 볼 얼굴이니 악수나 한번 하지."; tutStart[2] = "... ... ...	"; tutStart[3] = "내가 누구냐고?"; tutStart[4] = "허허, 이것 참. 소개가 늦었군.";
        tutStart[5] = "앞으로 자네에게 필요한 모든 향료를 가져다줄 보부상이라고나 해둘까."; tutStart[6] = "...으흠, 여전히 아리송한 표정이군."; tutStart[7] = "보아하니 신참이라 아직 가게 운영이 익숙지 않은 모양이야."; tutStart[8] = "첫 날이니 내 오늘 하루만 도와주도록 하겠네."; tutStart[9] = "어디서부터 설명을 하면 좋을까... 그래, 자네는 앞으로 향수를 만들어 손님에게 판매해야 한다는 건 알고 있겠지.";
        tutStart[10] = "그것도 향을 통해 손님의 추억을 되살리는, 매우 특별한 향수 말이네."; tutStart[11] = "자, 그런 특별한 향수를 만들기 위해서는 당연히 특별한 향료가 필요하지 않겠는가?"; tutStart[12] = "나를 통해 그 향료들을 구매할 수 있다는 말일세."; tutStart[13] = "그럼, 오늘 들어온 향료를 좀 구경해볼텐가?";

        tutStore[0] = "알고 있다면 더 설명하지 않도록 하겠네. 자네는 향료의 분류나 향료를 구매하는 방법에 대해 알고 있나?"; tutStore[1] = "그렇다면 이 또한 간단히 설명하도록 하지."; tutStore[2] = "향수를 만들기 위해서는 베이스 노트, 미들 노트, 탑 노트, 이 세 노트 각각에 맞는 향료를 재료로 써야 하네."; tutStore[3] = "각 노트마다 향료가 하나씩 필요하므로, 하나의 향수에는 총 3가지 향료가 쓰인다고 볼 수 있지."; tutStore[4] = "자아, 먼저 베이스 노트는 주로 손님이 추억하고자 하는 대상을 표현한다네."; 
        tutStore[5] = "가령 사람, 동물, 물건, 심지어는 장소까지. 그 대상이 무엇이든지 말이야."; tutStore[6] = "다음으로 미들 노트는 손님과 손님이 추억하는 대상의 관계, 혹은 그 안에서의 분류를 표현하곤 하지."; tutStore[7] = "둘은 친구였을 수도, 연인이었을 수도, 가족이었을 수도 있을 걸세."; tutStore[8] = "이따금 반려동물을 추억하는 이들도 있기 마련이고,"; tutStore[9] = "장소의 경우에는 그 장소가 어떤 곳이었는지를 말하기도 하네."; 
        tutStore[10] = "마지막으로 탑 노트는 추억의 대상을 향한 손님의 감정을 드러낸다네."; tutStore[11] = "그것은 행복이나 사랑과 같이 더없이 긍정적인 감정이 될 수도 있고,"; tutStore[12] = "슬픔이나 죄책감과도 같은, 일종의 미련과도 같은 감정이 될 수도 있다네."; tutStore[13] = "이 모든 것을 판단하는 것은 주인장인 자네의 몫이야."; tutStore[14] = "부디 손님들의 이야기를 귀 기울여 들은 뒤, 그들의 추억을 온전히 향수로 담아주게나."; 
        tutStore[15] = "다시 본론으로 돌아와볼까. 구매 방법은 두 가지 중에서 편한대로 선택하게."; tutStore[16] = "각각의 향료를 눌러서 개별적으로 구매를 하거나,"; tutStore[17] = "어느 노트의 향료를 일괄적으로 구매하거나. 자네의 자유야.";

        tutBuy[0] = "그럼 실전으로 들어가볼까?"; tutBuy[1] = "오늘은 향수 5개는 충분히 만들 수 있도록, 향료를 넉넉히 구매를 해보게나."; tutBuy[2] = "손님이 무얼 바랄지 모르니 모든 향료를 빠짐 없이, 골고루 사보도록 하고."; tutBuy[3] = "편하게 향료를 둘러보게."; tutBuy[4] = ""; 
        tutBuy[5] = "훌륭하군. 앞으로도 이와 비슷하게 구매하면 되네."; tutBuy[6] = ""; tutBuy[7] = "좋아, 향료는 다 구매했으니 손님 응대하는 법을 알려주겠네."; tutBuy[8] = "나를 손님으로 생각하고 맞아보게나."; tutBuy[9] = "어디 보자..."; 
        tutBuy[10] = "나는 향료를 구하는 여정 중에 만났던 작은 산새 하나가 떠오르는군. 우연한 계기로 여정을 함께 하게 됐었다네."; tutBuy[11] = "그 조그만 새와 함께 있다보면 꽤 기뻤어. 콩 한쪽도 나누어 먹었지, 허허. 지금은 어찌 지내는지 궁금하구만."; tutBuy[12] = "아무튼, 부디 그 때의 기억을 언제고 다시 추억할 수 있게끔 해주게나."; tutBuy[13] = "아, 향은 강한 편이 좋겠어. 나의 기억만큼 진한 향 말이야."; tutBuy[14] = "허허, 물론 자네가 주인장이니 원한다면 그 어느 손님이든 주문을 거절할 수도 있다만..."; 
        tutBuy[15] = "지금은 연습이니 내 주문을 승낙한 것으로 치고 넘어가겠네."; tutBuy[16] = "";  tutBuy[17] = "여긴 자네가 향수를 만들 제작대라네. 자주 보게 될테니 익숙해지도록 하게나."; tutBuy[18] = "향수 만드는 방법을 알고 있다면 역시나 설명하지 않고 넘어가겠네. 자네는 향수 제조 과정을 알고 있는가?";

        tutCreate[0] = "그렇다면 이 또한 설명해주도록 하지."; tutCreate[1] = "여기, 이 상자는 자네가 구매한 향료를 보관한 곳이라네."; tutCreate[2] = "이곳에서 손님의 주문에 맞는 향료를 선택한 후, 노트에 맞게끔 총 3개의 제조 과정을 거치면 되지."; tutCreate[3] = "혹시라도 주문이 기억나지 않는다면 안심하게나, 이곳에서 다시 볼 수 있으니."; tutCreate[4] = "그럼 베이스 노트부터 골라볼까.";
        tutCreate[5] = "베이스 노트의 향료는 끓이는 과정을 거쳐 향을 추출할 수 있다네."; tutCreate[6] = "때문에 '증류기'를 사용해야만 해."; tutCreate[7] = "또 내 주문과 같은 경우에는 어느 한 '동물'을 추억하는 것이었으므로 그에 해당하는 향료를 써야겠지."; tutCreate[8] = "자아, '동물'에 해당하는 향료를 선택해보게."; tutCreate[9] = "옳지. 혹시라도 향료를 다른 것으로 바꾸고 싶다면 여길 눌러 다시 선택하면 된다네."; 
        tutCreate[10] = "이제 향료를 들고 증류기 쪽으로 와보게나.";tutCreate[11] = "증류기를 다루는 법은 쉬워. 여기, 이 아이를 지속적으로 클릭하면 불이 점점 세진다네."; tutCreate[12] = "불을 클릭하지 않고 가만히 있으면 다시 불은 약해지거나, 심지어는 꺼질 수 있는 것 또한 기억하게."; tutCreate[13] = "불이 셀수록 향료에서 추출되는 향도 강해지지. 이는 손님이 원하는 향의 강도에 맞춰주도록 해."; tutCreate[14] = "가령, 적당한 강도의 향을 원한다고 하면 중불의 세기를 유지해야겠지."; 
        tutCreate[15] = "그럼 자네가 한번 증류기로 향을 추출해보게나."; tutCreate[16] = "다시금 알려주자면, 나는 강하고 진한 향을 원했네.";tutCreate[17] = ""; tutCreate[18] = "좋아, 멀리 떨어져 있어도 이 정도의 향은 단번에 알아차리겠어. 잘 했네."; tutCreate[19] = "다음으론 미들 노트의 향료를 다뤄볼 차례겠지?"; tutCreate[20] = "미들 노트의 향료는 대체로 건조하고 단단하기 때문에 이를 가루로 만들어야 해."; 
        tutCreate[21] = "그러므로 '압착기'를 거쳐야 한다네. ...우선 향료를 골라보지."; tutCreate[22] = "산새, 라는 건 아무래도 반려동물로 분류가 되겠지. 그러니 그에 맞는 향료를 골라주게나."; tutCreate[23] = "잘했네, 이제 압착기 쪽으로 오도록 하게."; tutCreate[24] = "압착 과정은 이 아이가 도와줄걸세."; tutCreate[25] = "자네가 여기, 리듬에 맞추어 오른쪽, 또는 왼쪽을 알맞게 지시하면 그대로 이행하는 것이지."; 
        tutCreate[26] = "좌우 방향키(←→), 또는 왼쪽과 오른쪽 화면을 클릭하는 것으로 지시를 하면 돼."; tutCreate[27] = "방법은 편한대로 하게. 허나 제대로 빻지 않으면 향이 지나치게 약하게 우러나올테니 주의하게나."; tutCreate[28] = "그럼, 한번 해보겠는가?"; tutCreate[29] = ""; tutCreate[30] = "오호, 솜씨가 상당한데? 완성될 향이 기대되는군."; tutCreate[31] = "마지막은 탑 노트라네. 다시 이리로 와보게나."; 
        tutCreate[32] = "탑 노트의 향료는 주로 향유를 만드는 냉침 과정을 거친다네. 말에서도 알 수 있듯 '냉침기'를 사용하지."; tutCreate[33] = "이 노트의 향료들은 손님의 감정을 드러낸다는 것을 기억하는가?"; tutCreate[34] = "나는 그 작은 아이와 함께할 때에 '기쁨'을 느꼈다는걸 기억해보며, 어디 향료를 골라보게나."; tutCreate[35] = "잘했네. 이제 마지막 과정만 남았으니 힘내도록 하게."; tutCreate[36] = "냉침기를 통해 향을 추출하는 법은 간단하네."; 
        tutCreate[37] = "적절한 시간이 되면 향료를 냉침기에서 들어올리기만 하면 되지."; tutCreate[38] = "아마 척 보자마자 이 향료가 준비가 되었는지, 안되었는지 알 수 있을 걸세."; tutCreate[39] = "너무 일찍, 혹은 너무 늦게 꺼낸 향료는 제대로 된 향을 내지 않으니 하나하나 조심히 들어올리게나."; tutCreate[40] = "그럼 실전으로 들어가지. 자아, 유심히 관찰해보도록 하게."; tutCreate[41] = ""; tutCreate[42] = "완벽해, 이제 냉침기는 마스터했다고 봐도 되겠군."; 
        tutCreate[43] = "자아, 세 과정을 거쳤으니 이제 향수는 완성이 되었다네."; tutCreate[44] = "정말이지 그 아이에 대한 기억이 또렷이 떠오르는, 아주 훌륭한 향수군."; tutCreate[45] = "완성한 향수를 손님에게 전달하려면 여기, 향수병을 클릭하게나."; tutCreate[46] = "아, 마지막으로 하나 더. 완성 이전에 향수를 클릭한다면 그 때에도 곧바로 손님에게 전달될테니 조심하게.";

        tutResult[0] = "그럼 이만 마무리 짓도록 하지. 허허, 이제 진정한 가게 주인장 같군."; tutResult[1] = "손님이 완성된 향수를 받게 되면 추억에 대한 향수의 정확성과 과정의 완성도에 맞는 보상을 줄 걸세."; tutResult[2] = "한편, 향수를 엉망으로 만든다면 가게의 평판이 함께 나빠질 수 있으니 주의하게나."; tutResult[3] = "물론, 손님 응대를 전혀 하지 않고 내보내는 경우에도 비슷하게 나쁜 평을 들을 걸세."; tutResult[4] = "가게의 평판이 안 좋아지면... 흐음, 아마 자네의 가게 상황도 따라 어려워지겠지?";
        tutResult[5] = "되도록 좋은 평판을 유지해보게나."; tutResult[6] = "마지막으로 하나 더 팁을 알려주자면, 하루의 영업을 마무리한 후 그 날을 다시 되돌아보는 시간을 꼭 가지게나."; tutResult[7] = "손님은 얼마나 왔는지, 매출은 어떤지, 그런 것들을 돌이켜보며 가게 운영에 더 힘써보게."; tutResult[8] = "허허, 아마 자네 스스로도 잘 할테니 늙은이의 괜한 참견일지도 모르겠지만 말이야."; tutResult[9] = "그럼 이만 참견은 그만두고 물러나도록 하겠네.";
        tutResult[10] = "내일 이 시간에 또 보도록 하지, 주인장.";

    }

}
