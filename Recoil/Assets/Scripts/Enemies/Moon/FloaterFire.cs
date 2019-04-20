using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterFire : MonoBehaviour
{

    public GameObject gravity_proj;

    void Start() 
    {
        StartCoroutine(FloaterPattern());
    }

    IEnumerator FloaterPattern() 
    {
        while (true) {
            Shoot();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Shoot() 
    {
        GameObject proj = Instantiate(gravity_proj, transform.position, transform.rotation);
        StandardFireFunctions.FireLeft(proj, 70);
        proj = Instantiate(gravity_proj, transform.position, transform.rotation);
        StandardFireFunctions.FireRight(proj, 70);
    }
}
