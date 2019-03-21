using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    public GameObject cactus;

    void Start() {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        cactus = Instantiate(cactus, tmp, transform.rotation);
    }
}
