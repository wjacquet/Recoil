using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    private Vector2 direction;
    private int length = 16;
    private float speed = 64f;
    private Vector2 origin;
    public GameObject windParticle;

    public void Init(Vector2 direction, Vector2 origin) {
        this.direction = direction;
        this.origin = origin;
        StartCoroutine(SpawnWind());
    }

    void FixedUpdate() {
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
        setNewCollisionSize(distance);

        // Update position
        transform.position = getNewPosition(0);
    }

    IEnumerator SpawnWind() {
        int offset = 4;
        while (true) {
            // Get position for wind effect
            offset = offset * -1;
            Vector2 newPosition = getNewPosition(offset);

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
            Vector2 push = direction * 2;
            collision.gameObject.GetComponent<PlayerMovement>().Recoil(push);
        }
    }

    // calculate the new size of the hitbox from distance and direction
    void setNewCollisionSize(float distance) {
        BoxCollider2D collision = gameObject.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        length = Mathf.RoundToInt(distance);
        
        if (direction.x == 0) {
            collision.size = new Vector2(16, length);
        } else {
            collision.size = new Vector2(length, 16);
        }
    }

    // gets the new transform.position of the collision, or if offset is set, the wind particles
    Vector2 getNewPosition(int windOffset) {
        // set the offset to 2 for wind, length / 2 for the push object
        int offset = windOffset == 0 ? (length / 2) : 2;

        // get the new position based on the direction
        if (direction == Vector2.down)
            return new Vector2(origin.x + windOffset, origin.y - offset);
        if (direction == Vector2.up)
            return new Vector2(origin.x + windOffset, origin.y + offset);
        if (direction == Vector2.left)
            return new Vector2(origin.x - offset, origin.y + windOffset);
        if (direction == Vector2.right)
            return new Vector2(origin.x + offset, origin.y + windOffset);
        
        return new Vector2(0, 0);
    }
}
