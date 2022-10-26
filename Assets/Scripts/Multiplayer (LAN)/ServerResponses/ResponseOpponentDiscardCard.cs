using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseOpponentDiscardCard : ServerResponse
{
    int amountOfCardsToDiscard = 0; 

    public ResponseOpponentDiscardCard()
    {
        Type = 12;
    }
    public ResponseOpponentDiscardCard(int amountOfCardsToDiscard)
    {
        Type = 12;
        this.amountOfCardsToDiscard = amountOfCardsToDiscard; 
    }


}
