using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    private Vector2 direction;
    private int length = 16;
    private float speed = 64f;
    private int offset = 4;
    private Vector2 origin;
    public GameObject windParticle;

    public void Init(Vector2 direction, Vector2 origin) {
        this.direction = direction;
        this.origin = origin;
        StartCoroutine(SpawnWind());
    }

    void Update() {
        // calculate width/height of air current
        Ray2D ray = new Ray2D(origin, transform.right);
        RaycastHit2D[] hits;
        float distance = 0;
      
        hits = Physics2D.RaycastAll(ray.origin, direction, 20000);

        // find distance until ground
        for (int i = 0; i < hits.Length; ++i) {
            if (LayerMask.LayerToName(hits[i].collider.gameObject.layer) == "Ground") {
                distance = hits[i].distance;
                break;
            }
        }

        // Update size of box collider
        BoxCollider2D collision = gameObject.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        collision.size = new Vector2(16, distance);
        length = Mathf.RoundToInt(distance);

        // Update position
        transform.position = new Vector2(transform.position.x, origin.y - (length / 2));
    }

    IEnumerator SpawnWind() {
        while (true) {
            // Get position for wind effect
            offset = offset * -1;
            Vector2 newPosition = new Vector2(transform.position.x + offset, transform.position.y + (length / 2) - 2);

            // Spawn wind particle
            GameObject particle = Instantiate(windParticle, newPosition, transform.rotation);
            Rigidbody2D rigidBody = particle.GetComponent<Rigidbody2D>();
            rigidBody.velocity = direction * speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // push the player
    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Vector2 push = direction;
            collision.gameObject.GetComponent<PlayerMovement>().Recoil(push);
        }
    }
}
