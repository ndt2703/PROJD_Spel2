using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestRemoveCardsGraveyard : ClientRequest
{
    public List<TargetInfo> cardsToRemoveGraveyard = new List<TargetInfo>();

    public RequestRemoveCardsGraveyard()
    {
        Type = 10;
    }

    public RequestRemoveCardsGraveyard(List<TargetInfo> cardsToRemoveGraveyard)
    {
        this.cardsToRemoveGraveyard = cardsToRemoveGraveyard; 
    }


}
