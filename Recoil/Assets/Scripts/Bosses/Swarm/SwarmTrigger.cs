using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwarmTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject liquid;
    public Camera mainCamera;
    public Camera bossCamera;
    public GameObject swarmController;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        bossCamera.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col) {
        if (!triggered && col.gameObject.name == "obj_player") {
            // Disable Main Camera
            mainCamera.enabled = false;
            // Enable Boss Camera
            bossCamera.enabled = true;
            // Spawn Boss Walls
            bossWalls.transform.position = new Vector3(0, 0, 0);
            // Move Boss
            Instantiate(swarmController, transform.position, transform.rotation);

            StartCoroutine(RaiseWater());

            triggered = true;
            transform.position = new Vector3(0, 300, 0);
        }
    }

    IEnumerator RaiseWater() {
        Vector3 endLocation = new Vector3(-166, -138, -10);
        while (liquid.transform.position != endLocation) {
            liquid.transform.position = Vector2.MoveTowards(liquid.transform.position, endLocation, 200 * Time.deltaTime);
            yield return null;
        }
    }
}
