using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public GameObject bullet;
    public GameObject electricity;
    GameObject player;
    PlayerHealth playerHP;
    bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        StartCoroutine(SwarmAttacks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        Destroy(GameObject.Find("obj_liquid"));
    }

    IEnumerator SwarmAttacks() {
        // initial left movement
        StandardFireFunctions.FireLeft(gameObject, 48.0f);
        while (transform.position.x > 80) {
            yield return null;
        }

        StartCoroutine(SwarmFire());

        while(true) {
            // movement left and right
            if (left) {
                StandardFireFunctions.FireLeft(gameObject, 48.0f);
                gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);        
            } else {
                StandardFireFunctions.FireRight(gameObject, 48.0f);
                gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);        
            }

            // flip when wall is reached
            if ((transform.position.x > 120 && !left) || (transform.position.x < -100 && left)) left = !left;

            yield return null;
        }
    }

    IEnumerator SwarmFire() {
        while (true) {
            // homing shot
            for (int i = 0;i < 6;i++) {
                GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
                StandardFireFunctions.FireAtPlayer(projectile);

                yield return new WaitForSeconds(3.0f);
            }

            yield return new WaitForSeconds(1.0f);

            // electric fields
            for (int i = 0;i < 4;i++) {
                Vector3 electricPosition = new Vector3(player.transform.position.x, player.transform.position.y, -1);
                Instantiate(electricity, electricPosition, transform.rotation);

                yield return new WaitForSeconds(3.0f);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
    }
}
