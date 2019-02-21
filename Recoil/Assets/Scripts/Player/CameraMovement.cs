using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public bool lockX;
    public bool lockY;

    public float minX = float.MinValue;
    public float minY = float.MinValue;
    public float maxX = float.MaxValue;
    public float maxY = float.MaxValue;
    

    private Vector3 offset = new Vector3(0, 0, -10);

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + offset;

        // Prevent the camera from going out of bounds
        if (newPosition.y > maxY) {
            newPosition.y = maxY;
        } else if (newPosition.y < minY) {
            newPosition.y = minY;
        }

        if (newPosition.x > maxX) {
            newPosition.x = maxX;
        } else if (newPosition.x < minX) {
            newPosition.x = minX;
        }

        transform.position = newPosition;
    }
}
