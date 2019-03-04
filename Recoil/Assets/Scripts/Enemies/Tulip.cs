using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulip : MonoBehaviour {
    
    public GameObject bullet;
    public GameObject player; 

    public int FirstDegreeOffset = 20;
    public int SecondDegreeOffset = 40; 
    public float timeBetweenShoots = 1.0f;

    private GameObject bullet1;
    private GameObject bullet2;
    private GameObject bullet3;
    private GameObject bullet4;
    private GameObject bullet5;

    void Start() {
        StartCoroutine(TulipPattern());
    }

    IEnumerator TulipPattern() {
        while (true) {
            yield return Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
            yield return Drop();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }
    
    IEnumerator Shoot() {
        bullet1 = Instantiate(bullet, transform.position, transform.rotation);
        bullet2 = Instantiate(bullet, transform.position, transform.rotation);
        bullet3 = Instantiate(bullet, transform.position, transform.rotation);
        bullet4 = Instantiate(bullet, transform.position, transform.rotation);
        bullet5 = Instantiate(bullet, transform.position, transform.rotation);

        StandardFireFunctions.FireVetically(bullet1);
        StandardFireFunctions.FireVeticallyDegreeOffset(bullet2, FirstDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset(bullet3, -FirstDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset(bullet4, SecondDegreeOffset);
        StandardFireFunctions.FireVeticallyDegreeOffset(bullet5, -SecondDegreeOffset);

        yield return null;
    }

    IEnumerator Drop() {
        StandardFireFunctions.FireDown(bullet1);
        StandardFireFunctions.FireDown(bullet2);
        StandardFireFunctions.FireDown(bullet3);
        StandardFireFunctions.FireDown(bullet4);
        StandardFireFunctions.FireDown(bullet5);

        yield return null;
    }

}
