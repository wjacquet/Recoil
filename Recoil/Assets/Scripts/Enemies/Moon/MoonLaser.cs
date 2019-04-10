using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLaser : MonoBehaviour {

    public float timer = 2.0f;
    public float warningTimer = 1.0f;

    public bool floor = false;
    public bool leftWall = true;
    public bool cieling = false;
    public bool rightWall = false;

    private bool stopLaser = false;
    private bool warning = false;

    private LineRenderer line;
    private PlayerHealth playerHP;
    private Vector2 rotateVector = new Vector2(0, 0); 

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        line = gameObject.transform.GetComponent<LineRenderer>();
        SetSide();

        StartCoroutine(LaserRoutine());
    }

    void SetSide() {
        if (floor)
            rotateVector = Quaternion.AngleAxis(90, Vector3.forward) * Vector3.right;
        else if (leftWall)
            rotateVector = Quaternion.AngleAxis(0, Vector3.forward) * Vector3.right;
        else if (cieling)
            rotateVector = Quaternion.AngleAxis(270, Vector3.forward) * Vector3.right;
        else if (rightWall)
            rotateVector = Quaternion.AngleAxis(180, Vector3.forward) * Vector3.right;         
    }

    void Update() {
        DetectHits();
    }

    IEnumerator LaserRoutine() {
        while (true) {
            stopLaser = true;
            yield return new WaitForSeconds(timer);
            stopLaser = false;
            warning = true;
            yield return new WaitForSeconds(warningTimer);
            warning = false;
            yield return new WaitForSeconds(timer);
        }
    }

    void DetectHits() {
 
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D[] hits;
      
        hits = Physics2D.RaycastAll(ray.origin, rotateVector, 20000);
       
        HandleCollisions(hits, line, ray);
    }

    void HandleCollisions(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {

        line.SetPosition(0, ray.origin);

        if (warning) {
            line.SetWidth(1, 1);
        } else {
            line.SetWidth(5, 5);
        }

        if (stopLaser) {
            line.SetPosition(1, ray.origin);
            return;
        }

        for (int i = 0; i < hits.Length; ++i) {
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Ground") {
                line.SetPosition(1, hits[i].point);
                break;
            } else if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Player" && !warning) {
                playerHP.TakeDamage();
            } else {
                line.SetPosition(1, ray.GetPoint(20000));
            }
        }
    }
}
