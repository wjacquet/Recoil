using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    public GameObject flame;
    public bool isFlaming = true;


    void Start()
    {
        StartCoroutine(FireFlame());
    }

    IEnumerator FireFlame() {
        while (true) {
            flame.SetActive(isFlaming);
            yield return new WaitForSeconds(3f);
            flame.SetActive(!isFlaming);
            yield return new WaitForSeconds(2f);

        }
    }
}
