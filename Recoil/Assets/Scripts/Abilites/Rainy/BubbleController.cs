using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject bubble;

    public void EnableBubble(bool enable) {
        bubble.SetActive(enable);
    }
}
