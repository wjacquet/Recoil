using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinShoot : MonoBehaviour {

    public GameObject bullet;
    private float timeBetweenShoots = 3.0f;

    public float timeCounter1 = 0;
    public float timeCounter2 = 30;
    public float timeCounter3 = 60;
    public float timeCounter4 = 90;

    public float radius = 0.5f;
    public Vector2 center;

    void Start() {
        StartCoroutine(UrchinFirePattern());
        Shoot();
        center = transform.position;
    }

    void FixedUpdate() {
        radius += 0.25f;   
        timeCounter1 += Time.deltaTime;
        timeCounter2 += Time.deltaTime;
        timeCounter3 += Time.deltaTime;
        timeCounter4 += Time.deltaTime;
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
