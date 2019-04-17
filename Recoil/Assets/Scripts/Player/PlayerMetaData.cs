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
    public bool speed;
    public string currentAbility;
    public int numberOfHealthUpgrades;

    public PlayerMetaData(int maxHP, int currHP, int wealth, string scene, float[] pos, bool[] upgradesFound, bool[] scenesVisited, bool[] gunsFound, int[] selectedGuns, int currentGunIndex, bool magnet, bool flower, bool speed, string currentAbility, int numberOfHealthUpgrades) {
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
        this.speed = speed;
        this.currentAbility = currentAbility;
        this.numberOfHealthUpgrades = numberOfHealthUpgrades;
    }
}
