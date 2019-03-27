using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMag : MonoBehaviour
{

    GameObject player;
    public float angle;
    public float spread;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("obj_player");
    }

    // Update is called once per frame
    void Update() 
    {
        
        player = GameObject.Find("obj_player");
        Vector2 magPos = new Vector2(transform.position.x, transform.position.y);
        float currAngle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * 180 / Mathf.PI;
        if (Vector2.Distance(magPos, player.transform.position) < (range*16)) {
            if ( currAngle < angle+ spread && currAngle > angle - spread) {
                player.transform.position = Vector2.MoveTowards(player.transform.position, magPos, 50 * Time.deltaTime);
            }
        }
    }
}
