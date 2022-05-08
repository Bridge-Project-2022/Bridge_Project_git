using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript2 : MonoBehaviour
{
    public GameObject Customer;
    public GameObject Distiller;


    //�մ� ��� �迭 - ��ü�� ���������� ���δ� ����������

    public static int FirstDayCustomerNum = 9;
    public int[] Customer_ID = new int[FirstDayCustomerNum];//�� ��¥�� ���� �մ��� ���̵� (�մ� ����ŭ �Ҵ�)
    public Sprite[] Customer_Image = new Sprite[20];//�մ� �̹��� -> ���̵�� ����
    public string[] Customer_PerfumeOrder = new string[10];//�մ� ��� �ֹ� ���
    public string[] Customer_IntensityOrder = new string[5];//��� ���� ���
    public string[] Customer_Flavoring = new string[3];//���ϴ� ��� ����(��, ��, ž)
    public string[] Customer_RejectReaction = new string[5];//�մ� ���� ����
    public string[] Customer_PerfumeReaction = new string[5];//��� ���� �� �մ� ����

    //���� ��� �迭 - ���� ���� ����
    public string[] Dialogue_C_1 = new string[3];//���� - �� ���� ���
    public string[] Dialogue_C_2 = new string[3];//���� - ���� ���

    public void Start()
    {
        //�մ� ���̵� �迭�� 1-9���� �߿� �������� �ֵ� �ߺ����� �ʵ��� ��ġ��. 
        for (int i = 0; i < Customer_ID.Length; i++)
        {
            Customer_ID[i] = Random.Range(1001,1010);
            for (int j = 0; j < i; j++)
            {
                if (Customer_ID[i] == Customer_ID[j])
                {
                    i--;
                    break;
                }
            }
        }
        if(Customer_ID[0] == 1001)//A : �ʵ��л� ���ھ���, �����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[0];

            Customer_PerfumeOrder[0] = "�ȳ�?";
            Customer_PerfumeOrder[1] = "� �� �ƺ� ����� ���� ���̰����� �ٽ� ���� �;�!";
            Customer_PerfumeOrder[2] = "�׶� ��¥ �ູ�߰ŵ�!!";
            Customer_PerfumeOrder[3] = "����� ������� �� ������?";

            Customer_IntensityOrder[0] = "���� ���ϰ� ����";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "���̰���";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "���� �� ����°ž�?";
            Customer_RejectReaction[1] = "�׷��� ������ �ð�!";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���� ����!! ������!!";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��! �̸��ϸ� ������ �� ���ƿ�!";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "���� ����� �̷�����..?";
                    Customer_PerfumeReaction[1] = "���� ���е�..?";
                    Customer_PerfumeReaction[2] = "�Ƿ��� ��..";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "���� ���� �Ŷ� �ٸ� �� ��������?";
                    Customer_PerfumeReaction[1] = "�̷� ���� ���µ�..";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�� �ϳ� ���߸��� �� �ƴϿ���?";
                    Customer_PerfumeReaction[1] = "�̰� �ƴ� �� ������..";
                    Customer_PerfumeReaction[2] = "���� ���̾�!";
                }
            }

        }

        else if (Customer_ID[0] == 1002)//B : ���� ����� 30-40�� ���ܸ�, �ҽ���, ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[1];

            Customer_PerfumeOrder[0] = "�����?";
            Customer_PerfumeOrder[1] = "�츮 �ְ� ������ � �� ������ ��� ������ �� �ؾ��.";
            Customer_PerfumeOrder[2] = "�׷��� �⻵�ϸ鼭 ������ ��� �Ŷ� ���ش� �Ѵٸ�..";
            Customer_PerfumeOrder[3] = "�̹� ���� ���� �����ε� �� ������ �� �ؾ����� ��..";
            Customer_PerfumeOrder[4] = "Ȥ�� ��� �����ұ��?";

            Customer_IntensityOrder[0] = "������..? ���ּ���.";
            Customer_IntensityOrder[1] = "�ְ� �ʹ� �⿡ ����� �����̳׿�.";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "�ƴ� ���� �شٴµ�����?";
            Customer_RejectReaction[1] = "�����ϳ׿�.";
            Customer_RejectReaction[2] = "�̰� �ٸ� ��������׵� �˷��߰ھ��.";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�����մϴ�. �̰Ÿ� �츮 �� �����̶� �޷� �� �ְ���?";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. �����׿�.";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ����� �ƴѵ���?";
                    Customer_PerfumeReaction[1] = "�̷��Ա��� �� ���� ���̾�..";
                    Customer_PerfumeReaction[2] = "�ٸ� ����鵵 �˾ƾ� �� �� ���׿�.";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "��.. �̰� ���� ���� �Ŷ� �ٸ�����?";
                    Customer_PerfumeReaction[1] = "�̰� �³���?";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�ϼ��� �ȵ� �� �̷��� �ȾƵ� �ǳ���?";
                    Customer_PerfumeReaction[1] = "�ֺ� ��������� �� ���Ұſ���!";
                }
            }
        }

        else if (Customer_ID[0] == 1003)//C : �۽��̴� 20-30�� ����, ��ô��
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[2];

            Customer_PerfumeOrder[0] = "..����..��?";
            Customer_PerfumeOrder[1] = "...���� �� ����� �ٽ� �ѹ����̶� ���� �;�..";
            Customer_PerfumeOrder[2] = "���� �̷��� �����ϴµ�.. ��ü ��� ������ �ִ°ž�..?";
            Customer_PerfumeOrder[3] = "���� ����ϴ� �׳డ ��ġ���� ���� �;�..";

            Customer_IntensityOrder[0] = "���� ������ �ʵ��� ���ϰ� ���ּ���..";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "...������ ��ü �� �׷���?";
            Customer_RejectReaction[1] = "��Ÿ�ŭ�� �׷��� �� ���ݾ�..";
            Customer_RejectReaction[2] = "�ٸ� ��������׵� ���Ұž�.";
            Customer_RejectReaction[3] = "��ȸ���� ��, ����� �� �������ݾ�?";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�̰��� �ٷ� �׳��� ��..";
                    Customer_PerfumeReaction[0] = "���� �����մϴ�.. ������...";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "������..";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�ʹ� �� ����� �ƴѰ���..?";
                    Customer_PerfumeReaction[1] = "�ٸ� ����鵵 ����� �̷��� �� ����� �� �˰� �ֳ���?";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�̰� ���� �ð� ���� ���� �ƴϿ���..";
                    Customer_PerfumeReaction[1] = "���� �־��̳׿�..";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "����� ���� �� �³���..?";
                    Customer_PerfumeReaction[1] = "�ƹ� �͵� �������� �ʾƿ�..";
                }
            }
        }

        else if(Customer_ID[0] == 1004)//D : �ʵ��л� 4-5�г� ���� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[3];

            Customer_PerfumeOrder[0] = "�ȳ��ϼ���?";
            Customer_PerfumeOrder[1] = "���� �� ������ �;��!";
            Customer_PerfumeOrder[2] = "���� ������ ���ڴ�!";
            Customer_PerfumeOrder[3] = "�׷� �ǳ� ���� ��� �ູ���ٵ�!!";
            Customer_PerfumeOrder[4] = "�� ������ ���� �� �������?!!";

            Customer_IntensityOrder[0] = "�ƹ��ų� ���ּ���!!";
            Distiller.GetComponent<Distiller>().DistillerStatus = "�ƹ��ų�";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "�ȵſ�??";
            Customer_RejectReaction[1] = "�� �ȵſ�??";
            Customer_RejectReaction[2] = "��¥�ο�??";
            Customer_RejectReaction[3] = "�˰ھ��..";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��!! �����ϴ�!!";
                    Customer_PerfumeReaction[1] = "�̰Ÿ� ���� ���� ����ǰ�??!";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "����.. �����ϴ�!!";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰�.. �����ϴ�..!";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�̰� �� ������ �ƴѵ���..?";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "������ �� �������µ�..";
                    Customer_PerfumeReaction[1] = "������ ����� ���� �� �¾ƿ�?";
                }
            }
        }

        else if(Customer_ID[0] == 1005)//E : 10-20�� �ʹ� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[4];

            Customer_PerfumeOrder[0] = "������..?";
            Customer_PerfumeOrder[1] = "������ � �� ���� �ڵ����� �� ������ �������� �ɱ�?";
            Customer_PerfumeOrder[2] = "�� �� ������ ��⸸ �ص� �ູ�ؼ� �׷���?";
            Customer_PerfumeOrder[3] = "���� �� �𸣰ڴµ� �峭�� �ڵ����� �ڲ� ������..";

            Customer_IntensityOrder[0] = "��.. �����ϰ� ����!";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�峭��";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "��??";
            Customer_RejectReaction[1] = "ĩ ��� ��������!";
            Customer_RejectReaction[2] = "���� �ٽ� �� �ðž�!";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��.. ��¥����!!";
                    Customer_PerfumeReaction[1] = "�ڵ��� Ÿ�� ���ƴٴ� �� ���� �� ����!";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. �� ����ϳ�!";
                    Customer_PerfumeReaction[1] = "���� ã�� �ڵ����� ���� �� ����!";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "��.. �ʹ� ���е�?";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "���� ã�� �ڵ����� �ƴ��ݾ�??";
                    Customer_PerfumeReaction[1] = "�̷� �����⸦ �� �������?";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�̰� ��ü ���� ������?";
                    Customer_PerfumeReaction[1] = "�ƹ� ���� �� ���ݾ�!";
                    Customer_PerfumeReaction[2] = "�� ����ž� ��ü?";
                }
            }
        }

        else if(Customer_ID[0] == 1006)//F : 30�� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[5];

            Customer_PerfumeOrder[0] = "���� ��������... ������ �ٸ��� �ǳԾ��..";
            Customer_PerfumeOrder[1] = "���� ��ħ ���� �߸�, ���̰� ��� ��ĥ �� ���ƿ�..";
            Customer_PerfumeOrder[2] = "�װ� ���� ����ٰ�.. ��å�� �� ����µ�..";
            Customer_PerfumeOrder[3] = "�� �� ������ ���ؼ� �ʹ� �̾��ѵ�..";

            Customer_IntensityOrder[0] = "���̶� ���� ���� �ڴ� �̺ҿ� �Ѹ� �ſ���..";
            Customer_IntensityOrder[1] = "�� �̺ҿ��� ��ŭ�� ���̸� ���� �� �ְ�..";
            Customer_IntensityOrder[2] = "�̷� �Ÿ� ���ؾ߰���..?";

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�ݷ�����";
            Customer_Flavoring[2] = "��å��";

            Customer_RejectReaction[0] = "...?";
            Customer_RejectReaction[1] = "������ �ݷ����� Ű���� ������ ��������?";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���̾�.. �� ������ �ʹ� �ʹ� �׸�����..";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�� ������ �׸�����..";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̷��� �� ����� �͵� ���ִ� ����.";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�̰� ���� �����ΰ���??";
                    Customer_PerfumeReaction[1] = "���� ������ �ƴѵ�?";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "���� ���µ� �� ������ �ž�?";
                }
            }
        }

        else if(Customer_ID[0] == 1007)//G : 40-50�� �߳��� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[6];

            Customer_PerfumeOrder[0] = "�ȳ��ϽŰ�..";
            Customer_PerfumeOrder[1] = "�� ���� ģ�� ���� ���� �ͱ���..";
            Customer_PerfumeOrder[2] = "�� �� ���� ����� ���Ⱦ�� �ߴµ� ���̾�..";
            Customer_PerfumeOrder[3] = "�������.. �׳��� ��� �ָ��Ⱦ�..";
            Customer_PerfumeOrder[4] = "�����.. �� ſ���� ��..";

            Customer_IntensityOrder[0] = "�� ģ�� ���� ������ ���ӵ����� ���ڱ�..";
            Customer_IntensityOrder[1] = "���� ���� �̷��� �Ǵ� �ɱ�..?";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "ģ��";
            Customer_Flavoring[2] = "��å��";

            Customer_RejectReaction[0] = "����.. ���� ��ſ��� �� �߸�����..?";
            Customer_RejectReaction[1] = "���õ� �� ���� �Ϸ籸��..";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "����.. ����...";
                    Customer_PerfumeReaction[1] = "����...";
                    Customer_PerfumeReaction[2] = ".....";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "����.. �ڳ�..";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ��ü ��..";
                    Customer_PerfumeReaction[1] = "���������.";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "���� �����?";
                    Customer_PerfumeReaction[1] = "�̷� �Ÿ� ����ġ���.";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "���� �峭�ϴ°ǰ�?";
                    Customer_PerfumeReaction[1] = "���� �� �������µ� �� ��϶�� �ž�?";
                }
            }
        }

        else if(Customer_ID[0] == 1008)//H : 20�� �ʹ��� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[7];

            Customer_PerfumeOrder[0] = "���� �� ���̾�!";
            Customer_PerfumeOrder[1] = "��Ʈ ��� ���� ���� ����� �ִ°� �˾�?";
            Customer_PerfumeOrder[2] = "�� ���� ����� ���������� ���� �ϳ� �ִµ�";
            Customer_PerfumeOrder[3] = "�ű⼭ ������ �ѷ����� �׷��� ���� ���� ����...?";
            Customer_PerfumeOrder[4] = "�� ǳ�濡 ��� ������ ���� �� �������� �ʾ�!";
            Customer_PerfumeOrder[5] = "�׶� �������� ���� ����?";

            Customer_IntensityOrder[0] = "������ �ٽ� ������ �� �ֵ��� �����ϰ� ����!";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "������";
            Customer_Flavoring[2] = "����";

            Customer_RejectReaction[0] = "��..? �մ��� �׷��� ���ص� �Ǵ°ž�? �Ǹ��̾�";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�ʹ� ¥����! �� ���п� �� ǳ���� �ٽ� ��� �� �־���.";
                    Customer_PerfumeReaction[1] = "���� ����!";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. �����������?!";
                    Customer_PerfumeReaction[1] = "���� ����!";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "����....";
                    Customer_PerfumeReaction[1] = "�־��̾�..";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "�̰� ��ü ���� ������?!";
                    Customer_PerfumeReaction[1] = "���� ���ϴ� �� �ƴ��ݾ�!!";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�̰� �¾�?";
                    Customer_PerfumeReaction[1] = "������ �� �� �� �¾�?!";
                }
            }
        }

        else if(Customer_ID[0] == 1009)//I : 10���� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[8];

            Customer_PerfumeOrder[0] = "����.. �ȳ��ϼ���?";
            Customer_PerfumeOrder[1] = "��� ���� �� ������ ������� �� ���Ƽ���..";
            Customer_PerfumeOrder[2] = "�ǽ��ϰ� ���� ������ ģ���� ��� ������ ������ �ڲ� �������!";
            Customer_PerfumeOrder[3] = "�׳� �� ������ �� ���⵵ �ϰ�..";
            Customer_PerfumeOrder[4] = "�ƹ��� ����� �ǻ��ܺ��� Ȯ���� ������ �ʾƼ���..";

            Customer_IntensityOrder[0] = "��Ȯ�ϰ� ����� �� �ֵ��� ���ϰ� ���ּ���!";
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "ģ��";
            Customer_Flavoring[2] = "�ǽ�";

            Customer_RejectReaction[0] = "�ơ� �ƹ��� �����غ��� �°� �´� �� ������..";
            Customer_RejectReaction[1] = "..��ġ�ڳ�";

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��.. �ָӴϰ� ���� ������ �Ծ �׷���";
                    Customer_PerfumeReaction[1] = "�����ؼ� ģ���� �ǽ��� �� �߾��!";
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "���� �� �߸����ݾ�!?";
                    Customer_PerfumeReaction[1] = "������!!";
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰ǡ� ����.";
                }
            }
            else//��Ḧ �ϳ��� �ٸ��� ����� ���
            {
                if (GameObject.FindObjectOfType<TotalScore>().originPrice == 0)//��Ḧ �ϳ��� ���� �ʰ� �ٷ� ��� ������ ���
                {
                    Customer_PerfumeReaction[0] = "���� ���ϴ� �� �ƴѵ���..?";
                    Customer_PerfumeReaction[1] = "�̰ǡ� ����.";
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�ƹ� ���� ���µ���?";
                    Customer_PerfumeReaction[1] = "�̰ǡ� ����.";
                }
            }
        }


        //���� : '��' ������ ���
        Dialogue_C_1[0] = "���� ����� ��� ������ �ص帱���?";
        Dialogue_C_1[1] = "���� ��� ������ �ص帱���?";
        Dialogue_C_1[2] = "�����Ͻ� ���� ���Ⱑ �������?";

        //���� : '�ƴϿ�' ������ ���
        Dialogue_C_2[0] = "�˼��մϴ�. �մԿ��� �Ǹ��� �� �����.";
        Dialogue_C_2[1] = "�˼��մϴ�. �մԿ��� ����� ������� �� �����.";
        Dialogue_C_2[2] = "�˼��մϴ�. �մ��� ����� ���� �� �����.";
    }
}
