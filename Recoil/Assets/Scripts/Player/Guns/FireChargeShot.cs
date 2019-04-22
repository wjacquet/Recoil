using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChargeShot : MonoBehaviour
{
    public GameObject shot1, shot2, shot3, shot4;
    private GameObject player;
    public int reload;
    public int damage;
    public int knockback = 30;
    private int chargeCounter = 0;
    public int speed = 100;
    public int chargeTimePerLevel;

    void Start() 
    {
        player = GameObject.Find("obj_player");
    }

    // // Update is called once per frame
    void Update()
    {
        if (chargeCounter > 0) {
            chargeCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0) && chargeCounter == 0) {
            chargeCounter = reload;
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject newBull = Instantiate(shot1, transform.position, transform.rotation);
        newBull.GetComponent<BulletMovement>().SetDamage(damage);
        newBull.GetComponent<BulletMovement>().SetSpeed(speed);
        
        Vector2 recoil = newBull.GetComponent<BulletMovement>().FireBullet() * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
