using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugGunner : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    public SpriteRenderer mySpriteRenderer;
 
    public int firstSpreadDegree = 25;
    public int secondSpreadDegree = 15;

    void Start() {
        StartCoroutine(BugGunnerPattern());
    }

    void Update() {
        player = GameObject.Find("obj_player");
        if (player.transform.position.x <= 0) 
            mySpriteRenderer.flipX = true;
        else
            mySpriteRenderer.flipX = false;
    }

    IEnumerator BugGunnerPattern() {
        while (true) {
            yield return FirstSpread();
            yield return new WaitForSeconds(1.0f);
            yield return SecondSpread();
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator FirstSpread() {
        StandardFireFunctions.FireAtPlayer(Instantiate(bullet, transform.position, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), firstSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), -firstSpreadDegree);
        yield return null;
    }

    IEnumerator SecondSpread() {
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), secondSpreadDegree);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(bullet, transform.position, transform.rotation), -secondSpreadDegree);
        yield return null;   
        }
    
}
