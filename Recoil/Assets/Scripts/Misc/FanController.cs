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
        Instantiate(push, transform.position, transform.rotation)
            .GetComponent<PushController>()
            .SetSpeed(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        blades.Rotate(0.0f, 0.0f, -5.0f);
    }
}
