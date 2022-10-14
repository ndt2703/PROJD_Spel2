using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDrawCard : ServerResponse
{
    public int amountToDraw = 0; 

    public ResponseDrawCard() 
    {
        Type = 2;
    }
    
    public ResponseDrawCard(int amountToDraw)
    {
        Type = 2;
        this.amountToDraw = amountToDraw; 
    }
}
