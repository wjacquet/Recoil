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
    public bool[] scenesVisited;

    public PlayerMetaData(int maxHP, int wealth, string scene, float[] pos, bool[] upgradesFound, bool[] scenesVisited) {
        this.maxHP = maxHP;
        this.currHP = maxHP;
        this.wealth = wealth;
        this.scene = scene;
        this.position = pos;
        this.upgradesFound = upgradesFound;
        this.scenesVisited = scenesVisited;
    }
}
