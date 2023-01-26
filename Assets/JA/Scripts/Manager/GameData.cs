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
}
