using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public string[] tutStart = new string[10];
    public string[] tutStore = new string[10];
    public string[] tutBuy = new string[10];
    public string[] tutCreate = new string[10];
    public string[] tutResult = new string[10];

    public void Update()
    {
        tutStart[0] = "�ȳ�"; tutStart[1] = "Ʃ�丮�� �����Ұ�"; tutStart[2] = "�̰� �����"; tutStart[3] = "�̰� ��� ����"; tutStart[4] = "���� ���� �����Ұ�";

        tutStore[0] = "�������� ���� �� �� �־�"; tutStore[1] = "��ŵ�Ͻ�?"; tutStore[2] = "���̽� ��Ʈ �� �� �־�"; tutStore[3] = "�̵� Ŭ���غ�"; tutStore[4] = "�̵� �� �� �־�"; tutStore[5] = "ž Ŭ���غ�"; tutStore[6] = "ž �� �� �־�";
    }

}
