using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResult : MonoBehaviour
{
    public Text personText;//총 방문객 수
    public Text rejectPersonText;//거절 횟수
    public Text reputationText;//평판
    public Text revenueText;// 순수익 = 전체 수익 - 사용 향료 원가
    public Text costText;//사용한 향료 원가
    public Text allRevenueText;//전체 수익


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
