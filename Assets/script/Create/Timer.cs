using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public bool isTimerStart = false;

    private void Update()
    {
        if (isTimerStart == true)
        {
            TimerStart();
        }
    }
    public void TimerStart()
    {
        time += Time.deltaTime;
        TotalScore.FindObjectOfType<TotalScore>().totalTime = Mathf.Round(time);
        //Debug.Log("½Ã°£ : " + Mathf.Round(time));
    }

    public void TimerStop()
    {
        time = 0;
        isTimerStart = false;
    }
}
