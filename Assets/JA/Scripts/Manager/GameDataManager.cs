using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class GameDataManager : Singleton<GameDataManager>
{
    protected GameDataManager() { }

    private GameData gameData;

    //private const string newGameDataFileName = "GameData";
    private const string runTimeGameDataFileName = "run_GameData";


    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public bool isGameStart = false;
    private void Awake()
    {
        
        
    }

    private void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        
        dataHandler = new FileDataHandler(Application.persistentDataPath, runTimeGameDataFileName);
    }

    #region Property

    public int Money
    {
        get => gameData.money;
        set => gameData.money = Mathf.Clamp(value, 0, 999999);
    }

    public int Day
    {
        get => gameData.day;
        set => gameData.day = Mathf.Clamp(value, 0, 9);
    }

    public int Reputation
    {
        get => gameData.reputation;
        set => gameData.reputation = Mathf.Clamp(value, 0, 100);
    }
    public float ReputationValue
    {
        get => gameData.reputationValue;
        set => gameData.reputationValue = Mathf.Clamp(value, 0, 100);
    }

    public float BGM
    {
        get => gameData.bgm;
        set => gameData.bgm = Mathf.Clamp(value, 0, 100);
    }
    public float SFX
    {
        get => gameData.sfx;
        set => gameData.sfx = Mathf.Clamp(value, 0, 100);
    }

    public bool SoundEnable
    {
        get => gameData.soundEnable;
        set => gameData.soundEnable = value;
    }
    
    public void AddBaseItem(ItemProperty item)
    {
        if (item == null)
            return;
        if(gameData.baseItemList.Contains(item))
        {
            gameData.baseItemList.Find(x => x == item).itemCount += 1;
        }
        else
        {
            gameData.baseItemList.Add(item);
        }
    }
    public void AddMiddleItem(ItemProperty item)
    {
        if (item == null)
            return;
        if (gameData.middleItemList.Contains(item))
        {
            gameData.middleItemList.Find(x => x == item).itemCount += 1;
        }
        else
        {
            gameData.middleItemList.Add(item);
        }
    }
    public void AddTopItem(ItemProperty item)
    {
        if (item == null)
            return;
        if (gameData.topItemList.Contains(item))
        {
            gameData.topItemList.Find(x => x == item).itemCount += 1;
        }
        else
        {
            gameData.topItemList.Add(item);
        }
    }

    /*public void RemoveItem(ItemProperty item)
    {
        if (item == null)
            return;
        if(gameData.itemList.Contains(item))
        {
            gameData.itemList.Find(x => x == item).itemCount -= 1;
        }
    }*/

    #endregion 

    #region PublicMethod

    /// <summary>
    /// 게임 시작 후 첫 시작의 경우 호출
    /// </summary>
    public void NewGameStart()
    {
        // 초기화 추가
        gameData = new GameData();
        isGameStart = true;
        // 추가적인 newGame 게임 세팅 여기서
        // ...
        
    }

    /// <summary>
    /// 하루가 종료되었을 때 호출
    /// </summary>
    public void SaveData()
    {

        foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
        {
            dataPersistence.SaveData(ref gameData);
        }
        // 저장 후 처리
        
        dataHandler.Save(gameData);
    }
    
    /// <summary>
    /// 이어하기 클릭 후 호출
    /// </summary>
    public void LoadData()
    {
        this.gameData = dataHandler.Load();
        
        if (this.gameData == null)
        {
            NewGameStart();
        }
        
        SceneManager.LoadScene("Main");
        // 불러오기 처리

        foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
        {
            dataPersistence.LoadData(gameData);
        }
    }

    #endregion

    #region UtillsMethod

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }

    private void GameDataJsonLoad(string fileName)
    {

        /*Debug.Log(GameDataManager.Instance.Money);
        Debug.Log(GameDataManager.Instance.Day);
        Debug.Log(GameDataManager.Instance.Reputation);
        Debug.Log(GameDataManager.Instance.BGM);
        Debug.Log(GameDataManager.Instance.SoundEnable);
        */
         // FirstDaySetting.FindObjectOfType<FirstDaySetting>().Money = GameDataManager.Instance.Money;
         // NextDay.FindObjectOfType<NextDay>().day = GameDataManager.Instance.Day - 1;
         // FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation = GameDataManager.Instance.Reputation;
         // GameObject.Find("ReputationSlider").GetComponent<Slider>().value = GameDataManager.Instance.ReputationValue;
         // GameObject.Find("Panels").transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<Slider>().value = GameDataManager.Instance.BGM;
         // GameObject.Find("Panels").transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<Slider>().value = GameDataManager.Instance.SFX;
         // GameObject.Find("SoundManager").GetComponent<SoundController>().isBGMOn = GameDataManager.Instance.SoundEnable;
         //
         // if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation <= 30)
         // {
         //     GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationBad;
         // }
         // else if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation <= 60 && FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation > 30)
         // {
         //     GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationNormal;
         // }
         // else if (FirstDaySetting.FindObjectOfType<FirstDaySetting>().Reputation > 60)
         // {
         //     GameObject.Find("ReputationHandle").GetComponent<Image>().sprite = TotalScore.FindObjectOfType<TotalScore>().ReputationGood;
         // }
        
        // Inventory.FindObjectOfType<Inventory>().ResetInven();
        // for (int i = 0; i < gameData.baseItemList.Count; i++)
        // {
        //     gameData.baseItemList[i].InvenItemNum -= 1;
        //     Inventory.FindObjectOfType<Inventory>().BuyItem(gameData.baseItemList[i]);
        // }
        // for (int i = 0; i < gameData.middleItemList.Count; i++)
        // {
        //     gameData.middleItemList[i].InvenItemNum -= 1;
        //     Inventory.FindObjectOfType<Inventory>().BuyItem(gameData.middleItemList[i]);
        // }
        // for (int i = 0; i < gameData.topItemList.Count; i++)
        // {
        //     gameData.topItemList[i].InvenItemNum -= 1;
        //     Inventory.FindObjectOfType<Inventory>().BuyItem(gameData.topItemList[i]);
        // }
        // NextDay.FindObjectOfType<NextDay>().NextDayClick();
    }
    

    #endregion
}

// 1. 새로운 게임의 경우 데이터를 초기화 해야함 즉, 기초 데이터 테이블 필요
// 2. 이어하기, 저장하기 즉, 게임 도중에 생성 및 삭제 해야 하는 데이터