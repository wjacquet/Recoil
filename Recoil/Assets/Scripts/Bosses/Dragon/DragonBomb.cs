using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBomb : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("obj_player");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 45 * Time.deltaTime);
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(4.0f);
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        boom.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        Destroy(gameObject);
    }
}
