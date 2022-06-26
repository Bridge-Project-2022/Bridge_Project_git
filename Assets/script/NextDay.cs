using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    public int day = 1;
    GameObject Trigger;
    public string SceneName;

    public void NextDayClick()
    {
        Trigger = GameObject.Find("Trigger").gameObject;
        if (day == 1)
        {
            day++;
            Trigger.GetComponent<DialogueRandom>().enabled = false;
            Trigger.GetComponent<SecondDialogueRandom>().enabled = true;
            SceneName = "SecondDay";
            SceneManager.LoadScene(SceneName);
        }
        OnEnable(); 
    }

    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.GetComponent<Store>().Start();
    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
