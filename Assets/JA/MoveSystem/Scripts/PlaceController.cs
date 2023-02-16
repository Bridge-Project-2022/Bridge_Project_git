using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlaceDialogDB data;
    
    [Header("Places")]
    [SerializeField] private List<Place> places;
    
    public int VisitableNum { get; private set; }
    public int SpecialNum { get; private set; }

    private void Start()
    {
        Init();
        ReSearchPlace();
        Rendering();
    }

    private void Init()
    {
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
        List<PlaceDialogDBEntity> placeDialogList = new List<PlaceDialogDBEntity>();
        
        for (int i = 0; i < data.PlaceEntity.Count; i++)
        {
            if (data.PlaceEntity[i].day == curDay && data.PlaceEntity[i].place == curPlace)
            {
                placeDialogList.Add(data.PlaceEntity[i]);
            }
        }

        return placeDialogList;
    }
}


// cutsene으로 넘겨주는 데이터 -> 내용(순차), 말하는 사람, 스프라이트 정보, 장소, 현재 날짜
// 즉 전체 데이터를 만들고 해당 날짜, 장소가 동일하면 데이터를 cutscene으로 넘겨줌 getPlaceDialogData()