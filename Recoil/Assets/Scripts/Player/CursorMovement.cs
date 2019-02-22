using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    // Set the cursor to not be visible
    void Start()
    {
        Cursor.visible = false;
    }

    // Get the position of the mouse
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Get the mouse position relative to the camera
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // set the cursor to the mouse position
        transform.position = new Vector3(mousePosition.x, mousePosition.y, -15);
    }
}
