using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontyShot : MonoBehaviour
{
    PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("obj_player");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 45 * Time.deltaTime);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHP.TakeDamage();
            Destroy(gameObject);
        }

    }
}
