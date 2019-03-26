using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popPillar : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation).SendMessage("PopPillar"); ;
    }
}
