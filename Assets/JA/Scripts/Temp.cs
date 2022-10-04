using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    void Start()
    {
        //print(DialogueManager.Instance.DialogueToString(1, CustomerState.VisitComment));
        print(DialogueManager.Instance.DialogueToString(0,CustomerState.NoExist));
    }
    
}
