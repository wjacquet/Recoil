using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTurret : MonoBehaviour
{
    public GameObject bullet;
    private bool firing = false;

    // Update is called once per frame
    void Update()
    {
        if (!firing && GetVectorToPlayer().y <= 20) {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        firing = true;
        GameObject proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(proj);
        yield return new WaitForSeconds(0.8f);
        proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(proj, 8);
        yield return new WaitForSeconds(0.8f);
        proj = Instantiate(bullet, transform.position, transform.rotation);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(proj, -8);
        yield return new WaitForSeconds(2.5f);
        firing = false;
    }

    Vector2 GetVectorToPlayer() 
    {
        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        return player.transform.position - transform.position;
    }
}
