using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    protected GameDataManager() { }

    private GameData gameData;

    private string newGameDataFileName = "GameData";
    private string runTimeGameDataFileName = "run_GameData";

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

    public float Sound
    {
        get => gameData.sound;
        set => gameData.sound = Mathf.Clamp(value, 0, 100);
    }

    public bool SoundEnable
    {
        get => gameData.soundEnable;
        set => gameData.soundEnable = value;
    }
    
    public void AddItem(ItemProperty item)
    {
        if (item == null)
            return;
        gameData.itemList.Add(item);
    }

    public void RemoveItem(ItemProperty item)
    {
        if (item == null)
            return;
        gameData.itemList.Remove(item); // 아이템 데이터 삭제 물어볼 것
    }

    private void Awake()
    {
        gameData = new GameData();
        gameData.itemList = new List<ItemProperty>();
    }

    /// <summary>
    /// 게임 시작 후 첫 시작의 경우 호출
    /// </summary>
    public void NewGameStart()
    {
        GameDataJsonLoad(newGameDataFileName);
        GameDataJsonSave(runTimeGameDataFileName);
        // 추가적인 newGame 게임 세팅 여기서
        // ...
    }

    /// <summary>
    /// 하루가 종료되었을 때 호출
    /// </summary>
    public void SaveData()
    {
        GameDataJsonSave(runTimeGameDataFileName);
        // 저장 후 처리
    }
    
    /// <summary>
    /// 이어하기 클릭 후 호출
    /// </summary>
    public void LoadData()
    {
        GameDataJsonLoad(runTimeGameDataFileName);
        // 불러오기 처리
    }

    #region UtillsMethod

    private void GameDataJsonLoad(string fileName)
    {
        var fromJson = Resources.Load<TextAsset>("Json/" + fileName);
        gameData = JsonUtility.FromJson<GameData>(fromJson.ToString());
    }

    private void GameDataJsonSave(string fileName)
    {
        string toJson = JsonUtility.ToJson(gameData, prettyPrint: true);
        File.WriteAllText(Application.dataPath + "/Resources/Json/" + fileName+".txt", toJson);
    }

    #endregion
}

// 1. 새로운 게임의 경우 데이터를 초기화 해야함 즉, 기초 데이터 테이블 필요
// 2. 이어하기, 저장하기 즉, 게임 도중에 생성 및 삭제 해야 하는 데이터