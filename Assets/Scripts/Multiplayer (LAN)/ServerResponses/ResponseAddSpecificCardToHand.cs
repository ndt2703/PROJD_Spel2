using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseAddSpecificCardToHand : ServerResponse
{

    public string cardToAdd = "";

    public ResponseAddSpecificCardToHand()
    {
        Type = 11; 
    }
    public ResponseAddSpecificCardToHand(string cardToAdd)
    {
        this.cardToAdd = cardToAdd;
    }
}
