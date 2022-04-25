using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    public string[] Dialogue_A = new string[3];
    public string[] Dialogue_B = new string[3];
    public string[] Dialogue_C_1 = new string[3];
    public string[] Dialogue_C_2 = new string[3];
    public string[] Dialogue_D_1 = new string[3];
    public string[] Dialogue_D_2 = new string[3];

    public string[] Dialogue_E_1 = new string[4];
    public string[] Dialogue_E_2 = new string[3];
    public string[] Dialogue_E_3 = new string[3];

    public Sprite[] customerSprites = new Sprite[3];//�մ� �̹��� �迭
    public void Start()
    {
        //�մ� : ���� ��Ʈ
        Dialogue_A[0] = "�ȳ��ϼ���.";
        Dialogue_A[1] = "�����..?";
        Dialogue_A[2] = "����� ���� �� �������?";

        //�մ� : ��� ���� ����
        Dialogue_B[0] = "���� ����ߴ� ���� ���� �ð� �;��...";
        Dialogue_B[1] = "����� �� ���� ���� ���̰����� ���� ����� ã���ּ���..";
        Dialogue_B[2] = "������ �ٸ��� �ǳ� �������� �����ϸ� �ʹ� ���ۿ�..";
       // Dialogue_B[3] = "�����Դ� ������ŭ �����߰ŵ��..";

        //���� : '��' ������ ���
        Dialogue_C_1[0] = "���� ����� ��� ������ �ص帱���?";
        Dialogue_C_1[1] = "���� ��� ������ �ص帱���?";
        Dialogue_C_1[2] = "�����Ͻ� ���� ���Ⱑ �������?";

        //���� : '�ƴϿ�' ������ ���
        Dialogue_C_2[0] = "�˼��մϴ�. �մԿ��� �Ǹ��� �� �����.";
        Dialogue_C_2[1] = "�˼��մϴ�. �մԿ��� ����� ������� �� �����.";
        Dialogue_C_2[2] = "�˼��մϴ�. �մ��� ����� ���� �� �����.";

        //�մ� : C_1 ���� ���. ���� ���� ����
        Dialogue_D_1[0] = "���� �����ϰ� ���ּ���..";
        Dialogue_D_1[1] = "������ ���ּ���. \n�ʹ� ���ϸ� ���Ĺ�������..";
        Dialogue_D_1[2] = "���� ���ϰ� ���ּ���..";

        //�մ� : C_2 ���� ���. D_2 ���� �ٽ� A�� ���ư�.
        Dialogue_D_2[0] = "��ü ����? �׷� �Ÿ� ���Ը� ���� ���簡..";
        Dialogue_D_2[1] = "���� ���γ׿�.";
        Dialogue_D_2[2] = "�ƹ��� ������ ���� �ź��ϴ� �� ���� �ʹ��ϳ׿�.";

        //��� �Ǹ����� �� ������ Very Good or Good �� ���
        Dialogue_E_1[0] = "�����̶� �� ���� ���̴� �͸� ���ƿ�..";
        Dialogue_E_1[1] = "�����ϴ١� ���� �����ϴ�..";
        Dialogue_E_1[2] = "���� ���� ���̳׿�..";
        Dialogue_E_1[3] = "���ݸ� �� ���� �ðɡ� \n�����մϴ�..";

        //��� �Ǹ����� �� ������ Normal �� ���
        Dialogue_E_2[0] = "�׷����� �����׿�.";
        Dialogue_E_2[1] = "�̸��ϸ� ������ �� ���ƿ�.\n������";
        Dialogue_E_2[2] = "���� �ƽ�����, ��¿ �� ������.";

        //��� �Ǹ����� �� ������ Bad or Very Bad �� ���
        Dialogue_E_3[0] = "�̰� ������ �θ� �� �ֳ���..?";
        Dialogue_E_3[1] = "���� ������� �󸶳� ������µ� �̷� ����� ��ٴ�..\n���� �Ʊ��׿�";
        Dialogue_E_3[2] = "�̰� ���� ã�� ���� �ƴѵ��� ";


    }
}
