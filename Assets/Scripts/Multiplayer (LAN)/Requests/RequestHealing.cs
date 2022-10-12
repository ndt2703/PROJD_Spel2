using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestHealing : ClientRequest
{
    int amountToHeal = 0;
    
    // Start is called before the first frame update
    public RequestHealing() { }// ta ej bortr
    public RequestHealing(int amountToHeal)
    {
        this.amountToHeal = amountToHeal;
        Type = 4; 
    }
}
