using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBucketAttacks : MonoBehaviour
{
    public GameObject photonShot;
    public GameObject projectile;
    //public GameObject enemySpawn;

    private bool newAttack = false;
    private bool allowStream = false;

    private int firstSpreadDegree = 25;
    private int secondSpreadDegree = 15;

    private int atkSelector;
    private Vector3 projectileSpawnPos = new Vector3(288.5f, 366f, 0f);

    void OnEnable()
    {
        StartCoroutine(startScorch());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (newAttack) {
            atkSelector = Random.Range(0, 5);
            newAttack = false;

            switch(atkSelector) {
                case 0:
                    StartCoroutine(startStream());
                    break;
                case 1:
                    StartCoroutine(startScorch());
                    break;
                case 2:
                    StartCoroutine(shootPhoton());
                    break;
                case 3:
                    StartCoroutine(shootSpread());
                    break;
                case 4:
                    StartCoroutine(idle());
                    break;
            }
        }

        if (allowStream) 
        {
            shootStream();
        }
    }

    IEnumerator idle() 
    {
        yield return new WaitForSeconds(1.5f);
        newAttack = true;
    }

    public void shootStream() 
    {
        GameObject proj = Instantiate(projectile, projectileSpawnPos, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
    }

    IEnumerator startStream() 
    {
        allowStream = true;
        yield return new WaitForSeconds(1.25f);
        allowStream = false;
        yield return new WaitForSeconds(1.0f);
        newAttack = true;
        
    }

    IEnumerator shootPhoton() 
    {        
        GameObject proj = Instantiate(photonShot, projectileSpawnPos, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
        yield return new WaitForSeconds(2.5f);
        newAttack = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator startScorch() 
    {
        JunkScorchers.shouldFlame = true;
        yield return new WaitForSeconds(2.5f);
        newAttack = true;
        yield return new WaitForSeconds(0.5f);
        JunkScorchers.shouldFlame = false;
    }


    
    IEnumerator shootSpread() {
        StandardFireFunctions.FireAtPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), firstSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), -firstSpreadDegree);
        yield return new WaitForSeconds(1.5f);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), secondSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), -secondSpreadDegree);
        yield return new WaitForSeconds(1.0f);
        newAttack = true;
    }
}
