using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBlock : MonoBehaviour
{
    public GameObject block;
    public bool flowerReady = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && PlayerAbilities.flower && flowerReady && AbilitySelection.currentAbility == "flower") {
            // Get location of cursor
            GameObject cursor = GameObject.Find("obj_cursor");
            Instantiate(block, cursor.transform.position, cursor.transform.rotation);

            // start cooldown for flower block
            flowerReady = false;
            StartCoroutine(FlowerTimer());
        }
    }

    IEnumerator FlowerTimer() {
        yield return new WaitForSeconds(8.0f);
        flowerReady = true;
    }
}
