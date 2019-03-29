using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScrewdrivers : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int recharge;
    private int rechargeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (rechargeCounter > 0)
        {
            rechargeCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (rechargeCounter == 0)
        {
            rechargeCounter = recharge;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("NormalToss");
    }
}
