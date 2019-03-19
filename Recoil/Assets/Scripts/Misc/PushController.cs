using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    private int xSpeed;
    private int ySpeed;
    private float speed = 64f;
    private int offset = 4;
    public GameObject windParticle;

    public void SetSpeed(int xSpeed,int ySpeed) {
        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;
        StartCoroutine(SpawnWind());
    }

    IEnumerator SpawnWind() {
        while (true) {
            // Randomly generate an offset for wind
            offset = offset * -1;
            Vector2 newPosition = new Vector2(transform.position.x + offset, transform.position.y - 10);

            // Spawn wind particle
            GameObject particle = Instantiate(windParticle, newPosition, transform.rotation);
            Rigidbody2D rigidBody = particle.GetComponent<Rigidbody2D>();
            rigidBody.velocity = (new Vector2(xSpeed, ySpeed)) * speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
