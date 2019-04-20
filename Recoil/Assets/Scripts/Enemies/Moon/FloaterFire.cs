using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterFire : MonoBehaviour
{

    public GameObject gravity_proj;
    public GameObject photon_proj;

    private Vector3[] firingPositions = new Vector3[4];
    private int horizontalOffset = 9;
    private int verticalOffsetSideShots = 8;

    void Start() 
    {
        firingPositions[0] = new Vector3(transform.position.x + horizontalOffset, transform.position.y + verticalOffsetSideShots, transform.position.z);
        firingPositions[1] = new Vector3(transform.position.x - horizontalOffset, transform.position.y + verticalOffsetSideShots, transform.position.z);
        firingPositions[2] = new Vector3(transform.position.x, transform.position.y + 17, transform.position.z);
        firingPositions[3] = new Vector3(transform.position.x, transform.position.y - 12, transform.position.z);
        StartCoroutine(FloaterPattern());
    }

    IEnumerator FloaterPattern() 
    {
        while (true) {
            ShootBasicProjectiles();
            yield return new WaitForSeconds(1.5f);
            ShootPhoton();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void ShootBasicProjectiles() 
    {
        GameObject proj = Instantiate(gravity_proj, firingPositions[0], transform.rotation);
        StandardFireFunctions.FireRight(proj, 60);
        proj = Instantiate(gravity_proj, firingPositions[1], transform.rotation);
        StandardFireFunctions.FireLeft(proj, 60);
        proj = Instantiate(gravity_proj, firingPositions[2], transform.rotation);
        StandardFireFunctions.FireVeticallyDegreeOffset(proj, 10);
        proj = Instantiate(gravity_proj, firingPositions[2], transform.rotation);
        StandardFireFunctions.FireVeticallyDegreeOffset(proj, -10);
    }

    void ShootPhoton() 
    {
        GameObject proj = Instantiate(photon_proj, firingPositions[3], transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(proj, 30);
    }
}
