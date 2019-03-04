using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugGunner : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D rigidBody;

    private Vector2 center;
 
    public int firstSpreadDegree = 25;
    public int secondSpreadDegree = 15;
    public float hoverDistance = 50;

    void Start() {
        StartCoroutine(BugGunnerPattern());
        // StartCoroutine(HoverPattern());
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        center = transform.position;
    }

    void Update() {
        player = GameObject.Find("obj_player");
        if (player.transform.position.x <= 0) 
            mySpriteRenderer.flipX = true;
        else
            mySpriteRenderer.flipX = false;

        Vector2 movement = new Vector2(Random.Range(-hoverDistance, hoverDistance), Random.Range(-hoverDistance, hoverDistance));
        transform.Translate(movement * Time.deltaTime);
    }

    IEnumerator Hover() {
        Vector2 movement = new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
        transform.Translate(movement * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator HoverPattern() {
        while (true) {
            yield return Hover();
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator BugGunnerPattern() {
        while (true) {
            yield return FirstSpread();
            yield return new WaitForSeconds(1.0f);
            yield return SecondSpread();
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator FirstSpread() {
        StandardFireFunctions.FireAtPlayer(Instantiate(bullet, transform.position, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), firstSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), -firstSpreadDegree);
        yield return null;
    }

    IEnumerator SecondSpread() {
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), secondSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), -secondSpreadDegree);
        yield return null;   
        }
    
}
