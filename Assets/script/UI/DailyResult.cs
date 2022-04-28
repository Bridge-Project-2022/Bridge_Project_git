using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResult : MonoBehaviour
{
    public Text personText;//�� �湮�� ��
    public Text rejectPersonText;//���� Ƚ��
    public Text reputationText;//����
    public Text revenueText;// ������ = ��ü ���� - ��� ��� ����
    public Text costText;//����� ��� ����
    public Text allRevenueText;//��ü ����


    public int personNum = 0;
    public int rejectNum = 0;
    public int todayReputation = 0;
    public int todayRevenue = 0;
    public int originCost = 0;
    public int allRevenue = 0;


    // Update is called once per frame
    void Update()
    {
        todayRevenue = allRevenue - originCost;

        personText.text = personNum.ToString();
        rejectPersonText.text = rejectNum.ToString();
        reputationText.text = todayReputation.ToString();
        revenueText.text = todayRevenue.ToString();
        costText.text = originCost.ToString();
        allRevenueText.text = allRevenue.ToString();

    }
}
