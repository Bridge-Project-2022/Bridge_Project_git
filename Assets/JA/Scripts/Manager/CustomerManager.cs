using System;
using System.IO;
using UnityEngine;

public class CustomerManager : Singleton<CustomerManager>
{
    protected CustomerManager() { }

    private string fileName = "CustomerData.json";
    
    public Day[] days;
    private int dayNum = 5;
    private int oneDayCustomer = 9;
    
    private void Awake()
    {
        Init();

        CustomerJsonLoad();

        //MakeJsonFile();
    }

    /// <summary>
    /// json파일을 로드하는 메서드
    /// 데이터 변경 시 호출
    /// </summary>
    private void CustomerJsonLoad()
    {
        string fromjson = File.ReadAllText(Application.dataPath + "/JA/" + fileName);
        days = JsonHelper.FromJson<Day>(fromjson);
    }

    /// <summary>
    /// json파일 생성하는 메서드
    /// 형식이 바뀔때 호출
    /// </summary>
    private void MakeJsonFile()
    {
        string toJson = JsonHelper.ToJson(days, prettyPrint: true);
        File.WriteAllText(Application.dataPath + "/JA/" + fileName, toJson);
    }

    private void Init()
    {
        days = new Day[dayNum];
        for (int i = 0; i < days.Length; i++)
        {
            days[i] = new Day();
            days[i].customer = new Customer[oneDayCustomer];
            for (int j = 0; j < days[i].customer.Length; j++)
            {
                days[i].customer[j] = new Customer();
                days[i].customer[j].dialogue = new Dialogue();
                days[i].customer[j].currentPerfume = new Perfume();
            }
        }
    }
}
