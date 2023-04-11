using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoad : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider reputationSlider;

    private GameData gameData;
    void Awake()
    {
        if (GameDataManager.Instance.Day > 1)//로드를 한 경우
        {
            NextDay.FindObjectOfType<NextDay>().DayCheckTest();

            GameDataManager.Instance.LoadInvenData();

            bgmSlider.value = GameDataManager.Instance.BGM;
            sfxSlider.value = GameDataManager.Instance.SFX;
            reputationSlider.value = GameDataManager.Instance.ReputationValue;

            if (GameDataManager.Instance.Reputation <= 30)
            {
                GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationBad;
            }
            else if (GameDataManager.Instance.Reputation <= 60 && GameDataManager.Instance.Reputation > 30)
            {
                GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationNormal;
            }
            else if (GameDataManager.Instance.Reputation > 60)
            {
                GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationGood;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
