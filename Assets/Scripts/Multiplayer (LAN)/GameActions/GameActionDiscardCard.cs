using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionDiscardCard : GameAction
{
    public List<int> listOfCardsDiscarded = new List<int>();
    public GameActionDiscardCard()
    {
        Type = 4; 
    }
    public GameActionDiscardCard(List<int> listOfCardsDiscarded)
    {
        Type = 4;

        this.listOfCardsDiscarded = new List<int>(listOfCardsDiscarded); 
    }
}
