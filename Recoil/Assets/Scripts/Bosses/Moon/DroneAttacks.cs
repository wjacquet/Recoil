using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttacks : MonoBehaviour
{
    public GameObject proj;
    // Start is called before the first frame update

    private Vector3 blasterPos;

    GameObject tempProj;
    void Start()
    {
        blasterPos = transform.position;
        blasterPos.y = blasterPos.y - 18;
        gameObject.GetComponent<ShipMovement>().TriggerRightMovement();
        StartCoroutine(FireThreeDown());
    }

    // Update is called once per frame
    void Update()
    {
        blasterPos = transform.position;
        blasterPos.y = blasterPos.y - 18;   
    }


    IEnumerator FireThreeDown() 
    {
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
    }

    IEnumerator FireWaves() 
    {
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
        tempProj = Instantiate(proj, blasterPos, transform.rotation);
        StandardFireFunctions.FireDownFakeGravity(tempProj, 100);
        yield return new WaitForSeconds(0.75f);
    }
}
