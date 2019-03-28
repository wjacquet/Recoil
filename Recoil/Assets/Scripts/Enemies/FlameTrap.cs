using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    public GameObject flame;


    void Start()
    {
        StartCoroutine(FireFlame());
    }

    IEnumerator FireFlame() {
        while (true) {
            flame.SetActive(true);
            yield return new WaitForSeconds(3f);
            flame.SetActive(false);
            yield return new WaitForSeconds(2f);

        }
    }
}
