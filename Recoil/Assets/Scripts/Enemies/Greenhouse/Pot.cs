using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    public GameObject cactus;

    public float SpawnRate = 3.0f;

    void Start() {
        StartCoroutine(PotPattern());
    }

    IEnumerator PotPattern() {
        while (true) {
            yield return Create();
        }
    }

    IEnumerator Create() {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        Instantiate(cactus, tmp, transform.rotation);

        yield return new WaitForSeconds(SpawnRate);
    }
}
