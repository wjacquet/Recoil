using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JunkTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject bucket;
    public GameObject[] scorchers;
    // Start is called before the first frame update
    void Start()
    {
        bucket.SetActive(false);
        foreach (GameObject go in scorchers) 
        {
            go.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "obj_player") {
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0,0,0);
            // Move Boss
            bucket.SetActive(true);
            // Set all scorchers to be active
            foreach (GameObject go in scorchers) 
            {
                go.SetActive(true);
            }
            // Destroy Trigger
            Destroy(gameObject);
        }
    }
}
