using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBucketAttacks : MonoBehaviour
{
    public GameObject photonShot;
    public GameObject projectile;
    public GameObject enemySpawn;

    private bool shouldScorchers = false;

    // Update is called once per frame
    void Update()
    {
        startScorch();
    }



    public void startScorch() 
    {
        JunkScorchers.shouldFlame = true;
    }
}
