using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    public bool activated = true;
    public GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Toggle());
        if (!activated) {
            beam.SetActive(false);
        }
    }

    IEnumerator Toggle() {
        while (true) {
            yield return new WaitForSeconds(2.0f);
            activated = !activated;
            beam.SetActive(activated);
        }
    }
}
