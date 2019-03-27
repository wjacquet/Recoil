using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTrashLaser : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    public int recharge;
    private int rechargeCounter = 0;
    private int dirCount = 0;

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
        dirCount++;
    }

    void Shoot()
    {
        //Debug.Log(dirCount);
        if ((dirCount/60)% 2 == 0)
        {
            //Debug.Log("Left laser");
            Instantiate(bullet, transform.position, transform.rotation).SendMessage("LeftLaser"); ;
        } else
        {
            //Debug.Log("Right laser");
            Instantiate(bullet, transform.position, transform.rotation).SendMessage("RightLaser"); ;
        }
    }

}
