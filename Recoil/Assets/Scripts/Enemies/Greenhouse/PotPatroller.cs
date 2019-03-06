using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPatroller : MonoBehaviour {

    public GameObject bullet;

    public float timeBetweenShoots = 0.05f;
    public float timeBetweenBurst = 2.0f;
    
    void Start() {
        StartCoroutine(PotFirePattern());
    }

    IEnumerator PotFirePattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenBurst);

        }
    }
    
    IEnumerator Shoot() {
        GameObject proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);

        yield return null;
    }
}
