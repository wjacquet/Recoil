using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinShoot : MonoBehaviour {

    public GameObject bullet;
    private float timeBetweenShoots = 3.0f;

    void Start() {
        StartCoroutine(UrchinFirePattern());
    }

    IEnumerator UrchinFirePattern() {
        while(true) {
            yield return Shoot();
        }
    }

    IEnumerator Shoot() {
        Instantiate(bullet, new Vector2(transform.position.x + 5 , transform.position.y + 5), transform.rotation).SendMessage("one");
        Instantiate(bullet, new Vector2(transform.position.x - 5, transform.position.y - 5), transform.rotation).SendMessage("two");
        Instantiate(bullet, new Vector2(transform.position.x + 5, transform.position.y - 5), transform.rotation).SendMessage("three");
        Instantiate(bullet, new Vector2(transform.position.x - 5 , transform.position.y + 5), transform.rotation).SendMessage("four");

        yield return new WaitForSeconds(timeBetweenShoots);
    }
}
