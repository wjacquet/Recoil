using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int recharge;
    private int rechargeCounter = 0;
    private 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (rechargeCounter > 0) {
            rechargeCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (rechargeCounter == 0) {
            rechargeCounter = recharge;
            ShootAngle();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation)
        .SendMessage("NormalFire");
        // Shoot a projectile diagonally up
        Instantiate(bullet, transform.position, transform.rotation)
            .SendMessage("DiagonalOffset",true);
        // Shoot a projectile diagonally down
        Instantiate(bullet, transform.position, transform.rotation)
            .SendMessage("DiagonalOffset",false);
    }

    void ShootAngle() 
    {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("RootyTootyFuckingShooty", 360);
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("RootyTootyFuckingShooty", 20);
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("RootyTootyFuckingShooty", -20);
    }
}
