using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragonTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject dragon;
    public Camera mainCamera;
    public Camera bossCamera;
    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(false);
        bossCamera.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "obj_player") {
            // Destroy Main Camera
            mainCamera.enabled = false;
            // Spawn Boss Camera
            bossCamera.enabled = true;
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0,0,0);
            // Move Boss
            dragon.SetActive(true);
            // Destroy Trigger
            Destroy(gameObject);
        }
    }
}
