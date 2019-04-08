using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBlock : MonoBehaviour {

    // To use the magnet, right click and the object will fly towards you with gravity

    public float magnetStrength = 900f;
    public GameObject block;

    private bool magnet = false;
    private bool touching;

    void OnMouseOver(){
        // If Right clicked, flip bool
        if(Input.GetMouseButtonDown(1) && AbilitySelection.currentAbility == "magnet") {
            magnet = !magnet;
        }
    }

    void Update() {
        if (magnet && touching && PlayerAbilities.magnet) {
            StandardFireFunctions.MagnetTowardsPlayer(block, magnetStrength);
        }  
    } 

    void OnCollisionEnter2D(Collision2D collision) {
        touching = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        touching = false;
    }
}
