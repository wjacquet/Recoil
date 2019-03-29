using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GuardianMovement : MonoBehaviour
{
    //positions
    private Vector3 startLocation = new Vector3(-1700, 512, 0);
    private Vector3 leftLocation = new Vector3(-1850, 512, 0);
    private Vector3 rightLocation = new Vector3(-1550, 512, 0);

    private bool bossStarted = false;

    //shots
    public GameObject eyeshot;
    public GameObject homingBall;
    public Tilemap bossWalls;

    void OnDestroy()
    {
        bossWalls.transform.position = new Vector3(-440, -400, 0);
    }

    void Update()
    {
        // Boss enters the arena
        if (transform.position.x != startLocation.x && !bossStarted)
        {
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 360 * Time.deltaTime);
            //Debug.Log("if");
            return;
        }
        else if (!bossStarted && transform.position.x == startLocation.x)
        {
            //Debug.Log("else");
            bossStarted = true;
            StartCoroutine(BossPatterns());
        }
    }

    IEnumerator BossPatterns()
    {
        while (true)
        {
            yield return Act();
            yield return new WaitForSeconds(2.0f);
        }
    }

    void Overload()
    {
        Instantiate(homingBall, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(Instantiate(eyeshot, transform.position, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(eyeshot, transform.position, transform.rotation), 20);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(eyeshot, transform.position, transform.rotation), -20);
    }

    IEnumerator Act()
    {
        // choose a different position randomly
        Vector3 newPosition = startLocation;
        Vector3 nextPosition = startLocation;
        switch (Random.Range(0, 2))
        {
            case 0:
                newPosition = rightLocation;
                nextPosition = leftLocation;
                break;
            case 1:
                newPosition = leftLocation;
                nextPosition = rightLocation;
                break;
        }

        Overload();

        // Move to top or bottom
        while (transform.position != newPosition)
        {
            //Debug.Log("currPos: " + transform.position + "newPos: " + newPosition);

            transform.position = Vector2.MoveTowards(transform.position, newPosition, 40 * Time.deltaTime);
            yield return null;
        }
        Overload();
        // Move up/down
        while (transform.position != nextPosition)
        {
            Debug.Log("2");
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, 40 * Time.deltaTime);
            yield return null;
        }
        Overload();
        // Return to middle
        while (transform.position != startLocation)
        {
            Debug.Log("3");
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 30 * Time.deltaTime);
            yield return null;
        }
        Overload();
    }
}
