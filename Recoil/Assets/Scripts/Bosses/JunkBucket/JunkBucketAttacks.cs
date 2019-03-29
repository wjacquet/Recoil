using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBucketAttacks : MonoBehaviour
{
    public GameObject photonShot;
    public GameObject projectile;
    public GameObject enemySpawn;

    // private bool shouldScorchers = false;
    private bool newAttack = false;
    private bool allowStream = false;
    private bool shot = false;

    private int firstSpreadDegree = 25;
    private int secondSpreadDegree = 15;

    private int atkSelector;
    private Vector3 projectileSpawnPos = new Vector3(288.5f, 341f, 0f);

    void OnEnable()
    {
        StartCoroutine(startScorch());
    }

    // Update is called once per frame
    void Update()
    {
        if (newAttack) {
            atkSelector = Random.Range(0, 5);

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
                    StartCoroutine(startStream());
                    break;
                case 4:
                    StartCoroutine(startStream());
                    break;
            }

            newAttack = false;
        }

        if (allowStream) 
        {
            shootStream();
        }
    }

    public void shootStream() 
    {
        GameObject proj = Instantiate(projectile, projectileSpawnPos, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
    }

    IEnumerator startStream() 
    {
        allowStream = true;
        yield return new WaitForSeconds(2.0f);
        newAttack = true;
        yield return new WaitForSeconds(1.0f);
        allowStream = false;
    }

    IEnumerator shootPhoton() 
    {        
        GameObject proj = Instantiate(photonShot, projectileSpawnPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(proj, 120);    
        yield return new WaitForSeconds(2.0f);
        newAttack = true;
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator startScorch() 
    {
        JunkScorchers.shouldFlame = true;
        yield return new WaitForSeconds(2.0f);
        newAttack = true;
        yield return new WaitForSeconds(1.0f);
        JunkScorchers.shouldFlame = false;
    }


    
    IEnumerator FirstSpread() {
        StandardFireFunctions.FireAtPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), firstSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), -firstSpreadDegree);
        yield return new WaitForSeconds(1.5f);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), secondSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(projectile, projectileSpawnPos, transform.rotation), -secondSpreadDegree);
    }
}
