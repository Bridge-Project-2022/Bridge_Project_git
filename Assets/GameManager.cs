using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    // Start is called before the first frame update
    void Start()
    {
        //���� ������ ������ ������ �迭�� ũ�� ����
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        print(currentText);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        //�� �ٿ��� ������ ����
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int ii = 0; ii < rowSize; ii++)
            {
                if (ii == rowSize - 1) Sentence[i, ii] = row[ii].Substring(0, row[ii].Length - 1);
                else Sentence[i, ii] = row[ii];
            }
        }
        print(Sentence[0, 1]);

        //�մ� ���, ���� ��� queue�� ���� ���� ������ ��ȭâ�� �߰� �ϸ� �� ��
        //json
    }
}
