using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkScorchers : MonoBehaviour
{
    public GameObject flame;
    public static bool shouldFlame = false;

    // Update is called once per frame
    void Update()
    {
        flame.SetActive(shouldFlame);
    }
}
