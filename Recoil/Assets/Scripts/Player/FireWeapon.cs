using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public int reload;
    private int reloadCounter = 0;
    private Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position;
    }

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

        // rotate gun
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        int aimLow = 1; // we need to negate the angle if the cursor is below the gun
        if (cursor.transform.position.y < transform.position.y) {
            aimLow = -1;
        }
        transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(Vector2.right, direction) * aimLow);
    }

    void LateUpdate() {
        // Gun stays in player's hand
        transform.position = player.transform.position + offset;
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
