using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public int fireDelay;
    public int recharge;

    private int fireDelayCounter = 0;
    private int rechargeCounter = 0;
    private bool inBurst = false;
    private int burstCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Future stats probably
    }

    // Update is called once per frame
    void Update()
    {
        if (inBurst) {
            if (fireDelayCounter > 0) {
                fireDelayCounter--;
            }

            // Fire on mouse click and reset reloadTimer
            if (fireDelayCounter == 0) {
                fireDelayCounter = fireDelay;
                Shoot();
                if (++burstCounter >= 3) {
                    inBurst = false;
                    burstCounter = 0;
                }
                
            }
        } 
        else { 
            if (rechargeCounter > 0) {
                rechargeCounter--;
            }
            if (rechargeCounter == 0) {
                rechargeCounter = recharge;
                inBurst = true;
            }
        }

    }

    void Shoot() 
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
