using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    public static bool magnet = false;
    public static bool flower = false;
   
    public void SetMagnet(bool value) {
        magnet = value;
    }

    public void SetFlower(bool value) {
        flower = value;
    }

}
