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

    public void Start()
    {
        for (int i = 0; i < CriminalNum.Length; i++)
        {
            CriminalNum[i] = Random.Range(1, 6);
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
    public void DeclarationClick()
    {
        if (GameObject.Find("RC").GetComponent<CriminalImage>().isCriminal == true)
        {
            Debug.Log("검거 성공");
            DailyResult.transform.GetChild(8).GetComponent<Image>().sprite = Success;
        }
        else if (GameObject.Find("RC").GetComponent<CriminalImage>().isCriminal == false)
        {
            Debug.Log("검거 실패");
            DailyResult.transform.GetChild(8).GetComponent<Image>().sprite = Fail;
        }
        isDeclareClick = true;
        Declaration.SetActive(false);
    }
}
