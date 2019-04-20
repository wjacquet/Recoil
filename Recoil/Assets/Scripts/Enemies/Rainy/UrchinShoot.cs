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
        Instantiate(bullet, new Vector2(transform.position.x + 5 , transform.position.y + 5), transform.rotation).SendMessage("topRight");
        Instantiate(bullet, new Vector2(transform.position.x - 5, transform.position.y - 5), transform.rotation).SendMessage("bottomLeft");
        Instantiate(bullet, new Vector2(transform.position.x + 5, transform.position.y - 5), transform.rotation).SendMessage("bottomRight");
        Instantiate(bullet, new Vector2(transform.position.x - 5 , transform.position.y + 5), transform.rotation).SendMessage("topLeft");

        yield return new WaitForSeconds(timeBetweenShoots);
    }
}
