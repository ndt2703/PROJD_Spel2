using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseHeal : ServerResponse
{
    public int amountToHeal = 0; 
    public ResponseHeal()
    {
        Type = 4; 
    }

    public ResponseHeal(int amountToHeal)
    {
        Type = 4;
        this.amountToHeal = amountToHeal;
    }
}
