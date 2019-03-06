using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPatroller : MonoBehaviour {

    public GameObject bullet;

    public float timeBetweenShoots = 2.0f;
    
    void Start() {
        StartCoroutine(PotFirePattern());
    }

    IEnumerator PotFirePattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }
    
    IEnumerator Shoot() {
        GameObject proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);

        yield return null;
    }
}
