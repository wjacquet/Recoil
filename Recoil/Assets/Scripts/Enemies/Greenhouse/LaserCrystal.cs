using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrystal : MonoBehaviour {

    public GameObject crystal;
    public GameObject laser; 

    void Start() {
        GameObject laser1 = Instantiate(laser, transform.position, transform.rotation);
        GameObject laser2 = Instantiate(laser, transform.position, transform.rotation);
        GameObject laser3 = Instantiate(laser, transform.position, transform.rotation);
        GameObject laser4 = Instantiate(laser, transform.position, transform.rotation);

        laser1.GetComponent<Laser>().SetAngle(45);
        laser2.GetComponent<Laser>().SetAngle(135);
        laser3.GetComponent<Laser>().SetAngle(225);
        laser4.GetComponent<Laser>().SetAngle(315);
    }

    void Update() {
        crystal.transform.Rotate(0, 0, 1f);
    }

}
