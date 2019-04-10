using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLaser : MonoBehaviour {

    public float timer = 2.0f;

    private bool stopLaser = false;

    private LineRenderer line;
    private PlayerHealth playerHP;
    private Vector2 rotateVector = new Vector2(0, 0); 

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        line = gameObject.transform.GetComponent<LineRenderer>();
        rotateVector = Quaternion.AngleAxis(90, Vector3.forward) * Vector3.right;

        StartCoroutine(LaserRoutine());
    }

    void Update() {
        DetectHits();
    }

    IEnumerator LaserRoutine() {
        while (true) {
            stopLaser = !stopLaser;
            yield return new WaitForSeconds(timer);
        }
    }

    void DetectHits() {
 
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D[] hits;
      
        hits = Physics2D.RaycastAll(ray.origin, rotateVector, 20000);
       
        GiveDamage(hits, line, ray);
        HandleCollisions(hits, line, ray);
    }

    void GiveDamage(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {
        for (int i = 0; i < hits.Length; ++i) 
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Player")
                playerHP.TakeDamage();
    }

    void HandleCollisions(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {

        line.SetPosition(0, ray.origin);

        if (stopLaser) {
            line.SetPosition(1, ray.origin);
            return;
        }

        for (int i = 0; i < hits.Length; ++i) {
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Ground") {
                line.SetPosition(1, hits[i].point);
                break;
            } else {
                line.SetPosition(1, ray.GetPoint(20000));
            }
        }
    }
}
