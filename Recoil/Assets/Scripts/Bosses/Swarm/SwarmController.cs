using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    public GameObject verticalPiranha;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwarmAttacks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwarmAttacks() {
        while (true) {
            yield return SpawnVerticalPiranhas();
            yield return new WaitForSeconds(2.0f);
        }
    }

    // Randomly spawn vertically jumping fish
    IEnumerator SpawnVerticalPiranhas() {
        // randomly choose x position
        int xPosition = (Random.Range(0, 17) * 16) - 128;
        Vector3 newPosition = new Vector3(xPosition, -144, transform.position.z);
        
        Instantiate(verticalPiranha, newPosition, Quaternion.Euler(0, 0, 270));
        return null;
    }
}
