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
        randomNum = Random.Range(2, 4);//�Ӹ�, ��, �� �߿� 2�� �̻��� ���� �ϹǷ� 2������ 3������ ��

        for (int i = 0; i < randomMontage.Length; i++)//�ߺ��� ���� �ʰ� 0,1,2�� �迭�� �������� ����
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

        if (randomNum == 2)//2�� ���� ��� �Ӹ�, ��, �� �߿� 2���� �ٲ�
        {
            Debug.Log("ss");
            randomN1 = randomMontage[0];
            randomN2 = randomMontage[1];
            randomResult3 = "";
        }

        else if (randomNum == 3)//3�� ���� ��� �� �� �ٲ�.
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
        randomNum = Random.Range(2, 4);//�Ӹ�, ��, �� �߿� 2�� �̻��� ���� �ϹǷ� 2������ 3������ ��

        for (int i = 0; i < randomMontage.Length; i++)//�ߺ��� ���� �ʰ� 0,1,2�� �迭�� �������� ����
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

        if (randomNum == 2)//2�� ���� ��� �Ӹ�, ��, �� �߿� 2���� �ٲ�
        {
            randomN1 = randomMontage[0];
            randomN2 = randomMontage[1];
            randomN3 = 3;
        }

        else if (randomNum == 3)//3�� ���� ��� �� �� �ٲ�.
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
            Debug.Log("��Ÿ�� : " + randomResult1 + " �ϰ� " + randomResult2 + "�� ������ �ٸ��ϴ�!");
        }
        else
            Debug.Log("��Ÿ�� : " + randomResult1 + " �ϰ� " + randomResult2 + " �ϰ� " +randomResult3 + "�� ������ �ٸ��ϴ�!");
    }
}
