using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CriminalSystem : MonoBehaviour
{
    public int[] CriminalNum = new int[5];
    public GameObject DailyResult;
    public GameObject Declaration;

    public Sprite Success;
    public Sprite Fail;

    public bool isDeclareClick = false;
    public Sprite[] GMontageIMG = new Sprite[5];
    public Sprite[] HMontageIMG = new Sprite[5];
    public Sprite[] DMontageIMG = new Sprite[5];
    public Sprite[] CMontageIMG = new Sprite[5];

    public bool isDeclareSuccess = false;
    public bool isCriminalSell = false;
    public void Start()
    {
        for (int i = 0; i < CriminalNum.Length; i++)
        {
            CriminalNum[i] = Random.Range(1, 5);
            for (int j = 0; j < i; j++)
            {
                if (CriminalNum[i] == CriminalNum[j])
                {
                    i--;
                    break;
                }
            }
        }
    }
    public void MontageShow()
    {
        if (NextDay.FindObjectOfType<NextDay>().day == 3)
        {
            if (CriminalNum[0] == 1)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[0];
            }
            if (CriminalNum[0] == 2)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[1];
            }
            if (CriminalNum[0] == 3)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[2];
            }
            if (CriminalNum[0] == 4)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[3];
            }
        }

        if (NextDay.FindObjectOfType<NextDay>().day == 4)
        {
            if (CriminalNum[0] == 1)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[0];
            }
            if (CriminalNum[0] == 2)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[1];
            }
            if (CriminalNum[0] == 3)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[2];
            }
            if (CriminalNum[0] == 4)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[3];
            }
        }

        if (NextDay.FindObjectOfType<NextDay>().day == 5)
        {
            if (CriminalNum[0] == 1)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[0];
            }
            if (CriminalNum[0] == 2)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[1];
            }
            if (CriminalNum[0] == 3)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[2];
            }
            if (CriminalNum[0] == 4)
            {
                GameObject.Find("Panels").transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = GMontageIMG[3];
            }
        }
    }
    public void DeclarationClick()
    {
        if (GameObject.Find("RC").GetComponent<CriminalImage>().isCriminal == true)
        {
            Debug.Log("검거 성공");
            DailyResult.transform.GetChild(8).GetComponent<Image>().sprite = Success;
            isDeclareSuccess = true;
        }
        else if (GameObject.Find("RC").GetComponent<CriminalImage>().isCriminal == false)
        {
            Debug.Log("검거 실패");
            DailyResult.transform.GetChild(8).GetComponent<Image>().sprite = Fail;
            isDeclareSuccess = false;
        }
        isDeclareClick = true;
        Declaration.SetActive(false);
    }

    public void CriminalDailyResult()
    {
        if (isDeclareSuccess == false)//신고 실패한 경우
        {
            if (isDeclareClick == true)//일반 손님 신고한 경우 - 10 차감
            {
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 10;
            }
            if (isDeclareClick == false)//끝까지 신고 버튼 못누른 경우 - 15 차감
            {
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 15;
            }
        }
        if (isDeclareSuccess == true)//범죄자 신고 성공한 경우
        {
            if (isDeclareClick == true && isCriminalSell == true)//신고는 했는데 판매 승낙한 경우 - 평판 5 차감
            {
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation -= 5;
            }
            if (isDeclareClick == false && isCriminalSell == false)//신고 성공하고 향수 판매도 안한 경우 - 평판 10 가산
            {
                FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation += 10;
            }
        }   
    }
}
