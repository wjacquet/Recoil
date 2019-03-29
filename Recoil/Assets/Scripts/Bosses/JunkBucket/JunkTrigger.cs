using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JunkTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {
        bucket.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "obj_player") {
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0,0,0);
            // Move Boss
            bucket.SetActive(true);
            // Destroy Trigger
            Destroy(gameObject);
        }
    }
}
