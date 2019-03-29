using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBlockTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
