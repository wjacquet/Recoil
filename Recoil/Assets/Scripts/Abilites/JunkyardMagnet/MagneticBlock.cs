using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBlock : MonoBehaviour {

    public GameObject block;
    private bool magnet = false;
    
    
    void Update() {
        // If Right clicked, flip bool
        if(Input.GetMouseButtonDown(1)) {
            magnet = !magnet;
        }

        if (magnet) {
            StandardFireFunctions.MagnetTowardsPlayer(block, 20);
        } else {
            StandardFireFunctions.StopFire(block);
        }
    }

}
