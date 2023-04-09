using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int money;
    public int day;
    public int reputation;
    public float reputationValue;
    public float bgm;
    public float sfx;
    public bool soundEnable;
    public List<ItemProperty> baseItemList;
    public List<ItemProperty> middleItemList;
    public List<ItemProperty> topItemList;

    public GameData()
    {
        this.money = 10000;
        this.day = 1;
        this.reputation = 60;
        this.reputationValue = 0.6f;
        this.bgm = 1.0f;
        this.sfx = 1.0f;
        this.soundEnable = false;
        this.baseItemList = new List<ItemProperty>();
        this.middleItemList = new List<ItemProperty>();
        this.topItemList = new List<ItemProperty>();
    }
}
