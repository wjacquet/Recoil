using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrystal : MonoBehaviour {

    private PlayerHealth playerHP;
    LineRenderer line;

    private Vector2 rotateVector = new Vector2(0, 1); 
    private int angle = 0;


    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update() {
        FireLaser();
    }

    void FireLaser(){
        line.enabled = true;
 
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D[] hits;

        Debug.Log(angle);
        rotateVector = Quaternion.AngleAxis(angle++, Vector3.forward) * Vector3.right;
        hits = Physics2D.RaycastAll(ray.origin, rotateVector, 20000);
        if (angle >= 360)
            angle = 0;


        line.SetPosition(0, ray.origin);
        
        for (int i = 0; i < hits.Length; ++i) {
            if (!(hits[i].collider.gameObject.tag == "Enemy")) {
                if (hits[i].collider.gameObject.tag == "Player") {
                    playerHP.TakeDamage();
                    line.SetPosition(1, hits[i].point);
                    break;
                } else {
                    line.SetPosition(1, hits[i].point);
                    break;
                }
            } else {
                line.SetPosition(1, ray.GetPoint(20000));
            }
        }

        // yield return null;

    }
}
