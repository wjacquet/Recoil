using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    Transform blades;
    // Start is called before the first frame update
    void Start()
    {
        blades = gameObject.transform.GetChild(0);
        print("BLADES");
        print(blades);
    }

    // Update is called once per frame
    void Update()
    {
        blades.Rotate(0.0f, 0.0f, -5.0f);
    }
}
