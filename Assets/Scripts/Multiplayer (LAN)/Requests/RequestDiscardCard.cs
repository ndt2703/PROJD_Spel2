using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDiscardCard : ClientRequest
{
    public List<string> listOfCardsDiscarded = new List<string>();

    public RequestDiscardCard() 
    {
        Type = 5; 
    }
    public RequestDiscardCard(List<string> listOfCardsDiscarded)
    {
        Type = 5;

        this.listOfCardsDiscarded = new List<string>(listOfCardsDiscarded); 
    }
}
