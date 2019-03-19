using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrystal : MonoBehaviour {

    LineRenderer line;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

    IEnumerator FireLaser(){
        line.enabled = true;
 
        while (Input.GetButton("Fire1")) {
            Ray2D ray = new Ray2D(transform.position, transform.right);
            RaycastHit2D hit;

            line.SetPosition(0, ray.origin);

            hit = Physics2D.Raycast(ray.origin, Vector2.right, 200);
            if (hit.collider){
                line.SetPosition(1, hit.point);
            } else {
                line.SetPosition(1, ray.GetPoint(200));
            }
            
            yield return null;
        }

        line.enabled = false;
    }
}
