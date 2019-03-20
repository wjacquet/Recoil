using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrystal : MonoBehaviour {

    public GameObject crystal;
    public LineRenderer line;
    public LineRenderer line1;
    public LineRenderer line2;
    public LineRenderer line3;

    // public float speed = 0.1f; 

    private PlayerHealth playerHP;

    private Vector2 rotateVector = new Vector2(0, 0); 
    private Vector2 rotateVector1 = new Vector2(0, 0); 
    private Vector2 rotateVector2 = new Vector2(0, 0); 
    private Vector2 rotateVector3 = new Vector2(0, 0); 
    
    private int angle = 45;
    private int angle1 = 135;
    private int angle2 = 225;
    private int angle3 = 315;


    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void Update() {
        FireLaser();
        crystal.transform.Rotate(0, 0, 0.2f);
    }

    void FireLaser(){
 
        Ray2D ray = new Ray2D(transform.position, transform.right);
        Ray2D ray1 = new Ray2D(transform.position, transform.right);
        Ray2D ray2 = new Ray2D(transform.position, transform.right);
        Ray2D ray3 = new Ray2D(transform.position, transform.right);

        
        RaycastHit2D[] hits;
        RaycastHit2D[] hits1;
        RaycastHit2D[] hits2;
        RaycastHit2D[] hits3;
        

        rotateVector = Quaternion.AngleAxis(angle++, Vector3.forward) * Vector3.right;
        rotateVector1 = Quaternion.AngleAxis(angle1++, Vector3.forward) * Vector3.right;
        rotateVector2 = Quaternion.AngleAxis(angle2++, Vector3.forward) * Vector3.right;
        rotateVector3 = Quaternion.AngleAxis(angle3++, Vector3.forward) * Vector3.right;

        hits = Physics2D.RaycastAll(ray.origin, rotateVector, 20000);
        hits1 = Physics2D.RaycastAll(ray1.origin, rotateVector1, 20000);
        hits2 = Physics2D.RaycastAll(ray2.origin, rotateVector2, 20000);
        hits3 = Physics2D.RaycastAll(ray3.origin, rotateVector3, 20000);
        
        angle = ResetAngle(angle);
        angle1 = ResetAngle(angle1);
        angle2 = ResetAngle(angle2);
        angle3 = ResetAngle(angle3);

        
        HandleCollisions(hits, line, ray);
        HandleCollisions(hits1, line1, ray1);
        HandleCollisions(hits2, line2, ray2);
        HandleCollisions(hits3, line3, ray3);
    }

    void HandleCollisions(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {

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
    }

    int ResetAngle(int angle) {
        if (angle >= 360)
            angle = 0;
        return angle;
    }
}
