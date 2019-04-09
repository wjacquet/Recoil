using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public Text coinText;
    public static int wealth = 0;

    void Start() 
    {
        coinText.text = "" + wealth;
    }

    public void AddCurrency(int pickUp = 0) 
    {
        wealth += pickUp;
        coinText.text = "" + wealth;
    }

    public void setCoinText() {coinText.text = "" + wealth;}
}
