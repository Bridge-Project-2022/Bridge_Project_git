using System.Collections.Generic;

// public enum CustomerState
// {
//     VisitGeneral, // 일반적인 방문 인사
//     VisitComment, // 캐릭터 방문 인사
//     RefusalComment, // 캐릭터 거절 대사
//     RequestComment, // 향 요청 대사
//     ResultCommentGood, // 결과 대사/
//     ResultCommentNormal, // 결과 대사
//     ResultCommentBad, // 결과 대사
//     NoExist, // 없다
//     NoFlavor // 향료가 없다.
// }

public enum CustomerFace
{
    sad,
    happy,
}

/// <summary>
/// 사용하지 않음
/// </summary>
public class DialogueManager : Singleton<DialogueManager>
{
    protected DialogueManager() { }

    private List<Dictionary<string, object>> data_DialogCustomer = null;

    //private Dictionary<CustomerState, Dictionary<CustomerFace, string>> data_DialogCustomer = null; real
    
    
    //private List<Dictionary<string, object>> data_DialogOwner = null;
    
    private enum Type 
    {
        Number,
        CustomerID,
        State,
        Content
    }
    
    void Awake()
    {
        data_DialogCustomer = CSVReader.Read("Dialog_Customer");
        //data_DialogCustomer = CSVReader.Read("Dialog_Owner");
    }
    
    /// <summary>
    /// 손님 id와 상태를 매개변수로 입력하면 해당 스크립트가 문자열로 반환됩니다.
    /// </summary>
    /// <param name="customerID">찾고자 하는 ID</param>
    /// <param name="state">현재 상태</param>
    /// <returns></returns>
    // public string DialogueToString(int customerID, CustomerState state)
    // {
    //     string temp = null;
    //     int id;
    //
    //     id = SearchCustomerID(customerID);
    //     if (id == -1)
    //     {
    //         Debug.LogError("Customer id that does not exist");
    //         return null;
    //     }
    //     
    //     for (int i = id; i <  data_DialogCustomer.Count; i++)
    //     {
    //         if (data_DialogCustomer[i][Type.State.ToString()].Equals((string)state.ToString()))
    //         {
    //             id = i;
    //             break;
    //         }
    //     }
    //
    //     temp = (string)data_DialogCustomer[id][Type.Content.ToString()];
    //
    //     return temp;
    // }

    /// <summary>
    /// 파싱된 csv파일을 순회하며 해당 id를 찾습니다.
    /// </summary>
    /// <param name="id">검색할 손님 id</param>
    /// <returns></returns>
    private int SearchCustomerID(int id)
    {
        for (int i = 0; i <  data_DialogCustomer.Count; i++)
        {
            if ((int)data_DialogCustomer[i][Type.CustomerID.ToString()] == id)
            {
                return i;
            }
        }

        return -1;
    }
}

/// TryGetValue 방식을 고민해 볼 것


