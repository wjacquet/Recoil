using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    public static bool magnet = false;
    public static bool flower = false;
    public static bool speed = false;
    public static bool bubble = false;
   
    public void SetMagnet(bool value) {
        magnet = value;
    }

    public void SetFlower(bool value) {
        flower = value;
    }

    public void SetSpeed(bool value) {
        speed = value;
    }

    public void SetBubble(bool value) {
        bubble = value; 
    }

}
