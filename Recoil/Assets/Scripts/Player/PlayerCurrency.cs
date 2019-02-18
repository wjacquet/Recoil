using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public Text coinText;
    private int wealth = 0;
    // Start is called before the first frame update

    void Start() 
    {
        coinText.text = "" + wealth;
    }

    public void AddCurrency(int pickUp = 0) 
    {
        wealth += pickUp;
        coinText.text = "" + wealth;
    }

    void setCoinText() {coinText.text = "" + wealth;}
}
