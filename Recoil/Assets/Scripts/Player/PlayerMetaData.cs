using System;

[Serializable]

public class PlayerMetaData
{
    public int maxHP;
    public int currHP;
    public int wealth;
    public string scene;
    public float[] position;
    public bool[] upgradesFound;

    public PlayerMetaData(int maxHP, int wealth, string scene, float[] pos, bool[] upgradesFound) {
        this.maxHP = maxHP;
        this.currHP = maxHP;
        this.wealth = wealth;
        this.scene = scene;
        this.position = pos;
        this.upgradesFound = upgradesFound;
    }
}
