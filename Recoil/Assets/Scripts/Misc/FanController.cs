using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    private Vector2[] directions = { Vector2.down, Vector2.left, Vector2.up, Vector2.right };
    private Vector3[] pushPositions = new Vector3[4];
    private Transform blades;
    public GameObject push;
    // Start is called before the first frame update
    void Start()
    {
        blades = gameObject.transform.GetChild(0);

        // get the positions for the air currents
        pushPositions[0] = new Vector3(transform.position.x, transform.position.y - 9, transform.position.z);
        pushPositions[1] = new Vector3(transform.position.x - 9, transform.position.y, transform.position.z);
        pushPositions[2] = new Vector3(transform.position.x, transform.position.y + 9, transform.position.z);
        pushPositions[3] = new Vector3(transform.position.x + 9, transform.position.y, transform.position.z);

        // create air currents in all directions
        for (int i = 0; i < pushPositions.Length; i++) {
            Instantiate(push, pushPositions[i], transform.rotation)
                .GetComponent<PushController>()
                .Init(directions[i], pushPositions[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        blades.Rotate(0.0f, 0.0f, -5.0f);
    }
}
