using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DaisyTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject daisy;
    public Camera mainCamera;
    public Camera bossCamera;
    private bool defeated = false;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        // daisy.SetActive(false);
        bossCamera.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (triggered && !defeated && GameObject.Find("obj_daisy") == null) {
            defeated = true;
            // Enable Main Camera
            mainCamera.enabled = true;
            // Disable Boss Camera
            bossCamera.enabled = false;
            // Move Boss Walls
            bossWalls.transform.position = new Vector3(0, 300, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!triggered && col.gameObject.name == "obj_player") {
            // Disable Main Camera
            mainCamera.enabled = false;
            // Enable Boss Camera
            bossCamera.enabled = true;
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0, 0, 0);
            // Move Boss
            daisy.SetActive(true);

            triggered = true;
            transform.position = new Vector3(0, 300, 0);
        }
    }
}
