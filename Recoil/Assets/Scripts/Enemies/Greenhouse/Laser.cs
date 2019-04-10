using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{

    public bool isWarning = false;
    private LineRenderer line;
    private PlayerHealth playerHP;
    private Vector2 rotateVector = new Vector2(0, 0); 
    private int angle = 45;

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        line = gameObject.transform.GetComponent<LineRenderer>();

        StartCoroutine(LaserPattern());
    }

    IEnumerator LaserPattern() {
        while (true) {
            yield return FireLaser();
        }
    }

    IEnumerator FireLaser(){
 
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D[] hits;
      
        rotateVector = Quaternion.AngleAxis(angle++, Vector3.forward) * Vector3.right;
        hits = Physics2D.RaycastAll(ray.origin, rotateVector, 20000);
       
        angle = ResetAngle(angle);
        HandleCollisions(hits, line, ray);

        yield return new WaitForSeconds(0.03f); 
    }

    // TODO Only if hits ground
    void HandleCollisions(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {

        line.SetPosition(0, ray.origin);

        for (int i = 0; i < hits.Length; ++i) {
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Ground") {
                line.SetPosition(1, hits[i].point);
                break;
            } else if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Player" && !isWarning) {
                playerHP.TakeDamage();
            } else {
                line.SetPosition(1, ray.GetPoint(20000));
            }
        }
    }

    public void SetAngle(int newAngle) {
        angle = newAngle;
        angle = newAngle % 360;
    }

    int ResetAngle(int angle) {
        if (angle >= 360)
            angle = 0;
        return angle;
    }
}
