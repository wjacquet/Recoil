using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peabody : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject player;

    private GameObject proj;

    public float timePerShot = 4.0f;
    public float shotSpeed = 40.0f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(PeabodyPattern());
    }

    void Update() {
        if (proj != null)
            StandardFireFunctions.FireAtPlayerWithSetSpeed(proj, shotSpeed);
    }

    IEnumerator PeabodyPattern() {
        while (true) {
            yield return Shoot();
        }
    }

    IEnumerator Shoot() {
        proj = Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(timePerShot);
        Destroy(proj);
    }

}
