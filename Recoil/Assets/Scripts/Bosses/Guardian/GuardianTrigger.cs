using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GuardianTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "obj_player")
        {
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(-440, 384, 0);
            // Move Boss
            boss.SetActive(true);
            // Destroy Trigger
            Destroy(gameObject);
        }
    }
}
