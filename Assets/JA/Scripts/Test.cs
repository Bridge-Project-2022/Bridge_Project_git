using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        //Debug.Log(CustomerManager.Instance.days[0].customer[0].dialogue.ResultGoodComment[1]);

        foreach (var v in CustomerManager.Instance.days[0].customer[0].dialogue.ResultGoodComment)
        {
            Debug.Log(v);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
