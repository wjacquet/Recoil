using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MontyMovement : MonoBehaviour
{

    //positions
    private Vector3 topLeftLoc = new Vector3(1768, 1968, 0);
    private Vector3 botLeftLoc = new Vector3(1768, 1800, 0);
    private Vector3 topRightLoc = new Vector3(1960, 1976, 0);
    private Vector3 botRightLoc = new Vector3(1960, 1800, 0);
    private Vector3 startingPos = new Vector3(1864, 1880, 0);
    private Vector3 offScreen = new Vector3(1872, 2432, 0);

    private bool bossStarted = false;

    //shots
    public GameObject montyShot;
    public Tilemap bossWalls;
    
    void OnDestroy()
    {
        bossWalls.transform.position = new Vector3(1584, 2424, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Boss enters the arena
        if (transform.position.x != startingPos.x && !bossStarted)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPos, 360 * Time.deltaTime);
            //Debug.Log("if");
            return;
        }
        else if (!bossStarted && transform.position.x == startingPos.x)
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
            //yield return new WaitForSeconds(2.0f);
        }
    }

    void Overload()
    {
        Instantiate(montyShot, transform.position, transform.rotation);
    }

    IEnumerator Act()
    {
        // choose a different position randomly
        Vector3 newPosition = startingPos;
        Vector3 nextPosition = startingPos;
        switch (Random.Range(0, 6))
        {
            case 0:
                newPosition = topLeftLoc;
                nextPosition = botLeftLoc;
                break;
            case 1:
                newPosition = topRightLoc;
                nextPosition = botRightLoc;
                break;
            case 2:
                newPosition = botLeftLoc;
                nextPosition = topRightLoc;
                break;
            case 3:
                newPosition = botRightLoc;
                nextPosition = topLeftLoc;
                break;
            case 4:
                newPosition = topLeftLoc;
                nextPosition = botLeftLoc;
                break;
            case 5:
                newPosition = topRightLoc;
                nextPosition = botRightLoc;
                break;
        }

        Overload();

        // Move to top or bottom
        while (transform.position != newPosition)
        {
           //Debug.Log("First Loop");

            transform.position = Vector2.MoveTowards(transform.position, newPosition, 80 * Time.deltaTime);
            yield return null;
        }
        Overload();
        // Move up/down
        while (transform.position != nextPosition)
        {
            //Debug.Log("2n Loop");
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, 80 * Time.deltaTime);
            yield return null;
        }
        Overload();
    }
}
