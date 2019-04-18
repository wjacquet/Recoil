using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    How to use the snake in unity

    1. Put the obj_snake_head into scene
    2. Put 4 obj_snake_bodies into the scene
    3. On each body, there is a distance from head to set.
        a. Set the first body (The one directly bethind the head) = 20
        b. Second body = 40
        c. Third Body = 60
 */

public class SnakeBody : MonoBehaviour {
 
    public int followDistance;
    private GameObject head;
    private List<Vector3> storedPositions;
 
    void Awake() {
        head = GameObject.Find("obj_snake_head");

        storedPositions = new List<Vector3>();
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine(LoadSprites());
    }

    IEnumerator LoadSprites() {
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }
 
    void Update() {
        if (head == null) Destroy(gameObject);
        if(storedPositions.Count == 0) {
            storedPositions.Add(head.transform.position); //store the heads currect position
            return;
        } else if (storedPositions[storedPositions.Count -1] != head.transform.position) {
            storedPositions.Add(head.transform.position); //store the position every frame
        }
 
        if (storedPositions.Count > followDistance) {
            transform.position = storedPositions[0]; //move
            storedPositions.RemoveAt(0); //delete the position that head just move to
        }
    }
}
