using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBlock : MonoBehaviour
{
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerAbilities.flower && Input.GetMouseButtonDown(1)) {
            // Get location of cursor
            GameObject cursor = GameObject.Find("obj_cursor");
            Instantiate(block, cursor.transform.position, cursor.transform.rotation);
        }
    }
}
