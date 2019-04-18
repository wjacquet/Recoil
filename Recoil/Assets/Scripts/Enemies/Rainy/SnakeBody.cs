using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour {
 
    public GameObject head;
    public int followDistance;
    private List<Vector3> storedPositions;
 
 
    void Awake() {
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
            Debug.Log("blank list");
            storedPositions.Add(head.transform.position); //store the heads currect position
            return;
        } else if (storedPositions[storedPositions.Count -1] != head.transform.position) {
            //Debug.Log("Add to list");
            storedPositions.Add(head.transform.position); //store the position every frame
        }
 
        if (storedPositions.Count > followDistance) {
            transform.position = storedPositions[0]; //move
            storedPositions.RemoveAt(0); //delete the position that head just move to
        }
    }
}
