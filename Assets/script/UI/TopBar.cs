using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    public GameObject DailyResult;
    public void OnDayBtnClicked()
    {
        if (DailyResult.activeSelf)
            DailyResult.SetActive(false);
        else
            DailyResult.SetActive(true);
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
