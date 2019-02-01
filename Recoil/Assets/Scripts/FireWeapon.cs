using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int reload;
    private int reloadCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (reloadCounter > 0) {
            reloadCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0) && reloadCounter == 0) {
            reloadCounter = reload;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
