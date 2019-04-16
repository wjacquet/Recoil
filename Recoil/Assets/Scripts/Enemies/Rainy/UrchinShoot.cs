using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinShoot : MonoBehaviour {

    public GameObject bullet;
    public float timeBetweenShoots = 1.0f;

    void Start() {
        StartCoroutine(UrchinFirePattern());
    }

    IEnumerator UrchinFirePattern() {
        while(true) {
            yield return Shoot();
        }
    }

    IEnumerator Shoot() {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("Fire");
        yield return new WaitForSeconds(timeBetweenShoots);
    }
}
