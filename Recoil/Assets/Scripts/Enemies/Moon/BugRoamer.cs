using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugRoamer : MonoBehaviour
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
        if (rechargeCounter == 0) {
            rechargeCounter = recharge;
            Shoot();
        }
    }

    void Shoot()
    {
        //StandardFireFunctions.FireClusterAtPlayer(Instantiate(bullet, transform.position, transform.rotation));

        
        GameObject newBull;
        for (int i = 0; i < 8; i++) {
            newBull = Instantiate(bullet, transform.position, transform.rotation);

            StandardFireFunctions.FireClusterAtPlayer(newBull);
        }
    }
}
