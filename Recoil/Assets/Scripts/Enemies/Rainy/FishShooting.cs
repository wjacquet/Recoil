using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShooting : MonoBehaviour {

    public GameObject bullet;
    public float timeBetweenShoots = 2.0f;

    private float speed = 1.0f;
    GameObject proj;
    GameObject proj1;

    void Start() {
        proj = Instantiate(bullet, transform.position, transform.rotation);
        proj1 = Instantiate(bullet, transform.position, transform.rotation);
    }

    void Update() {
        if (proj == null && proj1 == null) {
            proj = Instantiate(bullet, transform.position, transform.rotation);
            proj1 = Instantiate(bullet, transform.position, transform.rotation);
            speed = 1.0f;
        } else {
            Debug.Log(proj);
            if (proj != null) ShootUp();
            if (proj1 != null) ShootDown();
        }
    }
  
    void ShootUp() {
        StandardFireFunctions.FireVerticallyFakeGravity(proj, speed);
        speed = speed + 0.4f;
    }

    void ShootDown() {
        StandardFireFunctions.FireDownFakeGravity(proj1, speed);
        speed = speed + 0.4f;
    }
}
