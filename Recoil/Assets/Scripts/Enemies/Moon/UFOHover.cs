using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOHover : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public float hoverDistance = 20;
    public float distanceFromCenter = 30;

    private Vector2 center;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        StartCoroutine(HoverPattern());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Hover() {
        // Debug.Log(Vector2.Distance(transform.position, center));
        Vector2 movement = new Vector2(Random.Range(-hoverDistance, hoverDistance),Random.Range(-hoverDistance, hoverDistance));
        rigidBody.velocity = movement * 1/5;
        // Reset Back to center if he flaots too far (public distanceFromCenter)
        if (Vector2.Distance(transform.position, center) > distanceFromCenter) {
            transform.position = center;
        }
        yield return null;
        
    }

    IEnumerator HoverPattern() {
        while (true) {
            yield return Hover();
            yield return new WaitForSeconds(0.4f);
        }
    }
}
