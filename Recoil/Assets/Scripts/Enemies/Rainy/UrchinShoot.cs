using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinShoot : MonoBehaviour {

    public GameObject bullet;
    public float timeBetweenShoots = 10.0f;

    void Start() {
        // StartCoroutine(UrchinFirePattern());
        Shoot();
    }

    // IEnumerator UrchinFirePattern() {
    //     while(true) {
    //         yield return Shoot();
    //     }
    // }

    void Shoot() {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("CircleFire");
        // yield return new WaitForSeconds(timeBetweenShoots);
    }
}
