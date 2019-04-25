using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoonTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject drone;
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        drone.SetActive(false);
        ship.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "obj_player") {
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0,0,0);
            // Move Boss
            drone.SetActive(true);
            // Destroy Trigger
            // Destroy(gameObject);
            transform.position = new Vector3(0,0,0);
        }
    }

    void SpawnFinalPhase() 
    {
        
    }
}
