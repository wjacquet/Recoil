using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    private Transform blades;
    public GameObject push;
    // Start is called before the first frame update
    void Start()
    {
        blades = gameObject.transform.GetChild(0);

        Vector3 pushPosition = new Vector3(transform.position.x, transform.position.y - 9, transform.position.z);
        Instantiate(push, pushPosition, transform.rotation)
            .GetComponent<PushController>()
            .Init(Vector2.down, pushPosition);
    }

    // Update is called once per frame
    void Update()
    {
        blades.Rotate(0.0f, 0.0f, -5.0f);
    }
}
