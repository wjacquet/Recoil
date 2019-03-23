using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulip : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject player; 

    public int FirstDegreeOffset = 20;
    public int SecondDegreeOffset = 40; 
    public float timeBetweenShoots = 1.0f;
    public float floatTime = 0.08f;

    private static GameObject bullet1 = null;
    private static GameObject bullet2 = null;
    private static GameObject bullet3 = null;
    private static GameObject bullet4 = null;
    private static GameObject bullet5 = null;
    private GameObject[] bulletsArray = new GameObject[5] {bullet1, bullet2, bullet3, bullet4, bullet5};

    void Start() {
        StartCoroutine(TulipPattern());
    }

    IEnumerator TulipPattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
            yield return StopFire();
            yield return new WaitForSeconds(floatTime);
            yield return Drop();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }
    
    IEnumerator Shoot() {
        for (int i = 0; i < bulletsArray.Length; i++) {
            bulletsArray[i] = Instantiate(bullet, transform.position, transform.rotation);
        }

        StandardFireFunctions.FireVetically(bulletsArray[0]);
        StandardFireFunctions.FireVeticallyDegreeOffset( bulletsArray[1], FirstDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset( bulletsArray[2], -FirstDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset( bulletsArray[3], SecondDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset( bulletsArray[4], -SecondDegreeOffset);

        yield return null;
    }

    IEnumerator StopFire() {

        for (int i = 0; i < bulletsArray.Length; i++) {
            if (bulletsArray[i] != null)
                StandardFireFunctions.StopFire(bulletsArray[i]);
        }

        yield return null;
    }

    IEnumerator Drop() {
        for (int i = 0; i < bulletsArray.Length; i++) {
            if (bulletsArray[i] != null)
                StandardFireFunctions.FireDown(bulletsArray[i]);
        }

        yield return null;
    }

}
