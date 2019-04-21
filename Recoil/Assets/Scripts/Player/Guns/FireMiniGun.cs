using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMiniGun : MonoBehaviour
{ 
    public GameObject bullet;
    private GameObject player;
    public int reload;
    public int damage;
    public int knockback = 30;
    private int reloadCounter = 0;
    public int speed = 100;
    private int fireTime = 0;

    void Start() 
    {
        player = GameObject.Find("obj_player");
    }

    // // Update is called once per frame
    void Update()
    {
        if (reloadCounter > 0) {
            reloadCounter--;
        }
        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0)) {
            fireTime++;
            if (fireTimeReady() && reloadCounter == 0) {
                reloadCounter = reload;
                Shoot();
            }
        }

        if (!Input.GetMouseButton(0)) {
            fireTime = 0;
        }
    }

    bool fireTimeReady() 
    {
        return fireTime >= 45 ? true : false;
    }

    void Shoot()
    {
        GameObject newBull = Instantiate(bullet, transform.position, transform.rotation);
        newBull.GetComponent<BulletMovement>().SetDamage(damage);
        newBull.GetComponent<BulletMovement>().SetSpeed(speed);
        
        Vector2 recoil = newBull.GetComponent<BulletMovement>().FireMiniBullet() * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
