using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDiscardCard : ServerResponse
{
    public List<int> listOfCardsDiscarded = new List<int>(); 
    
    public ResponseDiscardCard()
    {
        Type = 3; 
    }
    public ResponseDiscardCard(List<int> listOfCardsDiscarded)
    {
        Type = 3;

        this.listOfCardsDiscarded = new List<int>(listOfCardsDiscarded); 
    }
}
