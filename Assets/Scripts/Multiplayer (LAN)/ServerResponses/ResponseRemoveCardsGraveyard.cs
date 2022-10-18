using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseRemoveCardsGraveyard : ServerResponse
{
    public List<TargetInfo> cardsToRemoveGraveyard = new List<TargetInfo>();

    public ResponseRemoveCardsGraveyard()
    {
        Type = 9;
    }

    public ResponseRemoveCardsGraveyard(List<TargetInfo> cardsToRemoveGraveyard)
    {
        this.cardsToRemoveGraveyard = cardsToRemoveGraveyard;
        Type = 9; 
    }

}
