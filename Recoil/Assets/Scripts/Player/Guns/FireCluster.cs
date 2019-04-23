using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCluster : MonoBehaviour
{
    public GameObject bullet;
    public int reload;
    public int damage;
    public int knockback = 50;
    private int reloadCounter = 0;
    private GameObject player;

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
        Vector2 recoil = new Vector2(0,0);
        GameObject newBull;
        for (int i = 0; i < 8; i++) {
            newBull = Instantiate(bullet, transform.position, transform.rotation);
            
            newBull.GetComponent<BulletMovement>().SetDamage(damage);
        
            recoil = newBull.GetComponent<BulletMovement>().FireClusterBullet() * knockback;
        }
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
