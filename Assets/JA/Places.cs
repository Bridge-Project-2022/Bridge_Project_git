using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour
{
    [SerializeField] private List<Place> places;

    public int VisitableNum { get; private set; }
    public int SpecialNum { get; private set; }

    private void Start()
    {
        ReSearchPlace();
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

    public void VisitPlace(Enums.MoveButton placeType)
    {
        foreach (var place in places)
        {
            place.TryVisitPlace(placeType);
        }

        ReSearchPlace();
    }
}
