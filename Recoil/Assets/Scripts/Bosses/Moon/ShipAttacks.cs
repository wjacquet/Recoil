using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttacks : MonoBehaviour
{
    public GameObject proj;
    public GameObject photonProj;
    public GameObject bombProj;
    public GameObject laserProj;
    public GameObject warningLaserProj;
    // Start is called before the first frame update

    private Vector3 blasterPos, leftCannonPos, rightCannonPos;
    
    ShipMovement DroneMovement;
    EnemyHealth DroneHealth;
    private int prevDest;
    private bool allowMovement = true;

    GameObject tempProj;

    void OnEnable()
    {
        SetWeaponPositions();
        DroneMovement = gameObject.GetComponent<ShipMovement>();
        DroneHealth = gameObject.GetComponent<EnemyHealth>();
        StartCoroutine(AttackDecider());
        StartCoroutine(MovementDecider());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetWeaponPositions();   

        if (transform.position == DroneMovement.GetLeft()) {
            DroneMovement.TriggerRightMovement();
        }
        else if (transform.position == DroneMovement.GetRight()) {
            DroneMovement.TriggerLeftMovement();
        }
    }

    IEnumerator AttackDecider() 
    {
        yield return new WaitForSeconds(2.0f);
        while (true) {
            int atkSelector = Random.Range(0,6);

            switch(atkSelector) {
                case 0:
                    StartCoroutine(FireThreeWaveBurstCenter());
                    break;
                case 1:
                    StartCoroutine(FireWaves());
                    StartCoroutine(FireThreeDRoundBurstRight());
                    StartCoroutine(FireThreeDRoundBurstLeft());
                    break;
                case 2:
                    StartCoroutine(FirePhotonLeft());
                    StartCoroutine(FirePhotonRight());
                    break;
                case 3:
                    StartCoroutine(FireClusterBlastLeft());
                    StartCoroutine(FireClusterBlastRight());
                    yield return new WaitForSeconds(2.0f);
                    break;
                case 4:
                    StartCoroutine(ShootExplosionPattern());
                    yield return new WaitForSeconds(4.0f);
                    break;
                case 5: 
                    allowMovement = false;
                    DroneMovement.PauseMovement();
                    yield return new WaitForSeconds(1.0f);
                    DroneMovement.PauseMovement();
                    StartCoroutine(FireLeftWave(leftCannonPos));
                    StartCoroutine(FireRightWave(rightCannonPos));
                    yield return new WaitForSeconds(4.0f);
                    allowMovement = true;
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

            if (!allowMovement) movSelector = 3;

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

    IEnumerator FireLeftWave(Vector3 pos) 
    {
        int angle = 90;
        while (angle != 0) {
            tempProj = Instantiate(proj, pos, transform.rotation);
            StandardFireFunctions.FireDownDegreeOffset(tempProj, angle, 100); 
            angle -= 5;
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    IEnumerator FireRightWave(Vector3 pos) 
    {
        int angle = -90;
        while (angle != 0) {
            tempProj = Instantiate(proj, pos, transform.rotation);
            StandardFireFunctions.FireDownDegreeOffset(tempProj, angle, 100); 
            angle += 5;
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    IEnumerator FireThreeWaveBurstCenter() 
    {
        for (int i = 0; i < 3; i++) {
            tempProj = Instantiate(proj, blasterPos, transform.rotation);
            StandardFireFunctions.FireDegreeOffsetFromPlayerSpeed(tempProj, 20, 100);
            tempProj = Instantiate(proj, blasterPos, transform.rotation);
            StandardFireFunctions.FireDegreeOffsetFromPlayerSpeed(tempProj, -20, 100);
            tempProj = Instantiate(proj, blasterPos, transform.rotation);
            StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
            yield return new WaitForSeconds(0.75f);
        }
    }

    IEnumerator FireThreeDRoundBurstRight() 
    {
        tempProj = Instantiate(proj, rightCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, rightCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, rightCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
    }

    IEnumerator FireThreeDRoundBurstLeft() 
    {
        tempProj = Instantiate(proj, leftCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, leftCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
        yield return new WaitForSeconds(0.25f);
        tempProj = Instantiate(proj, leftCannonPos, transform.rotation);
        StandardFireFunctions.FireAtPlayerWithSetSpeed(tempProj, 100);
    }

    IEnumerator ShootExplosionPattern() {
        Instantiate(bombProj, blasterPos, transform.rotation);
        yield return new WaitForSeconds(2.0f);

        int selector = Random.Range(0,2);
        switch (selector) {
            case 0:
                StartCoroutine(FirePhotonLeft());
                StartCoroutine(FirePhotonRight());              
                break;
            case 1:
                break;
            case 2:
                break;
        }
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
    IEnumerator FirePhotonLeft() 
    {        
        GameObject tempProj = Instantiate(photonProj, leftCannonPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 85);
        yield return new WaitForSeconds(0.75f);
    }
    IEnumerator FirePhotonRight() 
    {        
        GameObject tempProj = Instantiate(photonProj, rightCannonPos, transform.rotation);
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
            tempProj = Instantiate(proj, blasterPos, transform.rotation);

            StandardFireFunctions.FireClusterDown(tempProj);
        }
    }
    
    IEnumerator FireClusterBlastLeft() 
    {
        GenerateClusterLeft();
        yield return new WaitForSeconds(0.85f);
        GenerateClusterLeft();
        yield return new WaitForSeconds(0.85f);
        GenerateClusterLeft();
    }

    void GenerateClusterLeft() 
    {
        GameObject tempProj;
        for (int i = 0; i < 12; i++) {
            tempProj = Instantiate(proj, leftCannonPos, transform.rotation);

            StandardFireFunctions.FireClusterDown(tempProj);
        }
    }
    
    IEnumerator FireClusterBlastRight() 
    {
        GenerateClusterRight();
        yield return new WaitForSeconds(0.85f);
        GenerateClusterRight();
        yield return new WaitForSeconds(0.85f);
        GenerateClusterRight();
    }

    void GenerateClusterRight() 
    {
        GameObject tempProj;
        for (int i = 0; i < 12; i++) {
            tempProj = Instantiate(proj, rightCannonPos, transform.rotation);

            StandardFireFunctions.FireClusterDown(tempProj);
        }
    }

    void SetWeaponPositions() 
    {
        blasterPos = transform.position;
        blasterPos.y = blasterPos.y - 31;
        rightCannonPos = transform.position;
        rightCannonPos.y = rightCannonPos.y - 33;
        rightCannonPos.x = rightCannonPos.x + 34;
        leftCannonPos = transform.position;
        leftCannonPos.y = leftCannonPos.y - 33;
        leftCannonPos.x = leftCannonPos.x - 34;
    }
}
