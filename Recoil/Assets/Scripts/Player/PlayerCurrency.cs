using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public Text coinText;
    public static int wealth = 25000;

    void Start() 
    {
        coinText.text = "" + wealth;
    }

    public void AddCurrency(int pickUp = 0) 
    {
        wealth += pickUp;
        coinText.text = "" + wealth;
    }

    public void UpdateCurrency(int coins) {
        wealth = coins;
        coinText.text = "" + wealth;
    }

    void setCoinText() {coinText.text = "" + wealth;}
}
