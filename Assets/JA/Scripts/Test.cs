using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
       Customer a = CustomerManager.Instance.days.day[0].customer[0];
       
       print(a.id);
       print(a.name);
       print(a.criminalGuest);
       print(a.uniqueGuest);
       foreach (var VARIABLE in a.dialogue.refusalComment)
       {
           print(VARIABLE);
       }

        //foreach (var v in CustomerManager.Instance.days[0].customer[0].dialogue.ResultGoodComment)
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
