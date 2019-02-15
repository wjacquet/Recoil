using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    private int wealth = 0;
    // Start is called before the first frame update

    public void AddCurrency(int pickUp = 0) 
    {
        wealth += pickUp;
    }
}
