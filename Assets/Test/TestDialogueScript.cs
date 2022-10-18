using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestDialogueScript : MonoBehaviour
{
    //GameObject Customer;
    public GameObject Distiller;
    public GameObject RC;
    public GameObject DR;

    public string Customer_Name = "";
    public int[] Customer_ID = new int[6];//�� ��¥�� ���� �մ��� ���̵� (�մ� ����ŭ �Ҵ�)
    public string[] Customer_PerfumeOrder = new string[10];//�մ� ��� �ֹ� ���
    public string[] Customer_IntensityOrder = new string[5];//��� ���� ���
    public string[] Customer_Flavoring = new string[3];//���ϴ� ��� ����(��, ��, ž)
    public string[] Customer_RejectReaction = new string[5];//�մ� ���� ����
    public string[] Customer_PerfumeReaction = new string[5];//��� ���� �� �մ� ����
    public string[] Customer_CriminalDeclareReaction = new string[5];//�Ű����� �� ����

    public bool isRorenaBad = false;
    public void Start()
    {
        Customer_ID[0] = 1004;//���� A
        Customer_ID[1] = 1010;//�η��� 1
        Customer_ID[2] = 1003;//������ G
        Customer_ID[3] = 1008;//���� D
        Customer_ID[4] = 1011;//�η���2
        Customer_ID[5] = 1001;//���� B

        RC = GameObject.Find("RC").gameObject;
    }
    public void Update()
    {
        if (TestDialogueRandom.FindObjectOfType<TestDialogueRandom>().isLorenaReject == true)
        {
            if (Customer_ID[0] == 1011)
            {
                Customer_ID[0] = 1012;
            }
        }
        if (isRorenaBad == true)
        {
            if (Customer_ID[0] == 1011)
            {
                Customer_ID[0] = 1013;
            }
        }
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

            Customer_CriminalDeclareReaction[0] = "��..����...";
            Customer_CriminalDeclareReaction[1] = "��..�׷�..���..??";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
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
                    Customer_PerfumeReaction[0] = "���� ���� �Ŷ� �ٸ� �� ��������?";
                    Customer_PerfumeReaction[1] = "�̷� ���� ���µ�..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }

        }

        else if (Customer_ID[0] == 1010)// �η��� 1���� �湮
        {
            Customer_Name = "Lorena1";
            Customer_PerfumeOrder[0] = "...";
            Customer_PerfumeOrder[1] = "����";
            Customer_PerfumeOrder[2] = "������";
            Customer_PerfumeOrder[3] = "�������..��..�ࡦ";
            Customer_PerfumeOrder[4] = "......";
            Customer_PerfumeOrder[5] = "����ģ��...";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "����.. ���ص�.. ��...";

            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = "........";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "...";
            Customer_RejectReaction[1] = "�׷���..";

            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�;�..";
                    Customer_PerfumeReaction[1] = "�����մϴ�...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "..��..";
                    Customer_PerfumeReaction[1] = "�����׿�...";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    isRorenaBad = true;
                    Customer_PerfumeReaction[0] = "��...";
                    Customer_PerfumeReaction[1] = "�̰� �ƴ϶�...";
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
                    isRorenaBad = true;
                    Customer_PerfumeReaction[0] = "�̰�..";
                    Customer_PerfumeReaction[1] = "����..��..����...?";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    isRorenaBad = true;
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "...";
                    Customer_PerfumeReaction[1] = "�̰� ��ü...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1011)// �η���2��° �湮
        {
            Customer_Name = "Lorena2";
            Customer_PerfumeOrder[0] = "��...";
            Customer_PerfumeOrder[1] = "���� ķ�۽� �Ŵ� ��..., �ູ�ߴµ���.";
            Customer_PerfumeOrder[2] = "..";
            Customer_PerfumeOrder[3] = "....�׶��� �ʹ� �׸���...";
            Customer_PerfumeOrder[4] = "���� �� ���� ��...";

            for (int i = 5; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "�� ���� ����� ���������....";
            Customer_IntensityOrder[1] = "�� ���� ���� �ʿ���...";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = "...���ϴ°ž� ����?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "��...";
            Customer_RejectReaction[1] = "���� �̷��� �ʿ��ϴٴµ�...";
            Customer_RejectReaction[2] = "��ü ������ �� �׷��� �ž�?";
            Customer_RejectReaction[3] = "��°��..";

            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�� ����ģ���� ���� ����߾�...";
                    Customer_PerfumeReaction[1] = "���� ����...����...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�� ����� �¾�..";
                    Customer_PerfumeReaction[1] = "..����";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� ��ü ����...";
                    Customer_PerfumeReaction[1] = "�� �߾��� ��ġ�� ��!!";
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
                    Customer_PerfumeReaction[0] = "������ �� �׷��� �ž�..?";
                    Customer_PerfumeReaction[1] = "����� ���� ���� �ѽ���..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰� �ƴϾ�..";
                    Customer_PerfumeReaction[1] = "�ٽ� ���� �ʰھ�..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }
        else if (Customer_ID[0] == 1012)// �η���1 ���� �� �η��� 2 �ٸ��� ����.
        {
            Customer_Name = "Lorena2_1";
            Customer_PerfumeOrder[0] = "...";
            Customer_PerfumeOrder[1] = "����..";
            Customer_PerfumeOrder[2] = "������...�����..";
            Customer_PerfumeOrder[3] = "���õ�..";
            Customer_PerfumeOrder[4] = "...";
            Customer_PerfumeOrder[5] = "����ģ��..";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
            Customer_IntensityOrder[0] = "���� ������...";
            Customer_IntensityOrder[1] = "�ִ��� ������..";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = ".....���ϴ°ž� ����..?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "�ΰ�";
            Customer_Flavoring[1] = "����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "��...";
            Customer_RejectReaction[1] = "�� �׻�...";
            Customer_RejectReaction[2] = "�����Ը� �׷��� �ž�..?";


            for (int i = 2; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "��..";
                    Customer_PerfumeReaction[1] = "�� ������� �߾��� ���ö�...";
                    Customer_PerfumeReaction[2] = "";
                    Customer_PerfumeReaction[3] = "����..����...";
                    for (int i = 4; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�¾�..";
                    Customer_PerfumeReaction[1] = "�� �� ���� ã�� �־���.";

                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� �ƴϾ�..";
                    Customer_PerfumeReaction[1] = "�� �߾��� ���Ĺ����ٴ�..";
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
                    Customer_PerfumeReaction[0] = "��..";
                    Customer_PerfumeReaction[1] = "�� ����� ����...";
                    Customer_PerfumeReaction[2] = "������ ������ ��°�..?";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "����...";
                    Customer_PerfumeReaction[1] = "���� ���� ����..";
                    Customer_PerfumeReaction[2] = "�̷� �� �ƴϾ�...";
                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }
            }
        }

        else if (Customer_ID[0] == 1013)// �η���1 ���� �� �η��� 2 �ٸ��� ����.
        {
            Customer_Name = "Lorena2_2";
            Customer_PerfumeOrder[0] = "����ģ��..��...";
            Customer_PerfumeOrder[1] = "�ʹ�..�׸���..";
            Customer_PerfumeOrder[2] = "";
            Customer_PerfumeOrder[3] = "�� ���� ���� �ʿ���...";

            for (int i = 4; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }
            Customer_IntensityOrder[0] = "�츮��.. �߾���.. �� ��� ���� �ʿ���..";
            Customer_IntensityOrder[1] = "���� ������..";

            for (int i = 2; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }

            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_CriminalDeclareReaction[0] = "....";
            Customer_CriminalDeclareReaction[1] = ".....���ϴ°ž� ����..?";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "���";
            Customer_Flavoring[1] = "�б�";
            Customer_Flavoring[2] = "�ູ";

            Customer_RejectReaction[0] = "�׷�..";
            Customer_RejectReaction[1] = "���� ��� ���� ����..";
            Customer_RejectReaction[2] = "���� �̷��� ��...";
            Customer_RejectReaction[3] = "���� ���� �ʹ� �Ⱦ�..";


            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }
            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "�� ķ�۽����� ���� �ູ�ߴµ�...";
                    Customer_PerfumeReaction[1] = "����..����...";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "����..";
                    Customer_PerfumeReaction[1] = "�� ���� ���ǲ�� ���ö�..";
                    Customer_PerfumeReaction[2] = "����..";

                    for (int i = 3; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "...";
                    Customer_PerfumeReaction[1] = "�� �߾��� ���ƾ�..";
                    Customer_PerfumeReaction[2] = "������ ���� ������..";
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
                    Customer_PerfumeReaction[0] = "�̵�..�� ������ �� �ž�..?";
                    Customer_PerfumeReaction[1] = "���� �� �߸�����..";
                    for (int i = 2; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "���� ã�� ����� �ƴϾ�..";
                    Customer_PerfumeReaction[1] = "��ü �� ����ž�..?";
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
            Customer_PerfumeOrder[0] = "����� ������";
            Customer_PerfumeOrder[1] = "��� �� ���";
            Customer_PerfumeOrder[2] = "�츮 ���� �۰� �Ϳ��� �� �� ���� �ִµ�";
            Customer_PerfumeOrder[3] = "���� �� �ָ� �� ���� �־ ������ ��� �ð� �;��.";
            Customer_PerfumeOrder[4] = "�츮 ���� ���� ��ڴ� ���̿���";
            Customer_PerfumeOrder[5] = "�׷��� ����?";

            for (int i = 6; i < Customer_PerfumeOrder.Length; i++)
            {
                Customer_PerfumeOrder[i] = "";
            }

            Customer_IntensityOrder[0] = "��.. ���ϰ�.. ���ϰ� �սô�.";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

            Customer_CriminalDeclareReaction[0] = "�̰� �� �̷�?";
            Customer_CriminalDeclareReaction[1] = "�� ���� �Ѱ� �ƹ��͵� ���ٰ�!";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_Flavoring[0] = "����";
            Customer_Flavoring[1] = "�ݷ�����";
            Customer_Flavoring[2] = "���";

            Customer_RejectReaction[0] = "�ֿ�";
            Customer_RejectReaction[1] = "���� �� ���̶� �ұ� ��?";
            Customer_RejectReaction[2] = "��.. ���̰� ����";
            Customer_RejectReaction[3] = "������.. �ٽ� �ð�";
            for (int i = 4; i < Customer_RejectReaction.Length; i++)
            {
                Customer_RejectReaction[i] = "";
            }

            if (GameObject.FindObjectOfType<TotalScore>().RightItem == 3)//����ž ��� �ùٸ� ��� ����� ��� -> ���� ���� �Ǵ�
            {
                if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verygood") || (GameObject.FindObjectOfType<TotalScore>().reputation == "good"))
                {
                    Customer_PerfumeReaction[0] = "������ �� ���Կ�~";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (GameObject.FindObjectOfType<TotalScore>().reputation == "normal")
                {
                    Customer_PerfumeReaction[0] = "�� ���׿�";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if ((GameObject.FindObjectOfType<TotalScore>().reputation == "verybad") || (GameObject.FindObjectOfType<TotalScore>().reputation == "bad"))
                {
                    Customer_PerfumeReaction[0] = "�̰� �� �� �ִ°� ����...?";
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
                    Customer_PerfumeReaction[0] = "�̰� �� �� �ִ°� ����...?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
                    {
                        Customer_PerfumeReaction[i] = "";
                    }
                }

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
                {
                    //RC.GetComponent<RandomImage>().CurrentFeel = "bad";
                    Customer_PerfumeReaction[0] = "�̰� �� �� �ִ°� ����...?";
                    for (int i = 1; i < Customer_PerfumeReaction.Length; i++)
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

            Customer_CriminalDeclareReaction[0] = "����??!!";
            Customer_CriminalDeclareReaction[1] = "¥����!!";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
            }

            Customer_IntensityOrder[0] = "���� ������ ���ּ���!!";
            for (int i = 1; i < Customer_IntensityOrder.Length; i++)
            {
                Customer_IntensityOrder[i] = "";
            }
            Distiller.GetComponent<Distiller>().DistillerStatus = "����";

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

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
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

            Customer_CriminalDeclareReaction[0] = "���� �ֿ�??";
            Customer_CriminalDeclareReaction[1] = "�̻��� ����̾� ����";

            for (int i = 2; i < Customer_CriminalDeclareReaction.Length; i++)
            {
                Customer_CriminalDeclareReaction[i] = "";
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

                else if (TotalScore.FindObjectOfType<TotalScore>().isAllFinished == true)
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
    }
}
