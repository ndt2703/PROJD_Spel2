using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDiscardCard : ServerResponse
{
    public List<string> listOfCardsDiscarded = new List<string>(); 
    
    public ResponseDiscardCard()
    {
        Type = 3; 
    }
    public ResponseDiscardCard(List<string> listOfCardsDiscarded)
    {
        Type = 3;

        this.listOfCardsDiscarded = new List<string>(listOfCardsDiscarded); 
    }
}
