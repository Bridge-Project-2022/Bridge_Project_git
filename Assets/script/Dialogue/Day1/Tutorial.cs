using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI TutCustomerDialogue;
    public TextMeshProUGUI TutDialogue;
    public GameObject SkipSelect;
    public GameObject TutCustomer;
    public GameObject TutorialDialogue;

    public bool isDialogueEnd = false;

    public TutorialScript TS;

    public GameObject BlackPanel;
    public GameObject MaskPanel;
    public GameObject MaskArrow;
    public RectTransform MaskArrowPos;

    bool isTutStart = false;
    bool isTutStore = false;

    int startCnt = 0;
    public int storeCnt = 0;

    public void Update()
    {
        TS = GameObject.Find("TutorialScript").GetComponent<TutorialScript>();
    }

    public void NextTutDialogue()
    {
        if (isTutStart == true)
        {
            if (startCnt == 0)
            {
                StartCoroutine(NormalChat_1(TS.tutStart[0]));
                startCnt++;
            }
            else if(startCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_1(TS.tutStart[startCnt]));
                    startCnt++;
                }

                if (startCnt == 6)
                {
                    this.GetComponent<UIOnOff>().StoreOpen();
                    GameObject.Find("Canvas").transform.GetChild(8).gameObject.GetComponent<Store>().StoreOpen();
                    TutCustomer.SetActive(false);
                    Invoke("StoreDialogue", 1f);
                    BlackPanel.SetActive(true);
                }
            }
        }

        if (isTutStore == true)
        {
            if (storeCnt == 0)
            {
                StartCoroutine(NormalChat_2(TS.tutStore[0]));
                storeCnt++;
            }
            else if (storeCnt != 0)
            {
                if (isDialogueEnd == true)
                {
                    StartCoroutine(NormalChat_2(TS.tutStore[storeCnt]));
                    storeCnt++;
                }
                if (storeCnt == 2)//��ŵ ���� ����
                {
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(true);
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);
                }
                if (storeCnt == 3)
                {
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                    TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
                    MaskPanel.SetActive(true);
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(true);
                    MaskArrow.SetActive(true);
                }
                if (storeCnt == 4)
                {
                    MaskPanel.transform.GetChild(0).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(true);//���̶����� ����ũ Ȱ��ȭ
                    MaskArrowPos.anchoredPosition = new Vector3(-876,66,0);
                    TutorialDialogue.GetComponent<Button>().interactable = false;//���̶����� �κ� Ŭ���ؾ� �ϴµ� ��ȭâ Ŭ���Ǹ� �ȵǹǷ� ��Ȱ��ȭ 
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);// ��ȭ �ѱ�� �ִϸ��̼ǵ� ��Ȱ��ȭ
                    MaskPanel.transform.GetChild(1).GetComponent<Button>().interactable = true;//���̶����� �κ� Ŭ�� �����ϰ� Ȱ��ȭ
                }
                if (storeCnt == 5)
                {
                    MaskArrow.SetActive(false);
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(1);
                    MaskPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                }
                if (storeCnt == 6)
                {
                    MaskPanel.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).gameObject.SetActive(true);
                    MaskArrow.SetActive(true);
                    MaskArrowPos.anchoredPosition = new Vector3(-876, -107, 0);
                    TutorialDialogue.GetComponent<Button>().interactable = false;
                    TutorialDialogue.transform.GetChild(1).gameObject.SetActive(false);
                    MaskPanel.transform.GetChild(2).GetComponent<Button>().interactable = true;
                }
                if (storeCnt == 7)
                {
                    MaskArrow.SetActive(false);
                    GameObject.Find("Store").GetComponent<StoreTab>().ClickTab(2);
                    MaskPanel.transform.GetChild(2).GetComponent<Button>().interactable = false;
                    TutorialDialogue.GetComponent<Button>().interactable = true;
                }
            }
        }
    }
    public void StartDialogue()//��� ������ ���, ����� �� ��� �Ұ�, ���� Ŭ��
    {
        isTutStart = true;
        startCnt = 0;
        NextTutDialogue();
    }

    public void StoreDialogue()//��� ��Ʈ ����. ��ŵ ���� ���� => �� : ���� �Ѿ / �ƴϿ� : ���̽� ���� & �̵��� ���̶�����, �̵� ���� & ž�� ���̶�����, ž ���� & ���̽��� Ŭ������ & ù��° ��� ���� �� ���� / �ϰ����� ����
    {
        isTutStart = false;
        isTutStore = true;
        storeCnt = 0;
        this.transform.GetChild(1).gameObject.SetActive(true);
        NextTutDialogue();
    }

    public void BuyDialogue() // ��� ���� ����, �Ϸ� ���� Ȯ�� -> �Ϸ� �� ���� ����, �մ� �ý��� ����, ���� / ���� ���� �� Ŭ�� ����, ��� ��� ������ ����
    {
        Debug.Log("���� Ʃ�丮��� ����!");
        TutorialDialogue.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void CreateDialogue()//���� ȭ�� �Ѿ. ��ŵ ���� ���� => �� : �������� �Ѿ / �ƴϿ� : �κ� Ŭ�� ����, ���̽� ���� ����, ������ ���� ����, ������ ����, ���� ���� �� �� ���� �ݺ�, ���� �� �絵�� ���, 
                                // �̵� ���� ����, ������ ���� ����, ������ ����, ���� ������ �� ���� �ݺ�, ���� �� �絵�� ���, 
                                // ž ���� ����, ��ħ�� ���� ����, ��ħ�� ����, ��ħ ������ �� ���� �ݺ�, ���� �� �絵�� ���
                                // ���� ȭ�� �ѱ�, �ϼ� ��� ���̶����� �� ���, Ŭ�� ����
    { 
        
    }

    public void ResultDialogue()//��� ����, ����, �̵��� ���� ���� ��, �Ϲ� �ϰ��� �Ѿ
    { 
        
    }

    IEnumerator NormalChat_1(string narration)
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
            {
                isDialogueEnd = true;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
            }

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
            TutCustomerDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }

    IEnumerator NormalChat_2(string narration)
    {
        string writerText = "";
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];

            if (a + 1 == narration.Length)
            {
                isDialogueEnd = true;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                isDialogueEnd = false;
                GameObject.Find("TutorialPanel").transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
            }

            if (narration[a] == ' ')
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
            }
            else
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("typing");
            TutDialogue.text = writerText;
            yield return new WaitForSeconds(0.08f);
            yield return null;

        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().typeStop();
    }
}
