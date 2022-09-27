using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsTime : MonoBehaviour
{

    public int[] randomMontage  = new int[3];
    public string[] randomCriminal = new string[3];

    int randomN1 = 0;
    int randomN2 = 0;
    int randomN3 = 0;

    public int randomNum = 0;

    public string randomResult1 = "";
    public string randomResult2 = "";
    public string randomResult3 = "";

    public void Montage()
    {
        randomNum = Random.Range(2, 4);//머리, 눈, 옷 중에 2개 이상을 골라야 하므로 2개일지 3개일지 고름

        for (int i = 0; i < randomMontage.Length; i++)//중복이 되지 않게 0,1,2를 배열에 랜덤으로 저장
        {
            randomMontage[i] = Random.Range(1, 4);
            for (int j = 0; j < i; j++)
            {
                if (randomMontage[i] == randomMontage[j])
                {
                    i--;
                    break;
                }
            }
        }

        if (randomNum == 2)//2가 나올 경우 머리, 옷, 눈 중에 2개만 바뀜
        {
            Debug.Log("ss");
            randomN1 = randomMontage[0];
            randomN2 = randomMontage[1];
            randomResult3 = "";
        }

        else if (randomNum == 3)//3이 나올 경우 셋 다 바뀜.
        {
            Debug.Log("sss");
            randomN1 = 1;
            randomN2 = 2;
            randomN3 = 3;
        }

        if (randomN1 == 1)
            randomResult1 = "hair";
        if (randomN1 == 2)
            randomResult1 = "eye";
        if (randomN1 == 3)
            randomResult1 = "cloth";
        if (randomN2 == 1)
            randomResult2 = "hair";
        if (randomN2 == 2)
            randomResult2 = "eye";
        if (randomN2 == 3)
            randomResult2 = "cloth";
        if (randomN3 == 1)
            randomResult3 = "hair";
        if (randomN3 == 2)
            randomResult3 = "eye";
        if (randomN3 == 3)
            randomResult3 = "cloth";

        Debug.Log(randomResult1 + " " + randomResult2 + " " + randomResult3);

    }
    private void Start()
    {
        randomNum = Random.Range(2, 4);//머리, 눈, 옷 중에 2개 이상을 골라야 하므로 2개일지 3개일지 고름

        for (int i = 0; i < randomMontage.Length; i++)//중복이 되지 않게 0,1,2를 배열에 랜덤으로 저장
        {
            randomMontage[i] = Random.Range(0, 3);
            for (int j = 0; j < i; j++)
            {
                if (randomMontage[i] == randomMontage[j])
                {
                    i--;
                    break;
                }
            }
        }

        if (randomNum == 2)//2가 나올 경우 머리, 옷, 눈 중에 2개만 바뀜
        {
            randomN1 = randomMontage[0];
            randomN2 = randomMontage[1];
            randomN3 = 3;
        }

        else if (randomNum == 3)//3이 나올 경우 셋 다 바뀜.
        {
            randomN1 = 0;
            randomN2 = 1;
            randomN3 = 2;
        }

        if (randomN1 == 0)
            randomResult1 = "hair";
        if (randomN1 == 1)
            randomResult1 = "eye";
        if (randomN1 == 2)
            randomResult1 = "cloth";
        if (randomN2 == 0)
            randomResult2 = "hair";
        if (randomN2 == 1)
            randomResult2 = "eye";
        if (randomN2 == 2)
            randomResult2 = "cloth";
        if (randomN3 == 0)
            randomResult3 = "hair";
        if (randomN3 == 1)
            randomResult3 = "eye";
        if (randomN3 == 2)
            randomResult3 = "cloth";
        if (randomN3 == 3)
            randomResult3 = "";

        if (randomNum == 2)
        {
            Debug.Log("몽타주 : " + randomResult1 + " 하고 " + randomResult2 + "이 기존과 다릅니다!");
        }
        else
            Debug.Log("몽타주 : " + randomResult1 + " 하고 " + randomResult2 + " 하고 " +randomResult3 + "이 기존과 다릅니다!");
    }
}
