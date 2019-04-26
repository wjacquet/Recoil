using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoonTrigger : MonoBehaviour
{
    public Tilemap bossWalls;
    public GameObject drone;
    public GameObject ship;
    public Vector3 spawnPos;
    public Vector3 distancePos;
    public Camera mainCamera;
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
            
            mainCamera.GetComponent<CameraMovement>().minY = mainCamera.GetComponent<CameraMovement>().maxY;
            

            // Destroy Trigger
            // Destroy(gameObject);
            transform.position = new Vector3(0,0,0);
        }
    }

    public IEnumerator SpawnFinalPhase() 
    {
        while(drone.transform.position != spawnPos) {
            drone.transform.position = Vector2.MoveTowards(drone.transform.position, spawnPos, 10 * Time.deltaTime);
            yield return null;
        }
        ship.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        while(ship.transform.position != distancePos) {
            ship.transform.position = Vector2.MoveTowards(ship.transform.position, distancePos, 2 * Time.deltaTime);
            yield return null;
        }
        drone.SetActive(false);
    }
}
