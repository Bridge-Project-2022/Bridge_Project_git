using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueRandom : MonoBehaviour
{
    public GameObject Seller;
    public GameObject Buyer;
    public GameObject Select;

    public GameObject Customer;

    public TextMeshProUGUI BuyerDialogue;
    public TextMeshProUGUI SellerDialogue;

    private SpriteRenderer spriteRenderer;

    public bool makeStart = false;

    public GameObject arrow;

    int A_random;
    int B_random;
    int C_1_random;
    int C_2_random;
    int D_1_random;
    int D_2_random;
    int Sprite_random;

    public string[] BuyerSentences = new string[4];// 손님 대화 배열
    public string[] SellerSentences = new string[2];// 유저 대화 배열

    public DialogueScript DS;
    public void RandomDialogue()// 랜덤 함수(대화, 이미지 랜덤)
    {
        A_random = Random.Range(0, DS.Dialogue_A.Length);
        B_random = Random.Range(0, DS.Dialogue_B.Length);
        C_1_random = Random.Range(0, DS.Dialogue_C_1.Length);
        C_2_random = Random.Range(0, DS.Dialogue_C_2.Length);
        D_1_random = Random.Range(0, DS.Dialogue_D_1.Length);
        D_2_random = Random.Range(0, DS.Dialogue_D_2.Length);

        Sprite_random = Random.Range(0, DS.customerSprites.Length);

        BuyerSentences[0] = DS.Dialogue_A[A_random];
        BuyerSentences[1] = DS.Dialogue_B[B_random];
        BuyerSentences[2] = DS.Dialogue_D_1[D_1_random];
        BuyerSentences[3] = DS.Dialogue_D_2[D_2_random];

        SellerSentences[0] = DS.Dialogue_C_1[C_1_random];
        SellerSentences[1] = DS.Dialogue_C_2[C_2_random];

    }

    public void A_Start()//손님 : 입장, 여기서 손님 이미지 랜덤 제공
    {
        RandomDialogue();
        Customer.GetComponent<SpriteRenderer>().sprite = DS.customerSprites[Sprite_random];
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);
        StartCoroutine(NormalChat(BuyerSentences[0]));
        Invoke("B_Start", 2f);
    }
    public void B_Start()//손님 : 향수 구매 이유 제시
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[1]));
        Select.SetActive(true);
    }
    public void C_1_Start()// 유저 : 승낙 - 향 세기 질문
    {
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 2f);
    }

    public void C_2_Start()//유저 : 거부 - 거부 이유 제시
    {
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 2f);
    }

    public void D_1_Start()//손님 : 승낙 - 향 세기 결정
    {
        Buyer.gameObject.SetActive(true);
        Seller.gameObject.SetActive(false);
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[2]));
        arrow.gameObject.SetActive(true);
        makeStart = true;

    }

    public void D_2_Start()// 손님 : 거부 - 불만 표출
    {
        Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[3]));
        Invoke("End", 2f);
    }
    public void End()
    {
        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);
        Invoke("A_Start", 5f);//손님 가고 5초 뒤에 다음 손님 등장. 인게임 시간 보고 추가 조건문 달아야 함
    }

    IEnumerator NormalChat(string narration)// 타이핑 효과
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            BuyerDialogue.text = writerText;
            SellerDialogue.text = writerText;
            yield return new WaitForSeconds(0.05f);
            yield return null;
        }
    }
}

