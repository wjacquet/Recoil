using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTurret : MonoBehaviour
{
    public GameObject bullet;
    public int recharge;
    private int rechargeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (rechargeCounter > 0) {
            rechargeCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (rechargeCounter == 0 && GetVectorToPlayer().y <= 20) {
            rechargeCounter = recharge;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
    }

    Vector2 GetVectorToPlayer() 
    {
        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        return player.transform.position - transform.position;
    }

    // IEnumerator StaggeredFire() 
    // {

    // }
}
