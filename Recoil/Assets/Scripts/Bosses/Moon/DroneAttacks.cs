using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttacks : MonoBehaviour
{
    public GameObject proj;
    public GameObject photonProj;
    // Start is called before the first frame update

    private Vector3 blasterPos;
    ShipMovement DroneMovement;
    EnemyHealth DroneHealth;
    private int prevDest;

    GameObject tempProj;
    void Start()
    {
        blasterPos = transform.position;
        blasterPos.y = blasterPos.y - 18;
        DroneMovement = gameObject.GetComponent<ShipMovement>();
        DroneHealth = gameObject.GetComponent<EnemyHealth>();
        StartCoroutine(AttackDecider());
        StartCoroutine(MovementDecider());
        DroneMovement.TriggerLeftMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        blasterPos = transform.position;
        blasterPos.y = blasterPos.y - 18;   

        if (transform.position == DroneMovement.GetLeft()) {
            DroneMovement.TriggerRightMovement();
        }
        else if (transform.position == DroneMovement.GetRight()) {
            DroneMovement.TriggerLeftMovement();
        }

        if (DroneHealth.getCurrHP() < 5000) {
            // Spawn the second phase
        }
    }

    IEnumerator AttackDecider() 
    {
        while (true) {
            int atkSelector = Random.Range(0,4);

            switch(atkSelector) {
                case 0:
                    StartCoroutine(FireThreeDRoundBurst());
                    break;
                case 1:
                    StartCoroutine(FireWaves());
                    break;
                case 2:
                    StartCoroutine(FirePhoton());
                    break;
                case 3:
                    StartCoroutine(FireClusterBlast());
                    yield return new WaitForSeconds(2.0f);
                    break;
            }
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator MovementDecider() 
    {
        while (true) {
            int movSelector = Random.Range(0,4);

            if (movSelector == prevDest) continue;

            if (movSelector == 3 && DroneMovement.isStationary()) {
                movSelector = Random.Range(0,3);
            }

            switch(movSelector) {
                case 0:
                    DroneMovement.TriggerRightMovement();
                    break;
                case 1:
                    DroneMovement.TriggerLeftMovement();
                    break;
                case 2:
                    DroneMovement.TriggerMidMovement();
                    break;
                case 3:
                    DroneMovement.PauseMovement();
                    break;
            }
            prevDest = movSelector;
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator FireThreeDRoundBurst() 
    {
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
    }

    IEnumerator FireWaves() 
    {
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, 20, 100);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, -20, 100);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);

        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, 10, 100);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, -10, 100);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, 28, 100);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownDegreeOffset(tempProj, -28, 100);
    }

    IEnumerator FirePhoton() 
    {        
        GameObject tempProj = Instantiate(photonProj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 85);
        yield return new WaitForSeconds(0.75f);
    }

    IEnumerator FireClusterBlast() 
    {
        GenerateCluster();
        yield return new WaitForSeconds(0.85f);
        GenerateCluster();
        yield return new WaitForSeconds(0.85f);
        GenerateCluster();
    }

    void GenerateCluster() 
    {
        GameObject tempProj;
        for (int i = 0; i < 12; i++) {
            tempProj = Instantiate(proj, transform.position, transform.rotation);

            StandardFireFunctions.FireClusterDown(tempProj);
        }
    }
}
