using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peabody : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject player;

    private GameObject proj;

    public float timePerShot = 2.0f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(PeabodyPattern());
    }

    void Update() {
        StandardFireFunctions.FireAtPlayer(proj);
    }

    IEnumerator PeabodyPattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(timePerShot);
            Destroy(proj);
        }
    }

    IEnumerator Shoot() {
        proj = Instantiate(bullet, transform.position, transform.rotation);
        yield return null;
    }

}
