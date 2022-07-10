using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    public GameObject RC;
    public GameObject DR;

    //�մ� ��� �迭 - ��ü�� ���������� ���δ� ����������

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//�� ��¥�� ���� �մ��� ���̵� (�մ� ����ŭ �Ҵ�)
    public string[] Customer_PerfumeOrder = new string[10];//�մ� ��� �ֹ� ���
    public string[] Customer_IntensityOrder = new string[5];//��� ���� ���
    public string[] Customer_Flavoring = new string[3];//���ϴ� ��� ����(��, ��, ž)
    public string[] Customer_RejectReaction = new string[5];//�մ� ���� ����
    public string[] Customer_PerfumeReaction = new string[5];//��� ���� �� �մ� ����

    //���� ��� �迭 - ���� ���� ����
    public string[] Dialogue_C_1 = new string[3];//���� - �� ���� ���
    public string[] Dialogue_C_2 = new string[3];//���� - ���� ���

    GameObject RandomImage;

    public void Start()
    {
        //�մ� ���̵� �迭�� 1-9���� �߿� �������� �ֵ� �ߺ����� �ʵ��� ��ġ��. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001, 1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }
        //Customer = GameObject.Find("Etc").transform.GetChild(5).gameObject;
        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (Customer_ID[0] == 1001)//B : �ʵ��л� ���ھ���, �����
        {
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "�ȳ�?";
            Customer_PerfumeOrder[1] = "� �� �ƺ� ����� ���� ���̰����� �ٽ� ���� �;�!";
            Customer_PerfumeOrder[2] = "�׶� ��¥ �ູ�߰ŵ�!!";
            Customer_PerfumeOrder[3] = "����� ������� �� ������?";
            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "���� ���� ���ϰ� ����!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "���̰���";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "���� �� ����°ž�?";
            Customer_RejectReaction[1] = "�׷��� ������ �ð�!";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���� ����!! ������!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��! �̸��ϸ� ������ �� ����!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "���� ����� �̷�����..?";
                    Customer_PerfumeReaction[1] = "���� ���е�..?";
                    Customer_PerfumeReaction[2] = "�Ƿ��� ��..";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�� �ϳ� ���߸��� �� �ƴϿ���?";
                    Customer_PerfumeReaction[1] = "�̰� �ƴ� �� ������..";
                    Customer_PerfumeReaction[2] = "���� ���̾�!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "���� ���� �Ŷ� �ٸ� �� ��������?";
                    Customer_PerfumeReaction[1] = "�̷� ���� ���µ�..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1002)//J : ���� ����� 30-40�� ���ܸ�, �ҽ���, ����
        {
            Customer_Name = "J";
            Customer_PerfumeOrder[0] = "�����?";
            Customer_PerfumeOrder[1] = "�츮 �ְ� ������ � �� ������ ��� ������ �� �ؾ��.";
            Customer_PerfumeOrder[2] = "�׷��� �⻵�ϸ鼭 ������ ��� �Ŷ� ���ش� �Ѵٸ�..";
            Customer_PerfumeOrder[3] = "�̹� ���� ���� �����ε� �� ������ �� �ؾ����� ��..";
            Customer_PerfumeOrder[4] = "Ȥ�� ��� �����ұ��?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "������, ���� ������..? ���ּ���.";
            Customer_IntensityOrder[1] = "�ְ� �ʹ� �⿡ ����� �����̳׿�.";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "�ƴ� ���� �شٴµ�����?";
            Customer_RejectReaction[1] = "�����ϳ׿�.";
            Customer_RejectReaction[2] = "�̰� �ٸ� ��������׵� �˷��߰ھ��.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�����մϴ�. �̰Ÿ� �츮 �� �����̶� �޷� �� �ְ���?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. �����׿�.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ����� �ƴѵ���?";
                    Customer_PerfumeReaction[1] = "�̷��Ա��� �� ���� ���̾�..";
                    Customer_PerfumeReaction[2] = "�ٸ� ����鵵 �˾ƾ� �� �� ���׿�.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�ϼ��� �ȵ� �� �̷��� �ȾƵ� �ǳ���?";
                    Customer_PerfumeReaction[1] = "�ֺ� ��������� �� ���Ұſ���!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "��.. �̰� ���� ���� �Ŷ� �ٸ�����?";
                    Customer_PerfumeReaction[1] = "�̰� �³���?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1003)//G : ������ 30�� ����
        {
            Customer_Name = "G";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ���!";
            Customer_PerfumeOrder[1] = "���� ���� ����ģ������ ûȥ�� �Ϸ��� �մϴ�.";
            Customer_PerfumeOrder[2] = "����! �������׿�.";
            Customer_PerfumeOrder[3] = "���� ����ϴ� ������ ����� �Բ� �����ϰ� ������..";
            Customer_PerfumeOrder[4] = "�غ� �����ұ��?";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "��! ���� ���� ���ϰ� ��Ź�帳�ϴ�.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "�ȵȴٰ��?";
            Customer_RejectReaction[1] = "�̷��� ������ �����ص� �Ǵ°̴ϱ�?";
            Customer_RejectReaction[2] = "����! �� ��� �� ���Ƴ�.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��! ���� �� ���ߴ� ����׿�.";
                    Customer_PerfumeReaction[1] = "�̰Ÿ� ûȥ�� ������ �� �ְھ��.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�����մϴ�. �� ������ ��׿�.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�� �����..";
                    Customer_PerfumeReaction[1] = "�޴� �� ����ģ���� ��� ���ڰھ��.";
                    Customer_PerfumeReaction[2] = "�ƽ��ϴ�.";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "ůů..";
                    Customer_PerfumeReaction[1] = "���⼭ �ƹ� �⵵ ���� �ʴ� �ɿ�?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "��.. ���� ��Ź�帰 ����� �ƴ� �� ������..";
                    Customer_PerfumeReaction[1] = "�����ڽ��ϴ�.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1004)//A : �ʵ��л� 4-5�г� ���� ����
        {
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ���?";
            Customer_PerfumeOrder[1] = "���� �� ������ �;��!";
            Customer_PerfumeOrder[2] = "���� ������ ���ڴ�!";
            Customer_PerfumeOrder[3] = "�׷� �ǳ� ���� ��� �ູ���ٵ�!!";
            Customer_PerfumeOrder[4] = "�� ������ ���� �� �������?!!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ����� �ƹ��ų� ��������!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "�ƹ��ų�";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "�ȵſ�??";
            Customer_RejectReaction[1] = "�� �ȵſ�??";
            Customer_RejectReaction[2] = "��¥�ο�??";
            Customer_RejectReaction[3] = "�˰ھ��..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��!! �����ϴ�!!";
                    Customer_PerfumeReaction[1] = "�̰Ÿ� ���� ���� ����ǰ�??!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "����.. �����ϴ�!!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰�.. �����ϴ�..!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "������ �� �������µ�..";
                    Customer_PerfumeReaction[1] = "������ ����� ���� �� �¾ƿ�?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰� �� ������ �ƴѵ���..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1005)//E : 10-20�� �ʹ� ����
        {
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "�ȳ�..?";
            Customer_PerfumeOrder[1] = "����.. ��Ź�� �� �ִµ�..";
            Customer_PerfumeOrder[2] = "�츮 �� ����� ���� �� �����̶� �ٽ� ������ �;�...";
            Customer_PerfumeOrder[3] = "�� ���� �� �߷� ��Ʋ�Ÿ��鼭 �Ͼ���� ����ϴ� �� ������ ������..";
            Customer_PerfumeOrder[4] = "�� ó���� �ƹ� �͵� �� �ϴ���..";
            Customer_PerfumeOrder[5] = "���� �� �̻� �� �� ����..";
            Customer_PerfumeOrder[6] = "�� ���׸� ���̰� �󸶳� ���ʹ��� �����ϸ�..";
            Customer_PerfumeOrder[7] = "�������� ���� ������ ��..";
            Customer_PerfumeOrder[8] = "���� ���� �� �����̶� ���� �� �ְ� ����...";
            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� �ʹ� ��������... �ʹ� ���������� �ʰ� ���ࡦ";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�ݷ�����";
            Customer_Flavoring[2] = "����";

            Customer_RejectReaction[0] = "...������ ��ü �� �׷���?";
            Customer_RejectReaction[1] = "�� �� ���� ���� ������ �͵� �ȵǴ� �ž�?";
            Customer_RejectReaction[2] = "���� �̷��Ա��� �ߴµ�..";
            Customer_RejectReaction[3] = "�ٸ� ��������׵� ���� �ž�.";
            Customer_RejectReaction[4] = "��ȸ���� �� ����� �� �������ݾ�.";

            for (int i = 5; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�����... �����...";
                    Customer_PerfumeReaction[1] = "���� ���� ��� ���;�� �ϴµ�...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "������...";
                    Customer_PerfumeReaction[1] = "�̷��Զ� ���� �� �� �־..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "���� �־��̳׿�...";
                    Customer_PerfumeReaction[0] = "�ٸ� ����鵵 ����� �̷��� �� ����� �� �˰� �ֳ���..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "����� ���� �� �³���..?";
                    Customer_PerfumeReaction[1] = "�������� �� ���µ�..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�� ���� �ƴѵ���..?";
                    Customer_PerfumeReaction[1] = "�� ���� ����..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1006)//I : 40�� ������ ü���� ����
        {
            Customer_Name = "I";
            Customer_PerfumeOrder[0] = "�ڳ� ���� ���� ���ó�?";
            Customer_PerfumeOrder[1] = "���� ���� �𸣴� ����̱�..?";
            Customer_PerfumeOrder[2] = "���� ����� ���̾�...";
            Customer_PerfumeOrder[3] = "���� �� ����� ����!";
            Customer_PerfumeOrder[4] = "���� ���� ���޶��� ���� �ٴٷ� �ѷ����� �Ƹ��ٿ� ���̶��!";
            Customer_PerfumeOrder[5] = "�״ÿ��� ���νõ��� ��¦�̴� �ٴٸ� �ٶ󺸸� ��� ȲȦ����...";
            Customer_PerfumeOrder[6] = "�� �ٽ� �ѹ� ���� ���� ���̾�...!";
            Customer_PerfumeOrder[7] = "�׶��� �����ϸ� �ʹ��� �ູ�ϱ�!";
            Customer_PerfumeOrder[8] = "Ǫ�� �ٴ尡�� �������� �������� ������ �� ��� ���� ���� �ɼ�!";


            for (int i = 9; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ���� ���ϰ� ��Ź�ϳ�!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "������";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "��... �˰ڳ�..";
            Customer_RejectReaction[1] = "�Ǹ��� ũ����..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "������ �ٴ� ����..";
                    Customer_PerfumeReaction[1] = "�ٷ� �̰���!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "������ �ڳ�!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ����..?";
                    Customer_PerfumeReaction[1] = "���� ������ ������..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�ƹ� ���� �� ���µ�...";
                    Customer_PerfumeReaction[1] = "�̷� �� �ȾƵ� �Ǵ� �ǰ�..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰� ���� �� ������ �ƴϱ� �׷�..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1007)//C : ������ ���� û�ҳ� ����
        {
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ���, ������";
            Customer_PerfumeOrder[1] = "���� �ƺ��� �Ϳ��� ���� �������� ������ �Ծ��.";
            Customer_PerfumeOrder[2] = " �Ͼ� ���� ���������� ������ �츮 ���� ���� ��ٴ�..";
            Customer_PerfumeOrder[3] = "���� �츮 ������ �� ���������� ù ������ ��� ����ϰ� �;��.";
            Customer_PerfumeOrder[4] = "�����ּ���..!";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ������ �� �����ϰ� ǳ��� ���ھ��.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�ݷ�����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "��?";
            Customer_RejectReaction[1] = "��.. ��.. ��¿ �� ����..";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�;�!";
                    Customer_PerfumeReaction[1] = "�����մϴ�!";
                    Customer_PerfumeReaction[2] = "�츮 �� �������� ���� ������~";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�����մϴ�..";
                    Customer_PerfumeReaction[1] = "�� ��� �� �����ҰԿ�.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "���⼭ �̻��� ������ ����..";
                    Customer_PerfumeReaction[1] = "�ϴ� �����մϴ�.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "����..?";
                    Customer_PerfumeReaction[1] = "�� �ڰ� ���� �ǰ�..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰� ���� ���� �� �ƴ��ݾƿ�..";
                    Customer_PerfumeReaction[1] = "�ϴ� �����մϴ�.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1008)//D : �ܹ� �Ӹ��� û�ҳ� ����
        {
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ���?";
            Customer_PerfumeOrder[1] = "�츮 ���� �Ϳ��� ������ �ɲ��� �ְŵ��?";
            Customer_PerfumeOrder[2] = "�� ������ �󸶳� ��������� �𸣰ھ��!";
            Customer_PerfumeOrder[3] = "�̰� �ٸ� �ֵ����׵� �˷��ְ� ������..!";
            Customer_PerfumeOrder[4] = "����� �����ϸ� ���� �������?";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ���� ���ϰ�? ���ּ���!!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�ݷ�����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "��?";
            Customer_RejectReaction[1] = "��.. �ֿ�??";
            Customer_RejectReaction[2] = "��� �ȸ� ���� �� �ƴѰ�??";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��..��¥ �ɲ� ������!";
                    Customer_PerfumeReaction[1] = "������!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�� �ɲ� ��������!";
                    Customer_PerfumeReaction[1] = "���ƿ�!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "��.. �̻��� ����!!";
                    Customer_PerfumeReaction[1] = "�ɲ��� ������ ������ ���ٱ���!!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�̰� ���� ������..?";
                    Customer_PerfumeReaction[1] = "�� �̷��� ���� �ſ���??";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "��.. ���� ������..?";
                    Customer_PerfumeReaction[1] = "������ �ٸ� �����ε���?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1009)//H : 30�� ����
        {
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "�����..?";
            Customer_PerfumeOrder[1] = "����� �� �� ���̳� �����µ�, ������ �������� �� ���ϱ��..?";
            Customer_PerfumeOrder[2] = "����� �� �����⸸ �ؼ� ������� �ķ��� �� �˾Ҵµ�..";
            Customer_PerfumeOrder[3] = "�� ���� ����� ���� ���߳� ����.";
            Customer_PerfumeOrder[4] = "�̷� �� �˾����� �������� ���Ҿ�� �ߴµ�...";
            Customer_PerfumeOrder[5] = "�� �ٺ� ����?";
            Customer_PerfumeOrder[6] = "�ٺ� ���ٴ� �� ������, ������ �����ְ� �;��..";
            Customer_PerfumeOrder[7] = "���� ������ �� �ֳ���..?";

            for (int i = 8; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ���ϰ� ���ּ���..";
            Customer_IntensityOrder[1] = "���� ���ϸ� �̷��� ��� ���� ���� ���ݾƿ�..? ";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "����";

            Customer_RejectReaction[0] = "....";
            Customer_RejectReaction[1] = "......";
            Customer_RejectReaction[2] = "�˰ھ��..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�����ϸ� �Ҽ��� �� ��� �� �����µ�..";
                    Customer_PerfumeReaction[1] = "������ ���� �� ���� �� ���ƿ�..";
                    Customer_PerfumeReaction[2] = "������.. ������ ���� ����� ������..?";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "������..";
                    Customer_PerfumeReaction[1] = "������ ������ �� �ְ���..?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "��� �̷� ���� ����..?";
                    Customer_PerfumeReaction[1] = "�־��̿���..";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0 && TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "��.. ���� ���� ���� ���µ���..?";
                    Customer_PerfumeReaction[1] = "����� �� �� �³���...?";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰�.. ����..?";
                    Customer_PerfumeReaction[1] = "���� �ٸ� ������ ���µ���..?";
                    Customer_PerfumeReaction[2] = "�̻��� �� ������ ��ؿ�!!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
  }
