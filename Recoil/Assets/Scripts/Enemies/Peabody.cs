using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peabody : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject player;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(PeabodyPattern());
    }

    IEnumerator PeabodyPattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator Shoot() {
        GameObject proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
        yield return null;
    }

}
