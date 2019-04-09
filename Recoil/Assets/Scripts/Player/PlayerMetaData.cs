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
    public bool[] gunsFound;
    public int[] selectedGuns;
    public int currentGunIndex;
    public bool magnet;
    public bool flower;
    public string currentAbility;

    public PlayerMetaData(int maxHP, int currHP, int wealth, string scene, float[] pos, bool[] upgradesFound, bool[] scenesVisited, bool[] gunsFound, int[] selectedGuns, int currentGunIndex, bool magnet, bool flower, string currentAbility) {
        this.maxHP = maxHP;
        this.currHP = currHP;
        this.wealth = wealth;
        this.scene = scene;
        this.position = pos;
        this.upgradesFound = upgradesFound;
        this.scenesVisited = scenesVisited;
        this.gunsFound = gunsFound;
        this.selectedGuns = selectedGuns;
        this.currentGunIndex = currentGunIndex;
        this.magnet = magnet;
        this.flower = flower;
        this.currentAbility = currentAbility;
    }
}
