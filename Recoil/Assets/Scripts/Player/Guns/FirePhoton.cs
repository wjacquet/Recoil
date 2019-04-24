using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePhoton : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;
    public int reload;
    public int damage;
    public int speed;
    public int knockback;
    private int reloadCounter = 0;

    void Start() 
    {
        player = GameObject.Find("obj_player");
    }

    // // Update is called once per frame
    void Update()
    {
        if (reloadCounter > 0) {
            reloadCounter--;
        }

        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0) && reloadCounter == 0 && !SelectionMenus.gameIsPaused) {
            reloadCounter = reload;
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject newBull = Instantiate(bullet, transform.position, transform.rotation);
        newBull.GetComponent<BulletMovement>().SetDamage(damage);
        newBull.GetComponent<BulletMovement>().SetSpeed(speed);
        
        Vector2 recoil = newBull.GetComponent<BulletMovement>().FireBullet() * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
