using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public bool lockX;
    public bool lockY;
    

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        // transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
    }
}
