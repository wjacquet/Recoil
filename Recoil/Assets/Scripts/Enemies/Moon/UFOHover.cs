using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOHover : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public float hoverDistance = 20;
    private Vector3 center;
    private bool shouldHover = false;
    private Vector3 hoverPos;


    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        StartCoroutine(HoverPattern());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldHover)
            transform.position = Vector2.MoveTowards(transform.position, hoverPos, 40 * Time.deltaTime);

    }

    public void NewHoverPos() {
        hoverPos = new Vector3(
            center.x + Random.Range(-hoverDistance, hoverDistance),
            center.y + Random.Range(-hoverDistance, hoverDistance),
            center.z
        );        
    }

    IEnumerator HoverPattern() {
        while (true) {
            NewHoverPos();
            shouldHover = true;
            yield return new WaitForSeconds(1.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == 10) // Hits the wall 
        {
            NewHoverPos();
        }
    }
}
