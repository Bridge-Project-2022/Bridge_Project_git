using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SecondDialogueScript : MonoBehaviour
{
   //public GameObject Customer;
   public GameObject Distiller;

    GameObject RC;
    //�մ� ��� �迭 - ��ü�� ���������� ���δ� ����������

    public static int FirstDayCustomerNum = 9;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[FirstDayCustomerNum];//�� ��¥�� ���� �մ��� ���̵� (�մ� ����ŭ �Ҵ�)
    //public Sprite[] Customer_Image = new Sprite[10];//�մ� �̹��� -> ���̵�� ����
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
            Customer_ID[i] = Random.Range(2001, 2010);
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
        if (Customer_ID[0] == 2001)
        {
            Customer_Name = "J";
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[0];

            Customer_PerfumeOrder[0] = "�����?";
            Customer_PerfumeOrder[1] = "������.. ���� �� ��ȥ������̶��ϴ�..";
            Customer_PerfumeOrder[2] = "�װ� ó������ ������ ������ �ǳ��� ���� ���� ��¦ ��� ������ ���߾��.. ";
            Customer_PerfumeOrder[3] = "�׶��� ������ ���ϻ��� �������׿�..";
            Customer_PerfumeOrder[4] = "���� ���̻� �׸� �� ���� �������� ������.";
            Customer_PerfumeOrder[5] = "�̷� ���� �� �߾ﵵ ����� �� �ֳ���?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }


            Customer_IntensityOrder[0] = "�� �̻� ���ſ� �����ϰ� ���� �ʾƿ�..";
            Customer_IntensityOrder[1] = "���� �׳� �����ϰ� ���ּ���!";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "����";

            Customer_RejectReaction[0] = "�״��� ����� ��Ź�� ���� �ʾҴ� �� ������.. ";
            Customer_RejectReaction[1] = "�ٽô� �̷� ���� ������ ���ڳ׿�.";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��������, ���п� ���� ��︸�� �������׿�..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. ���������׿�.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ������ ��� ����� �ſ���?";
                    Customer_PerfumeReaction[1] = "�̰� �����ݾƿ� ����";
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
                    Customer_PerfumeReaction[0] = "�̰� �� ���� �ǰ���..? ";
                    Customer_PerfumeReaction[1] = "���� ��ġ�� ���׿�.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "��ü ���� ����� ���� ����?";
                    Customer_PerfumeReaction[1] = "���� �������׿�.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 2002)//K: ������ �� Ǫ���� �λ��� �Ҿƹ���
        {
            Customer_Name = "K";
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[1];

            Customer_PerfumeOrder[0] = "�ݰ���, ���� ���!";
            Customer_PerfumeOrder[1] = "���� �� ���Դ� ó�������� ������ ���� ���������±�..";
            Customer_PerfumeOrder[2] = "�츮 �Ҹص� �̷� ���� ���� ���� �ٵ�..";
            Customer_PerfumeOrder[3] = "�Ҹذ� �ܵ��� ����Ʈ�ϴ� �׶� ����� �� �� �ִ� �ǰ�?";
            Customer_PerfumeOrder[4] = "����! �׷��ٸ� �츮 �Ҹ��� �ɴٿ� ����, �ູ�ߴ� �̼Ҹ� �ٽ� ���� �ͱ���..";
            Customer_PerfumeOrder[5] = "��� ����� �� �� �ִ°�?";
            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�׶� �츮 �Ҹ��� �׷��� ������..";
            Customer_IntensityOrder[1] = "���� ���� ��~�ϰ� ���ְԳ�!";
            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "��.. �˰ڳס�";
            Customer_RejectReaction[1] = "���� ã�ƿԱ���... ";
            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��������, �츮 �Ҹ��� �̼Ҹ� ���� ���� �ູ������ �͸� ����!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��ȣ, ���� ���� �������.";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ������ ���� �ǰ���?";
                    Customer_PerfumeReaction[1] = "�Ҹ��� ���� �ͱ�����";
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
                    Customer_PerfumeReaction[0] = "������ �ϱ⿣.. �ƹ� ������ ���� �ʴ±���!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "���� ã�� ����� �̰� �ƴ� �� ������..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2003)//A: �������� �Ӹ��� ���� ���ھ���
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[2];
            Customer_Name = "A";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ��� ?";
            Customer_PerfumeOrder[1] = "���� ������ ������ �;��!!";
            Customer_PerfumeOrder[2] = "ģ������ �����̶��� ���� �ų��� �Ҳ߳��̸� �ϴ��󱸿�!";
            Customer_PerfumeOrder[3] = "���� ��¥ �� ����� �ڽ� �ִµ�..";
            Customer_PerfumeOrder[4] = "���� ���� ������ �þƺ��� �;��..!";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "Ȥ�� ������ ��ĥ �� �����ϱ� ���� �ʹ� �����ʰ� ���ּ���!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "�ȵſ�??";
            Customer_RejectReaction[1] = "�� �ȵſ�??";
            Customer_RejectReaction[2] = "��¥�ο�..?";
            Customer_RejectReaction[3] = "�˰ھ��..";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "���! ���� �̷� ������ ���ƴ޶�� �ҷ���!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�����մϴ�!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "����. ���ξߡ� ";
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
                    Customer_PerfumeReaction[0] = "������ �� �������µ��� ����� ���� �� �¾ƿ�..?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "����.. �̷� ������� �緯 �� �� �ƴϿ���..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2004)//F:��¦�̴� ���� 20�� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[3];
            Customer_Name = "F";
            Customer_PerfumeOrder[0] = "���� �� ���̾�!";
            Customer_PerfumeOrder[1] = "��Ʈ ��� ���� ���� ����� �ִ� �� �˾�?";
            Customer_PerfumeOrder[2] = "�� ���� ����� ���������� ���� �ϳ� �ִµ�";
            Customer_PerfumeOrder[3] = "�ű⼭ ������ �ѷ����� �׷��� ���� ���� ����...?";
            Customer_PerfumeOrder[4] = "�� ǳ�濡 ��� ������ ���� �� �������� �ʾ�!";
            Customer_PerfumeOrder[5] = "�׶� �������� ���� ����?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "����! ���� ������ �ٽ� ������ �� �ֵ��� ���� �����ϰ� ����!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "������";
            Customer_Flavoring[2] = "����";

            Customer_RejectReaction[0] = "��..?";
            Customer_RejectReaction[1] = "�մ��� �׷��� ���ص� �Ǵ°ž�?";
            Customer_RejectReaction[2] = "�Ǹ��̾�..";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�ʹ� ¥����! �� ���п� �� ǳ���� �ٽ� ��� �� �־���.";
                    Customer_PerfumeReaction[1] = "���� ������!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. �����������?";
                    Customer_PerfumeReaction[1] = "���� ������!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "����.. �־��̾�..";
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
                    Customer_PerfumeReaction[0] = "�̰� �¾�?";
                    Customer_PerfumeReaction[1] = "������ �� �� �� �¾�..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�̰� ��ü ���� ������?";
                    Customer_PerfumeReaction[1] = "���� ���ϴ� �� �ƴ��ݾ�!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2005)//B: �簥�� �Ӹ��� ���� ���� ����
        {
            // Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[4];
            Customer_Name = "B";
            Customer_PerfumeOrder[0] = "����...";
            Customer_PerfumeOrder[1] = "�� ���� ������ �ʹ� �׸���..";
            Customer_PerfumeOrder[2] = "�� ������ �������� ��¥ �ູ�ߴµ�..";
            Customer_PerfumeOrder[3] = "������ �� ������ �����ٰ� �������� �� ����..?";
            Customer_PerfumeOrder[4] = "���� ������ �ֱ�� ���� ����ߴµ���";
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ��û ����! ���ϰ�! �����!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "���� �� ����� �ֽ� �ſ���?";
            Customer_RejectReaction[1] = "�̿�..";
            Customer_RejectReaction[2] = "��¥ �̿�!!";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��! �����̴�!!";
                    Customer_PerfumeReaction[1] = "�׷��׷�, �ʸ� �ٽ� �����ϱ� �ʹ� ����!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�;�.. ���� �����մϴ�!";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�� ���� �ƴϾ�!!";
                    Customer_PerfumeReaction[1] = "�� ���� ������ �ƴϾ�!!";

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
                    Customer_PerfumeReaction[0] = "�� �ϳ� ��Ʈ���� �� �ƴϿ���?";
                    Customer_PerfumeReaction[1] = "�̰� �ƴ� �� ������..";
                    Customer_PerfumeReaction[2] = "���� ���̾�!";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�׷��ϱ�.. .�̰�.. �� �����̾�.?";
                    Customer_PerfumeReaction[1] = "�̷� ���� ���µ�..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2006)//D
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[5];
            Customer_Name = "D";
            Customer_PerfumeOrder[0] = "����..";
            Customer_PerfumeOrder[1] = "������ � �� ���� �ڵ����� �� ������ �������� �ɱ�?";
            Customer_PerfumeOrder[2] = "�׶� ������ ��⸸ �ص� �ູ�ؼ� �׷���?";
            Customer_PerfumeOrder[3] = "���� �� �𸣰ڴµ� �峭�� �ڵ����� �ڲ� ������";
            Customer_PerfumeOrder[4] = "�� �� �������� ������?";
 
            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "��.. ���� �����ϰ� ��Ź�Ұ�!";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�峭��";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "��??";
            Customer_RejectReaction[1] = "ĩ ��� ��������.";
            Customer_RejectReaction[1] = "���� �ٽ� �� �� �ž�!";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�� ��¥����!!";
                    Customer_PerfumeReaction[1] = "�ڵ��� Ÿ�� ���ƴٴ� �� ���� �� ����!!!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�� �� ����ϳ׿�?";
                    Customer_PerfumeReaction[1] = "���� ã�� �ڵ����� ���� �� ����!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�. �ʹ� ���е�?";
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
                    Customer_PerfumeReaction[0] = "�̰� ��ü ���� ������?";
                    Customer_PerfumeReaction[1] = "�ƹ� ���� �ȳ��ݾ�";
                    Customer_PerfumeReaction[2] = "�� ����ž� ��ü?";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "���� ã�� �ڵ����� �ƴ��ݾ�??";
                    Customer_PerfumeReaction[1] = "�̷� �����⸦ �� �������?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2007)//E: ��ô�ϰ� ��ũ��Ŭ �ִ� 20�� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[6];
            Customer_Name = "E";
            Customer_PerfumeOrder[0] = "....��...";
            Customer_PerfumeOrder[1] = "....����..ģ..��...";
            Customer_PerfumeOrder[2] = "...��..��...�;�...";
            Customer_PerfumeOrder[3] = "...����...��...��...?";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "����.. ..��...�ϰ�...";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = ".....";
            Customer_RejectReaction[1] = ".........";
            Customer_RejectReaction[2] = ".............";

            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��.�ͼ��� ��..";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "....������...";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "...���ξ�..";
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
                    Customer_PerfumeReaction[0] = ".....";
                    Customer_PerfumeReaction[1] = "..........";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�̰�..�ƴ�..��.....?"; ;
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2008)//H : �ܹ߸Ӹ� �Ȱ��� �� û�ҳ� ����
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[7];
            Customer_Name = "H";
            Customer_PerfumeOrder[0] = "�ȳ��ϼ���~";
            Customer_PerfumeOrder[1] = "��������� �ϴ� ���� �ϳ� �־��.";
            Customer_PerfumeOrder[2] = "�ٷιٷ�..";
            Customer_PerfumeOrder[3] = "���� ����� ���ϴ� �ν��� ���� �հ��ߴٰ���!";
            Customer_PerfumeOrder[4] = "�� ��� ���� ���� ��� ����ϰ� �;��~";
            Customer_PerfumeOrder[5] = "��� �ϳ��� ��Ź�帱�Կ�!";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� �������� �ص� ����� �� ���ƿ�!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "�б�";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "��..?";
            Customer_RejectReaction[1] = "��.. ���̰� ���׿�..";
            Customer_RejectReaction[2] = "����� ���� �Դ� �� ���ƿ�.";
            for (int i = 3; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�� �߾��� �����ϰ� �� �����ؼ� ���� ��ȣ�簡 �ɰԿ�.";
                    Customer_PerfumeReaction[1] = "���� �����մϴ�!";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��.. ���ƿ�!";
                    Customer_PerfumeReaction[1] = "�����մϴ�!";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "��.. �̰� ������..?";
                    Customer_PerfumeReaction[1] = "�̰� ������ �ִٰ� �����ϴ� �ɿ�..";
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
                    Customer_PerfumeReaction[0] = "���� ���� ���ٴ� ����..";
                    Customer_PerfumeReaction[1] = "�װ� �ϼ�ǰ�ΰ���?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "����..ã�� ���� �ƴϰ���?";
                    Customer_PerfumeReaction[1] = "�Ǽ��� �볳�� �� �����.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 2009)//C
        {
            //Customer.GetComponent<SpriteRenderer>().sprite = Customer_Image[8];
            Customer_Name = "C";
            Customer_PerfumeOrder[0] = "�����..?";
            Customer_PerfumeOrder[1] = "�ƴ�.. �װ�..";
            Customer_PerfumeOrder[2] = "Ȥ�� ¦����� �غ� ���� �ֳ���..?";
            Customer_PerfumeOrder[3] = "���� ���� �� ¦��� ���� ����ġ�� �� ������ �αٰŷ���.";
            Customer_PerfumeOrder[4] = "���� �� ���� ������..";
            Customer_PerfumeOrder[5] = "�̷� �� ������ ��� ������� �ʵ��� ������ ����� �������?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ���� ������ ������ �����ϰ� ��Ź�ؿ�.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "ģ��";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "����.. �̷��� ��¥ ��Ű�� �� �ƴϾ�..?";
            Customer_RejectReaction[1] = "���ڴ�..";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�����... �����...";
                    Customer_PerfumeReaction[1] = "���� ���� ��� ���;�� �ߴµ�...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "��!";
                    Customer_PerfumeReaction[1] = "�� ������ �� ����.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�� ������ ��ų ���� ���ڳ׿�.";
                    Customer_PerfumeReaction[1] = "��.. �����մϴ�.";
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
                    Customer_PerfumeReaction[1] = "�� �ڰ� �̻��Ѱǰ�..?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else
                {
                    Customer_PerfumeReaction[0] = "�̰�..��...";
                    Customer_PerfumeReaction[1] = "���� ã�� ����� �ƴϿ���.";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
    }
}