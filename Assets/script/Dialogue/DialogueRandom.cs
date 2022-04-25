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

    public GameObject Distiller;
    public GameObject Presser;
    public GameObject Cooler;

    public TextMeshProUGUI BuyerDialogue;
    public TextMeshProUGUI SellerDialogue;

    private SpriteRenderer spriteRenderer;

    public bool makeStart = false;

    public GameObject arrow;

    public int rejectCnt = 0;//���� Ƚ�� -> ���� ����, ���� ���� �� ���� ���µǾ�� ��.

    int A_random;
    int B_random;
    int C_1_random;
    int C_2_random;
    int D_1_random;
    int D_2_random;
    int E_1_random;
    int E_2_random;
    int E_3_random;

    int Sprite_random;

    public string[] BuyerSentences = new string[7];// �մ� ��ȭ �迭
    public string[] SellerSentences = new string[2];// ���� ��ȭ �迭

    public DialogueScript DS;
    public void RandomDialogue()// ���� �Լ�(��ȭ, �̹��� ����)
    {
        A_random = Random.Range(0, DS.Dialogue_A.Length);
        B_random = Random.Range(0, DS.Dialogue_B.Length);
        C_1_random = Random.Range(0, DS.Dialogue_C_1.Length);
        C_2_random = Random.Range(0, DS.Dialogue_C_2.Length);
        D_1_random = Random.Range(0, DS.Dialogue_D_1.Length);
        D_2_random = Random.Range(0, DS.Dialogue_D_2.Length);
        E_1_random = Random.Range(0, DS.Dialogue_E_1.Length);
        E_2_random = Random.Range(0, DS.Dialogue_E_2.Length);
        E_3_random = Random.Range(0, DS.Dialogue_E_3.Length);

        Sprite_random = Random.Range(0, DS.customerSprites.Length);

        BuyerSentences[0] = DS.Dialogue_A[A_random];
        BuyerSentences[1] = DS.Dialogue_B[B_random];
        BuyerSentences[2] = DS.Dialogue_D_1[D_1_random];
        BuyerSentences[3] = DS.Dialogue_D_2[D_2_random];
        BuyerSentences[4] = DS.Dialogue_E_1[E_1_random];
        BuyerSentences[5] = DS.Dialogue_E_2[E_2_random];
        BuyerSentences[6] = DS.Dialogue_E_3[E_3_random];



        SellerSentences[0] = DS.Dialogue_C_1[C_1_random];
        SellerSentences[1] = DS.Dialogue_C_2[C_2_random];

    }

    public void A_Start()//�մ� : ����, ���⼭ �մ� �̹��� ���� ����
    {
        RandomDialogue();
        Customer.GetComponent<SpriteRenderer>().sprite = DS.customerSprites[Sprite_random];
        Customer.gameObject.SetActive(true);
        Buyer.gameObject.SetActive(true);
        StartCoroutine(NormalChat(BuyerSentences[0]));
        Invoke("B_Start", 2f);
    }
    public void B_Start()//�մ� : ��� ���� ���� ����
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[1]));
        Select.SetActive(true);
    }
    public void C_1_Start()// ���� : �³� - �� ���� ����
    {
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[0]));
        Invoke("D_1_Start", 2f);
    }

    public void C_2_Start()//���� : �ź� - �ź� ���� ����
    {
        rejectCnt += 1;
        if(rejectCnt == 1)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 8;
        else if (rejectCnt == 2)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
        if (rejectCnt >= 3)
            FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
        Select.SetActive(false);
        RandomDialogue();
        Buyer.gameObject.SetActive(false);
        Seller.gameObject.SetActive(true);
        StartCoroutine(NormalChat(SellerSentences[1]));
        Invoke("D_2_Start", 2f);
    }

    public void D_1_Start()//�մ� : �³� - �� ���� ����
    {
        Buyer.gameObject.SetActive(true);
        Seller.gameObject.SetActive(false);
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[2]));
        arrow.gameObject.SetActive(true);
        makeStart = true;

    }

    public void D_2_Start()// �մ� : �ź� - �Ҹ� ǥ��
    {
        Seller.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(true);
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[3]));
        Invoke("End", 2f);
    }

    public void E_1_Start()//�մ� : ��� ���� GOOD�� ��� 
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[4]));
        Invoke("End", 2f);
    }

    public void E_2_Start()//�մ� : ��� ���� NORMAL�� ���
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[5]));
        Invoke("End", 2f);
    }

    public void E_3_Start()//�մ� : ��� ���� BAD�� ���
    {
        RandomDialogue();
        StartCoroutine(NormalChat(BuyerSentences[6]));
        Invoke("End", 2f);
    }
    public void End()
    {
        Customer.gameObject.SetActive(false);
        Buyer.gameObject.SetActive(false);
        Invoke("A_Start", 5f);//�մ� ���� 5�� �ڿ� ���� �մ� ����. �ΰ��� �ð� ���� �߰� ���ǹ� �޾ƾ� ��
    }

    IEnumerator NormalChat(string narration)// Ÿ���� ȿ�� -> ���⼭ ���� ���⿡ ���� ������ ���� ���� ����
    {
        if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_D_1[0])
        {
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_D_1[1])
        {
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_D_1[2])
        {
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";
        }

        if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[0])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "�ΰ�";
            Presser.GetComponent<Presser>().MiddleItemName = "����";
            Cooler.GetComponent<Cooler>().TopItemName = "���";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[1])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "���";
            Presser.GetComponent<Presser>().MiddleItemName = "���̰���";
            Cooler.GetComponent<Cooler>().TopItemName = "�ູ";
        }
        else if (narration == DialogueScript.FindObjectOfType<DialogueScript>().Dialogue_B[2])
        {
            Distiller.GetComponent<Distiller>().BaseItemName = "����";
            Presser.GetComponent<Presser>().MiddleItemName = "�ݷ�����";
            Cooler.GetComponent<Cooler>().TopItemName = "����";
        }

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

