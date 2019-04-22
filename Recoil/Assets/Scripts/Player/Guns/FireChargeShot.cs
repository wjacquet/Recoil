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
    private int currCharge = 0;

    private bool shotCharging = false;

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

        if (!Input.GetMouseButton(0) && shotCharging) {
            if (currCharge < 30) {
                Shoot(shot1, 1);

            } else if (currCharge < 60) {
                Shoot(shot2, 2);

            } else if (currCharge < 90) {
                Shoot(shot3, 4);

            } else {
                Shoot(shot4, 8);
            }
            
            shotCharging = false;
            currCharge = 0;
        }

        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0)) {
            shotCharging = true;
            currCharge++;
        }
    }


    void Shoot(GameObject shot, int multiplier)
    {
        GameObject newBull = Instantiate(shot, transform.position, transform.rotation);
        newBull.GetComponent<BulletMovement>().SetDamage(damage * multiplier);
        newBull.GetComponent<BulletMovement>().SetSpeed(speed);
        
        Vector2 recoil = newBull.GetComponent<BulletMovement>().FireBullet() * knockback * multiplier;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
