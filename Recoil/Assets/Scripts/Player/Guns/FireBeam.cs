using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeam : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int reload;
    public int damage;
    public int knockback = 30;

    private LineRenderer line;
    private int reloadCounter = 0;

    void Start() 
    {
        player = GameObject.Find("obj_player");
        line = gameObject.transform.GetComponent<LineRenderer>(); 
        line.sortingOrder = 1;
        line.material = new Material (Shader.Find ("Sprites/Default"));
    }

    // // Update is called once per frame
    void Update()
    {
        if (reloadCounter > 0) {
            reloadCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0) && reloadCounter == 0) {
            reloadCounter = reload;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.Normalize();

        Vector2 recoil = new Vector2(-direction.x, -direction.y) * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
        
        Ray2D ray = new Ray2D(transform.position, direction);
        RaycastHit2D[] hits;
      
        hits = Physics2D.RaycastAll(ray.origin, ray.direction, 20000);
    
        line.enabled = true;
        HandleCollisions(hits, line, ray);
        StartCoroutine(LaserStall(ray));
    }

    void HandleCollisions(RaycastHit2D[] hits, LineRenderer line,  Ray2D ray) {

        line.SetPosition(0, ray.origin);

        for (int i = 0; i < hits.Length; ++i) {
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Ground") {
                line.SetPosition(1, hits[i].point);
                break;
            } else if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Enemy") {
                hits[i].collider.gameObject.GetComponent<EnemyHealth>().Damage(damage);
                line.SetPosition(1, hits[i].point);
            } else {
                line.SetPosition(1, ray.GetPoint(20000));
            }
        }
    }

    IEnumerator LaserStall(Ray2D ray) {
        yield return new WaitForSeconds(0.2f);
        line.enabled = false;
    }
}
