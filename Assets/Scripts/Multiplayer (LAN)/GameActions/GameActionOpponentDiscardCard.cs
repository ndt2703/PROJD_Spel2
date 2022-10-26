using System.Collections;
using System.Collections.Generic;


public class GameActionOpponentDiscardCard : GameAction
{
    public int amountOfCardsToDiscard = 0;

    public GameActionOpponentDiscardCard()
    {
        Type = 12;
    }
    
    public GameActionOpponentDiscardCard(int amountOfCardsToDiscard)
    {
        Type = 12;
        this.amountOfCardsToDiscard = amountOfCardsToDiscard;
    }

}
