using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFire : MonoBehaviour
{
    public GameObject flame;
    private GameObject player;
    public int reload;
    public int damage;
    public int knockback = 30;

    void Start() 
    {
        player = GameObject.Find("obj_player");
        flame.SetActive(false);
    }

    // // Update is called once per frame
    void Update()
    {
        // Fire on mouse click and reset reloadTimer
        if (Input.GetMouseButton(0)) {
            flame.SetActive(true);
            AddRecoil();
        } else {
            flame.SetActive(false);
        }
        
    }


    void AddRecoil()
    {
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.Normalize();

        Vector2 recoil = new Vector2(-direction.x, -direction.y) * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }
}
