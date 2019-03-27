using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriderShot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int recharge;
    private int rechargeCounter = 0;
    private int typeCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        typeCount++;
    }

    void Shoot()
    {
        if ((typeCount / 60) % 2 == 0)
        {
            StandardFireFunctions.FireAtPlayer(Instantiate(bullet, transform.position, transform.rotation));
            StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), 20);
            StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), -20);
        }
        else
        {
            StandardFireFunctions.FireAtPlayer(Instantiate(bullet, transform.position, transform.rotation));
        }
    }
}
