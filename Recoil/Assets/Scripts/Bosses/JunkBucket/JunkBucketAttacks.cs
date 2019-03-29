using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBucketAttacks : MonoBehaviour
{
    public GameObject photonShot;
    public GameObject projectile;
    public GameObject enemySpawn;

    private bool shouldScorchers = false;
    private bool shot = false;

    private Vector3 projectileSpawnPos = new Vector3(288.5f, 341f, 0f);

    void Start() 
    {
        //shootPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!shot) shootPhoton();
        shot = true;
    }


    public void shootPhoton() 
    {        
        GameObject proj = Instantiate(photonShot, projectileSpawnPos, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
    }

    public void startScorch() 
    {
        JunkScorchers.shouldFlame = true;
    }
}
