using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShooting : MonoBehaviour {

    public GameObject bullet;
    public float timeBetweenShoots = 1.0f;

    void Start() {
        StartCoroutine(FishFirePattern());
    }

    IEnumerator FishFirePattern() {
        while(true) {
            yield return LoadBullet();
        }
    }

    IEnumerator LoadBullet() {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("FireUp");
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("FireDown");
        yield return new WaitForSeconds(timeBetweenShoots);
    }
}
