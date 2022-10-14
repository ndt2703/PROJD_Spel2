using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDiscardCard : ClientRequest
{
    public List<int> listOfCardsDiscarded = new List<int>();

    public RequestDiscardCard() 
    {
        Type = 5; 
    }
    public RequestDiscardCard(List<int> listOfCardsDiscarded)
    {
        Type = 5;

        this.listOfCardsDiscarded = new List<int>(listOfCardsDiscarded); 
    }
}
