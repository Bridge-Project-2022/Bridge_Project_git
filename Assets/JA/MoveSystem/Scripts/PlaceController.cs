using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlaceDialogDB data;
    
    [Header("Places")]
    [SerializeField] private List<Place> places;
    
    public int VisitableNum { get; private set; }
    public int SpecialNum { get; private set; }
    
    //private Dictionary<Enums.MoveButton, PlaceDialogDBEntity> placeDialogDic = new Dictionary<Enums.MoveButton, PlaceDialogDBEntity>();

    private void Start()
    {
        Init();
        ReSearchPlace();
        Rendering();
    }

    private void Init()
    {
        //placeDialogDic.Clear();

        // foreach (var item in data.PlaceEntity)
        // {
        //     if (!placeDialogDic.ContainsKey(item.place))
        //         placeDialogDic.Add(item.place, item);
        // }
        
        if (data.PlaceEntity == null)
            data = Resources.Load<PlaceDialogDB>("Data/PlaceDialogDB");

        for (int i = 0; i < data.PlaceEntity.Count; i++)
        {
            if (data.PlaceEntity[i].day == GameDataManager.Instance.Day)
            {
                foreach (var place in places)
                {
                    if (place.PlaceState == data.PlaceEntity[i].place)
                    {
                        place.SetVisitable(data.PlaceEntity[i].special);
                    }
                }
            }
        }

        foreach (var place in places)
        {
            if (place.PlaceState == Enums.MoveButton.RootOfReadButton)
            {
                place.SetVisitable(false);
            }
        }
    }
    
    private void ReSearchPlace()
    {
        VisitableNum = 0;
        SpecialNum = 0;

        foreach (var place in places)
        {
            if (place.IsVisitable)
            {
                VisitableNum++;
            }

            if (place.IsSpecial)
            {
                SpecialNum++;
            }
        }
    }

    private void Rendering()
    {
        foreach (var place in places)
        {
            place.Rendering();
        }
    }

    public void VisitPlace(Enums.MoveButton placeType)
    {
        foreach (var place in places)
        {
            place.TryVisitPlace(placeType);
        }

        ReSearchPlace();
    }

    public List<PlaceDialogDBEntity> GetPlaceDialogData(int curDay, Enums.MoveButton curPlace)
    {
        // List<PlaceDialogDBEntity> placeDialogList = new List<PlaceDialogDBEntity>();
        //
        // for (int i = 0; i < data.PlaceEntity.Count; i++)
        // {
        //     if (data.PlaceEntity[i].day == curDay && data.PlaceEntity[i].place == curPlace)
        //     {
        //         placeDialogList.Add(data.PlaceEntity[i]);
        //     }
        // }

        List<PlaceDialogDBEntity> placeDialogList = (from dialogDB in data.PlaceEntity
            where dialogDB.day == curDay && dialogDB.place == curPlace
            select dialogDB).ToList();

        return placeDialogList;
    }
    
    public bool IsUniquePlace(Enums.MoveButton placeType)
    {
        foreach (var place in places)
        {
            if (place.PlaceState == placeType)
            {
                return place.IsSpecial;
            }
        }

        return false;
    }
}


// cutsene으로 넘겨주는 데이터 -> 내용(순차), 말하는 사람, 스프라이트 정보, 장소, 현재 날짜
// 즉 전체 데이터를 만들고 해당 날짜, 장소가 동일하면 데이터를 cutscene으로 넘겨줌 getPlaceDialogData()